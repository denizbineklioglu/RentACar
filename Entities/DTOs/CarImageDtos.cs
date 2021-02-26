using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class CarImageDtos:IDto
    {
        public int CarImageID { get; set; }
        public string CarName { get; set; }
        public string ImagePath { get; set; }
    }
}
