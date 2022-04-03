using Challenge.Context;
using Challenge.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Challenge.Controllers
{
    [ApiController]
    [Route("RatioElements")]
    public class RatioElementsController : Controller
    {
        private readonly AppDbContext _context;
        public RatioElementsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost]

        public async Task<ActionResult> Post([FromBody] List<int> input_array)
        {
            float positives=0,negatives=0,zeros = 0;
            RatioElements rte = new RatioElements();
            var string_input = "[";
            try
            {
                int counter = 0;  
                foreach (int n in input_array)
                {
                    counter++;
                    string_input += n;
                    if (n == 0)
                    {
                        zeros++;
                    }
                    if (counter < input_array.Count)
                    {
                        string_input += ",";
                    }
                    if (n > 0) { positives++;}
                    if (n < 0) {negatives++;}   
                }
                string_input += "]";
                
                rte.Input = string_input;
                rte.ZerosRatio = string.Format("{0:N6}", (zeros / input_array.Count));
                rte.PositivesRatio = string.Format("{0:N6}", (positives / input_array.Count));
                rte.NegativesRatio = string.Format("{0:N6}",(negatives/input_array.Count));
                _context.Add(rte);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }
            return Ok(rte);

        }
        [HttpGet]
        public async Task<ActionResult<RatioElements>> Get()
        {
            var vbss = await _context.RatioElements.ToListAsync();

            return Ok(vbss);

        }
        [HttpGet("{id}")]
        public async Task<ActionResult<RatioElements>> Get(Guid id)
        {
            var vbs = await _context.RatioElements.FirstOrDefaultAsync(bs => bs.Id == id);
            if (vbs == null)
            {
                return NotFound();
            }
            return Ok(vbs);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var vbs = await _context.VeryBigSums.FirstOrDefaultAsync(bs => bs.Id == id);
            if (vbs != null)
            {
                _context.VeryBigSums.Remove(vbs);
                _context.SaveChanges();
            }

            return Ok();

        }
    }
}
