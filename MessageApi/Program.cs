
using MessageAPI.Config;
using MessageAPI.Interfaces;
using MessageAPI.Persistence;
using MessageAPI.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MessageApiContext>
(options => options.UseSqlServer(
    "Data Source=DESKTOP-T6KTKSE\\HANSPETER;Initial Catalog=Message_APiRest;Persist Security Info=True;User ID=Hanspeter;Password=123456"));


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMessageService, MessageService>();

var twilioConfigString = File.ReadAllText("TwilioConfig.json");
var twilioConfig = JsonSerializer.Deserialize<TwilioConfig>(twilioConfigString);

TwilioClient.Init(username: "xxxxxxxxxxxxxxxxxxxxx", password: "xxxxxxxxxxxxxxxxxxxxxxxx");

/*
 * To use put your username and password, AccountSID and AuthToken.
 * I can't put my username and password about security :(
 */

var message = MessageResource.Create(
    body: "You have been verified.",
    from: new Twilio.Types.PhoneNumber("+16122356801"),
    to: new Twilio.Types.PhoneNumber("+XXXXXXXXXXXXXXXX"));

/*
 * in "from:" put your Twilio number.
 * in "to:" put your REAL number above (+XXXXXXX...)
 */

Console.WriteLine(message.Status);

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
