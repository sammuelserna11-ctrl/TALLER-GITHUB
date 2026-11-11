using System;
namespace TallerAlgoritmosModulares;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("     =======Taller de Algoritmos Modulares=======     ");


        Console.WriteLine(" 1. Control de turno para IPS");
        Console.WriteLine(" 2. Control academico (notas)");
        Console.WriteLine(" 3. Control de produccion de una fabrica de empaques");
        Console.WriteLine(" 0. Salir");

        int opcion;

        do
        {
            Console.WriteLine("Ingrese una opcion: ");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    ControlTurno();
                    break;
                    // case 2:
                    //     ControlAcademico();
                    //     break;
                    // case 3:
                    //     ControlProduccion.Ejecutar();
                    //     break;
                    // case 0:
                    //     Console.WriteLine("Saliendo del programa...");
                    //     break;
                    // default:
                    //     Console.WriteLine("Opcion invalida. Intente nuevamente.");
                    //     break;
            }
        } while (opcion != 0);
    }

    public static void ControlTurno()

    {

        Console.WriteLine("     =======Control de Turno para IPS=======     ");


        const int maximoPacientes = 30;
        const int prioridadMinima = 1;
        const int prioridadMaxima = 5;
        const int cantidadTipos = 3;
        const int cantidadDatos = 5;


        int totalPacientes = 0;
        // 0 = nombres, 1 = documentos, 2 = edades, 3 = prioridades, 4 = tipos 
        object[,] pacientes = new object[maximoPacientes, cantidadDatos];


        static void RegistrarPaciente(object[,] pacientes, int totalPacientes)
        {

            Console.WriteLine("Ingrese el nombre del paciente: ");
            pacientes[totalPacientes, 0] = Console.ReadLine();

            Console.WriteLine("Ingrese el documento del paciente: ");
            pacientes[totalPacientes, 1] = Console.ReadLine();

            Console.WriteLine("Ingrese la edad del paciente: ");
            pacientes[totalPacientes, 2] = int.TryParse(Console.ReadLine(), out int edad) ? edad : 0;



            int tipos;

            do
            {
                Console.WriteLine("Ingrese el tipo de paciente (1-3): ");

                Console.WriteLine(" 1. Urgencias");
                Console.WriteLine(" 2. Consulta General");
                Console.WriteLine(" 3. Prioritaria");

                tipos = int.TryParse(Console.ReadLine(), out tipos) ? tipos : 0;


                switch (tipos)
                {
                    case 1:
                        pacientes[totalPacientes, 4] = "Urgencias";
                        break;
                    case 2:
                        pacientes[totalPacientes, 4] = "Consulta General";
                        break;
                    case 3:
                        pacientes[totalPacientes, 4] = "Prioritaria";
                        break;
                    default:
                        Console.WriteLine("Tipo de paciente no válido.");
                        break;
                }


            } while (tipos != 1 && tipos != 2 && tipos != 3);

            int prioridad;

            do
            {
                Console.WriteLine($"Ingrese la prioridad del paciente ({prioridadMinima}-{prioridadMaxima}): ");
                prioridad = int.TryParse(Console.ReadLine(), out prioridad) ? prioridad : 0;

                if (prioridad < prioridadMinima || prioridad > prioridadMaxima)
                {
                    Console.WriteLine("Prioridad no válida. Intente nuevamente.");
                }
            } while (prioridad < prioridadMinima || prioridad > prioridadMaxima);

            pacientes[totalPacientes, 3] = prioridad;

            totalPacientes++;
            Console.WriteLine("Paciente registrado correctamente.");
        }
    }
}