using BackEnd_Itika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd_Itika.Data
{
    public interface IHoraExtra
    {
        List<HoraExtra> ListarHoraExtra();
        HoraExtra Add_HoraExtra(HoraExtra hora);
        HoraExtra Delete_HoraExtra(HoraExtra hora);
        HoraExtra Update_HoraExtra(HoraExtra hora);
        HoraExtra Get_HoraExtra(int Id);
    }
}
