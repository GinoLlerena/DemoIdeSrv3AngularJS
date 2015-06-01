using Sistemas.WebResources.Models;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Web.Http;
using System.Web.Http.Description;
using Thinktecture.IdentityModel.WebApi;

namespace Sistemas.WebResources.Controllers
{
    [RoutePrefix("api/unidad")]
    public class UnidadController : ApiController
    {
        
        [HttpGet]
        [Route("")]
        [ResourceAuthorize("Read", "Unidades")]
        public IEnumerable<Unidad> Get()
        {
            return Unidades.Instance.Lista.ToList();
        }

        [HttpGet]
        [Route("{id}")]
        [ResponseType(typeof(Unidad))]
        [ResourceAuthorize("Read", "Unidades")]
        public IHttpActionResult Get(int id)
        {
            Unidad  unidad = Unidades.Instance.Lista.FirstOrDefault(x => x.Id == id);
            if (unidad == null)
            {
                return NotFound();
            }

            return Ok(unidad);
        }

        [HttpPut]
        [Route("{id}")]
        [ResponseType(typeof(void))]
        [ResourceAuthorize("Write", "Unidades")]
        public IHttpActionResult Put(int id, Unidad unidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (id != unidad.Id)
            {
                return BadRequest();
            }

            Unidad u = Unidades.Instance.Lista.Where(x => x.Id == id).FirstOrDefault();
            if (u != null) {
                u.Nemonico = unidad.Nemonico;
                u.Descripcion = unidad.Descripcion;
            } 


            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpPost]
        [Route("")]
        [ResponseType(typeof(Unidad))]
        [ResourceAuthorize("Write", "Unidades")]
        public IHttpActionResult Post(Unidad unidad)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Unidades.Instance.Lista.AddItem(unidad);

            return Ok(unidad);
        }

        [HttpDelete]
        [Route("{id}")]
        [ResponseType(typeof(Unidad))]
        [ResourceAuthorize("Write", "Unidades")]
        public IHttpActionResult Delete(int id)
        {

            var unidad = Unidades.Instance.Lista.Single(r => r.Id == id);
            
            if (unidad == null)
            {
                return NotFound();
            }

            Unidades.Instance.Lista.Remove(unidad); 
            
            return Ok(unidad);
        }

    }
}
