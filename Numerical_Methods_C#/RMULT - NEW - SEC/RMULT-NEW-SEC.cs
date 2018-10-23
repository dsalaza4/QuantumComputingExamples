using System;
using System.Collections.Generic;
using MathNet.Symbolics;


namespace ConsoleApp1 {
    class Program {

        static void Multiple_Roots(Expression f, float x0, float tol, int ite) {
            var xdict = new Dictionary<string, FloatingPoint> { { "x", x0 } };

            Expression x = Expression.Symbol("x");
            Expression df = Calculus.Differentiate(x, f);
            Expression d2f = Calculus.Differentiate(x, df);

            int cont = 0;
            float absError = tol + 1;
            float relError;
            float x1;

            float fx = (float)Evaluate.Evaluate(xdict, f).RealValue;
            float dfx = (float)Evaluate.Evaluate(xdict, df).RealValue;
            float d2fx = (float)Evaluate.Evaluate(xdict, d2f).RealValue;
            float denominator = (float)Math.Pow(dfx, 2) - (fx * d2fx);
            
            Console.WriteLine("|{0,-4}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}|{6,-15}|", "cont", "x", "fx", "dfx", "d2fx", "AbsError", "RelError");
            Console.WriteLine("|{0,-4}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}|{6,-15}|", cont, x0, fx, dfx, d2fx, "", "");

            while (fx != 0 && absError > tol && denominator != 0 && cont < ite) {
                x1 = x0 - ((fx * dfx) / denominator);
                xdict["x"] = x1;

                fx = (float)Evaluate.Evaluate(xdict, f).RealValue;
                dfx = (float)Evaluate.Evaluate(xdict, df).RealValue;
                d2fx = (float)Evaluate.Evaluate(xdict, d2f).RealValue;
                denominator = (float)Math.Pow(dfx, 2) - (fx * d2fx);

                absError = Math.Abs(x1 - x0);
                relError = absError / Math.Abs(x1);
                x0 = x1;
                cont++;
                Console.WriteLine("|{0,-4}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}|{6,-15}|", cont, x0, fx, dfx, d2fx, absError, relError);
            }

            if (fx == 0) {
                Console.WriteLine("\n" + x0 + " is a root.");
            }
            else if (absError < tol) {
                Console.WriteLine("\n" + x0 + " approximates to the function's root with a tolerance of: " + tol.ToString());
            }
            else if (denominator == 0) {
                Console.WriteLine("\n" + x0 + " denominator became 0");
            }
            else {
                Console.WriteLine("\n" + "Maximum number of iterations exceeded.");
            }
        }

        static void Secant(Expression f, float x0, float x1, float tol, int ite) {
            var x0dict = new Dictionary<string, FloatingPoint> { { "x", x0 } };
            
            float fx0 = (float)Evaluate.Evaluate(x0dict, f).RealValue;
            if (fx0 == 0) {
                Console.WriteLine("\n" + x0 + " is a root.");
            }
            else {
                var x1dict = new Dictionary<string, FloatingPoint> { { "x", x1 } };
                int cont = 0;
                float x2;
                float absError = tol + 1;
                float relError;

                float fx1 = (float)Evaluate.Evaluate(x1dict, f).RealValue;
                float denominator = fx1 - fx0;

                Console.WriteLine("|{0,-4}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}|{6,-15}|", "cont", "x0", "x1", "fx0", "fx1", "AbsError", "RelError");
                Console.WriteLine("|{0,-4}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}|{6,-15}|", cont, x0, x1, fx0, fx1, "", "");

                while (fx1 != 0 && absError > tol && denominator != 0 && cont < ite) {
                    x0 = (float)x0dict["x"].RealValue;
                    x1 = (float)x1dict["x"].RealValue;
                    x2 = x1 - ((fx1 * (x1 - x0))/denominator);
                    absError = Math.Abs(x2 - x1);
                    relError = absError / Math.Abs(x2);
                    x0 = x1;
                    fx0 = fx1;
                    x1 = x2;
                    x1dict["x"] = x0;
                    x1dict["x"] = x1;
                    fx1 = (float)Evaluate.Evaluate(x1dict, f).RealValue;
                    denominator = fx1 - fx0;
                    cont++;
                    Console.WriteLine("|{0,-4}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}|{6,-15}|", cont, x0, x1, fx0, fx1, absError, relError);
                }

                if (fx1 == 0) {
                    Console.WriteLine("\n" + x0 + " is a root.");
                }
                else if (absError < tol) {
                    Console.WriteLine("\n" + x0 + " approximates to the function's root with a tolerance of: " + tol.ToString());
                }
                else if (denominator == 0) {
                    Console.WriteLine("\n" + x0 + " is possibly a multiple root.");
                }
                else {
                    Console.WriteLine("\n" + "Maximum number of iterations exceeded.");
                }
            }
        }

        static void Newton(Expression f, float x0, float tol, int ite) {
            var x0dict = new Dictionary<string, FloatingPoint> { { "x", x0 } };
            var x1dict = new Dictionary<string, FloatingPoint> { { "x", 0 } };

            Expression x = Expression.Symbol("x");
            Expression df = Calculus.Differentiate(x, f);

            int cont = 0;
            float absError = tol + 1;
            float relError;

            float fx = (float)Evaluate.Evaluate(x0dict, f).RealValue;
            float dfx = (float)Evaluate.Evaluate(x0dict, df).RealValue;

            Console.WriteLine("|{0,-4}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}|", "cont", "x", "fx", "dfx", "AbsError", "RelError");
            Console.WriteLine("|{0,-4}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}|", cont, x0, fx, dfx, "", "");

            while (fx != 0 && absError > tol && dfx != 0 && cont < ite) {
                x0 = (float)x0dict["x"].RealValue;
                float x1 = x0 - (fx / dfx);
                x1dict["x"] = x1;

                fx = (float)Evaluate.Evaluate(x1dict, f).RealValue;
                dfx = (float)Evaluate.Evaluate(x1dict, df).RealValue;

                absError = Math.Abs(x1 - x0);

                relError = absError / Math.Abs(x1);

                x0dict["x"] = x1;
                cont++;
                Console.WriteLine("|{0,-4}|{1,-15}|{2,-15}|{3,-15}|{4,-15}|{5,-15}|", cont, x0, fx, dfx, absError, relError);
            }

            if (fx == 0) {
                Console.WriteLine("\n" + x0 + " is a root.");
            }
            else if (absError < tol) {
                Console.WriteLine("\n" + x0 + " approximates to the function's root with a tolerance of: " + tol.ToString());
            }
            else if (dfx == 0) {
                Console.WriteLine("\n" + x0 + " is possibly a multiple root.");
            }
            else {
                Console.WriteLine("\n" + "Maximum number of iterations exceeded.");
            }
        }

        static void Main(string[] args) {
            Console.WriteLine("Please insert a function with x as dependant variable: ");
            string fstring = Console.ReadLine();
            Expression f = Infix.ParseOrUndefined(fstring);
            Newton(f, 4f, (float)(10* Math.Pow(10,-10)), 20);
            Secant(f, 1f, 4f, (float)(10 * Math.Pow(10, -10)), 20);
            Multiple_Roots(f, 4f, (float)(10 * Math.Pow(10, -10)), 20);
            Console.Read();
        }
    }
}
