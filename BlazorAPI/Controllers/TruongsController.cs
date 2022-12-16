using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorAPI.Responsitories;
using BlazorModel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TruongsController : ControllerBase
    {
        private readonly ITruongResponsitories _truongResponsitories;

        public TruongsController(ITruongResponsitories truongResponsitories)
        {
            _truongResponsitories = truongResponsitories;
        }

        // GET: api/Truongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Truong>>> GetTruongs()
        {
            var task = await _truongResponsitories.GetList();
            return Ok(task);
        }

        // GET: api/Truongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Truong>> GetTruong(string id)
        {
            var truong = await _truongResponsitories.GetById(id);

            if (truong == null)
            {
                return NotFound();
            }

            return truong;
        }

        // PUT: api/Truongs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTruong(string id, [FromBody] Truong truong)
        {
            if (id != truong.MaTruong)
            {
                return BadRequest();
            }

            try
            {
                await _truongResponsitories.Update(truong);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_truongResponsitories.GetById(id).IsFaulted)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Truongs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Truong>> PostTruong(Truong truong)
        {
            try
            {
                await _truongResponsitories.Create(truong);
            }
            catch (DbUpdateException)
            {
                if (_truongResponsitories.GetById(truong.MaTruong).IsCompletedSuccessfully)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTruong", new { id = truong.MaTruong }, truong);
        }

        // DELETE: api/Truongs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTruong(string id)
        {
            await _truongResponsitories.Delete(id);
            if (_truongResponsitories.GetById(id).IsFaulted)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}