#pragma warning disable 1591
using System;
using Microsoft.Quantum.Primitive;
using Microsoft.Quantum.Simulation.Core;
using Microsoft.Quantum.MetaData.Attributes;

[assembly: OperationDeclaration("Quantum.Quantum_Incremental_Searches", "Example (resultado : Int) : Int", new string[] { }, "C:\\Users\\monto\\Desktop\\Quantum Methods\\Quantum_Incremental_Searches\\Quantum_Incremental_Searches\\Qsharp.qs", 176L, 8L, 2L)]
[assembly: OperationDeclaration("Quantum.Quantum_Incremental_Searches", "MeasurementOneQubit () : Result", new string[] { }, "C:\\Users\\monto\\Desktop\\Quantum Methods\\Quantum_Incremental_Searches\\Quantum_Incremental_Searches\\Qsharp.qs", 661L, 21L, 44L)]
#line hidden
namespace Quantum.Quantum_Incremental_Searches
{
    public class Example : Operation<Int64, Int64>, ICallable
    {
        public Example(IOperationFactory m) : base(m)
        {
        }

        String ICallable.Name => "Example";
        String ICallable.FullName => "Quantum.Quantum_Incremental_Searches.Example";
        protected ICallable<String, QVoid> Message
        {
            get;
            set;
        }

        public override Func<Int64, Int64> Body => (__in) =>
        {
            var resultado = __in;
#line 11 "C:\\Users\\monto\\Desktop\\Quantum Methods\\Quantum_Incremental_Searches\\Quantum_Incremental_Searches\\Qsharp.qs"
            Message.Apply("Hi, I am Quantum Message");
#line 12 "C:\\Users\\monto\\Desktop\\Quantum Methods\\Quantum_Incremental_Searches\\Quantum_Incremental_Searches\\Qsharp.qs"
            Message.Apply("Método de Busquedas Incrementales");
#line 13 "C:\\Users\\monto\\Desktop\\Quantum Methods\\Quantum_Incremental_Searches\\Quantum_Incremental_Searches\\Qsharp.qs"
            Message.Apply(("Convenciones usadas: " + "pi, sin(), cos(), tan(), e, abs(), ^, sqrt(), ln()"));
#line 14 "C:\\Users\\monto\\Desktop\\Quantum Methods\\Quantum_Incremental_Searches\\Quantum_Incremental_Searches\\Qsharp.qs"
            Message.Apply("Notación: f(x) = <expresión>");
#line 15 "C:\\Users\\monto\\Desktop\\Quantum Methods\\Quantum_Incremental_Searches\\Quantum_Incremental_Searches\\Qsharp.qs"
            Message.Apply("Está en radianes");
#line 16 "C:\\Users\\monto\\Desktop\\Quantum Methods\\Quantum_Incremental_Searches\\Quantum_Incremental_Searches\\Qsharp.qs"
            Message.Apply("----------------------------------------------------------------------------");
#line 17 "C:\\Users\\monto\\Desktop\\Quantum Methods\\Quantum_Incremental_Searches\\Quantum_Incremental_Searches\\Qsharp.qs"
            return (resultado * 2L);
        }

        ;
        public override void Init()
        {
            this.Message = this.Factory.Get<ICallable<String, QVoid>>(typeof(Microsoft.Quantum.Primitive.Message));
        }

        public override IApplyData __dataIn(Int64 data) => new QTuple<Int64>(data);
        public override IApplyData __dataOut(Int64 data) => new QTuple<Int64>(data);
        public static System.Threading.Tasks.Task<Int64> Run(IOperationFactory __m__, Int64 resultado)
        {
            return __m__.Run<Example, Int64, Int64>(resultado);
        }
    }

    public class MeasurementOneQubit : Operation<QVoid, Result>, ICallable
    {
        public MeasurementOneQubit(IOperationFactory m) : base(m)
        {
        }

        String ICallable.Name => "MeasurementOneQubit";
        String ICallable.FullName => "Quantum.Quantum_Incremental_Searches.MeasurementOneQubit";
        protected Allocate Allocate
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveH
        {
            get;
            set;
        }

        protected ICallable<Qubit, Result> M
        {
            get;
            set;
        }

        protected Release Release
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumPrimitiveX
        {
            get;
            set;
        }

        public override Func<QVoid, Result> Body => (__in) =>
        {
#line 23 "C:\\Users\\monto\\Desktop\\Quantum Methods\\Quantum_Incremental_Searches\\Quantum_Incremental_Searches\\Qsharp.qs"
            var result = Result.Zero;
            // The following using block creates a fresh qubit and initializes it 
            // in the |0〉 state.
#line 26 "C:\\Users\\monto\\Desktop\\Quantum Methods\\Quantum_Incremental_Searches\\Quantum_Incremental_Searches\\Qsharp.qs"
            var qubits = Allocate.Apply(1L);
#line 27 "C:\\Users\\monto\\Desktop\\Quantum Methods\\Quantum_Incremental_Searches\\Quantum_Incremental_Searches\\Qsharp.qs"
            var qubit = qubits[0L];
            // We apply a Hadamard operation H to the state, thereby creating the 
            // state 1/sqrt(2)(|0〉+|1〉). 
#line 30 "C:\\Users\\monto\\Desktop\\Quantum Methods\\Quantum_Incremental_Searches\\Quantum_Incremental_Searches\\Qsharp.qs"
            MicrosoftQuantumPrimitiveH.Apply(qubit);
            // Now we measure the qubit in Z-basis.
#line 32 "C:\\Users\\monto\\Desktop\\Quantum Methods\\Quantum_Incremental_Searches\\Quantum_Incremental_Searches\\Qsharp.qs"
            result = M.Apply(qubit);
            // As the qubit is now in an eigenstate of the measurement operator, 
            // we reset the qubit before releasing it. 
#line 35 "C:\\Users\\monto\\Desktop\\Quantum Methods\\Quantum_Incremental_Searches\\Quantum_Incremental_Searches\\Qsharp.qs"
            if ((result == Result.One))
            {
#line 36 "C:\\Users\\monto\\Desktop\\Quantum Methods\\Quantum_Incremental_Searches\\Quantum_Incremental_Searches\\Qsharp.qs"
                MicrosoftQuantumPrimitiveX.Apply(qubit);
            }

#line hidden
            Release.Apply(qubits);
            // Finally, we return the result of the measurement. 
#line 40 "C:\\Users\\monto\\Desktop\\Quantum Methods\\Quantum_Incremental_Searches\\Quantum_Incremental_Searches\\Qsharp.qs"
            return result;
        }

        ;
        public override void Init()
        {
            this.Allocate = this.Factory.Get<Allocate>(typeof(Microsoft.Quantum.Primitive.Allocate));
            this.MicrosoftQuantumPrimitiveH = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.H));
            this.M = this.Factory.Get<ICallable<Qubit, Result>>(typeof(Microsoft.Quantum.Primitive.M));
            this.Release = this.Factory.Get<Release>(typeof(Microsoft.Quantum.Primitive.Release));
            this.MicrosoftQuantumPrimitiveX = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Primitive.X));
        }

        public override IApplyData __dataIn(QVoid data) => data;
        public override IApplyData __dataOut(Result data) => new QTuple<Result>(data);
        public static System.Threading.Tasks.Task<Result> Run(IOperationFactory __m__)
        {
            return __m__.Run<MeasurementOneQubit, QVoid, Result>(QVoid.Instance);
        }
    }
}