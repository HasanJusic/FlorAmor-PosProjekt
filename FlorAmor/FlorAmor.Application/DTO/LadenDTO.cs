using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlorAmor.Application.DTO
{
    public class LadenDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Land { get; set; }
        public string Ort { get; set; }
        public int PLZ { get; set; }
    }
}
