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
    [Route("api/jugador")]
    [ApiController]
    public class JugadorController : ControllerBase
    {
        private readonly IJugadorService jugadorService;

        public JugadorController(IJugadorService jugadorService)
        {
            this.jugadorService = jugadorService;
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var result = this.jugadorService.Get();
            var jugadores = new List<NuevoJugadorDTO>();

            foreach (var item in result)
            {
                var jugador = new NuevoJugadorDTO();
                jugador.Nombres = item.Nombres;
                jugador.Edad = item.Edad;
                jugador.Posicion = item.Posicion;
                jugador.EquipoId = item.EquipoId;

                jugadores.Add(jugador);
            }

            return Ok(jugadores);
        }

        [HttpGet]
        [Route("{jugadorId}")]
        public IActionResult ObtenerPorId(int jugadorId)
        {
            var jugador = this.jugadorService.Get(jugadorId);

            if (jugador == null)
            {
                return BadRequest("El jugador consultado no existe");
            }

            return Ok(jugador);
        }

        [HttpPost]
        public IActionResult NuevoJugador(NuevoJugadorDTO nuevoJugador)
        {
            var jugador = new Jugador
            {
                Nombres = nuevoJugador.Nombres,
                Edad = nuevoJugador.Edad,
                Posicion = nuevoJugador.Posicion,
                EquipoId = nuevoJugador.EquipoId
            };

            this.jugadorService.Add(jugador);
            this.jugadorService.Save();
            return Ok("Jugador creado!");
        }
    }
}
