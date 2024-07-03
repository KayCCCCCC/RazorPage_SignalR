using Microsoft.EntityFrameworkCore;
using NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.Business;
using NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.Data.Models;
using NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.Data.Repository;
using NET1704_221_ASM3_SE172587_NguyenNgoThanhNha.RazorPage.Pages.Hubs;

var builder = WebApplication.CreateBuilder(args);

//SignalR configuration
builder.Services.AddSignalR()
    .AddJsonProtocol(options => {
        // Serialize not change the casing of property name, instead of (Camel Case)
        options.PayloadSerializerOptions.PropertyNamingPolicy = null;
    });
// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<AppDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(GenericRepository<>));
builder.Services.AddScoped<TutorRepository>();
builder.Services.AddScoped<TutorBusiness>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.MapHub<TutorHub>("/tutorHub");

app.UseAuthorization();

app.MapRazorPages();

app.Run();
