global using ProductCatalog.Shared;
global using Microsoft.EntityFrameworkCore;
using ProductCatalog.Server.Data;
using ProductCatalog.Server.IRepository;
using ProductCatalog.Server.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Diagnostics;
using ProductCatalog.Server.Helpers;
using System.Net;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using AutoMapper;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//*************** Add services to the container******
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration
        .GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddCors();
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//***************End Services add*****************

//****************Register Repository**************
builder.Services.AddScoped<IProductRepository,ProductRepository>();
builder.Services.AddScoped<IAuthRepository,AuthRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<IPictureRepository,PictureRepository>();
builder.Services.AddScoped<IAttributeRepository,AttributeRepository>();
//****************End Repository Register***********

//****************Add Swagger To Project************
builder.Services.AddSwaggerGen(option=>{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement{
        {
            new OpenApiSecurityScheme{
                Reference=new OpenApiReference{
                    Type=ReferenceType.SecurityScheme,Id="Bearer"
                }
            },
            new string[]{}
        }
    });

    });
//**************End Swagger Add*********************


//**************Json Ignore For Cycle***************
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
//**************End json ignore*********************


//****************Register authentication middleware***********
var tokenKey = builder.Configuration.GetValue<string>("TokenKey");
var key = Encoding.ASCII.GetBytes(tokenKey);
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(x =>
{
    
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});
//*******************End authentication middleware register********************

var app = builder.Build();

// Configure the HTTP request pipeline.
    
        app.UseExceptionHandler(builder=>{
            builder.Run(async context=>
            {
                context.Response.StatusCode=(int) HttpStatusCode.InternalServerError;
                var error=context.Features.Get<IExceptionHandlerFeature>();
                if(error != null)
                {
                    context.Response.AddApplicationError(error.Error.Message);
                    await context.Response.WriteAsync(error.Error.Message);
                }
            });
        });
    


app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Blazor API V1");
});

app.UseRouting();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();
   app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });
app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");




app.Run();
