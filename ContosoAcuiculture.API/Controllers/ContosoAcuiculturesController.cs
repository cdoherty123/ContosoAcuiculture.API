using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using ContosoAcuiculture.API.Models;
using ContosoAcuiculture.API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContosoAcuiculture.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContosoAcuiculturesController : ControllerBase
    {
        private readonly ICosmosDBService _cosmoService;

        public ContosoAcuiculturesController(ICosmosDBService cosmoService)
        {
            _cosmoService = cosmoService;
        }

        // GET: api/<ContosoAcuicultures>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var shrimps = await _cosmoService.GetAllAsync("SELECT * FROM c");

            if (!shrimps.Any())
            {
                return await Task.FromResult(StatusCode((int)HttpStatusCode.OK, "Empty"));
            }

            return await Task.FromResult(StatusCode((int)HttpStatusCode.OK, shrimps.ToList()));
        }

        // GET api/<ContosoAcuicultures>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] string id)
        {
            return await Task.FromResult(StatusCode((int)HttpStatusCode.OK, _cosmoService.GetAsync(id)));
        }

        // POST api/<ContosoAcuicultures>
        [Route("insert")]
        [HttpPost]
        public async Task<IActionResult> InsertShrimp([FromBody] ContosoAcuicultureModel shrimp)
        {
            if (ModelState.IsValid)
            {
                await _cosmoService.AddAsync(shrimp);
                return RedirectToAction("GetAll");
            }

            return await Task.FromResult(StatusCode((int)HttpStatusCode.BadRequest, shrimp));
        }

        // POST api/<ContosoAcuicultures>
        [Route("edit")]
        [HttpPost]
        public async Task<IActionResult> EditShrimp([FromBody] ContosoAcuicultureModel shrimp)
        {
            Console.WriteLine("hello");
            Console.WriteLine(shrimp);
            if (ModelState.IsValid)
            {
                Console.WriteLine(ModelState);
                var req = await _cosmoService.UpdateAsync(shrimp);

                if (req == null)
                {
                    return await Task.FromResult(StatusCode((int)HttpStatusCode.OK, "Book not found"));
                }

                return RedirectToAction("GetAll");
            }

            return await Task.FromResult(StatusCode((int)HttpStatusCode.BadRequest, shrimp));
        }
    }
}