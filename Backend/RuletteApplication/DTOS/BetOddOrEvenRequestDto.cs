using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuletteApplication.DTOS
{
    public class BetOddOrEvenRequestDto : BetRequestDto
    {
        public int NumberRoulette { get; set; }
        public bool IsOdd { get; set; }
    }
}
