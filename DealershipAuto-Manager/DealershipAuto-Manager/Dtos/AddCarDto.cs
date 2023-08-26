﻿using DealershipAuto_Manager.Models;

namespace DealershipAuto_Manager.Dtos
{
    public class AddCarDto
    {
        public string Model { get; set; }
        public string Brand { get; set; }
        public int ProductionYear { get; set; }
        public Category Category { get; set; }
        public double Price { get; set; }
    }
}
