using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Join
{
    public class Category
    {
       public string Name { get; set; }
       public int ID { get; set; }
    }

    public class Product
    {
        public string Name { get; set; }
        public int CategoryID { get; set; }
    }
  
}
