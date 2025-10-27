using SupportFlow.Domain.Entities;
using SupportFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Application.DTOs.SuporteDTOs
{
    public class SuporteResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Status Status { get; set; }
        public DateTimeOffset? DataSuporte { get; set; }
        public int UsuarioID { get; set; }
        public string? NomeUsuario { get; set; }
    }
}
