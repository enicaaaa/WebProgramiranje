using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web_server.Models;
using Microsoft.EntityFrameworkCore;
namespace Web_server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GarageController : ControllerBase
    {
        public GarageContext Context { get; set; }
        public GarageController(GarageContext context)
        {
            Context = context;
        }
        [Route("PreuzmiGaraze")]
        [HttpGet]
        public async Task<List<Garaza>> PreuzmiGaraze()
        {
            return await Context.Garaza.Include(p => p.ParkingMesta).ToListAsync();
        }

        [Route("UpisiGarazu")]
        [HttpPost]
        public async Task UpisiGarazu([FromBody] Garaza garaza)
        {
            Context.Garaza.Add(garaza);
            await Context.SaveChangesAsync();
        }

        [Route("IzmeniGarazu")]
        [HttpPut]
        public async Task IzmeniGarazu([FromBody] Garaza garaza)
        {
            Context.Update<Garaza>(garaza);
            await Context.SaveChangesAsync();
        }

        [Route("ObrisiGarazu")]
        [HttpDelete]
        public async Task ObrisiGarazu(int id)
        {
            var g = await Context.Garaza.FindAsync(id);
            Context.Remove(g);
            await Context.SaveChangesAsync();
        }

        [Route("UpisiParkingMesto/{idGaraze}")]
        [HttpPost]
        public async Task UpisiParkingMesto(int idGaraze, [FromBody] ParkingMesto mesto)
        {
            var g = await Context.Garaza.FindAsync(idGaraze);
            mesto.Garaza = g;
            Context.ParkingMesto.Add(mesto);
            await Context.SaveChangesAsync();
        }
    }
}
