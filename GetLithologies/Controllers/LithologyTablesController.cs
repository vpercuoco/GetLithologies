using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GetLithologies.DataAccess;
using GetLithologies.Models;
using System.Linq;
using System.Linq.Expressions;
using GetLithologies.StaticMethods;

namespace GetLithologies.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LithologyTablesController : ControllerBase
    {
        private readonly IDataRepository _repo;

        public LithologyTablesController(IDataRepository repo)
        {
            _repo = repo;
        }

        // GET: api/LithologyTables

        #region TestMethods

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LithologyTable>>> GetLithologyTable()
        {
            return await _repo.GetTop25LithologiesAsync();

        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LithologyTable>>> GetTop25Lithologies()
        {
            return await _repo.GetTop25LithologiesAsync();

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LithologyTable>> GetSingleRecord(string id)
        {
            var record = await _repo.LithologyTables.FirstOrDefaultAsync(x => x.LithologicDescriptionLithologicId == id);

            if (record == null)
            {
                return NotFound();
            }
            return record;

        }
        [HttpGet("{principal}")]
        public async Task<ActionResult<IEnumerable<LithologySectionInfoModel>>> GetPrincipalLithologyRecords(string principal)
        {
            var record = await _repo.RecordsOfPrincipal(principal);

            if (record == null)
            {
                return NotFound();
            }
            return record;

        }



        [HttpGet("{textID}")]
        public async Task<ActionResult<IEnumerable<LithologySectionInfoModel>>> GetLithologiesBySection(string textID)
        {
            var records = await _repo.Sections.Where(x => x.SectionTextId == textID)
                .Include(x => x.LithologicDescriptions)
                .ThenInclude(x => x.LithologyTable)
                .SelectMany(x => x.LithologicDescriptions)
                .Select(x => new LithologySectionInfoModel(x.LithologyTable, x.SectionInfo))
                .ToListAsync();

            return records;
        }

        #endregion

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LithologySectionInfoModel>>> GetDescriptions([FromQuery] DescriptionRequestModel request)
        {
            try
            {
                var records = await _repo.Sections.WhereIf(request.ExpeditionsCollection.Count !=0, x=>request.ExpeditionsCollection.Contains(x.Expedition))
                                                  .WhereIf(request.SitesCollection.Count != 0, x => request.SitesCollection.Contains(x.Site))
                                                  .WhereIf(request.HolesCollection.Count != 0, x => request.HolesCollection.Contains(x.Hole))
                                                  .WhereIf(request.CoresCollection.Count != 0, x => request.CoresCollection.Contains(x.Core))
                                                  .WhereIf(request.CoreTypesCollection.Count != 0, x => request.CoreTypesCollection.Contains(x.Type))
                                                  .Include(x => x.LithologicDescriptions)
                                                  .ThenInclude(x => x.LithologyTable)
                                                  .SelectMany(x => x.LithologicDescriptions)
                                                  .Select(x => new LithologySectionInfoModel(x.LithologyTable, x.SectionInfo))
                                                  .ToListAsync();
                return records;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<LithologySectionInfoModel>>> GetDescriptionsBySection([FromQuery] DescriptionRequestModel requestParameters)
        {
            try
            {
                var records = await _repo.Sections.Where(x => requestParameters.SectionTextIDsCollection.Contains(x.SectionTextId))
                    .Include(x => x.LithologicDescriptions)
                    .ThenInclude(x => x.LithologyTable)
                    .SelectMany(x => x.LithologicDescriptions)
                    .Select(x => new LithologySectionInfoModel(x.LithologyTable, x.SectionInfo))
                    .ToListAsync();

                return records;
            }
            catch (Exception)
            {

                throw;
            }

        }


        [HttpGet()]
        public async Task<ActionResult<IEnumerable<LithologySectionInfoModel>>> GetLithologiesBySection()
        {
            var list = new List<string>() { "SHLF9038691", "SHLF9039801", "SHLF9040631" };

            var records = await _repo.Sections.Where(x => list.Contains(x.SectionTextId))
                        .Include(x => x.LithologicDescriptions)
                        .ThenInclude(x => x.LithologyTable)
                        .SelectMany(x => x.LithologicDescriptions)
                        .Select(x => new LithologySectionInfoModel(x.LithologyTable, x.SectionInfo))
                        .ToListAsync();

            return records;

        }

        //TODOl Change this to a get method, I am not creating new items
        [HttpPost()]
        [Consumes("application/json")]
        public async Task<ActionResult<IEnumerable<LithologySectionInfoModel>>> GetLithologiesBySection([FromBody] DescriptionRequestModel request)
        {
            var records = await _repo.Sections.Where(x => request.SectionTextIDsCollection.Contains(x.SectionTextId))
                .Include(x => x.LithologicDescriptions)
                .ThenInclude(x => x.LithologyTable)
                .SelectMany(x => x.LithologicDescriptions)
                .Select(x => new LithologySectionInfoModel(x.LithologyTable, x.SectionInfo))
                .ToListAsync();

            return records;
        }

        /*
        // PUT: api/LithologyTables/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLithologyTable(string id, LithologyTable lithologyTable)
        {
            if (id != lithologyTable.LithologicDescriptionLithologicId)
            {
                return BadRequest();
            }

            _repo.Entry(lithologyTable).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LithologyTableExists(id))
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
        */

        /*
        // POST: api/LithologyTables
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<LithologyTable>> PostLithologyTable(LithologyTable lithologyTable)
        {
            _repo.LithologyTables.aAdd(lithologyTable);
            try
            {
                await _repo.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (LithologyTableExists(lithologyTable.LithologicDescriptionLithologicId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetLithologyTable", new { id = lithologyTable.LithologicDescriptionLithologicId }, lithologyTable);
        }
        */
        /*
        // DELETE: api/LithologyTables/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<LithologyTable>> DeleteLithologyTable(string id)
        {
            var lithologyTable = await _context.LithologyTable.FindAsync(id);
            if (lithologyTable == null)
            {
                return NotFound();
            }

            _context.LithologyTable.Remove(lithologyTable);
            await _context.SaveChangesAsync();

            return lithologyTable;
        }
        */

        private bool LithologyTableExists(string id)
        {
            return _repo.LithologyTables.Any(e => e.LithologicDescriptionLithologicId == id);
        }
    }
}
