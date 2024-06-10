using RazorTest.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorTest.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<RazorTestContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("RazorTestContext") ?? throw new InvalidOperationException("Connection string 'RazorTestContext' not found.")));
builder.Services.AddHttpClient();
builder.Services.AddScoped<ApiService>();
builder.Services.AddControllersWithViews();
//builder.Services.AddHttpClient<DiscountService>();

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

app.MapRazorPages();

app.Run();
