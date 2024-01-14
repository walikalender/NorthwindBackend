using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;


var host = CreateHostBuilder(args).Build();

host.Run();




static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        // Autofac ile ba��ml�l�k enjeksiyonunu yap�land�r
        builder.RegisterModule(new AutofacBusinessModule());
    }).
    ConfigureWebHostDefaults(webBuilder =>
    {
        // ASP.NET Core web host konfig�rasyonu
        webBuilder.Configure(app =>
        {

            //Bu k�s�m, ASP.NET Core web host konfig�rasyonunu i�erir.
            //HTTPS y�nlendirmesi, yetkilendirme, rota kullan�m� ve Swagger entegrasyonu gibi middleware'leri ekler.
            app.UseCors(builder => builder.WithOrigins("http://localhost:3000").AllowAnyHeader());
            app.UseHttpsRedirection();
            app.UseRouting();

            // UseAuthorization should come after UseRouting
            app.UseAuthentication(); // bir yere girmek i�in anahtard�r. (ortama giri� anahtar�)
            app.UseAuthorization(); // anahtarla girdi�in yerde ne yap�labilir (yetki)
           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Your API V1");
            });


        });
    }).ConfigureServices(services =>
    {
        // ASP.NET Core servisleri konfig�rasyonu: ASP.NET Core servis konfig�rasyonunu i�erir.
        // Kontrolleri ekler, endpoint API ke�fi i�in gerekli olan servisleri ve Swagger belgelemesi i�in gerekli olan servisleri ekler.
        services.AddControllers();
        services.AddCors(options =>
        {
            options.AddPolicy("AllowOrigin", builder => builder.WithOrigins("https://localhost:3000"));

        });

        using var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
                };
            });
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    });
