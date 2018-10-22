using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.Simulation.Simulators;
using System;
using org.mariuszgromada.math.mxparser;

namespace Quantum.Quantum_Incremental_Searches
{
    class IncrementalSearches
    {
        static long res = 0;
        static long a = 8;

        static string funcion, x, d, it;
        static int contador;
        static double fx0, fx1;

        static void Main(string[] args)
        {

            using (var sim = new QuantumSimulator())
            {
                res = Example.Run(sim, a).Result;
                var res1 = MeasurementOneQubit.Run(sim).Result;
                Console.WriteLine(res1);
            }

            datosIniciales();

            metodoNumerico(funcion, x, d, it);

            Console.WriteLine(res);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

        }

        // Function f = new Function("f(x) = e^(3*x-12)+x*cos(3*x)-x^2+4");
        public static void metodoNumerico(string funcion, string x, string d, string it)
        {
            int x0 = int.Parse(x);  
            int delta = int.Parse(d);
            int iteraciones = int.Parse(it);
            int x1 = 0;

            Function f0 = new Function(funcion);
            fx0 = f0.calculate(x0);

            if (fx0 == 0)
            {
                Console.WriteLine(x0 + " es raiz.");
            }
            else
            {
                x1 = x0 + delta;
                contador = 1;
                Function f1 = new Function(funcion);
                fx1 = f1.calculate(x1);

                Console.WriteLine("-----------------------------------------");

                while (fx0 * fx1 > 0 & contador < iteraciones)
                {
                    Console.Write("n = " + (contador - 1) + "\t");
                    Console.Write("Xn = " + x0 + "\t");
                    Console.WriteLine("Fxn = " + fx0);

                    x0 = x1;
                    fx0 = fx1;
                    x1 = x0 + delta;
                    fx1 = f1.calculate(x1);

                    contador++;
                }

                Console.Write("n = " + (contador - 1) + "\t");
                Console.Write("Xn = " + x0 + "\t");
                Console.WriteLine("Fxn = " + fx0);

                Console.Write("n = " + (contador) + "\t");
                Console.Write("Xn+1 = " + x1 + "\t");
                Console.WriteLine("Fxn+1 = " + fx1);
                Console.WriteLine("-----------------------------------------");

                if (fx1 == 0)
                {
                    Console.WriteLine(x1 + " es raiz");
                }
                else if (fx0 * fx1 < 0)
                {
                    Console.WriteLine("Hay una raiz entre " + x0 + " y " + x1);
                    Console.WriteLine("fx0= " + fx0);
                    Console.WriteLine("fx1= " + fx1);
                }
                else
                {
                    Console.WriteLine("Fracasó en " + iteraciones + " iteraciones");
                }


            }

        }

        public static void datosIniciales()
        {
            Console.WriteLine("Digite una función: ");
            funcion = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Digite un X0: ");
            x = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Digite un delta: ");
            d = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Digite un número de iteraciones: ");
            it = Convert.ToString(Console.ReadLine());

        }

    }
}