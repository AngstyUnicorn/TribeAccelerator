using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TribeAccelerator.DataAccess.Repository.IRepository;
using TribeAccelerator.Models;

namespace TribeAccelerator.Areas.Admin.Controllers
{
    [Area("Admin")]   
    public class EventController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Upsert(int? id)
        {
            Event events = new Event();
            if (id == null)
            {
                //this is for create
                return View(events);
            }
            //this is for edit
            events = _unitOfWork.Events.Get(id.GetValueOrDefault());
            if (events == null)
            {
                return NotFound();
            }
            return View(events);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Event events)
        {
            if (ModelState.IsValid)
            {
                if (events.Id == 0)
                {
                    _unitOfWork.Events.Add(events);

                }
                else
                {
                    _unitOfWork.Events.Update(events);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(events);
        }


        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj = _unitOfWork.Events.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Events.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Events.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
