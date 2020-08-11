using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TribeAccelerator.DataAccess.Data;
using TribeAccelerator.Models;

namespace TribeAccelerator.DataAccess.Repository.IRepository
{
    public class EventRepository: Repository<Event>, IEventRepository
    {
        private readonly ApplicationDbContext _db;

        public EventRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Event events)
        {
            var objFromDb = _db.Events.FirstOrDefault(s => s.Id == events.Id);
            if (objFromDb != null)
            {
                objFromDb.Name = events.Name;
                objFromDb.Date = events.Date;
                objFromDb.Description = events.Description;               
                _db.SaveChanges();
            }
        }
    }
}
