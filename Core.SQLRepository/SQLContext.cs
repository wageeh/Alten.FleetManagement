using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.SQLRepository
{
    public class SQLContext : DbContext
    {
        public SQLContext(DbContextOptions<SQLContext> options)
            : base(options)
        {
        }

    }
}
