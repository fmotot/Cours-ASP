using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.Models;
using TP1_Module05.DAO;

namespace TP1_Module05.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            List<Chat> chats = FakeDb.Instance.Chats;

            return View(chats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            return View(FakeDb.Instance.Chats.Where(c => c.Id == id).FirstOrDefault());
        }

        // GET: Chat/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Chat/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chat/Edit/5
        public ActionResult Edit(int id)
        {
            return View(FakeDb.Instance.Chats.Where(c => c.Id == id).FirstOrDefault());
        }

        // POST: Chat/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            return View(FakeDb.Instance.Chats.Where(c => c.Id == id).FirstOrDefault());
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                FakeDb.Instance.Chats.Remove(FakeDb.Instance.Chats.Where(c => c.Id == id).FirstOrDefault());

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
