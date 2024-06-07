using JewelBO;
using JewelDAL;
using JewelDAO.DAOAuth;
using JewelDAO.DAOCustomer;
using JewelDAO.DAODiscount;
using JewelDAO.DAOGem;
using JewelDAO.DAOGold;
using JewelDAO.DAOInvoice;
using JewelDAO.DAOInvoiceItem;
using JewelDAO.DAOJewel;
using JewelDAO.DAOProduct;
using JewelDAO.DAOUser;
using JewelDAO.DAOWarranty;
using JewelRepository.RepositoryAuth;
using JewelRepository.RepositoryCustomer;
using JewelRepository.RepositoryDiscount;
using JewelRepository.RepositoryGem;
using JewelRepository.RepositoryGold;
using JewelRepository.RepositoryInvoice;
using JewelRepository.RepositoryInvoiceItem;
using JewelRepository.RepositoryJewel;
using JewelRepository.RepositoryProduct;
using JewelRepository.RepositoryUser;
using JewelRepository.RepositoryWarranty;
using JewelService.ServiceAuth;
using JewelService.ServiceCustomer;
using JewelService.ServiceDiscount;
using JewelService.ServiceGem;
using JewelService.ServiceGold;
using JewelService.ServiceInvoice;
using JewelService.ServiceInvoiceItem;
using JewelService.ServiceJewel;
using JewelService.ServiceProduct;
using JewelService.ServiceUser;
using JewelService.ServiceWarranty;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<JewelDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("JewelDBW2"));
});

builder.Services.AddTransient<IAuthService, AuthService>();
builder.Services.AddTransient<IAuthRepository, AuthRepository>();
builder.Services.AddTransient<IAuthDao, AuthDao>();

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserDao, UserDao>();

builder.Services.AddTransient<IGoldService, GoldService>();
builder.Services.AddTransient<IGoldRepository, GoldRepository>();
builder.Services.AddTransient<IGoldDao, GoldDao>();

builder.Services.AddTransient<IGemService, GemService>();
builder.Services.AddTransient<IGemRepository, GemRepository>();
builder.Services.AddTransient<IGemDao, GemDao>();

builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
builder.Services.AddTransient<ICustomerDao, CustomerDao>();

builder.Services.AddTransient<IInvoiceService, InvoiceService>();
builder.Services.AddTransient<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddTransient<IInvoiceDao, InvoiceDao>();

builder.Services.AddTransient<IInvoiceItemService, InvoiceItemService>();
builder.Services.AddTransient<IInvoiceItemRepository, InvoiceItemRepository>();
builder.Services.AddTransient<IInvoiceItemDao, InvoiceItemDao>();

builder.Services.AddTransient<IJewelService, JewelService.ServiceJewel.JewelService>();
builder.Services.AddTransient<IJewelRepository, JewelRepository.RepositoryJewel.JewelRepository>();
builder.Services.AddTransient<IJewelDao, JewelDao>();

builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<IProductDao, ProductDao>();

builder.Services.AddTransient<IDiscountService, DiscountService>();
builder.Services.AddTransient<IDiscountRepository, DiscountRepository>();
builder.Services.AddTransient<IDiscountDao, DiscountDao>();

builder.Services.AddTransient<IWarrantyService, WarrantyService>();
builder.Services.AddTransient<IWarrantyRepository, WarrantyRepository>();
builder.Services.AddTransient<IWarrantyDao, WarrantyDao>();



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
