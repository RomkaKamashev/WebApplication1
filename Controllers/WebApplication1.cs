using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
  

        [Route("api/[controller]")]
        [ApiController]
        public class AnimalsController : ControllerBase
        {
            private static List<Animal> Animals = new List<Animal>();
            private static List<Visit> Visits = new List<Visit>();

            // GET: api/Animals
            [HttpGet]
            public ActionResult<IEnumerable<Animal>> GetAnimals()
            {
                return Animals;
            }

            // GET: api/Animals/5
            [HttpGet("{id}")]
            public ActionResult<Animal> GetAnimal(int id)
            {
                var animal = Animals.FirstOrDefault(a => a.id == id);

                if (animal == null)
                {
                    return NotFound();
                }

                return animal;
            }

            // POST: api/Animals
            [HttpPost]
            public ActionResult<Animal> PostAnimal(Animal animal)
            {
                animal.id = Animals.Count + 1;
                Animals.Add(animal);
                return CreatedAtAction("GetAnimal", new { id = animal.id }, animal);
            }

            // PUT: api/Animals/5
            [HttpPut("{id}")]
            public IActionResult PutAnimal(int id, Animal animal)
            {
                if (id != animal.id)
                {
                    return BadRequest();
                }

                var existingAnimal = Animals.FirstOrDefault(a => a.id == id);
                if (existingAnimal == null)
                {
                    return NotFound();
                }

                existingAnimal.name = animal.name;
                existingAnimal.category = animal.category;
                existingAnimal.weight = animal.weight;
                existingAnimal.furcolor = animal.furcolor;

                return NoContent();
            }

            // DELETE: api/Animals/5
            [HttpDelete("{id}")]
            public IActionResult DeleteAnimal(int id)
            {
                var animal = Animals.FirstOrDefault(a => a.id == id);
                if (animal == null)
                {
                    return NotFound();
                }

                Animals.Remove(animal);
                return NoContent();
            }

        // GET: api/Animals/5/Visits
        [HttpGet("{id}/Visits")]
        public ActionResult GetVisitsByAnimalId(int id)
        {
            var visits = Visits.Where(v => v.AnimalId == id);
            return Ok(visits);
        }


        // POST: api/Animals/5/Visits
        [HttpPost("{id}/Visits")]
            public ActionResult<Visit> PostVisit(int id, Visit visit)
            {
                visit.Id = Visits.Count + 1;
                visit.AnimalId = id;
                Visits.Add(visit);
                return CreatedAtAction("GetVisit", new { id = visit.Id }, visit);
            }
        }
    
}
