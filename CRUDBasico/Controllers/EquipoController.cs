using CRUDBasico.Models.DataTransferObjects;
using CRUDBasico.Models.Entities;
using CRUDBasico.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDBasico.Controllers
{
    [Route("api/equipo")]
    [ApiController]
    public class EquipoController : ControllerBase
    {
        private readonly IEquipoService equipoService;

        public EquipoController(IEquipoService equipoService)
        {
            this.equipoService = equipoService;
        }

        [HttpGet]
        public IEnumerable<EquipoDeFutbol> ObtenerTodos()
        {
            var result = this.equipoService.Get();
            return result;
        }

        [HttpPost]
        public IActionResult NuevoEquipo([FromBody] NuevoEquipoDTO nuevoEquipo)
        {
            var equipo = new EquipoDeFutbol
            {
                Nombre = nuevoEquipo.Nombre,
                Presidente = nuevoEquipo.Presidente,
                AnioFundacion = nuevoEquipo.AnioFundacion,
                Liga = nuevoEquipo.Liga
            };
            this.equipoService.Add(equipo);
            this.equipoService.Save();
            return Ok("Equipo creado!");
        }

        [HttpPut]
        public IActionResult ActualizarEquipo([FromBody] NuevoEquipoDTO equipoActualizado, int equipoId)
        {
            var equipo = this.equipoService.Get(equipoId);

            if (equipo == null)
            {
                return BadRequest("El equipo a editar no existe");
            }

            equipo.Nombre = equipoActualizado.Nombre;
            equipo.Presidente = equipoActualizado.Presidente;
            equipo.AnioFundacion = equipoActualizado.AnioFundacion;
            equipo.Liga = equipoActualizado.Liga;

            this.equipoService.Update(equipo);
            this.equipoService.Save();
            return Ok("Equipo actualizado!");
        }

        [HttpDelete]
        public IActionResult EliminarEquipo(int equipoId)
        {
            var existeEquipo = this.equipoService.Get(equipoId);

            if (existeEquipo == null)
            {
                return BadRequest("No se puede eliminar un equipo que no existe");
            }

            this.equipoService.Delete(equipoId);
            this.equipoService.Save();
            return Ok("Equipo eliminado.");
        }
    }
}
