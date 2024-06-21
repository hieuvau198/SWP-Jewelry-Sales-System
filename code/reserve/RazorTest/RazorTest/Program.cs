using RazorTest.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorTest.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddDbContext<RazorTestContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorTestContext") ?? throw new InvalidOperationException("Connection string 'RazorTestContext' not found.")));
builder.Services.AddHttpClient();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(3000);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});



builder.Services.AddScoped<ApiService>();
builder.Services.AddHttpClient<ApiService>();
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient<DiscountService>();
builder.Services.AddScoped<DiscountService>();
builder.Services.AddHttpClient<GemService>();
builder.Services.AddScoped<GemService>();
builder.Services.AddHttpClient<GoldService>();
builder.Services.AddScoped<GoldService>();
builder.Services.AddHttpClient<ProductService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddHttpClient<CustomerService>();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddHttpClient<InvoiceService>();
builder.Services.AddScoped<InvoiceService>();
builder.Services.AddHttpClient<InvoiceItemService>();
builder.Services.AddScoped<InvoiceItemService>();
builder.Services.AddHttpClient<WarrantyService>();
builder.Services.AddScoped<WarrantyService>();
builder.Services.AddHttpClient<UserService>();
builder.Services.AddScoped<UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();



app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapRazorPages();

app.Run();
