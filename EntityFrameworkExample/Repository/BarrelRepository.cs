using EntityFrameworkExample.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.Repository
{
    public class BarrelRepository
    {
        private DataContext dbContext;
        public BarrelRepository()
        {
            dbContext = new DataContext();
        }
    }
}