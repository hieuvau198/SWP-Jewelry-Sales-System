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
using JewelSystemBE;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddHttpClient<GoldPriceService>();//new

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<JewelDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("JewelDBW2"));
});

// transient: create a new object every request
// scope: create or use the existed object in scope
// singleton: only one object

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
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };
});
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
    options.AddPolicy("ManagerPolicy", policy => policy.RequireRole("Manager"));
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseDeveloperExceptionPage();//new of image
}

var imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "Images");//new of image
if (!Directory.Exists(imagesPath))
{
    Directory.CreateDirectory(imagesPath);
}//new of image

// Shows UseCors with CorsPolicyBuilder
app.UseCors(builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
});

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(imagesPath),
    RequestPath = "/images"
});//new of image


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
