using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Cors;
using EnableCorsAttribute = System.Web.Http.Cors.EnableCorsAttribute;

namespace APIReact.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    public class space
    {
        public string id { get; set; }
        public string state { get; set; }
        public string placa { get; set; }

    }
    [Route("api/[controller]")]
    [ApiController]
    public class SpacesController : Controller
    {
        public List<space> spaces = new List<space>()
        {
            new space(){id="rfgyh67g",state = "in use",placa = "AGR-845"},
            new space(){id="rf65h67g",state = "free",placa = null},
            new space(){id="cvgyh67g",state = "in use",placa = "AYU-450"}


        };


        // GET: SpacesController
        [HttpGet]
        public ActionResult Get()
        {

            try
            {
                return Ok(spaces); 
            }
            catch { return BadRequest("No se pudo recuperar la informacion"); }
        }


        [HttpGet("{id}")]
        // GET: SpacesController/Create
        public ActionResult Get(string id)
        {
            space s1 = new space();
            for (int i = 0; i < spaces.Count; i++)
            {
                if (spaces[i].id == id) {
                    s1 = spaces[i];
                } 
            }

            if (s1.id == null)
            {
                return BadRequest("No se encontro el espacio");
            }
            else
            {
                return Ok(s1);
            }
           
            
        }

        // POST: SpacesController/Create
        [HttpPost]
        public ActionResult Post([FromBody] space user)
        {
            try
            {   
                spaces.Add(user);
                return Ok(spaces);
            }
            catch
            {
                return BadRequest("No se pudo agregar el espacio");
            }
        }

        // PUT api/spaces
        [HttpPut]
        public ActionResult Put([FromBody] space value)
        {
            space s1 = new space();
            for (int i = 0; i < spaces.Count; i++)
            {
                if (spaces[i].id == value.id)
                {
                    s1 = spaces[i];
                    spaces[i] = value;
                }
            }

            if (s1.id == null)
            {
                return BadRequest("No se encontro el espacio");
            }
            else
            {
                return Ok(spaces);
            }
        }



        // GET: SpacesController/Delete/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            space s1 = new space();
            for (int i = 0; i < spaces.Count; i++)
            {
                if (spaces[i].id == id)
                {
                    s1 = spaces[i];
                    spaces.RemoveAt(i);

                }
            }

            if (s1.id == null)
            {
                return BadRequest("No se encontro el espacio");
            }
            else
            {
                return Ok(spaces);
            }
        }

       
    }
}
