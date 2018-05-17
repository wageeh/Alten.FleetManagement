using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Core.SQLRepository
{
    public class BaseContext: DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options)
            : base(options)
        {
        }

    }
}
