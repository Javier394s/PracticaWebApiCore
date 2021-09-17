using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using _2018AN601.Models;

namespace _2018AN601
{
    [ApiController] 
    public class tipo_equipoController : ControllerBase
    {
        private readonly prestamosContext _contexto;

        public tipo_equipoController(prestamosContext miContexto) {
            this._contexto = miContexto;
        }

        [HttpGet]
        [Route("api/tipo_equipo")]
        public IActionResult Get(){
            var tipo_equipoList = _contexto.tipo_equipo;
                return Ok(tipo_equipoList);          
        } 
    }
}