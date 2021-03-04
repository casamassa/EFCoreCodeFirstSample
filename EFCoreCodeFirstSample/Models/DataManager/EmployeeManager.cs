using EFCoreCodeFirstSample.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Models.DataManager
{
    public class EmployeeManager : IDataRepository<Employee>
    {
        readonly RepositoryContext _repositoryContext;

        public EmployeeManager(RepositoryContext context)
        {
            _repositoryContext = context;
        }

        public void Add(Employee entity)
        {
            _repositoryContext.Employees.Add(entity);
            _repositoryContext.SaveChanges();
        }

        public void Delete(Employee entity)
        {
            _repositoryContext.Employees.Remove(entity);
            _repositoryContext.SaveChanges();
        }

        public Employee Get(long id)
        {
            return _repositoryContext.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _repositoryContext.Employees.ToList();
        }

        public void Update(Employee dbEntity, Employee entity)
        {
            dbEntity.FirstName = entity.FirstName;
            dbEntity.LastName = entity.LastName;
            dbEntity.Email = entity.Email;
            dbEntity.DateOfBirth = entity.DateOfBirth;
            dbEntity.PhoneNumber = entity.PhoneNumber;

            _repositoryContext.SaveChanges();
        }
    }
}
