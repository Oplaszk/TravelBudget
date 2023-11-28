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
        public BaseRepository(DBContact db)
        {
            _db = db;
        }
    }
}
