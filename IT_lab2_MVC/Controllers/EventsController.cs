using MVC_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_Project.Controllers
{

    public class EventsController : Controller
    {

        private static List<EventModel> _events = new List<EventModel>();

        // GET: Default
        public ActionResult Index()
        {
            return View(_events);
        }



        public ActionResult Delete(EventModel e)
        {
            _events.Remove(e);
            return View(_events);
        }



        // GET: Default/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Default/Create
        [HttpPost]
        public ActionResult Create(EventModel e)
        {
            if (_events.Any())
            {
                int id = _events.Max(ev => ev.Id) + 1;
                e.Id = id;
            }
            else
            {
                e.Id = 1;
            }

            _events.Add(e);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(_events.FirstOrDefault(e => e.Id == id));
        }

        [HttpPost]
        public ActionResult Update(EventModel e)
        {


            var existingEvent = _events.FirstOrDefault(nastan => nastan.Id == e.Id);
            if (existingEvent != null)
            {
                existingEvent.Ime = e.Ime;
                existingEvent.Lokacija = e.Lokacija;
            }

            return RedirectToAction("Index");
        }

        // POST: Default/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                // TODO: Add delete logic here

                _events.Remove(_events.FirstOrDefault(e => e.Id == id));

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
