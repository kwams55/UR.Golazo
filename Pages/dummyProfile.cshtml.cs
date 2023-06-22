using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace UR.Golazo.Pages;
using System.Xml;
using unirest_net.http;

public class DummyProfileModel : PageModel
{
    private string host = "http://localhost:5104/api/Player/";
    private readonly ILogger<DummyProfileModel> _logger;

    public DummyProfileModel(ILogger<DummyProfileModel> logger)
    {
        _logger = logger;
    }

    public void OnGet(int id){
        string endpoint = id.ToString();
        HttpResponse<string> response = Unirest.get(host + endpoint).header("Accept", "application/json").asJson<string>();
        string response_body = response.Body.ToString();
        List<Player> players = JsonConvert.DeserializeObject<List<Player>>(response_body);
        foreach (Player player in players){
            if (player.Id == id){
            Console.WriteLine(player);
            }
        }
    }

    public void OnPost(){

    }
}