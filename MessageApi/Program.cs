
using MessageAPI.Persistence;
using MessageAPI.Services.MessageService;
using MessageAPI.Services.UserService;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MessageApiContext>
(options => options.UseSqlServer(
    "Data Source=DESKTOP-T6KTKSE\\HANSPETER;Initial Catalog=Message_APiRest;Persist Security Info=True;User ID=Hanspeter;Password=123456"));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMessageService, MessageService>();

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
