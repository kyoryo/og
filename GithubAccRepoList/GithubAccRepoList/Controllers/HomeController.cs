using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using GithubAccRepoList.Models;
using Microsoft.Extensions.Configuration;
using Octokit;
using Activity = System.Diagnostics.Activity;

namespace GithubAccRepoList.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public string Token { get; set; }
        public string Owner { get; set; }
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
            Token = _configuration.GetSection("Github")["Token"];
            Owner = _configuration.GetSection("Github")["Owner"];
        }
        public async Task<IActionResult> Index()
        {
            var client = new GitHubClient(new ProductHeaderValue("Test"));
            client.Credentials = new Credentials(Token);

            //var user = await client.User.Current();
            var owner = "octokit";
            var repo = await client.Repository.GetAllForUser(owner);
            var result = repo.Select(x => x.Name);
            ViewData["owner"] = owner;
            ViewData["repo"] = result;
            return View();
        }
        public async Task<IActionResult> Issues(string owner, string repoName)
        {
            var client = new GitHubClient(new ProductHeaderValue("Test"));
            client.Credentials = new Credentials(Token);
            var issues = await client.Issue.GetAllForRepository(owner, repoName);
            var result = issues.ToList();
            
            ViewData["issues"] = result;
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}
