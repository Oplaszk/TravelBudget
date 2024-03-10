using AutoMapper;
using Microsoft.Extensions.Logging;

namespace TravelBudgetDBContact.Repositories
{
    public class BaseRepository(DBContact db, ILogger<BaseRepository> logger, IMapper mapper)
    {
        protected DBContact _db = db;
        protected readonly ILogger<BaseRepository> _logger = logger;
        protected readonly IMapper _mapper = mapper;
    }
}
