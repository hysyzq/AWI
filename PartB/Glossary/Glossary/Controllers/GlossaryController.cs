using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Glossary.Interfaces;
using Glossary.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Glossary.Controllers
{
    public class GlossaryController : Controller
    {
        IGlossaryRepository _repos;
        // Dependency Injection
        public GlossaryController(IGlossaryRepository repos)
        {
            _repos = repos;
        }

        // GET: Glossary
        public ActionResult Index(string sortby)
        {
            List<GlossaryItem> model;
            if (sortby== "Definition")
            {
                model =  _repos.Read().OrderBy(t=>t.Definition).ToList<GlossaryItem>();
            }
            else
            {
                model = _repos.Read();
            }
            
            return View(model);
        }

        // GET: Glossary/Details/5
        public ActionResult Details(int id)
        {
            GlossaryItem model = _repos.Read(id);
            return View(model);
        }

        // GET: Glossary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Glossary/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                GlossaryItem item = new GlossaryItem();
                item.Term = collection["Term"];
                item.Definition = collection["Definition"];
                _repos.Create(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Glossary/Edit/5
        public ActionResult Edit(int id)
        {
            GlossaryItem model = _repos.Read(id);
            return View(model);
        }

        // POST: Glossary/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                GlossaryItem item = new GlossaryItem();
                item.Id = id;
                item.Term = collection["Term"];
                item.Definition = collection["Definition"];
                _repos.Update(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Glossary/Delete/5
        public ActionResult Delete(int id)
        {
            GlossaryItem model = _repos.Read(id);
            return View(model);
        }

        // POST: Glossary/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                GlossaryItem item = new GlossaryItem();
                item.Id = id;
                _repos.Delete(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}