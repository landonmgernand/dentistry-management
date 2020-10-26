using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistryManagement.Server.Services
{
    public interface IService<T>
    {
        public List<T> GetAll();
    }
}
