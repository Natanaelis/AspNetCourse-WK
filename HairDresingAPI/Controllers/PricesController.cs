﻿using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HairDresingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly IPricesRepository repository;

        public PricesController(IPricesRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Ok(await repository.GetListAsync());

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await repository.GetAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(id);
        }

        //[HttpGet("{ok}")]
        //[Route("get")]
        //public async Task<IActionResult> Get(string ok)
        //{
        //    return Ok(true);
        //}

        [HttpPost]
        public async Task<ActionResult<Price>> Post(Price item)
        {
            await repository.AddAsync(item);
            await repository.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Price item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }
            await repository.UpdateAsync(item);
            try
            {
                await repository.SaveChangesAsync();
                return NoContent();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!repository.FindBy(a => a.Id == id).Any())
                {
                    return NotFound();
                }
                throw;
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Price>> Delete(int id)
        {
            var item = await repository.GetAsync(id);
            if(item == null)
            {
                return NotFound();
            }
            await repository.DeleteAsync(id);
            await repository.SaveChangesAsync();
            return Ok(item);
        }
    }
}
