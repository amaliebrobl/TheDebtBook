using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TheDebtBook.Models
{
    public class Values
    {
        [PrimaryKey, AutoIncrement]
        public int ValueId { get; set; }
        public int Value { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }

    }
}
