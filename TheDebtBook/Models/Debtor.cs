using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheDebtBook.Models
{
    public class Debtor
    {
        [PrimaryKey, AutoIncrement] 
        public int Id { get; set; } = 0;
        public string Name { get; set; } = "";
        public double AccumulatedValues { get; set; } = 0;
    }
}
