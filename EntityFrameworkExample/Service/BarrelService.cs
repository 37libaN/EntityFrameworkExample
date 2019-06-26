﻿using EntityFrameworkExample.Models;
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

        public List<Barrel> GetAllBarrels()
        {
            return repository.GetAllBarrels();
        }

        public void AddBarrel(Barrel toAdd)
        {
            repository.AddBarrel(toAdd);
        }

        public Barrel GetBarrelById(int id)
        {
            return repository.GetBarrelById(id);
        }
    }
}