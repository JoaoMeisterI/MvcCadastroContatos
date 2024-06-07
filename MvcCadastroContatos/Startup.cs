namespace MvcCadastroContatos;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MvcCadastroContatos.Data;
using MvcCadastroContatos.Repositorio;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // Métodos para injeção de dependência
    public void ConfigureServices(IServiceCollection services)
    {
        //Gerencia toda a parte do model,view e controller, sem ela o projeto nem roda
        services.AddControllersWithViews();
        //Essa primeira parte é relativa a injeção de dependencia do context a próxima é sobre a injeção da interface
        services.AddEntityFrameworkSqlServer()
            //Indica o uso do SQLSERVER E ADICIONA O CONTEXTO DO NOSSO DB JUNTO COM A CONNECT STRING DEFINIDA NA APPSETTINGS
        .AddDbContext<BancoContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DataBase")));
        services.AddScoped<IContatosRepositorio, ContatosRepositorio>();
        services.AddScoped<IUsuariosRepositiorio, UsuarioRepositorio>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            //Habilita as mensagens de erro , quando for produção tem que tirar
            app.UseDeveloperExceptionPage();
        }
        else
        {
            //Trata as excessões e redireciona para essa URL
            app.UseExceptionHandler("/Home/Error");
            //Força quem entra no site ao usar o protocolo https
            //app.UseHsts();
        }
        //Redireciona para o HTTP
        app.UseHttpsRedirection();
        //PERMITE UTILIZAÇÃO DE HTML,CSS E JS
        app.UseStaticFiles();
        //AJUDA NO MAPEAMENTO DAS URLS
        app.UseRouting();
        //Utilizado em aplicativos que tem regras de autorização 
        app.UseAuthorization();

        //DEFINE COMO AS REQUISIÇÕES DEVEM SER MAPEADAS PARA OS ENDPOITNS DAS CONTROLLERS
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Usuario}/{action=Login}/{id?}");
        });
    }
}
