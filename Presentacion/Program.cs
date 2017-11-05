using Negocio;
using Negocio.controladores;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    public class Program
    {
        static void Main(string[] args)
        {

            DatosUtils.inicializarDatos();

            int opcion = -1;
            while (opcion != 0)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkRed;

                Console.WriteLine("                                           `-+s:`                                         ");
                Console.WriteLine("                                        -ohNm+`                                          ");
                Console.WriteLine("                                     :smMMNo`                                              ");
                Console.WriteLine("                                  .omMMMMy.                                              ");
                Console.WriteLine("                                :yNMMMMMh:`                                               ");
                Console.WriteLine("                              `/dNMMMMMms/-..-::..-:/+osyyhhdddmmmNmdhso/-.               ");
                Console.WriteLine("                    .:+syyyo/+dMMMMMMMmyydmmNNNNNNNMMMMMMMMMMNmhyo/-``                    ");
                Console.WriteLine("                   .sddhhNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMmhs+:-.`                         ");
                Console.WriteLine("                   :-.```oMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNmmmmmdhyso/:.                   ");
                Console.WriteLine("                       `/mMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNs:..```                      ");
                Console.WriteLine("                     `/hNMmdhMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMms-                          ");
                Console.WriteLine("                 `-/ymNms:-+mMMMMMMMMMMNMMMMMMMMMMMMMMMMMMMMMMMMNs.                        ");
                Console.WriteLine("                /dNMMMh/:/dMMMMMMMMMMMMd+oydNMMMMMMMMMMMMMNyydNMMMm+`                      ");
                Console.WriteLine("            `./yNMMMMMMMMMMMMMMMMMmsNMN+s` `-/smMMMMMMMMMMMd.`./ymMMh.                     ");
                Console.WriteLine("        `-+ydNMMMMMMMMMMMMMMMMMMMN+ :dM:       `+mMMMMMMMMMMm.   .+dMm:                    ");
                Console.WriteLine("       -hNMMMMMMMMMMMMMMMMMMNNmds-   `y/         sMMMMMMMMMMMd.    `+dm:                   ");
                Console.WriteLine("       hMMMMMMMNmhyso+++///::-.`      ``      `-oNMMMMMMMMMMMMh`     `+d:                  ");
                Console.WriteLine("      hMMMMMMMNmhyso+++///::-.`      ``      `-oNMMMMMMMMMMMMh`     `+d:                  ");
                Console.WriteLine("      sNMMMMd+-`                       ``.-+sdNMMMMMMMMMMMMMMMo       `:`                 ");
                Console.WriteLine("       /ydh+`               ````..-:+oyhdNMMMMMMMMMMMMMMMMMMMMN-                          ");
                Console.WriteLine("                :ossssssyyhhhdmmNMMMMMMMMMMMMMMMMMMMMMMMMNMMMMMh                          ");
                Console.WriteLine("                 `/hNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNy/:dMMMMN-                         ");
                Console.WriteLine("                 `-+mMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNd+.   .dMMMM+                         ");
                Console.WriteLine("              `/ymMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNy:       /MMMMy                         ");
                Console.WriteLine("           `/hNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNh/`         `MMMMs                         ");
                Console.WriteLine("          -yNMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMNh+.            `NMMM+                         ");
                Console.WriteLine("        :hMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMMmy/`               `MMMm`                         ");
                Console.WriteLine("      .hMMMMMMMMMMMMMMMMMMdo:-.`:dMNmho/.                   .MMm-                          ");
                Console.WriteLine("     /NMMMMMMMMMMMMMMMMMy.    `:/:.`                                                       ");
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.WriteLine("---------------------------BIENVENIDO-----------------------------------------");
                Console.WriteLine("------------------------------------------------------------------------------");
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("0- SALIR");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("HABILIDADES ESPECIALES");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("1- CREAR  ");
                Console.WriteLine("2- MODIFICAR  ");
                Console.WriteLine("3- LISTAR  ");
                Console.WriteLine("4- ELIMINAR  ");
                Console.WriteLine("5- LISTAR POR CLASE  ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("CLASES");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("6- CREAR  ");
                Console.WriteLine("7- MODIFICAR  ");
                Console.WriteLine("8- LISTAR");
                Console.WriteLine("9- ELIMINAR");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("PERSONAJES");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("10- CREAR ");
                Console.WriteLine("11- MODIFICAR ");
                Console.WriteLine("12- LISTAR ");
                Console.WriteLine("13- ELIMINAR ");
                Console.WriteLine("14- LISTAR POR CLASE ");
                Console.WriteLine("15- LISTAR POR RAZA");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("RAZAS");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("16- CREAR ");
                Console.WriteLine("17- MODIFICAR ");
                Console.WriteLine("18- LISTAR");
                Console.WriteLine("19- ELIMINAR ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("CARACTERISTICAS");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("20- CREAR ");
                Console.WriteLine("21- MODIFICAR ");
                Console.WriteLine("22- LISTAR");
                Console.WriteLine("23- ELIMINAR ");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("NIVEL");
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("24- SUBIR NIVEL");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Ingrese la opción deseada:  ");
                opcion = InputUtils.leerInt();
                Console.Clear();
                switch (opcion)
                {
                    case 0:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("El programa ah finalizado");
                        break;
                    case 1:
                        HabilidadesEspecialesControlador.Crear();
                        break;
                    case 2:
                        HabilidadesEspecialesControlador.Modificar();
                        break;
                    case 3:
                        HabilidadesEspecialesControlador.Listar();
                        break;
                    case 4:
                        HabilidadesEspecialesControlador.Eliminar();
                        break;
                    case 5:
                        HabilidadesEspecialesControlador.ListarPorClase();
                        break;
                    case 6:
                        ClasesControlador.Crear();
                        break;
                    case 7:
                        ClasesControlador.Modificar();
                        break;
                    case 8:
                        ClasesControlador.Listar();
                        break;
                    case 9:
                        ClasesControlador.Eliminar();
                        break;
                    case 10:
                        PersonajeControlador.Crear();
                        break;
                    case 11:
                        PersonajeControlador.Modificar();
                        break;
                    case 12:
                        PersonajeControlador.Listar();
                        break;
                    case 13:
                        PersonajeControlador.Eliminar();
                        break;
                    case 14:
                        PersonajeControlador.ListarPorClase();
                        break;
                    case 15:
                        PersonajeControlador.ListarPorRaza();
                        break;
                    case 16:
                        RazaControlador.Crear();
                        break;
                    case 17:
                        RazaControlador.Modificar();
                        break;
                    case 18:
                        RazaControlador.Listar();
                        break;
                    case 19:
                        RazaControlador.Eliminar();
                        break;
                    case 20:
                        CaracteristicaVariableControlador.Crear();
                        break;
                    case 21:
                        CaracteristicaVariableControlador.Modificar();
                        break;
                    case 22:
                        CaracteristicaVariableControlador.Listar();
                        break;
                    case 23:
                        CaracteristicaVariableControlador.Eliminar();
                        break;
                    case 24:
                        PersonajeControlador.SubirNivel();
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("La opcion ingresada no es correcta");
                        break;
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }

        }
    }
}
