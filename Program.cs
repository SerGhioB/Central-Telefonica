using System;
using System.Collections.Generic;
using CentralTelefonica.Entidades;
using CentralTelefonica.App;
using CentralTelefonica.Util;

namespace CentralTelefonica
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            MenuPrincipal menu = new MenuPrincipal();
           menu.MostrarMenu();
             */
             DateTime fecha = DateTime.Now;
           
           Console.WriteLine ($"Dia: {fecha.DayOfWeek}");
           Console.WriteLine (fecha.Hour);
           Console.WriteLine (fecha.Minute);
           Console.WriteLine (fecha.Millisecond/1000);

           
        }
    }
}
