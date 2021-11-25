﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi_Net60.Models;
using WebApi_Net60.Services;

namespace WebApi_Net60.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        public PizzaController()
        {

        }

        // Get all Actions
        [HttpGet]
        public ActionResult<List<Pizza>> GetAll() => PizzaService.GetAll();

        // Get by id
        [HttpGet("{id}")]
        public ActionResult<Pizza> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza is null)
                return NotFound();

            return pizza;
        }

        // Post
        [HttpPost]
        public IActionResult Create(Pizza pizza)
        {
            PizzaService.Add(pizza);

            return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
        }

        //[HttpPost("x")]
        //public IActionResult Create(string name, bool isGlutenFree)
        //{
        //    var pizza = new Pizza(0, name, isGlutenFree);
            
        //    PizzaService.Add(pizza);

        //    return CreatedAtAction(nameof(Create), new { id = pizza.Id }, pizza);
        //}

        // Put
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza pizza)
        {
            if (id != pizza.Id)
                return BadRequest();

            var existingPizza = PizzaService.Get(id);
            if (existingPizza is null)
                return NotFound();

            PizzaService.Update(pizza);

            return NoContent();
        }

        // Delete
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var pizza = PizzaService.Get(id);

            if (pizza is null)
                return NotFound();

            PizzaService.Delete(id);
            
            return NoContent();
        }
    }
}
