
using Gimel.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();
builder.Services.AddControllers();



var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseDeveloperExceptionPage();
app.UseAuthorization();

app.UseCors(x => x.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed(origin => true));

app.MapRazorPages();

app.MapPost("/Test", async (HttpRequest request) =>
{

    try
    {
        using var bodyReader = new StreamReader(request.Body);
        string postData = await bodyReader.ReadToEndAsync();

        var submission = JsonSerializer.Deserialize<Data>(postData);

        if (submission == null)
        {
            return Results.BadRequest("Invalid data format.");
        }

        string powerName = PunchPower.UserName;
        string countName = PunchCountModel.UserName;
        string rtimeName = ReactionTimeModel.UserName;

        int ppower = submission.ppower;
        double speed = submission.speed;
        double punchtime = submission.punchtime;
        int rhand = submission.rhand;
        int lhand = submission.lhand;
        int both = submission.both;

        if(ppower != 0 && speed != 0)
        {
            double newSpeed = Math.Round(speed, 2);
            try
            {
                DAC.AddPower(powerName, ppower, newSpeed);
                TestStartModel.TestStart = "NotStarted";
                Gimel.Pages.PunchPower.TestDone = "Yes";
                Console.WriteLine("Data processed and query executed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DAC.NewQuery: {ex.Message}");
                return Results.Problem("An error occurred while processing the request in the database.");
            }
        }
        else if(punchtime != 0 && speed != 0)
        {
            double newSpeed = Math.Round(speed, 2);
            double newPunch = Math.Round(punchtime, 2);
            try
            {
                DAC.AddReactTime(rtimeName, newPunch, newSpeed);
                TestStartModel.TestStart = "NotStarted";
                ReactionTimeModel.TestDone = "Yes";
                Console.WriteLine("Data processed and query executed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DAC.NewQuery: {ex.Message}");
                return Results.Problem("An error occurred while processing the request in the database.");
            }
        }
        else if(rhand != 0 && lhand != 0 && both != 0)
        {
            try
            {
                DAC.AddCount(countName, rhand, lhand, both);
                TestStartModel.TestStart = "NotStarted";
                PunchCountModel.TestDone = "Yes";
                Console.WriteLine("Data processed and query executed.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in DAC.NewQuery: {ex.Message}");
                return Results.Problem("An error occurred while processing the request in the database.");
            }
        }

        return Results.Ok(new { message = "Data successfully processed" });
    }
    catch (Exception ex)
    {
        Console.WriteLine($"General error: {ex.Message}");
        return Results.Problem("An error occurred while processing the request.");
    }


});
app.Run();

record Data(int ppower, double speed, double punchtime, int rhand, int lhand, int both);

