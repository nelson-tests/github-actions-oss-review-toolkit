using Api;

var builder = WebApplication.CreateSlimBuilder(args);

var app = builder.Build();

app.MapProductsEndpoints();

app.Run();
