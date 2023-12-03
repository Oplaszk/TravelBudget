using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBudgetDBContact.Repositories
{
    public class BaseRepository
    {
        protected DBContact _db;
        protected readonly ILogger<BaseRepository> _logger;
        public BaseRepository(DBContact db, ILogger<BaseRepository> logger)
        {
            _db = db;
            _logger = logger;
        }
    }
}
