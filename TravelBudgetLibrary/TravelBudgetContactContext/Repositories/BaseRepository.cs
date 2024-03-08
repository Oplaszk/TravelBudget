using AutoMapper;
using Microsoft.Extensions.Logging;

namespace TravelBudgetDBContact.Repositories
{
    public class BaseRepository
    {
        protected DBContact _db;
        protected readonly ILogger<BaseRepository> _logger;
        protected readonly IMapper _mapper;
        public BaseRepository(DBContact db, ILogger<BaseRepository> logger, IMapper mapper )
        {
            _db = db;
            _logger = logger;
            _mapper = mapper;
        }
    }
}
