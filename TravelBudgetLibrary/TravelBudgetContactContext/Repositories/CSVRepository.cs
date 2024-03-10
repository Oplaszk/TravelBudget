using AutoMapper;
using Microsoft.Extensions.Logging;

namespace TravelBudgetDBContact.Repositories
{
    public class CSVRepository : BaseRepository
    {
        public CSVRepository(DBContact db, ILogger<CSVRepository> logger, IMapper mapper) : base(db, logger, mapper)
        {
            
        }
    }
}
