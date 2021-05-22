using System;
using System.Collections.Generic;
using System.Text;

namespace Avansight.Domain.Repository
{
    public interface IUnitOfWork
    {
        IPatientRepository Patient { get; }
    }
}
