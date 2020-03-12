using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyGraphQL.DBModels;

namespace MyGraphQL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly graphQLContext _context;

        public EmployeeController(graphQLContext context)
        {
            _context = context;
        }

        // GET: api/Emp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Emp>>> GetEmp()
        {
            try
            {
                return await _context.Emp.ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // GET: api/Emp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Emp>> GetEmp(long id)
        {
            var emp = await _context.Emp.FindAsync(id);

            if (emp == null)
            {
                return NotFound();
            }

            return emp;
        }

        // PUT: api/Emp/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmp(long id, Emp emp)
        {
            if (id != emp.Id)
            {
                return BadRequest();
            }

            _context.Entry(emp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpExists(id))
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

        // POST: api/Emp
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<Emp>> PostEmp(Emp emp)
        {
            _context.Emp.Add(emp);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmp", new { id = emp.Id }, emp);
        }

        // DELETE: api/Emp/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Emp>> DeleteEmp(long id)
        {
            var emp = await _context.Emp.FindAsync(id);
            if (emp == null)
            {
                return NotFound();
            }

            _context.Emp.Remove(emp);
            await _context.SaveChangesAsync();

            return emp;
        }

        private bool EmpExists(long id)
        {
            return _context.Emp.Any(e => e.Id == id);
        }
    }
}
