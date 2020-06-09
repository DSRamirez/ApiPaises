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
    public class PaisesController : ControllerBase
    {
        private readonly ApiContext context;

        public PaisesController(ApiContext context)
        {
            this.context = context;
        }

        #region Get

        [HttpGet]
        public ActionResult<IEnumerable<Pais>> Get()
        {
            return context.Paises.ToList();
        }

        [HttpGet("{Id}", Name = "ObtenerPaisPorId")]

        public ActionResult<Pais> Get(int id)
        {
            var pais = context.Paises.FirstOrDefault(p => p.Id == id);
            if (pais == null)
            {
                return NotFound();
            }
            return pais;
        }

        #endregion

        #region Post

        [HttpPost]
        //public ActionResult<Pais> Post([FromBody] Pais pais)
        public async Task<ActionResult<Pais>> Post([FromBody] Pais pais)
        {

            await context.Paises.AddAsync(pais);
            await context.SaveChangesAsync();

            //context.Paises.Add(pais);
            //context.SaveChanges();

            //return pais;
            return new CreatedAtRouteResult("ObtenerPaisPorId", new { id = pais.Id }, pais);
        }

        #endregion

        #region Put

        [HttpPut("{Id}")]

        public ActionResult<Pais> Put(int id, [FromBody] Pais pais)
        {
            if (id != pais.Id)
            {
                return BadRequest();
            }

            context.Entry(pais).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{Id}")]

        public ActionResult<Pais> Delete(int id)
        {
            var pais = context.Paises.FirstOrDefault(p => p.Id == id);
            if (pais == null)
            {
                return NotFound();
            }
            context.Paises.Remove(pais);
            context.SaveChanges();
            return Ok();
        }
        #endregion
    }
}
