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
    [Route("VeryBigSum")]
    public class VeryBigSumController : Controller
    {

        private readonly AppDbContext _context;

        public VeryBigSumController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]

        public async Task<ActionResult> Post([FromBody] List<int> input_array)
        {
            long sum = 0;
            var string_input = "[";
            try
            {
                var counter = 0;
                foreach (int n in input_array)
                {
                    counter++;
                    sum +=n;
                    string_input += n;
                    if (counter < input_array.Count)
                    {
                        string_input += ",";
                    }
                }
                string_input += "]";
                VeryBigSum vbs = new VeryBigSum();
                vbs.Input = string_input;
                vbs.Output = sum.ToString();
                vbs.Date = DateTime.Now;
                _context.Add(vbs);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

            }
            return Ok(sum);

        }
        [HttpGet]
        public async Task<ActionResult<VeryBigSum>> Get()
        {
            var vbss = await _context.VeryBigSums.ToListAsync();
             
            return Ok(vbss);
            
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<VeryBigSum>> Get(Guid id)
        {
            var vbs = await _context.VeryBigSums.FirstOrDefaultAsync(bs => bs.Id==id);
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
            if(vbs!=null)
            {
                _context.VeryBigSums.Remove(vbs);   
                _context.SaveChanges(); 
            } 

            return Ok();

        }

    }
}
