using Data;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Logic : ILogic
    {
        IDataAccess _dataAccess;
        public Logic(IDataAccess dataAccess)//constructor 
        {
            _dataAccess = dataAccess;
        }

        public int Login(string user,string pass)//Metodo para logeo
        {
            return _dataAccess.Login(user, pass);
        }

        public List<Aula> GetAulas()//Metodo GetAulas
        {
            return _dataAccess.GetAulas();
        }
        public void InsertTreeyearInTableCalendario()//NOOOOOOOOOO UTILIZARRRRR
        {
            _dataAccess.InsertTreeyearInTableCalendario();
        }

        public List<int> GetAnio()
        {
            return _dataAccess.GetAnio();
        }

        public List<int> GetMes(int año)
        {
            return _dataAccess.GetMes(año);
        }

        public List<string> GetHorarios()
        {
            return _dataAccess.GetHorarios();
        }

        public List<string> GetDiasConNombre(int año, int mes)
        {
            return _dataAccess.GetDiasConNombre(año, mes);
        }

        public List<Reservacion> ObtenerReservaciones(string nombreAula, string año, string mes)
        {
            return _dataAccess.ObtenerReservaciones(nombreAula, año, mes);
        }
    }
}
