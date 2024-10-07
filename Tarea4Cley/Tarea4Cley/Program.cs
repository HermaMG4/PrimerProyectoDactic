using System;
namespace Tarea4Cley
{
    // Crear clase Vehiculo con propiedades modelo y precio
    public class Vehiculo
    {
        public int IDVehiculo;
        public string Modelo { get; set; }
        public float Precio { get; set; }

        public void SeleccionarVehiculo()
        {
            Recoleccion.Mensaje("\nSelecciona el vehiculo: ", ref IDVehiculo);
            this.IDVehiculo = IDVehiculo;
            this.Modelo = ListasModelosYPrecios.modelos[IDVehiculo - 1];
            this.Precio = ListasModelosYPrecios.precios[IDVehiculo - 1];
        }

        // Anadir clase dentro de Vehiculo, Descuento que gestione
        // descuentos segun promociones especiales
        public static class Descuento
        {
            public static int dias = 0;
            public static float descuentoFinal = 0;

            // Crear metodo estatico dentro de Descuento para aplicar
            // el descuento al precio del vehiculo
            public static void AplicarDescuento(Vehiculo vehiculo)
            {
                Recoleccion.Mensaje("\nIngrese el numero de dias: ", ref dias);
                if (dias >= 3)
                {
                    descuentoFinal = vehiculo.Precio * (50F / 100F);
                    Console.WriteLine("Has seleccionado: " + dias + " dias, se le aplicara un descuento total de: C$ " + descuentoFinal);
                }

                else
                {
                    descuentoFinal = 0;
                    Console.WriteLine("Has seleccionado: " + dias + " dias, no se le aplicara descuento");
                }
            }
        }

        // Implementar metodo de extencion para formatear y mostrar
        // la informacion del vehiculo

        public static void InfoVehiculo(Vehiculo vehiculo)
        {
            Console.WriteLine("Has seleccionado un modelo: " + vehiculo.Modelo + ", a un precio de: C$ " + vehiculo.Precio + " por dia");
        }
    }

    // Crear una clase estatica CalcularReserva para calcular
    // el valor total de la reserva
    public static class CalcularReserva
    {
        public static void valorTotalAPagar(Vehiculo vehiculo)
        {
            Console.WriteLine("\nEl valor total a pagar es de: C$ " + ((vehiculo.Precio * Vehiculo.Descuento.dias) - Vehiculo.Descuento.descuentoFinal));
        }
    }

    #region Clases y metodos adicionales

    public static class Recoleccion
    {
        public static void Mensaje(string mensaje, ref string guardar)
        {
            Console.Write(mensaje);
            guardar = Console.ReadLine();
        }

        public static void Mensaje(string mensaje, ref int guardar)
        {
            Console.Write(mensaje);
            guardar = Convert.ToInt32(Console.ReadLine());
        }
    }

    public static class Saludos
    {
        public static void darBienvenida()
        {
            Console.WriteLine("Bienvenido al Sistema de Reserva de Vehiculos\n");
            Console.WriteLine("SUPER PROMOCION: ¡Si alquilas 3 dias o mas,\ntienes el 50% de descuento en un dia!\n");
        }
        public static void darDespedida()
        {
            Console.WriteLine("\n¡Disfruta de tu alquiler! :D");
        }
    }

    public static class ListasModelosYPrecios
    {
        // Nombres de modelos
        public static string[] modelos = { "Toyota", "Hiundai", "Hilux", "Lambo", "Mustang", "Formula", "Ferrari" };

        // Precios por dia
        public static float[] precios = { 436, 656.5F, 690, 754.5F, 811, 834.5F, 928 };

        public static string ModelosYPrecios = String.Empty;

        public static void listarModelosYPrecios()
        {
            Console.WriteLine("ID| Modelo\t| Precio por dia");
            Console.WriteLine("--------------------------------");
            for (int i = 0; i < 7; i++)
            {
                ModelosYPrecios += i + 1 + " | " + modelos[i] + "\t| C$ " + precios[i] + "\n";
            }

            Console.Write(ModelosYPrecios);
        }
    }

    #endregion
    class Program
    {
        public static void Main(string[] args)
        {
            Saludos.darBienvenida();

            // Mostramos lista de modelos y precios de vehiculos
            ListasModelosYPrecios.listarModelosYPrecios();

            // Instanciamos un vehiculo
            Vehiculo nuevoVehiculo = new Vehiculo();

            // Seleccionamos el vehiculo
            nuevoVehiculo.SeleccionarVehiculo();

            // Mostramos informaicion del vehiculo
            Vehiculo.InfoVehiculo(nuevoVehiculo);

            // Aplicamos un descuento segun numero de dias
            Vehiculo.Descuento.AplicarDescuento(nuevoVehiculo);

            // Calculamos el valor total de la reserva y aplicamos descuento si hubo
            CalcularReserva.valorTotalAPagar(nuevoVehiculo);

            Saludos.darDespedida();

            Console.ReadKey();
        }
    }
}
