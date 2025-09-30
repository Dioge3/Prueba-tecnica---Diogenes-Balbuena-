using Microsoft.EntityFrameworkCore;
using RuletteCore.Entities;
using RuletteCore.Interfaces;
using RuletteInfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuletteInfrastructure.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly RouletteContext _context;

        public PlayerRepository(RouletteContext context)
        {
            _context = context;
        }

        public async Task Add(Player newPlayer)
        {
            _ = _context.Players.Add(newPlayer);
            await _context.SaveChangesAsync();
        }

        public async Task<Player?> GetByName(string name) => await _context.Players
            .FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

        public async Task Update(Player updatePlayer)
        {
            _ = _context.Players.Update(updatePlayer);
            await _context.SaveChangesAsync();
        }
    }
}
