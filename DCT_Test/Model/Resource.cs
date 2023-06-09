﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCT_Test.Model
{
    public class Resource
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public double? PriceUsd { get; set; }

        public string Explore { get; set; }

        public double? Vwap { get; set; }

        public int Rank { get; set; }

        public string Symbol { get; set; }

        public string Feed { get; set; }

        public string MaxFeed { get; set; }

        public double? Capitalization { get; set; }

        public double? ChangePriceByDay { get; set; }

        public double? ChangePercentByDay { get; set; }
    }
}
