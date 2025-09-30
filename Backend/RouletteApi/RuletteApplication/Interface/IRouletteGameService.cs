using RuletteApplication.ApiResponses;
using RuletteApplication.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuletteApplication.Interface
{
    public interface IRouletteGameService
    {
        ResultT<RouletteDto> GetRoulette();
        ResultT<BetResultDto> BetColor(BetRequestDto betRequestDto);
        ResultT<BetResultDto> BetNumberAndColor(BetNumberAndColorRequestDto betNumerAndColorDto);
        ResultT<BetResultDto> BetOddOrEven(BetOddOrEvenRequestDto requestDto);
    }

}
