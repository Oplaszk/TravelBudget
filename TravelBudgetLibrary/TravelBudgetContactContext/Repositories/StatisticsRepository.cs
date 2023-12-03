using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBudgetDBContact.Repositories
{
    public class StatisticsRepository : BaseRepository
    {
        private readonly ILogger<StatisticsRepository> _logger;
        public StatisticsRepository(DBContact db, ILogger<StatisticsRepository> logger) : base(db)
        {
            _logger = logger;
        }


    }
}
