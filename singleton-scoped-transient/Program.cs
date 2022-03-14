using singleton_scoped_transient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<SingletonService>();
builder.Services.AddScoped<ScopedService>();
builder.Services.AddTransient<TransientService>();


var app = builder.Build();

app.Use(async (ctx, next) =>
{
    // Get all the services and increase their counters...
    var singleton = ctx.RequestServices.GetRequiredService<SingletonService>();
    var scoped = ctx.RequestServices.GetRequiredService<ScopedService>();
    var transient = ctx.RequestServices.GetRequiredService<TransientService>();

    singleton.Counter++;
    scoped.Counter++;
    transient.Counter++;

    next.Invoke();
});

app.Run(async ctx =>
{
    // ...then do it again...
    var singleton = ctx.RequestServices.GetRequiredService<SingletonService>();
    var scoped = ctx.RequestServices.GetRequiredService<ScopedService>();
    var transient = ctx.RequestServices.GetRequiredService<TransientService>();

    singleton.Counter++;
    scoped.Counter++;
    transient.Counter++;

    // ...and display the counter values.
    await ctx.Response.WriteAsync($"Singleton: {singleton.Counter}\n");
    await ctx.Response.WriteAsync($"Scoped: {scoped.Counter}\n");
    await ctx.Response.WriteAsync($"Transient: {transient.Counter}\n");
});

app.Run();
