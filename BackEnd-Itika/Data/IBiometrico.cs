using BackEnd_Itika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Data
{
    public interface IBiometrico
    {
        List<Biometrico> GetBiometrico();
        Biometrico Add_Biometrico(Biometrico biometrico);
        Biometrico Get_Biometrico(int Id);
        //List<Biometrico> Listar();

        bool Add_RegistroBiometrico();


    }
}
