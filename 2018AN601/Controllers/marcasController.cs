using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using _2018AN601.Models;

namespace _2018AN601
{
    [ApiController] 
    public class marcasController : ControllerBase
    {
        private readonly prestamosContext _contexto;

        public marcasController(prestamosContext miContexto) {
            this._contexto = miContexto;
        }

        [HttpGet]
        [Route("api/marcas")]
        public IActionResult Get(){
            var marcasList = _contexto.marcas;
                return Ok(marcasList);          
        } 
    }
}