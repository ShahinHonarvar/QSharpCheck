// In this script lines 6-41 are obtained from the lines 12-55 of ReferenceImplementation.qs produces
// by Microsoft available at https://github.com/microsoft/QuantumKatas/blob/master/Teleportation/ReferenceImplementation.qs

namespace TeleportationValidate {
    
    open Microsoft.Quantum.Preparation;
    open Microsoft.Quantum.Intrinsic;
    
    
    // Entangled pair
    operation Entangle_Reference (qAlice : Qubit, qBob : Qubit) : Unit
    is Adj {        
        H(qAlice);
        CNOT(qAlice, qBob);
    }
    
    
    // Send the message (Alice's task)
    operation SendMessage_Reference (qAlice : Qubit, qMessage : Qubit) : (Bool, Bool) {
        CNOT(qMessage, qAlice);
        H(qMessage);
        return (M(qMessage) == One, M(qAlice) == One);
    }
    
    
    // Reconstruct the message (Bob's task)
    operation ReconstructMessage_Reference (qBob : Qubit, (b1 : Bool, b2 : Bool)) : Unit {
        if (b1) {
            Z(qBob);
        }
        if (b2) {
            X(qBob);
        }
    }
    
    
    // Standard teleportation protocol
    operation StandardTeleport_Reference (qAlice : Qubit, qBob : Qubit, qMessage : Qubit) : Unit {
        Entangle_Reference(qAlice, qBob);
        let classicalBits = SendMessage_Reference(qAlice, qMessage);
        
        // Alice sends the classical bits to Bob.
        // Bob uses these bits to transform his part of the entangled pair into |ψ⟩.
        ReconstructMessage_Reference(qBob, classicalBits);
    }

    operation SetAllToZero(register : Qubit[]) : Unit {

        for (i in 0..2){
            if (M(register[i])!=Zero) {
                X(register[i]);
            }
        }
    }

    // Measure the qubit received by Bob
    operation Measurement (num : Int, theta : Double, phi : Double) : Int {

        mutable count = 0;
        
          using (qubits = Qubit[3]){

            let qAlice   = qubits[0];
            let qBob     = qubits[1];
            let qMessage = qubits[2];
            
            for (i in 1..num){

                SetAllToZero(qubits);
                Ry (theta, qMessage);
                R1 (phi, qMessage);

                StandardTeleport_Reference (qAlice, qBob, qMessage);
            
                if(M(qBob)==Zero) {set count += 1;}
            }

            ResetAll(qubits);
        }  

        return count;
    }
}
