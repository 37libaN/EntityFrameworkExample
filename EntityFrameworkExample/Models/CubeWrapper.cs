using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.Models
{
    public class CubeWrapper
    {
        public Cube cube;
        public double volume;
        public string duration;

        public CubeWrapper(Cube cube1, double volume1, string duration1)
        {
            cube = cube1;
            volume = volume1;
            duration = duration1;
        }
    }
}