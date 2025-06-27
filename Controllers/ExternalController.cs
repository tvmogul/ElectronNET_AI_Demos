using Microsoft.AspNetCore.Mvc;
using AiNetProfit.Helpers;
using System.Diagnostics;

namespace ElectronNET_AI_Demos.Controllers
{
    [Route("External")]
    public class ExternalController : Controller
    {
        [HttpPost("Open")]
        public IActionResult Open([FromBody] UrlRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request?.Url))
            {
                Debug.WriteLine("🌍 Launching external browser for URL: " + request.Url);
                BrowserHelper.OpenUrlInChromeOrDefault(request.Url);
            }

            return Ok();
        }

        public class UrlRequest
        {
            public string Url { get; set; } = string.Empty;
        }
    }
}
