using AutoMapper;
using FlorAmor.Application.DTO;
using FlorAmor.Application.Data;
using FlorAmor.Application.Model;
using FlorAmor.Application.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Hinzufügen der AutoMapper-Profile
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Session und HTTP Context hinzufügen
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddRazorPages();

// MongoDB-Kontext und Repositories hinzufügen
builder.Services.AddSingleton<MongoDBContext>(sp => new MongoDBContext("mongodb://localhost:27017", "FlorAmorDB"));
builder.Services.AddScoped<LadenRepository>();
builder.Services.AddScoped<BlumenRepository>();
builder.Services.AddScoped<UserRepository>();

var app = builder.Build();

// Hinzufügen von Testdaten nach dem Erstellen der App
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<MongoDBContext>();

    context._database.DropCollection("Geschäft");
    context._database.DropCollection("Blumen");

    var ladenRepository = new LadenRepository(context);
    var blumenRepository = new BlumenRepository(context);

    ladenRepository.Add(new Laden("FlorAmor", "Österreich", "Wien", 1160));
    ladenRepository.Add(new Laden("Rizzi", "Österreich", "Wien", 1110));
    ladenRepository.Add(new Laden("Marawan", "Österreich", "Linz", 4020));

    blumenRepository.Add(new Blume { Art = "Rose", Preis = 2.5m, Stückzahl = 100, Farbe = "Rot" });
    blumenRepository.Add(new Blume { Art = "Tulpe", Preis = 1.5m, Stückzahl = 150, Farbe = "Gelb" });
    blumenRepository.Add(new Blume { Art = "Narzisse", Preis = 1.0m, Stückzahl = 200, Farbe = "Weiß" });
    blumenRepository.Add(new Blume { Art = "Sonnenblume", Preis = 3.0m, Stückzahl = 75, Farbe = "Gelb" });
    blumenRepository.Add(new Blume { Art = "Chrysantheme", Preis = 2.0m, Stückzahl = 120, Farbe = "Pink" });
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
