using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrgDirectoryApi.Data;
using OrgDirectoryApi.Models;
using System.Xml.Serialization;
using System.Text;

namespace OrgDirectoryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public OrganizationsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Organization>>> GetAll()
        {
            return await _context.Organizations.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Organization>> Get(int id)
        {
            var org = await _context.Organizations.FindAsync(id);
            return org == null ? NotFound() : org;
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Organization>>> Search([FromQuery] string name)
        {
            return await _context.Organizations
                .Where(o => o.Name.Contains(name))
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Organization>> Create(Organization org)
        {
            _context.Organizations.Add(org);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = org.Id }, org);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Organization updatedOrg)
        {
            if (id != updatedOrg.Id) return BadRequest();
            _context.Entry(updatedOrg).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var org = await _context.Organizations.FindAsync(id);
            if (org == null) return NotFound();

            _context.Organizations.Remove(org);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("export/xml")]
        public async Task<IActionResult> ExportToXml()
        {
            var organizations = await _context.Organizations.ToListAsync();
            var serializer = new XmlSerializer(typeof(List<Organization>));
            var ms = new MemoryStream();
            serializer.Serialize(ms, organizations);
            ms.Position = 0;
            return File(ms, "application/xml", "organizations.xml");
        }

        [HttpPost("import/xml")]
        public async Task<IActionResult> ImportFromXml(IFormFile file)
        {
            if (file == null || file.Length == 0) return BadRequest("Invalid file.");
            var serializer = new XmlSerializer(typeof(List<Organization>));
            using var stream = file.OpenReadStream();
            var data = (List<Organization>)serializer.Deserialize(stream)!;
            _context.Organizations.AddRange(data);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}