using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
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

            app.UseHttpsRedirection();
            app.UseRouting();

            // UseAuthorization should come after UseRouting
            app.UseAuthorization();

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
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    });
