using Glossary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Glossary.Interfaces
{
    // Criteria 1 CRUD
    public interface IGlossaryRepository
    {
        void Create(GlossaryItem item);
        GlossaryItem Read(string term);
        GlossaryItem Read(int id);
        List<GlossaryItem> Read(); //paging is not included this time :D
        void Update(GlossaryItem item);
        void Delete(GlossaryItem item);
    }
}
