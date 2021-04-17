using Domain.Models;
using Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiClientHelpers;

namespace HairDressingMVC.Controllers
{
//    [Authorize(Roles = "Employee")] // Not OK - Strings in code
//    [Authorize(Roles = ConstValues.Employee)]
    [Authorize(Roles = nameof(RoleType.Employee))]    
    public class PricesController : Controller
    {
        private WebApiClient<Price> webApiClient;
        public PricesController(IConfiguration configuration)
        {
            var apiKey = configuration["ApiKey"];
            webApiClient = new WebApiClient<Price>(configuration.GetConnectionString("ApiBaseUrl"), "Prices",
                configuration["ApiKey"]);
        }
        public async Task<IActionResult> Index(string info = null, string error = null)
        {
            ViewBag.Info = info;
            ViewBag.Error = error;
            var model = await webApiClient.GetListAsync();
            return View(model);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Price item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item jest pusty");
            }
            if (ModelState.IsValid)
            {
                var result = await webApiClient.AddAsync(item);
                if (result != null)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(item);
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var result = await webApiClient.GetAsync((int)id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Price item)
        {
            if (id != item.Id)
            {
                    return NotFound();
            }
            if (ModelState.IsValid)
            {
                var updated = await webApiClient.UpdateAsync(item);
                if (updated)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(item);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var result = await webApiClient.GetAsync((int)id);
            if (id == null)
            {
                    return NotFound();
            }
            return View(result);
        }
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deleted = await webApiClient.DeleteAsync(id);
            if (deleted)
            {
                return RedirectToAction(nameof(Index), new { info = $"Usunieto element {id}" });
            }
            return RedirectToAction(nameof(Index), new { error = $"Nie mozna usunac {id}" });

        }
    }
}
