using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuletteApplication.DTOS
{
    public class BetRequestDto
    {
        public double Amount { get; set; }
        public double Bet { get; set; }
        public string ColorSelected { get; set; } = string.Empty;
        public string ColorRoulette { get; set; } = string.Empty;
    }
}
