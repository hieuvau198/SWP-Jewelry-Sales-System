using JewelSystemBE.Model;
using JewelSystemBE.Service.ServiceInvoice;
using JewelSystemBE.Service.ServiceUser;
using JewelSystemBE.VNPay;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VNPayController : ControllerBase
    {
        private readonly VNPaySetting _vnPaySettings;
        private readonly IInvoiceService _invoiceService;
        private readonly IUserService _userService;

        public VNPayController(IOptions<VNPaySetting> vnPaySettings, IInvoiceService invoiceService, IUserService userService)
        {
            _vnPaySettings = vnPaySettings.Value;
            _invoiceService = invoiceService;
            _userService = userService;
        }

        [HttpGet("payment/{userId}/{invoiceId}")]
        public ActionResult Payment(string userId, string invoiceId)
        {
            string orderInfo = $"{userId}{DateTime.Now:ddHHmmssyyyy}";

            var invoice = _invoiceService.GetInvoice(invoiceId);
            if (invoice == null || !_userService.ExistUser(userId))
            {
                return BadRequest("User or Invoice not found");
            }

            int amountInt = Convert.ToInt32(invoice.TotalPrice) * 100;
            string amount = amountInt.ToString();

            string clientIPAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            VNPayHelper pay = new VNPayHelper();
            pay.AddRequestData("vnp_Version", "2.1.0");
            pay.AddRequestData("vnp_Command", "pay");
            pay.AddRequestData("vnp_TmnCode", _vnPaySettings.TmnCode);
            pay.AddRequestData("vnp_Amount", amount);
            pay.AddRequestData("vnp_IpAddr", clientIPAddress);
            pay.AddRequestData("vnp_OrderInfo", $"{userId}/{invoiceId}");
            pay.AddRequestData("vnp_ReturnUrl", _vnPaySettings.ReturnUrl);
            pay.AddRequestData("vnp_TxnRef", orderInfo);
            pay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));

            string paymentUrl = pay.CreateRequestUrl(_vnPaySettings.Url, _vnPaySettings.HashSecret);

            return Redirect(paymentUrl);
        }
        // Endpoint xác nhận thanh toán từ VNPay
        [HttpGet("payment-confirm")]
        public ActionResult PaymentConfirm(
            [FromQuery] string vnp_TmnCode,
            [FromQuery] string vnp_Amount,
            [FromQuery] string vnp_BankCode,
            [FromQuery] string vnp_BankTranNo,
            [FromQuery] string vnp_CardType,
            [FromQuery] string vnp_PayDate,
            [FromQuery] string vnp_OrderInfo,
            [FromQuery] string vnp_TransactionNo,
            [FromQuery] string vnp_ResponseCode,
            [FromQuery] string vnp_TransactionStatus,
            [FromQuery] string vnp_TxnRef,
            [FromQuery] string vnp_SecureHash)
        {
            var responseParams = new SortedList<string, string>
            {
                { "vnp_TmnCode", vnp_TmnCode },
                { "vnp_Amount", vnp_Amount },
                { "vnp_BankCode", vnp_BankCode },
                { "vnp_BankTranNo", vnp_BankTranNo },
                { "vnp_CardType", vnp_CardType },
                { "vnp_PayDate", vnp_PayDate },
                { "vnp_OrderInfo", vnp_OrderInfo },
                { "vnp_TransactionNo", vnp_TransactionNo },
                { "vnp_ResponseCode", vnp_ResponseCode },
                { "vnp_TransactionStatus", vnp_TransactionStatus },
                { "vnp_TxnRef", vnp_TxnRef }
            };

            // Kiểm tra tính hợp lệ của mã băm
            string hashSecret = _vnPaySettings.HashSecret;
            bool isValidSignature = VNPayHelper.VerifySignature(responseParams, vnp_SecureHash, hashSecret);

            if (!isValidSignature)
            {
                return BadRequest("Invalid signature");
            }

            // Xử lý logic cập nhật trạng thái thanh toán cho hóa đơn
            if (vnp_ResponseCode == "00") // Thành công
            {
                Invoice? invoice = _invoiceService.GetInvoice(vnp_TxnRef);
                if (invoice != null)
                {
                    invoice.InvoiceStatus= "Paid";
                    _invoiceService.UpdateInvoice(invoice);
                }
            }

            return Ok("Payment confirmation received");
        }
    }
}
