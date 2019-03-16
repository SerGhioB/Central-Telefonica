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
        private const float precioLocal = 1.25f;
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
                    if (EsNumero(valor) == true)
                    {
                        opcion = Convert.ToInt16(valor);
                    }
                    if (opcion == 1)
                    {
                        RegistrarLlamda(opcion);
                    }
                    else if (opcion == 2)
                    {
                        RegistrarLlamda(opcion);
                    }
                    else if (opcion == 3)
                    {
                        MostrarCostoLllamadaLocales();
                    }
                    else if (opcion == 4)
                    {
                        MostrarDetalleLlamadaDepto();
                    }
                    else if (opcion == 6)
                    {
                        MostrarDetalle();
                    }
                }
                catch (Exception)
                {
                    throw new OpcionMenuException();
                }

            } while (opcion != 0);


        }

        public Boolean EsNumero(string valor)
        {
            Boolean resultado = false;
            try
            {
                int numero = Convert.ToInt16(valor);
                resultado = true;
            }
            catch (Exception)
            {

                throw new OpcionMenuException();
            }
            return resultado;
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
                ((LlamadaDepartamental)llamada).Franja = calcularFranja(DateTime.Now);
            }
            else
            {
                WriteLine("Tipo de llamada no resgistrada");
            }
            this.ListaLlamadas.Add(llamada);

        }
        /* 
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

        */
        public void MostrarDetalle()/*ciclo por foreach */
        {
            foreach (var llamada in ListaLlamadas)
            {
                WriteLine(llamada);
            }
        }

        public void MostrarCostoLllamadaLocales()
        {

            double tiempoLlamada = 0;
            double costoTotal = 0.0;
            foreach (var elemento in ListaLlamadas)
            {
                if (elemento.GetType() == typeof(LlamadaLocal))
                {
                    tiempoLlamada = elemento.Duracion;
                    costoTotal += elemento.CalcularPrecio();
                }
            }
            WriteLine($"Costo minimo: {precioLocal}");
            WriteLine($"Tiempo total de llamada {tiempoLlamada}");
            WriteLine($"Costo total: {costoTotal}");

        }

        public void MostrarDetalleLlamadaDepto()
        {
            double tiempoLlamadaFranjaUno = 0;
            double tiempoLlamadaFranjaDos = 0;
            double tiempoLlamadaFranjaTres = 0;
            double costoTotalFranjaUno =  0.0;
            double costoTotalFranjaDos =  0.0;
            double costoTotalFranjaDTres =  0.0;
            foreach (var elemento in ListaLlamadas)
            {
                if (elemento.GetType() == typeof(LlamadaDepartamental))
                {
                    switch(((LlamadaDepartamental)elemento).Franja)
                    {
                        case 0:
                        tiempoLlamadaFranjaUno += elemento.Duracion;
                        costoTotalFranjaUno += elemento.CalcularPrecio();
                        break;
                        case 1:
                        tiempoLlamadaFranjaDos += elemento.Duracion;
                        costoTotalFranjaDos += elemento.CalcularPrecio();
                        break;
                        case 2:
                        tiempoLlamadaFranjaTres += elemento.Duracion;
                        costoTotalFranjaDTres += elemento.CalcularPrecio();
                        break;
                    }
                    
                }                
            }
            WriteLine("Franja 1.");
            WriteLine($"Costo minuto: {precioUnoDepartamental}");
            WriteLine($"Costo minimo: {costoTotalFranjaUno}");
            
            WriteLine("Franja 2.");
            WriteLine($"Costo minuto: {precioDosDepartamental}");
            WriteLine($"Costo minimo: {costoTotalFranjaDos}");
            
            WriteLine("Franja 3.");
            WriteLine($"Costo minuto: {precioTresDepartamental}");
            WriteLine($"Costo minimo: {costoTotalFranjaDTres}");
            
        }

        public int calcularFranja(DateTime fecha)
        {
            int resultado = -1;

            return resultado; // 0, 1, 2 (franja)
        }

    }

}