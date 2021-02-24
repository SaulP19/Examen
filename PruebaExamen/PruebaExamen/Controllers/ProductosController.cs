using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PruebaExamen.Context;
using PruebaExamen.ENTITIES;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaExamen.Controllers
{
    [Route("api/[controller]")]
    public class ProductosController : Controller
    {
        private readonly AddDbContext context;


        public ProductosController(AddDbContext context)
        {
            this.context = context;
        }

   


        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<PRODUCTOS> Get()
        {
            return context.PRODUCTOS.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public PRODUCTOS Get(string id)
        {
            var PRODUCTO = context.PRODUCTOS.FirstOrDefault(p => p.SKU == id);
            return PRODUCTO;
        }

        // POST api/<controller>
        [HttpPost]
        public ActionResult Post([FromBody]PRODUCTOS producto)
        {
            try
            {
                context.PRODUCTOS.Add(producto);
                context.SaveChanges();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody]PRODUCTOS producto)
        {
            if (producto.SKU == id)
            {
                context.Entry(producto).State = EntityState.Modified;
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var producto = context.PRODUCTOS.FirstOrDefault(p => p.SKU == id);
            if (producto != null)
            {
                context.PRODUCTOS.Remove(producto);
                context.SaveChanges();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
