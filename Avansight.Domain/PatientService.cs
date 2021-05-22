using Avansight.Domain.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace Avansight.Domain
{
    public class PatientService : IPatientRepository
    {
        private readonly IDapper _dapper;

        public PatientService(IDapper dapper)
        {
            _dapper = dapper;
        }

        public async Task<int> AddAsync(Patient patient)
        {
            var dbParams = new DynamicParameters();
            dbParams.Add("Age", patient.Age, DbType.Int32);
            dbParams.Add("Gender", patient.Gender, DbType.String);
            var result = await Task.FromResult(_dapper.Insert<int>("PatientSet", dbParams, CommandType.StoredProcedure));

            return result;
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Patient>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Patient> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Patient entity)
        {
            throw new NotImplementedException();
        }
    }
}
