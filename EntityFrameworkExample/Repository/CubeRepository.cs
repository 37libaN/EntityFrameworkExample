using EntityFrameworkExample.Data.Context;
using EntityFrameworkExample.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.Repository
{
    public class CubeRepository
    {
        private DataContext dbContext;
        public CubeRepository()
        {
            dbContext = new DataContext();
        }

        public List<Cube> GetAllCubes()
        {
            return dbContext.Cubes.ToList();
        }

        public void AddCube(Cube toAdd)
        {
            dbContext.Cubes.Add(toAdd);
            dbContext.SaveChanges();
        }

        public Cube GetCubeById(int id)
        {
            return dbContext.Cubes.Find(id);
        }


        public void DeleteCube(Cube toDelete)
        {
            dbContext.Cubes.Remove(toDelete);
            dbContext.SaveChanges();
        }

        public void SaveEdits(Cube toSave)
        {
            dbContext.Entry(toSave).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}