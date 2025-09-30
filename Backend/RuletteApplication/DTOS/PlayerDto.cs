using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RuletteApplication.DTOS;
public record PlayerDto
{
    [Required]
    public string Name { get; set; } = string.Empty;
    [Required]
    public decimal Amount { get; set; }

    public PlayerDto(string name, decimal amount)
    {
        Name = name;
        Amount = amount;
    }
};
