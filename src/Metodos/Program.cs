using System;
namespace TallerAlgoritmosModulares;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("     =======Taller de Algoritmos Modulares=======     ");


        Console.WriteLine(" 1. Control de turno para IPS");
        Console.WriteLine(" 2. Control inventario de una cafeteria universitaria");
        Console.WriteLine(" 3. Sistema de notas de estudiantes");
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
                case 2:
                    ControlInventario();
                    break;
                case 3:
                    Sistemadenotas();
                    break;
                case 0:
                    Console.WriteLine("Saliendo del programa...");
                    break;
                default:
                    Console.WriteLine("Opcion invalida. Intente nuevamente.");
                    break;
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


    const int MAX_PRODUCTOS = 20;
    const int MAX_VENTAS = 200;

    static string[] codigos = new string[MAX_PRODUCTOS];
    static string[] nombres = new string[MAX_PRODUCTOS];
    static double[] precios = new double[MAX_PRODUCTOS];
    static int[] cantidades = new int[MAX_PRODUCTOS];
    static string[] categorias = new string[MAX_PRODUCTOS];
    static int totalProductos = 0;

    static double[,] ventas = new double[MAX_VENTAS, 3];
    static int totalVentas = 0;

    static string[] CATEGORIAS = { "Bebidas", "Panadería", "Snacks" };

    public static void ControlInventario()
    {
        int opcion = -1;
        while (opcion != 0)
        {
            MostrarMenuInventario();
            opcion = LeerEntero("Seleccione una opción: ", 0);

            if (opcion == 1) RegistrarProducto();
            else if (opcion == 2) RealizarVenta();
            else if (opcion == 3) ActualizarInventario();
            else if (opcion == 4) MostrarInventario();
            else if (opcion == 5) MostrarAgotados();
            else if (opcion == 6) MostrarVentasDia();
            else if (opcion == 0) Console.WriteLine("Volviendo al menú principal...");
            else Console.WriteLine("[!] Opción inválida.");

            if (opcion != 0)
            {
                Console.WriteLine("\nPresione Enter para continuar...");
                Console.ReadLine();
            }
        }
    }

    static void MostrarMenuInventario()
    {
        Console.WriteLine("\n===== CAFETERÍA UNIVERSITARIA =====");
        Console.WriteLine("1. Registrar producto");
        Console.WriteLine("2. Realizar venta");
        Console.WriteLine("3. Actualizar inventario");
        Console.WriteLine("4. Mostrar inventario");
        Console.WriteLine("5. Mostrar productos agotados");
        Console.WriteLine("6. Total vendido del día");
        Console.WriteLine("0. Volver al menú principal");
    }

    static void RegistrarProducto()
    {
        Console.WriteLine("\n--- REGISTRAR PRODUCTO ---");
        if (totalProductos >= MAX_PRODUCTOS)
        {
            Console.WriteLine("[!] Inventario lleno (máximo " + MAX_PRODUCTOS + " productos).");
            return;
        }

        string codigo = LeerTexto("Código: ").ToUpper();
        if (BuscarIndice(codigo) != -1)
        {
            Console.WriteLine("[!] Ya existe un producto con ese código.");
            return;
        }

        string nombre = LeerTexto("Nombre: ");
        double precio = LeerDecimal("Precio unitario: ");
        int cantidad = LeerEntero("Cantidad disponible: ", 0);
        string categoria = LeerCategoria();

        codigos[totalProductos] = codigo;
        nombres[totalProductos] = nombre;
        precios[totalProductos] = precio;
        cantidades[totalProductos] = cantidad;
        categorias[totalProductos] = categoria;
        totalProductos++;

        Console.WriteLine("[OK] Producto '" + nombre + "' registrado.");
    }

    static void MostrarInventario()
    {
        Console.WriteLine("\n--- INVENTARIO ---");
        if (totalProductos == 0)
        {
            Console.WriteLine("No hay productos registrados.");
            return;
        }
        Console.WriteLine("{0,-8}{1,-20}{2,10}{3,8}  {4}", "Código", "Nombre", "Precio", "Stock", "Categoría");
        Console.WriteLine(new string('-', 60));
        for (int i = 0; i < totalProductos; i++)
        {
            Console.WriteLine("{0,-8}{1,-20}{2,10:F2}{3,8}  {4}",
                codigos[i], nombres[i], precios[i], cantidades[i], categorias[i]);
        }
    }

    static void RealizarVenta()
    {
        Console.WriteLine("\n--- REALIZAR VENTA ---");
        if (totalProductos == 0)
        {
            Console.WriteLine("[!] No hay productos registrados.");
            return;
        }
        if (totalVentas >= MAX_VENTAS)
        {
            Console.WriteLine("[!] Se alcanzó el máximo de ventas del día.");
            return;
        }

        string codigo = LeerTexto("Código del producto: ").ToUpper();
        int pos = BuscarIndice(codigo);
        if (pos == -1)
        {
            Console.WriteLine("[!] Producto no encontrado.");
            return;
        }

        if (cantidades[pos] == 0)
        {
            Console.WriteLine("[!] '" + nombres[pos] + "' está AGOTADO. Venta cancelada.");
            return;
        }

        Console.WriteLine("Producto: " + nombres[pos] + " | Precio: " + precios[pos].ToString("F2")
            + " | Stock: " + cantidades[pos]);
        int cantidad = LeerEntero("Cantidad a vender: ", 1);

        if (cantidad > cantidades[pos])
        {
            Console.WriteLine("[!] Stock insuficiente. Solo hay " + cantidades[pos] + " unidades.");
            return;
        }

        double subtotal = cantidad * precios[pos];
        cantidades[pos] = cantidades[pos] - cantidad;

        ventas[totalVentas, 0] = pos;
        ventas[totalVentas, 1] = cantidad;
        ventas[totalVentas, 2] = subtotal;
        totalVentas++;

        Console.WriteLine("[OK] Venta registrada. Subtotal: $" + subtotal.ToString("F2"));
        if (cantidades[pos] == 0)
        {
            Console.WriteLine("[AVISO] '" + nombres[pos] + "' quedó agotado.");
        }
    }

    static void ActualizarInventario()
    {
        Console.WriteLine("\n--- ACTUALIZAR INVENTARIO ---");
        if (totalProductos == 0)
        {
            Console.WriteLine("[!] No hay productos registrados.");
            return;
        }

        string codigo = LeerTexto("Código del producto: ").ToUpper();
        int pos = BuscarIndice(codigo);
        if (pos == -1)
        {
            Console.WriteLine("[!] Producto no encontrado.");
            return;
        }

        Console.WriteLine("Producto: " + nombres[pos] + " | Stock actual: " + cantidades[pos]);
        Console.WriteLine("  1. Reabastecer (sumar unidades)");
        Console.WriteLine("  2. Ajustar stock (nuevo valor)");
        Console.WriteLine("  3. Cambiar precio");
        int opcion = LeerEntero("Opción: ", 1);

        if (opcion == 1)
        {
            int extra = LeerEntero("Unidades a agregar: ", 1);
            cantidades[pos] = cantidades[pos] + extra;
        }
        else if (opcion == 2)
        {
            cantidades[pos] = LeerEntero("Nuevo stock: ", 0);
        }
        else if (opcion == 3)
        {
            precios[pos] = LeerDecimal("Nuevo precio: ");
        }
        else
        {
            Console.WriteLine("[!] Opción inválida.");
            return;
        }
        Console.WriteLine("[OK] Actualizado. Stock: " + cantidades[pos] + " | Precio: " + precios[pos].ToString("F2"));
    }

    static void MostrarAgotados()
    {
        Console.WriteLine("\n--- PRODUCTOS AGOTADOS ---");
        int encontrados = 0;
        for (int i = 0; i < totalProductos; i++)
        {
            if (cantidades[i] == 0)
            {
                Console.WriteLine("  " + codigos[i] + " - " + nombres[i] + " (" + categorias[i] + ")");
                encontrados++;
            }
        }
        if (encontrados == 0)
        {
            Console.WriteLine("No hay productos agotados.");
        }
    }

    static double CalcularTotalDia()
    {
        double total = 0;
        for (int fila = 0; fila < totalVentas; fila++)
        {
            total = total + ventas[fila, 2];
        }
        return total;
    }

    static void MostrarVentasDia()
    {
        Console.WriteLine("\n--- VENTAS DEL DÍA ---");
        if (totalVentas == 0)
        {
            Console.WriteLine("Aún no hay ventas.");
        }
        else
        {
            Console.WriteLine("{0,-8}{1,-20}{2,6}{3,12}", "Código", "Producto", "Cant", "Subtotal");
            Console.WriteLine(new string('-', 46));
            for (int fila = 0; fila < totalVentas; fila++)
            {
                int pos = (int)ventas[fila, 0];
                Console.WriteLine("{0,-8}{1,-20}{2,6}{3,12:F2}",
                    codigos[pos], nombres[pos], (int)ventas[fila, 1], ventas[fila, 2]);
            }
        }
        Console.WriteLine("\nTOTAL VENDIDO DEL DÍA: $" + CalcularTotalDia().ToString("F2"));
    }

    static int BuscarIndice(string codigo)
    {
        for (int i = 0; i < totalProductos; i++)
        {
            if (codigos[i] == codigo)
            {
                return i;
            }
        }
        return -1;
    }

    static string LeerCategoria()
    {
        while (true)
        {
            Console.WriteLine("  Categorías:");
            for (int i = 0; i < CATEGORIAS.Length; i++)
            {
                Console.WriteLine("    " + (i + 1) + ". " + CATEGORIAS[i]);
            }
            int opcion = LeerEntero("  Elija categoría (número): ", 1);
            if (opcion <= CATEGORIAS.Length)
            {
                return CATEGORIAS[opcion - 1];
            }
            Console.WriteLine("  [!] Categoría inexistente.");
        }
    }

    // =====================================================
    // FUNCIONES DE LECTURA (las usan los dos casos)
    // =====================================================
    static int LeerEntero(string mensaje, int minimo)
    {
        while (true)
        {
            Console.Write(mensaje);
            string texto = Console.ReadLine();
            int valor;
            if (!int.TryParse(texto, out valor))
            {
                Console.WriteLine("  [!] Debe ingresar un número entero.");
            }
            else if (valor < minimo)
            {
                Console.WriteLine("  [!] El valor debe ser mayor o igual a " + minimo + ".");
            }
            else
            {
                return valor;
            }
        }
    }

    static double LeerDecimal(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string texto = Console.ReadLine();
            double valor;
            if (!double.TryParse(texto, out valor))
            {
                Console.WriteLine("  [!] Debe ingresar un número válido.");
            }
            else if (valor <= 0)
            {
                Console.WriteLine("  [!] El valor debe ser mayor que 0.");
            }
            else
            {
                return valor;
            }
        }
    }

    static string LeerTexto(string mensaje)
    {
        while (true)
        {
            Console.Write(mensaje);
            string texto = Console.ReadLine();
            if (texto != null && texto.Trim() != "")
            {
                return texto.Trim();
            }
            Console.WriteLine("  [!] El campo no puede estar vacío.");
        }
    }


    public static void Sistemadenotas()
    {

        Console.WriteLine("     =======Sistema de notas de estudiantes=======     ");


        string[] codigos = new string[25];
        string[] nombres = new string[25];
        double[,] notas = new double[25, 3];
        double[] asistencia = new double[25];
        double[] definitivas = new double[25];

        int cantidad;

        Console.WriteLine("Cantidad de estudiantes: ");
        cantidad = Convert.ToInt32(Console.ReadLine());

        while (cantidad < 1 || cantidad > 25)
        {
            Console.WriteLine("Ingrese una cantidad entre 1 y 25: ");
            cantidad = Convert.ToInt32(Console.ReadLine());
        }

        RegistrarEstudiantes(codigos, nombres, notas, asistencia, cantidad);

        CalcularDefinitivas(notas, definitivas, cantidad);

        MostrarResultados(codigos, nombres, definitivas, asistencia, cantidad);

        CalcularPromedio(definitivas, cantidad);

        MejorYPeor(nombres, definitivas, cantidad);

        Console.WriteLine("Fin del programa");
    }

    static void RegistrarEstudiantes(string[] codigos, string[] nombres, double[,] notas, double[] asistencia, int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            Console.WriteLine("ESTUDIANTE " + (i + 1));

            Console.WriteLine("Codigo: ");
            codigos[i] = Console.ReadLine();

            Console.WriteLine("Nombre: ");
            nombres[i] = Console.ReadLine();

            for (int j = 0; j < 3; j++)
            {
                Console.WriteLine("Nota parcial " + (j + 1) + ": ");
                notas[i, j] = Convert.ToDouble(Console.ReadLine());

                while (notas[i, j] < 0 || notas[i, j] > 5)
                {
                    Console.WriteLine("Ingrese una nota entre 0 y 5: ");
                    notas[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }

            Console.WriteLine("Asistencia: ");
            asistencia[i] = Convert.ToDouble(Console.ReadLine());

            while (asistencia[i] < 0 || asistencia[i] > 100)
            {
                Console.WriteLine("Ingrese un porcentaje entre 0 y 100: ");
                asistencia[i] = Convert.ToDouble(Console.ReadLine());
            }
        }
    }

    static void CalcularDefinitivas(double[,] notas, double[] definitivas, int cantidad)
    {
        double suma;

        for (int i = 0; i < cantidad; i++)
        {
            suma = 0;

            for (int j = 0; j < 3; j++)
            {
                suma = suma + notas[i, j];
            }

            definitivas[i] = suma / 3;
        }
    }

    static void DeterminarEstado(double definitiva, double asistencia)
    {
        if (asistencia < 80)
        {
            Console.WriteLine("Reprueba");
        }
        else if (definitiva >= 3)
        {
            Console.WriteLine("Aprobado");
        }
        else if (definitiva >= 2)
        {
            Console.WriteLine("Habilita");
        }
        else
        {
            Console.WriteLine("Reprueba");
        }
    }

    static void MostrarResultados(string[] codigos, string[] nombres, double[] definitivas, double[] asistencia, int cantidad)
    {
        for (int i = 0; i < cantidad; i++)
        {
            Console.WriteLine("Codigo: " + codigos[i]);
            Console.WriteLine("Nombre: " + nombres[i]);
            Console.WriteLine("Definitiva: " + definitivas[i].ToString("F2"));
            Console.WriteLine("Asistencia: " + asistencia[i] + "%");
            Console.WriteLine("Estado: ");

            DeterminarEstado(definitivas[i], asistencia[i]);
        }
    }

    static void CalcularPromedio(double[] definitivas, int cantidad)
    {
        double suma = 0;
        double promedio;

        for (int i = 0; i < cantidad; i++)
        {
            suma = suma + definitivas[i];
        }

        promedio = suma / cantidad;

        Console.WriteLine("Promedio general: " + promedio.ToString("F2"));
    }

    static void MejorYPeor(string[] nombres, double[] definitivas, int cantidad)
    {
        int mejor = 0;
        int peor = 0;

        for (int i = 1; i < cantidad; i++)
        {
            if (definitivas[i] > definitivas[mejor])
            {
                mejor = i;
            }

            if (definitivas[i] < definitivas[peor])
            {
                peor = i;
            }
        }

        Console.WriteLine("Mejor promedio: " + nombres[mejor] + " : " + definitivas[mejor]);
        Console.WriteLine("Peor promedio: " + nombres[peor] + " : " + definitivas[peor]);
    }
}