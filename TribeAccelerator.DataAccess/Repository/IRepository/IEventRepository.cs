using System;
using System.Collections.Generic;
using System.Text;
using TribeAccelerator.Models;

namespace TribeAccelerator.DataAccess.Repository.IRepository
{
    public interface IEventRepository:IRepository<Event>
    {
        void Update(Event feedback);
    }
}
