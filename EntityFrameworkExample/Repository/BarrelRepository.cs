using EntityFrameworkExample.Data.Context;
using EntityFrameworkExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public List<Barrel> GetAllBarrels()
        {
            return dbContext.Barrels.ToList();
        }

        public void AddBarrel(Barrel toAdd)
        {
            dbContext.Barrels.Add(toAdd);
            dbContext.SaveChanges();
        }

        public Barrel GetBarrelById(int id)
        {
            return dbContext.Barrels.Find(id);
        }


        public DeleteBarrel(Barrel toDelete)
        {
            dbContext.Barrels.Remove(toDelete);
        }
        public void SaveEdits(Barrel toSave)
        {
            dbContext.Entry(toSave).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}