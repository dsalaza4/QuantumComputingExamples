using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using org.mariuszgromada.math.mxparser;

namespace ValorAgregado
{
    class Biseccion
    {
        static void Main(string[] args) {
            string func;
            double xi, xs, tolerancia;
            int iteraciones;

            Console.WriteLine("Convenciones usadas: pi, sin(), cos(), tan(), e^, abs(), ^, sqrt(), ln()");
            Console.WriteLine("Ingrese la función f(x) a ser evaluada (Notación: f(x) = <expresión>)");
            func = Console.ReadLine();
            Console.WriteLine("La función es: " + func);

            Console.WriteLine("Ingrese el extremo inferior: ");
            xi = Double.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el extremo superior: ");
            xs = Double.Parse(Console.ReadLine());

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

            metodoBiseccion(func, xi, xs, tolerancia, iteraciones);
        }

        public static void metodoBiseccion (string func, double xi, double xs, double tolerancia, int iteraciones) {
            double fxi, fxs, fxm, xm, xaux, errorAbs, errorRel;
            int cont;

            Function fx1 = new Function(func);

            fxi = fx1.calculate(xi);
            fxs = fx1.calculate(xs);

            if (fxi == 0) {
                Console.WriteLine(xi + " es una raiz");
            } else if (fxs == 0) {
                Console.WriteLine(xs + " es una raiz");
            } else if (fxi * fxs > 0) {
                Console.WriteLine("El intervalo no contiene una raiz");
            } else {

                xm = (xi + xs)/2;

                fxm = fx1.calculate(xm);
   
                Console.WriteLine("iteración | xi | fxi | xs | fxs | xm | fxm | error absoluto | + error relativo");
                Console.WriteLine(0 + "|" + xi + "|" + fxi + "|" + xs + "|" + fxs + "|" + xm + "|" + fxm);
                cont = 1;
                errorAbs = tolerancia + 1;
                while (fxm != 0 && errorAbs > tolerancia && cont < iteraciones) {
                    if (fxi * fxm < 0) {
                        xs = xm;
                        fxs = fx1.calculate(xs);
                    } else {
                        xi = xm;
                        fxi = fx1.calculate(xi);
                    }

                    xaux = xm;
                    xm = (xi + xs)/2;
                    fxm = fx1.calculate(xm);

                    errorAbs = Math.Abs(xm - xaux); 
                    errorRel = errorAbs / xm;
                    Console.WriteLine(cont + "|" + xi + "|" + fxi + "|" + xs + "|" + fxs + "|" + xm + "|" + fxm + "|" + errorAbs + "|" + errorRel);
                    cont = cont + 1;
                }

                if (fxm == 0) {
                    Console.WriteLine(xm + " es una raiz");
                } else if (errorAbs < tolerancia) {
                    Console.WriteLine(xm + " se aproxima a una raiz de la función, con una tolerancia de: " + tolerancia);
                } else {
                    Console.WriteLine("Excedió el numero de iteraciones posible");
                }
            }
        }
    }
}