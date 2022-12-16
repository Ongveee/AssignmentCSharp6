using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlazorAPI.Responsitories;
using BlazorModel.Models;
using NuGet.Common;

namespace BlazorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiemsController : ControllerBase
    {
        private readonly IDiemRespositories _diemRespositories;

        public DiemsController(IDiemRespositories diemRespositories)
        {
            _diemRespositories = diemRespositories;
        }

        // GET: api/Diems
        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Diem>>> GetDiems()
        {
            var task = await _diemRespositories.GetList();
            return Ok(task);
        }
        // GET: api/Diems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Diem>> GetDiem(int id)
        {
            var diem = await _diemRespositories.GetById(id);

            if (diem == null)
            {
                return NotFound();
            }

            return diem;
        }

        // PUT: api/Diems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiem(int id, Diem diem)
        {
            if (id != diem.MaSv)
            {
                return BadRequest();
            }

            try
            {
                await _diemRespositories.Update(diem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_diemRespositories.GetById(id).IsFaulted)
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

        // POST: api/Diems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Diem>> PostDiem(Diem diem)
        {
            try
            {
                await _diemRespositories.Create(diem);
            }
            catch (DbUpdateException)
            {
                if (_diemRespositories.GetById((int)diem.MaSv).IsCompletedSuccessfully)
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetDiem", new { id = diem.MaSv }, diem);
        }

        // DELETE: api/Diems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiem(int id)
        {
            await _diemRespositories.Delete(id);
            if (_diemRespositories.GetById(id).IsFaulted)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}