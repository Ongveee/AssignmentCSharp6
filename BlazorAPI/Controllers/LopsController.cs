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
    public class LopsController : ControllerBase
    {
        private readonly ILopRespositories _lopRespositories;

        // GET: api/Lops
        public LopsController(ILopRespositories lopRespositories)
        {
            _lopRespositories = lopRespositories;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lop>>> GetLops()
        {
            var task = await _lopRespositories.GetList();
            return Ok(task);
        }

        // GET: api/Lops/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lop>> GetLop(string id)
        {
            var lop = await _lopRespositories.GetById(id);

            if (_lopRespositories.GetById(id).IsFaulted)
            {
                return NotFound();
            }

            return lop;
        }

        // PUT: api/Lops/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLop(string id, [FromBody] Lop lop)
        {
            if (id != lop.MaLop)
            {
                return BadRequest();
            }

            try
            {
                await _lopRespositories.Update(lop);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_lopRespositories.GetById(id).IsFaulted)
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

        // POST: api/Lops
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lop>> PostLop(Lop lop)
        {
            try
            {
                await _lopRespositories.Create(lop);
            }
            catch (DbUpdateException)
            {
                if (_lopRespositories.GetById(lop.MaLop).IsCompletedSuccessfully)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLop", new { id = lop.MaLop }, lop);
        }

        // DELETE: api/Lops/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLop(string id)
        {
            await _lopRespositories.Delete(id);
            if (_lopRespositories.GetById(id).IsFaulted)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}