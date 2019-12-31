// In this script lines 6-41 are obtained from the lines 12-55 of ReferenceImplementation.qs produces
// by Microsoft available at https://github.com/microsoft/QuantumKatas/blob/master/Teleportation/ReferenceImplementation.qs

namespace Demo {
    
    open Microsoft.Quantum.Preparation;
    open Microsoft.Quantum.Intrinsic;
    
    //Entangled pair
    operation Entangle_Reference (qAlice : Qubit, qBob : Qubit) : Unit
    is Adj {        
        H(qAlice);
        CNOT(qAlice, qBob);
    }
    
    
    //Send the message (Alice's task)
    operation SendMessage_Reference (qAlice : Qubit, qMessage : Qubit) : (Bool, Bool) {
        CNOT(qMessage, qAlice);
        H(qMessage);
        return (M(qMessage) == One, M(qAlice) == One);
    }
    
    
    //Reconstruct the message (Bob's task)
    operation ReconstructMessage_Reference (qBob : Qubit, (b1 : Bool, b2 : Bool)) : Unit {
        if (b1) {
            X(qBob);
        }
        if (b2) {
            Z(qBob);
        }
    }
    
    //Standard teleportation protocol
    operation StandardTeleport_Reference (qAlice : Qubit, qBob : Qubit, qMessage : Qubit) : Unit {
        Entangle_Reference(qAlice, qBob);
        let classicalBits = SendMessage_Reference(qAlice, qMessage);
        
        ReconstructMessage_Reference(qBob, classicalBits);
    }

    operation Measurement (num : Int) : (Int, Int) {

        mutable count = 0;
        for (i in 1..num){
          using (qubits = Qubit[3]){

            let qAlice   = qubits[0];
            let qBob     = qubits[1];
            let qMessage = qubits[2];

            Ry (0.628318530717959, qMessage);
            R1 (3.14159265358979, qMessage);

            StandardTeleport_Reference (qAlice, qBob, qMessage);
            if(M(qBob)==Zero) {set count += 1;}
            ResetAll(qubits);
          } 

        }  
        return (count, num - count);
    }
}
