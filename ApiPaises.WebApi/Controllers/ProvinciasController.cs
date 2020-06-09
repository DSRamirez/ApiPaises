using ApiPaises.WebApi.Controllers.Data;
using ApiPaises.WebApi.Controllers.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPaises.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciasController : ControllerBase
    {
        private readonly ApiContext context;

        public ProvinciasController(ApiContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Provincia>> Get()
        {
            return context.Provincias.Include(p => p.Pais).ToList();
        }

        [HttpGet("{Id}", Name = "ProvById")]

        public ActionResult<Provincia> Get(int id)
        {
            var provincia = context.Provincias.FirstOrDefault(p => p.Id == id);
            if (provincia == null)
            {
                return NotFound();
            }
            return provincia;
        }

        [HttpPost]   
        public ActionResult<Provincia> Post([FromBody] Provincia provincia)
        {
            context.Provincias.Add(provincia);
            context.SaveChanges();

            return new CreatedAtRouteResult("ProvById", new { id = provincia.Id }, provincia);
        }

        [HttpGet("ProvByCod/{cod}")]
        public ActionResult<Provincia> GetProvByCod(string cod)
        {
            var provincia = context.Provincias.Include(p => p.Pais).FirstOrDefault(p => p.CodProv == cod);
            if (provincia == null)
            {
                return NotFound();
            }
            return provincia;
        }

        [HttpPut("{Id}")]

        public ActionResult<Provincia> Put(int id, [FromBody] Provincia provincia)
        {
            if (id != provincia.Id)
            {
                return BadRequest();
            }

            context.Entry(provincia).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{Id}")]

        public ActionResult<Provincia> Delete(int id)
        {
            var provincia = context.Provincias.FirstOrDefault(p => p.Id == id);
            if (provincia == null)
            {
                return NotFound();
            }
            context.Provincias.Remove(provincia);
            context.SaveChanges();
            return Ok();
        }
    }
}
