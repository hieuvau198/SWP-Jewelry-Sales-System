using System.Security.Cryptography;
using System.Text;
using System.Web;

public class VNPayHelper
{
    private readonly SortedList<string, string> _requestData = new SortedList<string, string>();

    public void AddRequestData(string key, string value)
    {
        if (!_requestData.ContainsKey(key))
        {
            _requestData.Add(key, value);
        }
    }

    public string CreateRequestUrl(string baseUrl, string secretKey)
    {
        var data = new StringBuilder();
        foreach (var kvp in _requestData)
        {
            data.Append($"{kvp.Key}={HttpUtility.UrlEncode(kvp.Value)}&");
        }

        var queryString = data.ToString().TrimEnd('&');
        var hash = ComputeHash(secretKey, queryString);
        var paymentUrl = $"{baseUrl}?{queryString}&vnp_SecureHash={hash}";

        return paymentUrl;
    }

    private static string ComputeHash(string secretKey, string data)
    {
        var hashBytes = Encoding.UTF8.GetBytes(secretKey);
        using (var hmac = new HMACSHA512(hashBytes))
        {
            var dataBytes = Encoding.UTF8.GetBytes(data);
            var computedHash = hmac.ComputeHash(dataBytes);
            return BitConverter.ToString(computedHash).Replace("-", "").ToLower();
        }
    }

    public static bool VerifySignature(SortedList<string, string> responseParams, string receivedSignature, string secretKey)
    {
        var data = new StringBuilder();

        foreach (var kvp in responseParams)
        {
            if (!string.IsNullOrEmpty(kvp.Value) && !kvp.Key.Equals("vnp_SecureHash", StringComparison.OrdinalIgnoreCase))
            {
                data.Append($"{kvp.Key}={HttpUtility.UrlEncode(kvp.Value)}&");
            }
        }

        var queryString = data.ToString().TrimEnd('&');
        var computedHash = ComputeHash(secretKey, queryString);

        return computedHash.Equals(receivedSignature, StringComparison.OrdinalIgnoreCase);
    }
}
