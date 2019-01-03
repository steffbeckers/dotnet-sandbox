using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sandbox
{
    public class Export
    {
        public List<Dossier> Dossiers { get; set; }
    }

    public class Dossier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
    }

    public class Address
    {
        public string Street { get; set; }
        public int Number { get; set; }
        public string Extension { get; set; }
    }
}
