using Challenge.Context;
using Challenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("DiagonalSum")]
    public class DiagonalSumController : Controller
    {
        private readonly AppDbContext _context;

        public DiagonalSumController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DiagonalSum ds)
        {
            long diagonal1 = 0;
            long diagonal2 = 0;
            try
            {
                ds.Date = DateTime.Now;
                string[] line = ds.Input.Split(";");
                int k = line.Length - 1;
                for (int i = 0; i < line.Length; i++)
                {
                    string[] column = line[i].ToString().Trim().Split(" ");

                    for (int j = 0; j < column.Length; j++)
                    {
                        if (i == j && j >= 0)
                        {
                            diagonal1 += long.Parse(column[j]);
                        }
                        if ((k - i) == j && j >= 0)
                        {
                            diagonal2 += long.Parse(column[j]);
                        }

                    }

                }
               ds.Output = (Math.Abs(diagonal1 - diagonal2)).ToString();
                _context.Add(ds);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(ds);
        }

        [HttpGet]
        public async Task<ActionResult<DiagonalSum>> Get()
        {
            var vbs = await _context.DiagonalSums.ToListAsync();
            return Ok(vbs);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<DiagonalSum>> Get(Guid id)
        {
            var vbs = await _context.DiagonalSums.FirstOrDefaultAsync(bs => bs.Id == id);
            if (vbs == null)
                return NotFound();
            return Ok(vbs);
        }

     
        [HttpDelete("{id}")]
        public async  Task<IActionResult> Delete(Guid id)
        {
            var vbs =  await _context.DiagonalSums.FirstOrDefaultAsync(bs => bs.Id == id);
            if(vbs!= null)
            {
            _context.DiagonalSums.Remove(vbs);
            await _context.SaveChangesAsync();
            }
          
            return Ok(true);
        }

    }
}
