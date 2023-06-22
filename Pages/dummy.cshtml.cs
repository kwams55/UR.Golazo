using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace UR.Golazo.Pages;
using System.Xml;
using unirest_net.http;

public class Player{
    public int Id {get; set;}
    public string name {get; set;}
    public string playStyle {get; set;}
    public string team {get; set;}
    public string aka {get; set;}
}
public class DummyModel : PageModel
{
    private string host = "http://localhost:5104/api/Player/";
    private readonly ILogger<DummyModel> _logger;

    public DummyModel(ILogger<DummyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        HttpResponse<string> response = Unirest.get(host).header("Accept", "application/json").asJson<string>();
        string response_body = response.Body.ToString();
        List<Player> players = JsonConvert.DeserializeObject<List<Player>>(response_body);
        ViewData["players"] = players;
    }

    public void OnPost(){

    }
}