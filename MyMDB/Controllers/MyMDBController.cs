using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyMDB.Data;

namespace MyMDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MyMDBController<TEntity, TRepository> : ControllerBase
        where TEntity : class, IEntity where TRepository : IRepository<TEntity>
    {
        private readonly TRepository _repository;

        public MyMDBController(TRepository repository)
        {
            this._repository = repository;
        }

        // GET: api/MyMDB
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TEntity>>> Get()
        {
            return await _repository.GetAll();
        }

        // GET: api/MyMDB/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TEntity>> Get(int id)
        {
            var movie = await _repository.Get(id);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }

        // POST: api/MyMDB
        [HttpPost]
        public async Task<ActionResult<TEntity>> Post(TEntity movie)
        {
            await _repository.Add(movie);
            return CreatedAtAction("Get", new { id = movie.Id }, movie);
        }

        // PUT: api/MyMDB/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, TEntity movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }
            await _repository.Update(movie);
            return NoContent();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TEntity>> Delete(int id)
        {
            var movie = await _repository.Delete(id);
            if (movie == null)
            {
                return NotFound();
            }
            return movie;
        }
    }
}
