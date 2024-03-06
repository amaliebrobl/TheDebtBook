﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDebtBook.Models
{
    public class Debtor
    {
        [PrimaryKey]

        public string Name { get; set; }
        public double Value { get; set; }
        public DateTime Date { get; set; }
        public double AccumulatedValues { get; set; }
    }
}
