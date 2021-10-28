using System.Net;

var client = new HttpClient();
client.DefaultRequestVersion = HttpVersion.Version30;
client.DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact;

var resp = await client.GetAsync("https://localhost:7192/");
var body = await resp.Content.ReadAsStringAsync();

Console.WriteLine($"status: {resp.StatusCode}, version: {resp.Version}, body: {body.Substring(0, Math.Min(100, body.Length))}");