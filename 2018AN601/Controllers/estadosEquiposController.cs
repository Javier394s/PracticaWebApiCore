using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using _2018AN601.Models;

namespace _2018AN601
{
    [ApiController] 
    public class equiposController : ControllerBase
    {
        private readonly prestamosContext _contexto;

        public equiposController(prestamosContext miContexto) {
            this._contexto = miContexto;
        }

        [HttpGet]
        [Route("api/estados_equipo")]
        public IActionResult Get(){
            var estado_equipoList = _contexto.estados_equipo;
                return Ok(estado_equipoList);          
        } 
    }
}