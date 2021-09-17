using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using _2018AN601.Models;


namespace _2018AN601.Controllers
{
    [ApiController] 
    public class equiposController : ControllerBase
    {
        private readonly prestamosContext _contexto;

        public equiposController(prestamosContext miContexto) {
            this._contexto = miContexto;
        }

        [HttpGet]
        [Route("api/equipos")]
        public IActionResult Get(){
            var equiposList = _contexto.equipos;
                return Ok(equiposList);          
        } 
    }
}