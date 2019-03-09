using System;
using static System.Console;
using CentralTelefonica.Entidades;
using System.Collections.Generic;
using CentralTelefonica.Util;

namespace CentralTelefonica.App
{
    public class MenuPrincipal
    {
        private const float precioUnoDepartamental = 0.65f;
        private const float precioDosDepartamental = 8.85f;
        private const float precioTresDepartamental = 0.98f;
        private const float precioLocal = 0.49f;
        public List<Llamada> ListaLlamadas { get; set; }

        public MenuPrincipal()
        {
            this.ListaLlamadas = new List<Llamada>();
        }

        public void MostrarMenu()
        {
            var opcion = 100;
            do
            {
                try
                {

                    Console.WriteLine("1. registrar llamada Local");
                    Console.WriteLine("2. registrar llamada departamental");
                    Console.WriteLine("3. Costo total de las llamadas Locales");
                    Console.WriteLine("4. Costo total de las llamadas departamental");
                    Console.WriteLine("5. Costo total de las llamadas");
                    Console.WriteLine("6 Mostrar detalle");
                    Console.WriteLine("0 Salir");
                    Console.WriteLine("Ingrese su opcion");
                    string valor = Console.ReadLine();
                    opcion = Convert.ToInt16(valor);
                    if (opcion == 1)
                    {
                        RegistrarLlamda(opcion);
                    }
                    if (opcion == 2)
                    {
                        RegistrarLlamda(opcion);
                    }
                    else if (opcion == 6)
                    {
                        MostrarDetalleForEach();
                    }
                }
                catch (Exception e)
                {
                    throw new OpcionMenuException();
                }

            } while (opcion != 0);


        }

        public void RegistrarLlamda(int opcion)/*metodo */
        {
            string numeroOrigen = "";
            string numeroDestino = "";
            string duracion = "";
            Llamada llamada = null;
            WriteLine("Ingrese el numero de origen:");
            numeroOrigen = ReadLine();
            WriteLine("Ingrese el numero de destino:");
            numeroDestino = ReadLine();
            WriteLine("Duracion de llamda:");
            duracion = ReadLine();
            if (opcion == 1)
            {
                llamada = new LlamadaLocal(numeroOrigen, numeroDestino, Convert.ToDouble(duracion));
                ((LlamadaLocal)llamada).Precio = precioLocal;
            }
            else if (opcion == 2)
            {
                llamada = new LlamadaDepartamental(numeroOrigen, numeroDestino, Convert.ToDouble(duracion));

                llamada.NumeroDestino = numeroDestino;
                llamada.NumeroOrigen = numeroOrigen;
                llamada.Duracion = Convert.ToDouble(duracion);
                ((LlamadaDepartamental)llamada).PrecioUno = precioUnoDepartamental;
                ((LlamadaDepartamental)llamada).PrecioDos = precioDosDepartamental;
                ((LlamadaDepartamental)llamada).PrecioTres = precioTresDepartamental;
                ((LlamadaDepartamental)llamada).Franja = 0;
            }
            else
            {
                WriteLine("Tipo de llamada no resgistrada");
            }
            this.ListaLlamadas.Add(llamada);

        }

        public void MostrarDetalleWhile()
        {
            int i = 0;
            while (this.ListaLlamadas.Count > i)
            {
                WriteLine(this.ListaLlamadas[i]);
                i++;
            }
        }
        public void MostrarDetalleDoWhile()
        {
            int i = 0;
            do
            {
                WriteLine(this.ListaLlamadas[i]);
                i++;
            }
            while (this.ListaLlamadas.Count > i);
        }
        public void MostrarDetalleFor()
        {
            for (int i = 0; i < this.ListaLlamadas.Count; i++)
            {
                WriteLine(this.ListaLlamadas[i]);
            }
        }

        public void MostrarDetalleForEach()
        {
            foreach (var llamada in ListaLlamadas)
            {
                WriteLine(llamada);
            }
        }

    }



}