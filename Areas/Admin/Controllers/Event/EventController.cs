using Microsoft.AspNetCore.Mvc;

namespace RunForLive.Areas.Admin.Controllers.EventNamespace;

[Area("Admin")]
public class EventController :Controller
{
    public IActionResult Index(){
        return View();
    }
    [HttpGet]
    public IActionResult CreateEvent(){
        return View();
    }   
    [HttpPost]
    public IActionResult CreateEvent(string Name ){
        // L?y file t? Request.Form.Files
        IFormFile imageFile = Request.Form.Files["ImageFile"];

        System.Console.WriteLine("data {0} - data2: {1}", Name, imageFile);
        return Ok(new {name=Name, img =imageFile });
    } 
}
