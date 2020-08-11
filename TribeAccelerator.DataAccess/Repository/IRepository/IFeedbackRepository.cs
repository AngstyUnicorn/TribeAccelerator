using System;
using System.Collections.Generic;
using System.Text;
using TribeAccelerator.DataAccess.Repository.IRepository;
using TribeAccelerator.Models;

namespace TribeAccelerator.DataAccess.Repository
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        void Update(Feedback feedback);
    }
}
