using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using GetLithologies.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using GetLithologies.Models;

namespace GetLithologies
{
    public class DataRepository: IDataRepository
    {
        private LithologyDatabaseContext _context;
        public DataRepository() { }
        public DataRepository(LithologyDatabaseContext ctx)
        {
            _context = ctx;

            //Speeds up query execution because tracking is disabled
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }


        public IQueryable<LithologicDescriptions> LithologicDescriptions => _context.LithologicDescriptions;

        public IQueryable<LithologicSubintervals> LithologicSubintervals => _context.LithologicSubintervals;

        public IQueryable<DescriptionColumnValuePairs> DescriptionColumnValuePairs => _context.DescriptionColumnValuePairs;

        public IQueryable<Sections> Sections => _context.Sections;

        public IQueryable<LithologyTable> LithologyTables => _context.LithologyTable;


        public async Task<List<LithologyTable>> GetAllLithologiesAsync()
        {
            return await _context.LithologyTable.ToListAsync();
        }

        public async Task<List<LithologyTable>> GetTop25LithologiesAsync()
        {
            return await _context.LithologyTable.Take(25).ToListAsync();
        }

        public async Task<List<LithologySectionInfoModel>> RecordsOfPrincipal(string principalLithology)
        {
         return await _context.LithologyTable.Where(x => x.PrincipalLithology == principalLithology)
                .Select(s => new LithologySectionInfoModel (s, s.LithologicDescriptionLithologic.SectionInfo )).ToListAsync();           
        }


    }
}
