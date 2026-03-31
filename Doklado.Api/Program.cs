using Doklado.Integration.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient<DokladoHttpService>(client =>
{
    client.BaseAddress = new Uri("https://api-gateway-prod-europe-west-1-7epuecvu.ew.gateway.dev");
    client.DefaultRequestHeaders.Add("api_key", "ebt5bhbh98c-2a4ta3-4ucq83-9ovrb4-fb99l4aqbr-6bbqbdb");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();