using SupportFlow.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Application.DTOs
{
    public class AtualizarSuporteRequest
    {
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public string? Status {  get; set; }
    }
}
