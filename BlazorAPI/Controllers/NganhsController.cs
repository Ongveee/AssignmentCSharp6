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
    public class NganhsController : ControllerBase
    {
        private readonly INganhResponsitories _nganhResponsitories;

        public NganhsController(INganhResponsitories nganhResponsitories)
        {
            _nganhResponsitories = nganhResponsitories;
        }

        // GET: api/Nganhs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Nganh>>> GetNganhs()
        {
            var task = await _nganhResponsitories.GetList();
            return Ok(task);
        }

        // GET: api/Nganhs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Nganh>> GetNganh(string id)
        {
            var nganh = await _nganhResponsitories.GetById(id);

            if (nganh == null)
            {
                return NotFound();
            }

            return nganh;
        }

        // PUT: api/Nganhs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNganh(string id, [FromBody] Nganh nganh)
        {
            if (id != nganh.MaNganh)
            {
                return BadRequest();
            }

            try
            {
                await _nganhResponsitories.Update(nganh);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_nganhResponsitories.GetById(id).IsFaulted)
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

        // POST: api/Nganhs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Nganh>> PostNganh(Nganh nganh)
        {
            try
            {
                await _nganhResponsitories.Create(nganh);
            }
            catch (DbUpdateException)
            {
                if (_nganhResponsitories.GetById(nganh.MaNganh).IsFaulted)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetNganh", new { id = nganh.MaNganh }, nganh);
        }

        // DELETE: api/Nganhs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNganh(string id)
        {
            await _nganhResponsitories.Delete(id);
            if (_nganhResponsitories.GetById(id).IsFaulted)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}