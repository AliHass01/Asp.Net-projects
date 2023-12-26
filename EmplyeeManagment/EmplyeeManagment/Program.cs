using EmplyeeManagment.Module;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("EmployeeConnection");
builder.Services.AddMySqlDataSource(builder.Configuration.GetConnectionString("EmployeeConnection")!);


builder.Services.AddDbContextPool<ApplicationDbContext>(options =>
options.UseMySql(
    connectionString, ServerVersion.AutoDetect(connectionString)
    )
);

// Add services to the container.
builder.Services.AddRazorPages();

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

app.UseAuthorization();

app.MapRazorPages();

app.Run();

