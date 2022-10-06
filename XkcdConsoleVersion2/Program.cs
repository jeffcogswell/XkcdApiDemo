// NOTE: If you want to try building a similar project, you must add this NuGet package:
//    Microsoft.AspNet.WebApi.Client
//    (You might need to scroll up in the search results to see it?)

HttpClient web = new HttpClient();
web.BaseAddress = new Uri("https://xkcd.com/");
var connection = await web.GetAsync("info.0.json");
XkcdResult result = await connection.Content.ReadAsAsync<XkcdResult>();
Console.WriteLine(result.title);
Console.WriteLine($"Comic Number {result.num}");
Console.WriteLine($"Published {result.year}/{result.month}/{result.day}");
Console.WriteLine(result.img);

// To make this class, I had to look at the results from the API call in Postman or the browser.
class XkcdResult
{
	public string month { get; set; }
	public int num { get; set; }
	public string linke { get; set; }
	public string year { get; set; }
	public string news { get; set; }
	public string safe_title { get; set; }
	public string transcript { get; set; }
	public string alt { get; set; }
	public string img { get; set; }
	public string title { get; set; }
	public string day { get; set; }
}