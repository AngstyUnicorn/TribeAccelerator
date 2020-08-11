using TribeAccelerator.DataAccess.Data;
using TribeAccelerator.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Text;
using TribeAccelerator.DataAccess.Repository;

namespace TribeAccelerator.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;            
            Feedback = new FeedbackRepository(_db);
            Events = new EventRepository(_db);           
        }
      

        public IFeedbackRepository Feedback { get; private set; }
        public IEventRepository Events { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
