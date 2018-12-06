using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

//reference models
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private MovieListingsModel db;

        //constructor - connect to db as soon as this controller is instantiated
        public MoviesController(MovieListingsModel db)
        {
            this.db = db;
        }

        // GET: /api/movies
        [HttpGet]
        public IEnumerable<Movie> Get()
        {
            return db.Movies.OrderBy(a => a.Title).ToList();
        }

        // GET: /api/movies/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            Movie movie = db.Movies.SingleOrDefault(a => a.Id == id);

            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(movie);
            }
        }

        // POST: /api/movies/5
        [HttpGet("{id}")]
        public ActionResult Post([FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                db.Movies.Add(movie);
                db.SaveChanges();
                return CreatedAtAction("Post", movie);
            }
        }

        // PUT: api/movies/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else
            {
                db.Entry(movie).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
                return AcceptedAtAction("Put", movie);
            }
        }

        // DELETE: api/movies/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Movie movie = db.Movies.SingleOrDefault(a => a.Id == id);

            if (movie == null)
            {
                return NotFound();
            }
            else
            {
                db.Movies.Remove(movie);
                db.SaveChanges();
                return Ok();
            }
        }

    }
}