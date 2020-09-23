using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetLithologies.DataAccess;
using GetLithologies.Models;

namespace GetLithologies
{
    public interface IDataRepository
    {
        IQueryable<LithologicDescriptions> LithologicDescriptions { get; }

        IQueryable<LithologicSubintervals> LithologicSubintervals { get; }

        IQueryable<DescriptionColumnValuePairs> DescriptionColumnValuePairs { get; }

        IQueryable<Sections> Sections { get; }

        IQueryable<LithologyTable> LithologyTables { get; }



        #region GenericQueries
        public Task<List<LithologyTable>> GetAllLithologiesAsync();

        public Task<List<LithologyTable>> GetTop25LithologiesAsync();

        public Task<List<LithologySectionInfoModel>> RecordsOfPrincipal(string principalLithology);

        #endregion
    }
}