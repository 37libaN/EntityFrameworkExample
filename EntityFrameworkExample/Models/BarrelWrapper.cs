using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.Models
{
    public class BarrelWrapper
    {
        public Barrel barrel;
        public double volume;
        public string duration;

        public BarrelWrapper(Barrel barrel1, double volume1, string duration1)
        {
            barrel = barrel1;
            volume = volume1;
            duration = duration1;
        }
    }
}