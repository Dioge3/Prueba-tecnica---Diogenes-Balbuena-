using RuletteCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RuletteCore.Interfaces
{
        public interface IPlayerRepository
        {
            Task Add(Player newPlayer);
            Task<Player?> GetByName(string name);
            Task Update(Player updatePlayer);
        }
}
