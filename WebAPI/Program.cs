using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
var host = CreateHostBuilder(args).Build();

host.Run();



static IHostBuilder CreateHostBuilder(string[] args) => Host.CreateDefaultBuilder(args)
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        // Autofac ile baðýmlýlýk enjeksiyonunu yapýlandýr
        builder.RegisterModule(new AutofacBusinessModule());
    }).
    ConfigureWebHostDefaults(webBuilder =>
    {
        // ASP.NET Core web host konfigürasyonu
        webBuilder.Configure(app =>
        {

            //Bu kýsým, ASP.NET Core web host konfigürasyonunu içerir.
            //HTTPS yönlendirmesi, yetkilendirme, rota kullanýmý ve Swagger entegrasyonu gibi middleware'leri ekler.

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
        // ASP.NET Core servisleri konfigürasyonu: ASP.NET Core servis konfigürasyonunu içerir.
        // Kontrolleri ekler, endpoint API keþfi için gerekli olan servisleri ve Swagger belgelemesi için gerekli olan servisleri ekler.
        services.AddControllers();
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    });
