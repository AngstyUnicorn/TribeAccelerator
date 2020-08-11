using System;
using System.Collections.Generic;
using System.Text;

namespace TribeAccelerator.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
       
        IFeedbackRepository Feedback { get; }       
        IEventRepository Events { get; }

        void Save();
    }
}
