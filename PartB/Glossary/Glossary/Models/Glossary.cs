using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glossary.Models
{
    public class GlossaryItem
    {
        public int Id { get; set; }  // just use int this time
        public string Term { get; set; }
        public string Definition { get; set; }
    }
}
