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
    }
}