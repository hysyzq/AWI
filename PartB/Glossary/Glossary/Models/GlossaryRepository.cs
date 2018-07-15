using Glossary.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Glossary.Models
{
    public class GlossaryRepository: IGlossaryRepository
    {
        //use list to Mock a DBContext.
        private List<GlossaryItem> _glossaryList;
        private int _maxId;

        public void Initial()
        {
            using (StreamReader r = new StreamReader("./Models/Glossary.json"))
            {
                string json = r.ReadToEnd();
                List<GlossaryItem> items = JsonConvert.DeserializeObject<List<GlossaryItem>>(json);
                _glossaryList = items;
                _maxId = items.Count;
            }
        }

        public void Create(GlossaryItem item)
        {
            _maxId++;
            item.Id = _maxId;
            _glossaryList.Add(item);
        }

        public void Delete(GlossaryItem item)
        {
            GlossaryItem target = _glossaryList.FirstOrDefault(t => t.Id == item.Id);
            _glossaryList.Remove(target);
        }

        public GlossaryItem Read(string term)
        {
            GlossaryItem target = _glossaryList.FirstOrDefault(t => t.Term == term);
            return target;
        }

        public GlossaryItem Read(int id)
        {
            GlossaryItem target = _glossaryList.FirstOrDefault(t => t.Id == id);
            return target;
        }

        public List<GlossaryItem> Read()
        {
            return _glossaryList;
        }

        public void Update(GlossaryItem item)
        {
            GlossaryItem target = _glossaryList.FirstOrDefault(t => t.Id == item.Id);
            target.Term = item.Term;
            target.Definition = item.Definition;
        }

    }
}
