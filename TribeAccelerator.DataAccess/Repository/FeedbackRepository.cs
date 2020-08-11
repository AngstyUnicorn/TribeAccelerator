using TribeAccelerator.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using TribeAccelerator.DataAccess.Repository.IRepository;
using TribeAccelerator.Models;
using TribeAccelerator.DataAccess.Data;
using System.Linq;

namespace TribeAccelerator.DataAccess.Repository
{
    public class FeedbackRepository: Repository<Feedback>, IFeedbackRepository
    {
        private readonly ApplicationDbContext _db;

        public FeedbackRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Feedback feedback)
        {
            var objFromDb = _db.Feedbacks.FirstOrDefault(s => s.Id == feedback.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = feedback.Name;
                objFromDb.Email = feedback.Email;
                objFromDb.Description = feedback.Description;
                objFromDb.Date = feedback.Date;
                _db.SaveChanges();
            }
        }
       
    }
}
