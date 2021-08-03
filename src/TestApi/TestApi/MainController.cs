using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// A few words:
// ASP.NET Core is a rather strong opinionated framework. In contrast to Node or Deno.
// Also C# is not JS or TS. We wanna keep things simple, direct and flexible here.
// So we don't use ModelBinding and auto-created ProblemDetails responses here.
// Also we don't wanna handle with a jungle of strongly typed DTO models.
// Therefore we do these things not the typical MS ASP.NET Core way.

// Testing with cURL:
// For testing you can use the following cURL call:
// curl.exe -i -H "Content-Type: application/json" -d @json.txt http://localhost:5000
// For that cURL call, you need a file named "json.txt" containing the following content:
// {"firstName":"Steve","lastName":"Jobs","age":-1,"male":true,"workDays":["Monday","Wednesday","Friday"],"welcomeMessage":"Hello from client"}
// To make that cURL call work, you have to put this file into the same folder as the cURL binary (curl.exe).

namespace TestApi.Controllers
{
    [ApiController]
    [Route("/")]
    public class MainController : ControllerBase
    {
        [HttpGet]
        [Produces("application/json")]
        public IActionResult GetPerson()
        {
            var someList = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

            // We use IActionResult and Anonymous Types, instead of strongly typed DTO models.

            return Ok(new
            {
                FirstName = "Bill",
                LastName = "Gates",
                Age = 66,
                Male = true,
                WorkDays = someList,
                WelcomeMessage = "Hello World from Web API"
            });
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> PostPersonAsync()
        {
            // We don't use ModelBinding, cause ModelBinder automatically answers with ProblemDetails messages on invalid JSON.
            // ASP.NET Core offers a lot of ready-to-use stuff, but also soaks us deeper into the framework and its complexity.

            try
            {
                // Instead we gonna read the JSON by our own (using System.Text.Json), convert it and
                // validate it, to keep control over the complete behaviour and to keep things simple.

                var jsonElement = await Request.ReadFromJsonAsync<JsonElement>();

                var firstName = jsonElement.GetProperty("firstName").GetString();
                var lastName = jsonElement.GetProperty("lastName").GetString();
                var age = jsonElement.GetProperty("age").GetInt32();
                var male = jsonElement.GetProperty("male").GetBoolean();
                var workDays = jsonElement.GetProperty("workDays").EnumerateArray().Select(x => x.GetString());
                var welcomeMessage = jsonElement.GetProperty("welcomeMessage").GetString();

                return Ok(new
                {
                    message = $"successfully received personal data of {firstName} {lastName}",
                    firstName,
                    lastName,
                    age,
                    male,
                    workDays,
                    welcomeMessage
                });
            }
            catch
            {
                return BadRequest(new
                {
                    message = "invalid json"
                });
            }
        }
    }
}
