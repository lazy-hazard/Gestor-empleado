using System;

using System.Collections.Generic;

using System.Linq;

using System.Text;

using System.Threading.Tasks;


namespace casoemplea2

{

    internal class Program

    {

        static int max_empleados = 50;

        static string[] nombres_e = new string[max_empleados];

        static string[] correos = new string[max_empleados];

        static int puntero = 0;

        static string archivo;


        static public void Skip()

        {

            Console.WriteLine("******************************");

            Console.WriteLine("*****SISTEMA DE EMPLEADOS*****");

            Console.WriteLine("******************************");

        }

        static public void registro()

        {

            Console.WriteLine("/////////REGISTRO DE EMPLEADO: ////////\n");

            if (puntero >= max_empleados)

            {

                Console.WriteLine("Ya muchos ya"); return;

            }

            Console.WriteLine("Ingresa el nombre del empleado: ");

            string nombre = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(nombre))

            {

                Console.WriteLine("El nombre no puede estar vacio"); return;

            }

            string nombre_m = nombre.ToUpper();

            string[] partes = nombre_m.Split(' ');

            string primername, apellido;

            int c = 0;

            if (partes.Length > 0)

            {

                primername = partes[c];

                apellido = partes[c + 1];

            }

            else

            {

                primername = "User";

                apellido = "name";

            }

            string correo = $"{primername.ToLower()}{apellido.ToLower()}@upn.edu.pe";

            nombres_e[puntero] = nombre_m;

            correos[puntero] = correo;

            puntero++;

        }

        static public void busqueda()

        {

            Console.WriteLine("/////////BUSQUEDA DE EMPLEADO: ////////\n");

            if (puntero == 0)

            {

                Console.WriteLine("No hay gente"); return;

            }

            Console.Write("Ingresa el nombre a buscar: ");

            string buscar = Console.ReadLine().Trim().ToUpper();

            if (string.IsNullOrEmpty(buscar))

            {

                Console.WriteLine("El nombre no puede estar vacio"); return;

            }

            bool encontrado = false;

            for (int i = 0; i < puntero; i++)

            {

                if (nombres_e[i].Contains(buscar))

                {

                    Console.WriteLine($"Nombre: {nombres_e[i]}, Correo: {correos[i]}");

                    encontrado = true;

                }

            }

            if (!encontrado)

            {

                Console.WriteLine("No se encontró el empleado");

            }

        }

        static public void orden()

        {

            if (puntero <= 1)

            {

                Console.WriteLine("No hay gente"); return;

            }

            for (int i = 0; i < puntero - 1; i++)

            {

                for (int j = 0; j < puntero - 1 - i; j++)

                {

                    if (string.Compare(nombres_e[j], nombres_e[j + 1]) > 0)

                    {

                        string auxnom = nombres_e[j];

                        nombres_e[j] = nombres_e[j + 1];

                        nombres_e[j + 1] = auxnom;

                        string auxcor = correos[j];

                        correos[j] = correos[j + 1];

                        correos[j + 1] = auxcor;

                    }

                }

            }

        }

        static public void mostrar()

        {

            Console.WriteLine("/////////LISTA DE EMPLEADOS: ////////\n");

            if (puntero == 0)

            {

                Console.WriteLine("No hay gente"); return;

            }

            for (int i = 0; i < puntero; i++)

            {

                Console.WriteLine($"Nombre: {nombres_e[i]}, Correo: {correos[i]}");

            }

        }


        static public void Wardar()

        {

            Console.WriteLine("/////////GUARDAR EN ARCHIVO: ////////\n");

            if (puntero == 0)

            {

                Console.WriteLine("No hay gente"); return;

            }

            Console.WriteLine("Ingresa el nombre del archivo para guardar la informacion");

            archivo = Console.ReadLine().Trim();

            using (System.IO.StreamWriter file = new System.IO.StreamWriter($"{archivo}.txt"))

            {

                for (int i = 0; i < puntero; i++)

                {

                    file.WriteLine($"{nombres_e[i]},{correos[i]}");

                }

            }

            Console.WriteLine($"Datos guardados en {archivo}.txt");

        }

        static public void Load()

        {

            Console.WriteLine("/////////CARGAR DESDE ARCHIVO: ////////\n");

            Console.WriteLine("Ingresa el nombre del archivo para cargar la informacion");

            archivo = Console.ReadLine().Trim();

            if (!System.IO.File.Exists($"{archivo}.txt"))

            {

                Console.WriteLine("El archivo no existe"); return;

            }

            using (System.IO.StreamReader lector = new System.IO.StreamReader($"{archivo}.txt"))

            {

                string linea;

                while ((linea = lector.ReadLine()) != null)

                {

                    string[] partes = linea.Split(',');

                    if (partes.Length == 2)

                    {

                        nombres_e[puntero] = partes[0];

                        correos[puntero] = partes[1];

                        puntero++;

                    }

                }

            }

        }

        static void Read()

        {

            Console.WriteLine("/////////LEER DESDE ARCHIVO: ////////\n");

            Console.WriteLine("Ingresa el nombre del archivo para leer la informacion");

            archivo = Console.ReadLine().Trim();

            if (!System.IO.File.Exists($"{archivo}.txt"))

            {

                Console.WriteLine("El archivo no existe"); return;

            }

            string[] lineas = System.IO.File.ReadAllLines($"{archivo}.txt");

            puntero = 0;

            for (int i = 0; i < lineas.Length && i < max_empleados; i++)

            {

                string[] partes = lineas[i].Split(',');

                if (partes.Length == 2)

                {

                    nombres_e[puntero] = partes[0];

                    correos[puntero] = partes[1];

                    puntero++;

                }

            }

        }

        static void Main(string[] args)

        {


            int opc = 0;

            bool f = true;

            while (f == true)

            {

                Console.Clear();

                Skip();

                Console.WriteLine("1. Registrar empleado");

                Console.WriteLine("2. Buscar empleado");

                Console.WriteLine("3. Ordenar empleados");

                Console.WriteLine("4. Mostrar empleados");

                Console.WriteLine("5. Guardar en archivo");

                Console.WriteLine("6. Cargar desde archivo");

                Console.WriteLine("7. Leer desde archivo");

                Console.WriteLine("8. Salir");

                Console.Write("Ingresa una opcion: "); opc = int.Parse(Console.ReadLine());

                switch (opc)

                {

                    case 1:

                        registro();

                        break;

                    case 2:

                        busqueda();

                        break;

                    case 3:

                        orden();

                        break;

                    case 4:

                        mostrar();

                        break;

                    case 5:

                        Wardar();

                        break;

                    case 6:

                        Load();

                        break;

                    case 7:

                        Read();

                        break;

                    case 8:

                        f = false;

                        break;

                    default:

                        Console.WriteLine("Opcion invalida");

                        break;

                }

                Console.ReadKey();

            }

            Console.WriteLine("Gracias por usar el sistema\tPresiona cualquier tecla para salir."); Console.ReadKey();


        }

    }

}