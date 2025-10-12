using SupportFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Domain.Entities
{
    public class Suporte
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public Status Status { get; set; } 
        public DateTimeOffset? DataSuporte {  get; set; } = DateTimeOffset.UtcNow;
        public int? UsuarioID { get; set; }
        public virtual Usuario? Usuario { get; set; }
    }
}
