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
    public class MonHocsController : ControllerBase
    {
        private readonly IMonHocRespositories _monHocRespositories;

        public MonHocsController(IMonHocRespositories monHocRespositories)
        {
            _monHocRespositories = monHocRespositories;
        }

        // GET: api/MonHocs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonHoc>>> GetMonHocs()
        {
            var task = await _monHocRespositories.GetList();
            return Ok(task);
        }

        // GET: api/MonHocs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MonHoc>> GetMonHoc(string id)
        {
            var monHoc = await _monHocRespositories.GetById(id);

            if (monHoc == null)
            {
                return NotFound();
            }

            return monHoc;
        }

        // PUT: api/MonHocs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonHoc(string id, [FromBody] MonHoc monHoc)
        {
            if (id != monHoc.MaMh)
            {
                return BadRequest();
            }

            try
            {
                await _monHocRespositories.Update(monHoc);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_monHocRespositories.GetById(id).IsFaulted)
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

        // POST: api/MonHocs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MonHoc>> PostMonHoc(MonHoc monHoc)
        {
            try
            {
                await _monHocRespositories.Create(monHoc);
            }
            catch (DbUpdateException)
            {
                if (_monHocRespositories.GetById(monHoc.MaMh).IsFaulted)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMonHoc", new { id = monHoc.MaMh }, monHoc);
        }

        // DELETE: api/MonHocs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonHoc(string id)
        {
            await _monHocRespositories.Delete(id);
            if (_monHocRespositories.GetById(id).IsFaulted)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}