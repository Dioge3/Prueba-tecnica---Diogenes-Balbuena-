using RuletteApplication.ApiResponses;
using RuletteApplication.DTOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuletteApplication.Interface
{
    public interface IPlayerService
    {
        Task<Result> Add(PlayerDto playerDto);
        Task<ResultT<PlayerDto>> GetByName(string name);
        Task<Result> Update(PlayerDto playerDto);
    }
}
