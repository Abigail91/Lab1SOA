using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static APIReact.Controllers.SpacesController;


namespace APIReact.Controllers
{
    public class reservation
    {
        public string id { get; set; }
        public string hora { get; set; }
        public string placa { get; set; }

    }
    [Route("api/reservations")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        readonly List<space> spaces;
        public ValuesController()
        {
            SpacesController mc2 = new SpacesController();
            spaces = mc2.spaces;
        }
        
        List<reservation> reservations = new List<reservation>()
        {
            new reservation(){id="rfgyh67g",hora = "11:00am",placa = "AGR-845"},
            new reservation(){id="cvgyh67g",hora = "1:00pm",placa = "AYU-450"}


        };

        // GET api/reservations
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(reservations);
            }
            catch { return BadRequest("No se pudo recuperar la informacion"); }
        }

        // GET api/values/5
        [HttpPost]
        public ActionResult Post([FromBody] reservation res)
        {
            reservation s1 = new reservation();
            for (int i = 0; i < spaces.Count; i++)
            {
                if (spaces[i].state == "free")
                {
                    s1.placa = res.placa;
                    s1.hora = DateTime.Now.ToString("hh:mm:ss tt");
                    s1.id = spaces[i].id;
                    reservations.Add(s1);
                }
            }

            if (s1.id == null)
            {
                return BadRequest("No se encontro espacio libre");
            }
            else
            {
                
                return Ok(s1);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            reservation s1 = new reservation();
            for (int i = 0; i < reservations.Count; i++)
            {
                if (reservations[i].id == id)
                {
                    s1 = reservations[i];
                    reservations.RemoveAt(i);

                }
            }

            if (s1.id == null)
            {
                return BadRequest("No se encontro el espacio");
            }
            else
            {
                return Ok(reservations);
            }
        }
    }
}
