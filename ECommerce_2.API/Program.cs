using ECommerce_2.DAL.Context;
using ECommerce_2.DAL.Repos;
using ECommerce_2.DAL.Repos.OrdersRepo;
using ECommerce_2.DAL.Repos.ProducrsRepo;
using ECommerce_2.DAL;
using Microsoft.EntityFrameworkCore;
using ECommerce_2.BL;
using ECommerce_2.DAL.Models;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata;
using System.Text;
using ECommerce_2.API;
using static ECommerce_2.API.Constant;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

///DAL////////////
builder.Services.AddDALServices(builder.Configuration);
////BL///////////////
builder.Services.AddBLServices();


#region cors
/*const string AllowAllCorsPolicy = "AllowAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowAllCorsPolicy, b =>
    {
        b.AllowAnyOrigin()
         .AllowAnyMethod()
         .AllowAnyHeader();
    });
});*/
#endregion

#region Identity

builder.Services.AddIdentityCore<User2>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireUppercase = false;
    options.Password.RequiredLength = 3;

    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<AbilityContext>();

#endregion

#region Authentication

builder.Services.AddAuthentication(options =>
{
    // Configure used authentication 
    options.DefaultAuthenticateScheme = "MyDefault";
    options.DefaultChallengeScheme = "MyDefault"; // return 401 if not authenticated, 403 if authenticated but not authorized
})
    // Define the authentication scheme
    .AddJwtBearer("MyDefault", options =>
    {
        var keyFromConfig = builder.Configuration.GetValue<string>(ECommerce_2.API.Constant.AppSettings.SecretKey);
        var keyInBytes = Encoding.ASCII.GetBytes(keyFromConfig);
        var key = new SymmetricSecurityKey(keyInBytes);

        

        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateAudience = false,
            IssuerSigningKey = key
        };
    });

#endregion


var connectionString = builder.Configuration.GetConnectionString("AbilityDB4") ?? throw new InvalidOperationException("Connection string 'AbilityDB4' not found.");
builder.Services.AddDbContext<AbilityContext>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
