using EntityFrameworkExample.Models;
using EntityFrameworkExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.Service
{
    public class BarrelService
    {
        private BarrelRepository repository;
        public BarrelService()
        {
            repository = new BarrelRepository();
        }

        public void SaveEdits(Barrel toSave)
        {
            repository.SaveEdits(toSave);
        }

        public List<Barrel> GetAllBarrels()
        {
            return repository.GetAllBarrels();
        }

        public List<Barrel> GetActiveBarrels()
        {
            List<Barrel> activeBarrels = new List<Barrel>();
            List<Barrel> all = this.GetAllBarrels();
            foreach(Barrel b in all)
            {
                if(!b.hidden)
                    activeBarrels.Add(b);
            }
            return activeBarrels;
        }

        public List<Barrel> GetArchivedBarrels()
        {
            List<Barrel> archivedBarrels = new List<Barrel>();
            List<Barrel> all = this.GetAllBarrels();
            foreach (Barrel b in all)
            {
                if (b.hidden)
                    archivedBarrels.Add(b);
            }
            return archivedBarrels;
        }

        public void AddBarrel(Barrel toAdd)
        {
            repository.AddBarrel(toAdd);
        }

        public Barrel GetBarrelById(int id)
        {
            return repository.GetBarrelById(id);
        }

        public void DeleteBarrel(Barrel toDelete)
        { 
            repository.DeleteBarrel(toDelete);
        }

        public double Volume(Barrel barrel)
        {
            return Math.Round(Math.PI * barrel.Radius * barrel.Radius * barrel.Height, 3);
        }

        public string Duration(Barrel barrel)
        {
            TimeSpan duration = DateTime.Now - barrel.DateCreated;
            
            double duration2 = duration.TotalSeconds;
            int days = (int) (duration2 / 86400);
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