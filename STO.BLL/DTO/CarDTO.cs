﻿using System;
using System.Collections.Generic;
using System.Text;

namespace STO.BLL.DTO
{
    public class CarDTO
    {
        public int Id { get; set; }
        public string Number { get; set; }

        //public int? TypeCarId { get; set; }
        public TypeCarDTO TypeCar { get; set; }
    }
}
