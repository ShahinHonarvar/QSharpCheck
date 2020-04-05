// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

namespace QSharpCheck {
    
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
        
        ReconstructMessage_Reference(qBob, classicalBits);
    }
}
