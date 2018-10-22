namespace Quantum.Quantum_Incremental_Searches
{
    open Microsoft.Quantum.Primitive;
    open Microsoft.Quantum.Canon;


	operation Example (resultado : Int) : (Int)
	{
		body
		{
			Message("Hi, I am Quantum Message");
			Message("Método de Busquedas Incrementales");
            Message("Convenciones usadas: " + "pi, sin(), cos(), tan(), e, abs(), ^, sqrt(), ln()");
            Message("Notación: f(x) = <expresión>");
            Message("Está en radianes");
            Message("----------------------------------------------------------------------------");
			return resultado*2;
		}
	}

	operation MeasurementOneQubit () : Result {
		body {
			mutable result = Zero;
			// The following using block creates a fresh qubit and initializes it 
			// in the |0〉 state.
			using (qubits = Qubit[1]) {
				let qubit = qubits[0]; 
				// We apply a Hadamard operation H to the state, thereby creating the 
				// state 1/sqrt(2)(|0〉+|1〉). 
				H(qubit); 
				// Now we measure the qubit in Z-basis.
				set result = M(qubit);
				// As the qubit is now in an eigenstate of the measurement operator, 
				// we reset the qubit before releasing it. 
				if (result == One) {
					X(qubit);
				}            
			}
			// Finally, we return the result of the measurement. 
			return result;
		}
	}

}
