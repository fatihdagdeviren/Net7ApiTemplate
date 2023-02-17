using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Zone
{
    public class CreateZoneDto: IDto
    {
        public string Name { get; set; }
    }
}
