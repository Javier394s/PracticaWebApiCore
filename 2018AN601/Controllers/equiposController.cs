using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using _2018AN601.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

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
            IEnumerable<equipos> equiposList = from e in _contexto.equipos
                                                select e;
            if(equiposList.Count()>0){
                return Ok(equiposList);
            }                      
            return NotFound();        
        } 

        [HttpGet]
        [Route("api/equipos/{id}")]
        public IActionResult getbyid(int id)
        {
            equipos unEquipo = (from e in _contexto.equipos
                                where e.id_equipos == id  //filtro por id
                                select e).FirstOrDefault();
            if(unEquipo != null){
                return Ok(unEquipo);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("api/equipos/buscarnombre/{buscarNombre}")]
        public IActionResult getbyname(string buscarNombre)
        {
            IEnumerable<equipos> equipobyName = from e in _contexto.equipos
                                                where e.nombre.Contains(buscarNombre)
                                                select e;
            if( equipobyName.Count()>0){
                return Ok(equipobyName);
            }                           
            return NotFound();         
        }

        [HttpPost]
        [Route("api/equipos/insertar")]
        public IActionResult guardarEquipo([FromBody] equipos equipoNuevo, string usuario) 
        {
            try{
                IEnumerable<equipos> equipoExiste = from e in  _contexto.equipos
                                                    where e.nombre == equipoNuevo.nombre
                                                    select e;
                if(equipoExiste.Count()==0){
                    _contexto.equipos.Add(equipoNuevo);
                    _contexto.SaveChanges();
                    return Ok(equipoNuevo);
                }                                                    
                return Ok(equipoExiste);
            }catch(System.Exception){
                return BadRequest();
            }            
        }

        [HttpPut]
        [Route("api/equipos")]
        public IActionResult updateEquipo([FromBody] equipos equipoAModificar)
        {
            equipos equipoExiste = (from e in _contexto.equipos
                                    where  e.id_equipos  == equipoAModificar.id_equipos
                                    select e).FirstOrDefault();
            if(equipoExiste is null)
            {
                return NotFound();
            }

            equipoExiste.nombre = equipoAModificar.nombre;
            equipoExiste.descripcion = equipoAModificar.descripcion;
            equipoExiste.modelo = equipoAModificar.modelo;

            _contexto.Entry(equipoExiste).State = EntityState.Modified;
            _contexto.SaveChanges();
            return Ok(equipoExiste);
        }
    }
}