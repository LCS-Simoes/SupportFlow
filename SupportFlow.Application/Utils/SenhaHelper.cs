using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SupportFlow.Application.Utils
{
    public static class SenhaHelper
    {
        public static string GerarHash(string senha)
        {
            using var sha = SHA256.Create();
            var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(senha));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

        public static bool VerificarSenha(string senhaDigitada, string hashSalvo)
        {
            var hashDigitado = GerarHash(senhaDigitada);
            return hashDigitado == hashSalvo;
        }
    }
}
