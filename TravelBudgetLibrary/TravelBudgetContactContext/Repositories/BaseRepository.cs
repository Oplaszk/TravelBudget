using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBudgetContactContext.Repositories
{
    public class BaseRepository
    {
        protected DBContact _db { get; set; }
        public BaseRepository(DBContact db)
        {
            _db = db;
        }
    }
}
