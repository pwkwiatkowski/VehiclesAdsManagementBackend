using EasyNetQ;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VehiclesAdsManagement.Models;

namespace VehiclesAdsManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        private readonly VehicleContext _context;
        private readonly IBus messageBus = RabbitHutch.CreateBus("host=localhost"); //RabbitMQ

        public VehiclesController(VehicleContext context)
        {
            _context = context;
            messageBus = RabbitHutch.CreateBus("host=localhost"); //RabbitMQ
        }

        [HttpGet]
        public IEnumerable<Vehicle> GetVehicles()
        {
            var vehicles = _context.Vehicles.ToList();

            messageBus.PubSub.Publish("Pobrano listę pojazdów");

            return vehicles;
        }

        [HttpGet("{id}")]
        public ActionResult<Vehicle> GetVehicle(int id)
        {
            var Vehicle = _context.Vehicles.Find(id);

            messageBus.PubSub.Publish("Zapytano o pojazd " + id.ToString());

            if (Vehicle == null)
            {
                return NotFound();
            }

            return Vehicle;
        }

        [HttpPost]
        public ActionResult<Vehicle> PostVehicle(Vehicle vehicle)
        {
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();

            messageBus.PubSub.Publish("Dodano pojazd " + vehicle.ToString());

            return CreatedAtAction(nameof(GetVehicle), new { id = vehicle.Id }, vehicle);
        }

        [HttpPut("{id}")]
        public ActionResult PutVehicle(int id, Vehicle vehicle)
        {
            if (id != vehicle.Id)
            {
                return BadRequest();
            }

            _context.Vehicles.Update(vehicle);
            _context.SaveChanges();

            messageBus.PubSub.Publish("Zaktualizowano pojazd " + vehicle.ToString());

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteVehicle(int id)
        {
            var Vehicle = _context.Vehicles.Find(id);

            if (Vehicle == null)
            {
                return NotFound();
            }

            _context.Vehicles.Remove(Vehicle);
            _context.SaveChanges();

            messageBus.PubSub.Publish("Usunięto pojazd o id " + id.ToString());

            return NoContent();
        }
    }
}
