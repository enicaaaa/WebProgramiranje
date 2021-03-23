using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Web_server.Models;
using Microsoft.EntityFrameworkCore;
namespace Web_server.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class ParkingPlaceController : ControllerBase{
        public GarageContext Context {get; set;}
        public ParkingPlaceController(GarageContext context){
            Context = context;
        }

        [Route("PreuzmiParkingMesta")]
        [HttpGet]
        public async Task<List<ParkingMesto>> PreuzmiParkingMesta(){
            return await Context.ParkingMesto.ToListAsync();
        }

        [Route("PopuniParkingMesto")]
        [HttpPost]
        public async Task PopuniParkingMesto([FromBody] ParkingMesto mesto){
            Context.ParkingMesto.Add(mesto);
            await Context.SaveChangesAsync();
        }

        [Route("IzmeniParkingMesto")]
        [HttpPut]
        public async Task IzmeniParkingMesto([FromBody] ParkingMesto mesto){
            Context.Update<ParkingMesto>(mesto);
            await Context.SaveChangesAsync();
        }

        [Route("IsprazniParkingMesto")]
        [HttpDelete]
        public async Task IsprazniParkingMesto(int id){
            var p = await Context.ParkingMesto.FindAsync(id);
            Context.Remove(p);
            await Context.SaveChangesAsync();
        }
    }
}