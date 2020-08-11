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
    public class FeedbackController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FeedbackController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Upsert(int? id)
        {
            Feedback feedback = new Feedback();
            if (id == null)
            {
                //this is for create
                return View(feedback);
            }
            //this is for edit
            feedback = _unitOfWork.Feedback.Get(id.GetValueOrDefault());
            if (feedback == null)
            {
                return NotFound();
            }
            return View(feedback);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                if (feedback.Id == 0)
                {
                    _unitOfWork.Feedback.Add(feedback);

                }
                else
                {
                    _unitOfWork.Feedback.Update(feedback);
                }
                _unitOfWork.Save();
                return RedirectToAction(nameof(Index));
            }
            return View(feedback);
        }


        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            var allObj= _unitOfWork.Feedback.GetAll();
            return Json(new { data = allObj });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objFromDb = _unitOfWork.Feedback.Get(id);
            if (objFromDb == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }
            _unitOfWork.Feedback.Remove(objFromDb);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successful" });

        }
        #endregion
    }
}
