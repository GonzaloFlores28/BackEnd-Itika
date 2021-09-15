using BackEnd_Itika.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Data.LogearUsario
{
    public interface ILogearUsuario
    {
        UsuarioInfo AutenticarUsuario(string usuario, string password);

    }
}
