using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Join
{
        public class Person
        {
            public string Name { get; set; }
        }

        public class Pet
        {
            public string Name { get; set; }
            public Person Owner { get; set; }
        }

}

