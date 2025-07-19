using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Task.Models;

namespace Task.DAOs
{
    public interface IOfficeDAO
    {
        public IEnumerable<Office> GetAllOffices();
        public Office? GetOfficeById(Guid id);
    }
}