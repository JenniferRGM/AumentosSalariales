using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AumentosSalariales
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variable para la continuacion del bucle
            bool continuar = true;

            //Variables para la estadistica
            int cuentaOperarios = 0, cuentaTecnicos = 0, cuentaProfesionales = 0;
            double acSalarioNetoOperarios = 0, acSalarioNetoTecnicos = 0,
                acSalarioNetoProf = 0;

            while (continuar)
            {
                //Datos que se solicitan para ingresar a los empleados
                Console.WriteLine("Por favor ingrese el número de cédula del empleado:");
                string numeroCedula = Console.ReadLine();

                Console.WriteLine("Por favor ingrese el nombre del empleado:");
                string nombre = Console.ReadLine();

                int tipoEmpleado;
                do
                {
                    //Ingresa el tipo de empleado, horas y precio para sacar el salario
                    Console.WriteLine("Ingrese el tipo de empleado (1. Operario, 2. Tecnico, 3. Profesional): ");
                } while (!int.TryParse(Console.ReadLine(), out tipoEmpleado) || tipoEmpleado < 1 || tipoEmpleado > 3);

                Console.WriteLine("Ingrese la cantidad de horas laboradas: ");
                double horasLaboradas = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Ingrese el precio por hora: ");
                double precioPorHora = Convert.ToDouble(Console.ReadLine());

                double salarioOrdinario = horasLaboradas * precioPorHora;
                double aumento = 0;

                //Calcula el aumento con el tipo de empleado
                switch (tipoEmpleado)
                {
                    case 1:
                        aumento = salarioOrdinario * 0.15;
                        break;
                    case 2:
                        aumento = salarioOrdinario * 0.10;
                        break;
                    case 3:
                        aumento = salarioOrdinario * 0.05;
                        break;
                }

                //Calcula el salario bruto y deducciones
                double salarioBruto = salarioOrdinario + aumento;
                double deduccionCCSS = salarioBruto * 0.0917;
                double salarioNeto = salarioBruto - deduccionCCSS;

                //Acumula estadisticas segun el tipo de empleado
                switch (tipoEmpleado)
                {
                    case 1:
                        cuentaOperarios++;
                        acSalarioNetoOperarios += salarioNeto;
                        break;
                    case 2:
                        cuentaTecnicos++;
                        acSalarioNetoTecnicos += salarioNeto;
                        break;
                    case 3:
                        cuentaProfesionales++;
                        acSalarioNetoProf += salarioNeto;
                        break;
                }

                //Muestra los datos y calculos
                Console.WriteLine("-----------------------------------");
                Console.WriteLine($"Número de cédula: {numeroCedula}");
                Console.WriteLine($"Nombre empleado: {nombre}");
                Console.WriteLine($"Tipo de empleado: {tipoEmpleado}");
                Console.WriteLine($"Horas laboradas: {horasLaboradas}");
                Console.WriteLine($"Salario ordinario: {salarioOrdinario:C}");
                Console.WriteLine($"Aumento: {aumento:C}");
                Console.WriteLine($"Salario bruto: {salarioBruto:C}");
                Console.WriteLine($"Deducción CCSS: {deduccionCCSS:C}");
                Console.WriteLine($"Salario neto: {salarioNeto:C}");
                Console.WriteLine("-----------------------------------");

                Console.WriteLine("¿Desea agregar algun otro empleado? (si/no)");
                string respuesta = Console.ReadLine().ToLower();

                //Determina si se desea continuar con el bucle
                if (respuesta != "si")
                {
                    continuar = false;

                }
            }

            //Calcula promedios // el ? se utiliza para asegurar que no se intente dividir por 0 
            double promedioNetoOperarios = cuentaOperarios > 0 ? acSalarioNetoOperarios / cuentaOperarios : 0;
            double promedioNetoTecnicos = cuentaTecnicos > 0 ? acSalarioNetoTecnicos / cuentaTecnicos : 0;
            double promedioNetoProf = cuentaProfesionales > 0 ? acSalarioNetoProf / cuentaProfesionales : 0;

            //Muestra toda la estadistica
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("Estadísticas:");
            Console.WriteLine($"Cantidad de empleados que son operarios: {cuentaOperarios}");
            Console.WriteLine($"Salario acumulado neto para operarios: {acSalarioNetoOperarios:C}");
            Console.WriteLine($"Salario promedio neto para operarios: {promedioNetoOperarios:C}");
            Console.WriteLine($"Cantidad de empleados que son técnicos: {cuentaTecnicos}");
            Console.WriteLine($"Salario acumulado neto para técnicos: {acSalarioNetoTecnicos:C}");
            Console.WriteLine($"Salario promedio neto para técnicos: {promedioNetoTecnicos:C}");
            Console.WriteLine($"Cantidad de empleados que son profesionales: {cuentaProfesionales}");
            Console.WriteLine($"Salario acumulado neto para profesionales: {acSalarioNetoProf:C}");
            Console.WriteLine($"Salario promedio neto para profesionales: {promedioNetoProf:C}");

            Console.WriteLine("--------------------------------------------------------------------------------");

            Console.WriteLine("Se realiza lo requerido. Gracias!!!");

            }
        }
    }

