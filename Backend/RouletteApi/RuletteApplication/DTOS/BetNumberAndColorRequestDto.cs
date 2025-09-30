using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuletteApplication.DTOS
{
    public class BetNumberAndColorRequestDto : BetRequestDto
    {
        public double NumberSelected { get; set; }
        public double NumberRoulette { get; set; }
    }
}
