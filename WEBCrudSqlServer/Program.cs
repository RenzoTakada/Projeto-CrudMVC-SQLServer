using Microsoft.EntityFrameworkCore;
using WEBCrudSqlServer.Models;

const string connectionString = "Server=localhost,1433;Database=BancoCrudMVC;User ID=sa;Password=Renzo@2710;TrustServerCertificate=True";
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));



var app = builder.Build();

app.UseExceptionHandler("/Home/Error");
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(name: "default",  pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
