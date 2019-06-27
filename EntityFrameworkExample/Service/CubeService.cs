using EntityFrameworkExample.Models;
using EntityFrameworkExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.Service
{
    public class CubeService
    {
        private CubeRepository repository;
        public CubeService()
        {
            repository = new CubeRepository();
        }

        public void SaveEdits(Cube toSave)
        {
            repository.SaveEdits(toSave);
        }

        public List<Cube> GetAllCubes()
        {
            return repository.GetAllCubes();
        }

        public List<Cube> GetActiveCubes()
        {
            List<Cube> activeCubes = new List<Cube>();
            List<Cube> all = this.GetAllCubes();
            foreach (Cube c in all)
            {
                if (!c.hidden)
                    activeCubes.Add(c);
            }
            return activeCubes;
        }

        public List<Cube> GetArchivedCubes()
        {
            List<Cube> archivedCubes= new List<Cube>();
            List<Cube> all = this.GetAllCubes();
            foreach (Cube c in all)
            {
                if (c.hidden)
                    archivedCubes.Add(c);
            }
            return archivedCubes;
        }

        public void AddCube(Cube toAdd)
        {
            repository.AddCube(toAdd);
        }

        public Cube GetCubeById(int id)
        {
            return repository.GetCubeById(id);
        }

        public void DeleteCube(Cube toDelete)
        {
            repository.DeleteCube(toDelete);
        }

        public double Volume(Cube cube)
        {
            return Math.Round(cube.SideLength * cube.SideLength * cube.SideLength);
        }

        public string Duration(Cube cube)
        {
            TimeSpan duration = DateTime.Now - cube.DateCreated;

            double duration2 = duration.TotalSeconds;
            int days = (int)(duration2 / 86400);
            duration2 = duration2 - (days * 86400.0);
            int hours = (int)(duration2 / 3600);
            duration2 = duration2 - (hours * 3600.0);
            int minutes = (int)(duration2 / 60);
            duration2 = duration2 - (minutes * 60.0);
            int seconds = (int)duration2;
            string sentence = days + " days, " + hours + " hours, " + minutes + " minutes, and " + seconds + " seconds.";
            return sentence;
        }
    }
}