using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using org.mariuszgromada.math.mxparser;

namespace ValorAgregrado
{
    class PuntoFijo
    {
        static void Main(string[] args) {
            string funcF, funcG;
            double xa, tolerancia;
            int iteraciones;

            Console.WriteLine("Convenciones usadas: pi, sin(), cos(), tan(), e^, abs(), ^, sqrt(), ln()");
            Console.WriteLine("Ingrese la función f(x) a ser evaluada (Notación: f(x) = <expresión>)");
            funcF = Console.ReadLine();
            Console.WriteLine("La función es: " + funcF);

            Console.WriteLine("Ingrese la función g(x) a ser evaluada (Notación: g(x) = <expresión>)");
            funcG = Console.ReadLine();
            Console.WriteLine("La función es: " + funcG);

            Console.WriteLine("Ingrese la aproximación inicial: ");
            xa = Double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese la tolerancia: ");
            tolerancia = Double.Parse(Console.ReadLine());
            while (tolerancia == 0) {
                Console.WriteLine("La tolerancia debe ser diferente de 0, ingresela nuevamente: ");
                tolerancia = Double.Parse(Console.ReadLine());
            }

            Console.WriteLine("Ingrese el número maximo de iteraciones: ");
            iteraciones = int.Parse(Console.ReadLine());
            while (iteraciones <= 0) {
                Console.WriteLine("El número de iteraciones debe ser mayor a 0, ingrésela nuevamente: ");
                iteraciones = int.Parse(Console.ReadLine());
            }

            metodoPuntoFijo(funcF, funcG, xa, tolerancia, iteraciones);
        }

        public static void metodoPuntoFijo (string funcF, string funcG, double xa, double tolerancia, int iteraciones) {
            double fx, xn, errorAbs, errorRel;
            int cont;

            Function fx1 = new Function(funcF);
            Function gx = new Function(funcG);

            fx = fx1.calculate(xa);

            cont = 0;

            Console.WriteLine("iteración | xa | fx | error absoluto | error relativo");
            Console.WriteLine(cont + "|" + xa + "|" + fx + "|" + "---" + "|" + "---");

            errorAbs = tolerancia + 1;

            while (fx != 0 && errorAbs > tolerancia && cont < iteraciones) {
                xn = gx.calculate(xa);
                fx = fx1.calculate(xn);

                errorAbs = Math.Abs(xn - xa);
                errorRel = errorAbs/xn;
                xa = xn;
                cont = cont + 1;
                Console.WriteLine(cont + "|" + xa + "|" + fx + "|" + errorAbs + "|" + errorRel);
            }

            if (fx == 0) {
                Console.WriteLine(xa + " es una raíz");
            } else if (errorAbs < tolerancia) {
                Console.WriteLine(xa + " se aproxima a una raiz de la función, con una tolerancia de: " + tolerancia);
            } else {
                Console.WriteLine("Excedió el número de iteraciones posible");
            }  
        }
    }
}   