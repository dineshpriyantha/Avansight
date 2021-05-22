using Avansight.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Avansight.Domain
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IPatientRepository patientRepository)
        {
            Patient = patientRepository;
        }

        public IPatientRepository Patient { get; }
    }
}
