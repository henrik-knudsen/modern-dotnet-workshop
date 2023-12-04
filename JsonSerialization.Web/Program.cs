using JsonSerialization;
using JsonSerialization.Common;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureHttpJsonOptions(opt =>
{
    opt.SerializerOptions.TypeInfoResolverChain.Add(AppSerializerContext.Default);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


List<User> users =
[
    new User()
    {
        Name = "Bob",
        Age = 30,
    },

    new User()
    {
        Name = "Kari",
        Age = 30,
    }
];


app.MapGet("/users", () => users)
    .WithName("Users")
    .WithOpenApi();



app.Run();

