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
    public class VoziloController : ControllerBase
    {
        public GarageContext Context { get; set; }
        public VoziloController(GarageContext context){
            Context = context;
        }

        [Route("PreuzmiVozila")]
        [HttpGet]
        public async Task<List<Vozilo>> PreuzmiVozila(){
            return await Context.Vozilo.ToListAsync();
        }

        [Route("ParkirajVozilo")]
        [HttpPost]
        public async Task ParkirajVozilo([FromBody] Vozilo vozilo){
            Context.Vozilo.Add(vozilo);
            await Context.SaveChangesAsync();
        } 

        [Route("IzmeniVozilo")]
        [HttpPut]
        public async Task IzmeniVozilo([FromBody] Vozilo vozilo){
            Context.Update<Vozilo>(vozilo);
            await Context.SaveChangesAsync();
        }

        [Route("IsparkirajVozilo")]
        [HttpDelete]
        public async Task IsparkirajVozilo(int id){
            var v = await Context.Vozilo.FindAsync(id);
            Context.Remove(v);
            await Context.SaveChangesAsync();
        }
    }
}