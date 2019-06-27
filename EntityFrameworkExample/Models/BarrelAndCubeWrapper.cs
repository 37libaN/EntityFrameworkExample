using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkExample.Models
{
    public class BarrelAndCubeWrapper
    {
        public List<Barrel> barrels;
        public List<Cube> cubes;
        public BarrelAndCubeWrapper(List<Barrel> barrels, List<Cube> cubes)
        {
            this.barrels = barrels;
            this.cubes = cubes;
        }
    }
}