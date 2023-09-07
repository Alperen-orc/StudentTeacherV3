using Hangfire;
using Hangfire.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StackExchange.Profiling.Storage;
using StudentTeacher.Controllers;
using StudentTeacher.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Blazor Web Api",
        Description = "Blazor Web Api",
        Contact = new OpenApiContact
        {
            Name = "Mini Profiler",
            Url = new Uri($"{Environment.GetEnvironmentVariable("ASPNETCORE_URLS").Split(";").First()}/mini-profiler/results-index")
        }
    });
});
builder.Services.AddDbContext<Context>();
builder.Services.AddMemoryCache();
builder.Services.AddHangfire(configuration => configuration
        .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage("server=213.238.168.103;Database=StjDB; User Id=stj;Password=3bOBS12Uk4g5JGs;", new SqlServerStorageOptions
        {
            CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
            SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
            QueuePollInterval = TimeSpan.Zero,
            UseRecommendedIsolationLevel = true,
            DisableGlobalLocks = true
        }));

builder.Services.AddHangfireServer();

builder.Services.AddMiniProfiler(options =>
{
    options.RouteBasePath = "/mini-profiler";//uygulamanın arayüz adresini belirler
    options.IgnoredPaths.Add("/swagger");//swagger ile başlayan istekleri göstermez ve loglamaz
    options.Storage = new StackExchange.Profiling.Storage.SqlServerStorage("Server=213.238.168.103;Database=StjDB;User Id=stj;Password=3bOBS12Uk4g5JGs;MultipleActiveResultSets=true", "MiniProfilers", "MiniProfilerTimings", "MiniProfilerClientTimings");
    options.ColorScheme = StackExchange.Profiling.ColorScheme.Dark;//Tema rengini belirler. Tabiki koyu :)
    options.TrackConnectionOpenClose = true;//Bağlantı açma ve kapatmayı izlemeyi devre dışı bırakabilirsiniz.//Varsayılan olarak izlenmektedir.(true)
    options.SqlFormatter = new StackExchange.Profiling.SqlFormatters.InlineFormatter();//SQL formatlayıcısı kontrol edilmektedir.//Varsayılan olarak InlineFormatter'dir.
    options.UserIdProvider = (request) => request.HttpContext.User.Identity.Name;//Varsa istekdeki kullanıcı bilgilerini gösterir ve loglar
}).AddEntityFramework();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiniProfiler();

app.UseHangfireDashboard();

BackgroundJob.Enqueue<MyJobs>(x => x.SendEmail("ornek@email.com"));

app.UseAuthorization();

app.MapControllers();

app.Run();
