using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Postdb.data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<Validator>(builder.Configuration.GetSection("Validator"));
builder.Services.Configure<ConnectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<Itoken,Tokenaccess>();
builder.Services.AddScoped<Ipost,Mongodata>();
builder.Services.AddScoped<Ilike,Mongodata>();
builder.Services.AddSingleton<Iauth,Authuser>();
builder.Services.AddScoped<Ifollow,Authuser>();
builder.Services.AddTransient<Exceptionhandler>();



builder.Services.AddAuthentication(defaultScheme:JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options => {

                    var jwtoptions = builder.Configuration.GetSection("Validator").Get<Validator>();

                    options.TokenValidationParameters = new TokenValidationParameters(){

                    ValidIssuer=jwtoptions?.Issuer,
                    ValidAudience=jwtoptions?.Audience,
                    IssuerSigningKey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtoptions.secret)),
                    ValidateIssuer=true,
                    ValidateLifetime=true,
                    ValidateIssuerSigningKey=true,
                    ValidateAudience=true,

                    };

                });
builder.Services.AddAuthorization();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

if(builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        
        options.AddDefaultPolicy(
            policy =>
            {
                policy.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}


app.UseCors();
app.UseMiddleware<Exceptionhandler>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllers();

app.Run();
