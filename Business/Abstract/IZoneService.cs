﻿using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.Dtos.Zone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IZoneService : IBaseService<ZoneDto, CreateZoneDto, UpdateZoneDto>
    {
        //Task<Zone> Add(CreateZoneDto zone);
        //Task<bool> Delete(int id);
        //Task Update(UpdateZoneDto zone);
        //Task<List<ZoneDto>> GetAll();
        //Task<ZoneDto> GetById(int id);
        Task<bool> TestMethod();
    }
}
