// NOTE: If you want to try building a similar project, you must add this NuGet package:
//    Microsoft.AspNet.WebApi.Client
//    (You might need to scroll up in the search results to see it?)

HttpClient web = new HttpClient();
web.BaseAddress = new Uri("https://xkcd.com/");
var connection = await web.GetAsync("info.0.json");
string result = await connection.Content.ReadAsStringAsync();
Console.WriteLine(result);

// Web requests come back as strings! So here we're just printing out the string.
// In the next example (XkcdConsoleVersion2) we'll look at "parsing" the string into C# objects.
