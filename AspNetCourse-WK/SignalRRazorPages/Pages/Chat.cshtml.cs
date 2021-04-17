using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRRazorPages.Pages
{
    public class ChatModel : PageModel
    {
        private readonly IConfiguration configuration;
        public string stringApiBaseUrl {get; set;}

        public ChatModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void OnGet()
        {
            stringApiBaseUrl = configuration[nameof(stringApiBaseUrl)];
        }
    }
}
