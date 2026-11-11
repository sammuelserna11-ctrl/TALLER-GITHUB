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

        int opciones;

        do
        {
            Console.WriteLine("Ingrese una opcion: ");
            opciones = int.Parse(Console.ReadLine());

            switch (opciones)
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
        } while (opciones != 0);
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




        int opciones;

        do
        {
            Console.WriteLine("\n ==== Menu IPS ==== ");
            Console.WriteLine(" Cupos disponibles: " + (maximoPacientes - totalPacientes));
            Console.WriteLine(" 1. Registrar paciente");
            Console.WriteLine(" 2. Listado general");
            Console.WriteLine(" 3. Buscar paciente por documento");
            Console.WriteLine(" 4. Pacientes por tipo de atencion");
            Console.WriteLine(" 5. Paciente con mayor prioridad");
            Console.WriteLine(" 0. Volver al menu principal");

            opciones = int.Parse(Console.ReadLine());

            switch (opciones)
            {
                case 1:
                    RegistrarPaciente(pacientes, ref totalPacientes, maximoPacientes, prioridadMinima, prioridadMaxima);
                    break;
                case 2:
                    ListadoGeneral(pacientes, totalPacientes);
                    break;
                case 3:
                    BuscarPacientePorDocumento(pacientes, totalPacientes);
                    break;
                case 4:
                    PacientesPorTipoAtencion(pacientes, totalPacientes);
                    break;
                case 5:
                    PacienteConMayorPrioridad(pacientes, totalPacientes);
                    break;
                case 0:
                    Console.WriteLine();
                    break;
                default:
                    Console.WriteLine("Opcion invalida. Intente nuevamente.");
                    Console.WriteLine();
                    break;

            }


        } while (opciones != 0);
    }
    public static void RegistrarPaciente(object[,] pacientes, ref int totalPacientes,
    int maximoPacientes, int prioridadMinima, int prioridadMaxima)


    {


        if (totalPacientes == maximoPacientes)
        {
            Console.WriteLine("No hay cupos disponibles.");
            return;
        }
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

    public static void ListadoGeneral(object[,] pacientes, int totalPacientes)
    {
        if (totalPacientes == 0)
        {
            Console.WriteLine("No hay pacientes registrados.");
            return;
        }
        Console.WriteLine("Listado de pacientes:");
        for (int i = 0; i < totalPacientes; i++)
        {
            Console.WriteLine($"Nombre: {pacientes[i, 0]}, Documento: {pacientes[i, 1]}, Edad: {pacientes[i, 2]}, Tipo: {pacientes[i, 4]}, Prioridad: {pacientes[i, 3]}");
        }
    }

    public static void BuscarPacientePorDocumento(object[,] pacientes, int totalPacientes)
    {
        if (totalPacientes == 0)
        {
            Console.WriteLine("No hay pacientes registrados.");
            return;
        }

        Console.WriteLine("Ingrese el documento del paciente a buscar: ");
        string documentoBuscado = Console.ReadLine();

        bool encontrado = false;

        for (int i = 0; i < totalPacientes; i++)
        {
            if (pacientes[i, 1].ToString() == documentoBuscado)
            {
                Console.WriteLine($"Paciente encontrado: Nombre: {pacientes[i, 0]}, Documento: {pacientes[i, 1]}, Edad: {pacientes[i, 2]}, Tipo: {pacientes[i, 4]}, Prioridad: {pacientes[i, 3]}");
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Paciente no encontrado.");
        }
    }

    public static void PacientesPorTipoAtencion(object[,] pacientes, int totalPacientes)


    {

        int contadorurgencias = 0;
        int contadorconsulta = 0;
        int contadorprioritaria = 0;

        if (totalPacientes == 0)
        {
            Console.WriteLine("No hay pacientes registrados.");
            return;
        }

        Console.WriteLine("Ingrese el tipo de paciente a buscar (1-3): ");
        Console.WriteLine(" 1. Urgencias");
        Console.WriteLine(" 2. Consulta General");
        Console.WriteLine(" 3. Prioritaria");

        int tipoBuscado = int.TryParse(Console.ReadLine(), out tipoBuscado) ? tipoBuscado : 0;
        string tipoString = tipoBuscado switch
        {
            1 => "Urgencias",
            2 => "Consulta General",
            3 => "Prioritaria",
            _ => null
        };

        if (tipoString == null)
        {
            Console.WriteLine("Tipo de paciente no válido.");
            return;
        }

        bool encontrado = false;

        for (int i = 0; i < totalPacientes; i++)
        {
            if (pacientes[i, 4].ToString() == "urgencias")
            {
                contadorurgencias++;
            }
            else if (pacientes[i, 4].ToString() == "consulta")
            {
                contadorconsulta++;
            }
            else if (pacientes[i, 4].ToString() == "prioritaria")
            {
                contadorprioritaria++;
            }

        }

        Console.WriteLine($"Cantidad de pacientes por tipo:");
        Console.WriteLine($"- Urgencias: {contadorurgencias}");
        Console.WriteLine($"- Consulta General: {contadorconsulta}");
        Console.WriteLine($"- Prioritaria: {contadorprioritaria}");

        if (!encontrado)
        {
            Console.WriteLine($"No hay pacientes registrados del tipo {tipoString}.");
        }
    }

    public static void PacienteConMayorPrioridad(object[,] pacientes, int totalPacientes)
    {
        if (totalPacientes == 0)
        {
            Console.WriteLine("No hay pacientes registrados.");
            return;
        }

        int indiceMayorPrioridad = 0;

        for (int i = 1; i < totalPacientes; i++)
        {
            if ((int)pacientes[i, 3] > (int)pacientes[indiceMayorPrioridad, 3])
            {
                indiceMayorPrioridad = i;
            }
        }

        Console.WriteLine($"Paciente con mayor prioridad: Nombre: {pacientes[indiceMayorPrioridad, 0]}, Documento: {pacientes[indiceMayorPrioridad, 1]}, Edad: {pacientes[indiceMayorPrioridad, 2]}, Tipo: {pacientes[indiceMayorPrioridad, 4]}, Prioridad: {pacientes[indiceMayorPrioridad, 3]}");
    }

}