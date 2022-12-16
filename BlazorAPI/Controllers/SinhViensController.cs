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
    public class SinhViensController : ControllerBase
    {
        private readonly ISinhVienResponsitories _sinhVienResponsitories;

        public SinhViensController(ISinhVienResponsitories sinhVienResponsitories)
        {
            _sinhVienResponsitories = sinhVienResponsitories;
        }

        // GET: api/SinhViens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SinhVien>>> GetSinhViens()
        {
            var task = await _sinhVienResponsitories.GetList();
            return Ok(task);
        }

        // GET: api/SinhViens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SinhVien>> GetSinhVien(int id)
        {
            var nganh = await _sinhVienResponsitories.GetById(id);

            if (nganh == null)
            {
                return NotFound();
            }

            return nganh;
        }

        // PUT: api/SinhViens/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSinhVien(int id, [FromBody] SinhVien sinhVien)
        {
            if (id != sinhVien.MaSv)
            {
                return BadRequest();
            }

            try
            {
                await _sinhVienResponsitories.Update(sinhVien);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_sinhVienResponsitories.GetById(id).IsFaulted)
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

        // POST: api/SinhViens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<SinhVien>> PostSinhVien(SinhVien sinhVien)
        {
            await _sinhVienResponsitories.Create(sinhVien);
            return CreatedAtAction("GetSinhVien", new { id = sinhVien.MaSv }, sinhVien);
        }

        // DELETE: api/SinhViens/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSinhVien(int id)
        {
            await _sinhVienResponsitories.Delete(id);
            return Ok();
        }
    }
}