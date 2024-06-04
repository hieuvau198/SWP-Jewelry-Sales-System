using JewelSystemBE.Data;
using JewelSystemBE.Model;
using JewelSystemBE.Service.ServiceAuth;
using JewelSystemBE.Service.ServiceGold;
using JewelSystemBE.Service.ServiceGem;
using JewelSystemBE.Service.ServiceJewel;
using JewelSystemBE.Service.ServiceUser;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using JewelSystemBE.Service.ServiceProduct;
using JewelSystemBE.Service.ServiceDiscount;
using JewelSystemBE.Service.ServiceWarranty;
using JewelSystemBE.Service.ServiceCustomer;
using JewelSystemBE.Service.ServiceInvoice;
using JewelSystemBE.Service.ServiceInvoiceItem;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container .

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<JewelDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("JewelDBW2"));
});

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IJewelService, JewelService>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IGoldService, GoldService>();
builder.Services.AddTransient<IGemService, GemService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IDiscountService, DiscountService>();
builder.Services.AddTransient<IWarrantyService, WarrantyService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IInvoiceService, InvoiceService>();
builder.Services.AddTransient<IInvoiceItemService, InvoiceItemService>();


// Configure JWT authentication, it imports jwtbearer, token, text, model
var jwtSettings = builder.Configuration.GetSection("Jwt").Get<JwtSettings>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
        };
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Shows UseCors with CorsPolicyBuilder
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
