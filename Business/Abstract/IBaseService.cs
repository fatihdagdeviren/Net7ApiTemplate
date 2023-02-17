using Core.Entities;
using Entities.Dtos.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBaseService<T, C, U> where T : IDto
                                        where C : IDto
                                        where U : IDto
    {
        Task<T> Add(C zone);
        Task<bool> Delete(int id);
        Task Update(U zone);
        Task<List<T>> GetAll();
        Task<ZoneDto> GetById(int id);
    }
}
