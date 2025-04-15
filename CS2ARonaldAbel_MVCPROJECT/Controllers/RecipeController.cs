using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using CS2ARonaldAbel_MVCPROJECT.BusLogic.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class RecipeController : Controller
{
    private static readonly HttpClient client = new HttpClient();

    [HttpGet]
    public ActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Index(RecipeRequest model)
    {
        // Build the prompt with additional dish type and meal time information.
        string prompt = $"You are a recipe assistant. The user has a budget of {model.Budget}, available ingredients: {model.Ingredients}, and preferences: {model.Preferences}. " +
                        $"The recipe should be for a {model.DishType} dish intended for {model.MealTime}. " +
                        $"Recommend 1–2 simple recipes with estimated cost and easy-to-follow instructions.";

        var response = await CallGroqLLM(prompt);
        var recipe = new RecipeResponse { Reply = response };

        return View("Result", recipe);
    }
    
    private async Task<string> CallGroqLLM(string prompt)
    {
        var apiKey = "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";

        var requestBody = new
        {
            model = "llama-3.3-70b-versatile",
            messages = new[]
            {
            new { role = "system", content = "You are a helpful recipe assistant." },
            new { role = "user", content = prompt }
        }
        };

        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");

        var httpResponse = await client.PostAsync("https://api.groq.com/openai/v1/chat/completions", content);

        if (!httpResponse.IsSuccessStatusCode)
        {
            // If something went wrong, handle it.
            var errorContent = await httpResponse.Content.ReadAsStringAsync();
            return $"Error: {httpResponse.StatusCode} - {errorContent}";
        }

        var jsonString = await httpResponse.Content.ReadAsStringAsync();

        dynamic json = JsonConvert.DeserializeObject(jsonString);

        // Check if the parts we need are there
        if (json == null || json.choices == null || json.choices.Count == 0)
        {
            return "The response did not contain the expected data.";
        }

        // Now we safely access the data.
        return json.choices[0].message.content;
    }

}
