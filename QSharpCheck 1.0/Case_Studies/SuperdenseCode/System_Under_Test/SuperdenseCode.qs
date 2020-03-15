// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license.

namespace QSharpCheck {
    
    open Microsoft.Quantum.Intrinsic;
    open Microsoft.Quantum.Measurement;
    
    newtype ProtocolMessage = (Bit1 : Bool, Bit2 : Bool);

    operation CreateEntangledPair_Reference (q1 : Qubit, q2 : Qubit) : Unit is Adj {
        
        H(q1);
        CNOT(q1, q2);
    }
    
    operation EncodeMessageInQubit_Reference (qAlice : Qubit, message : ProtocolMessage) : Unit {
        
        if (message::Bit1) {
            Z(qAlice);
        }
        
        if (message::Bit2) {
            X(qAlice);
        }
    }
    
    operation DecodeMessageFromQubits_Reference (qAlice : Qubit, qBob : Qubit) : ProtocolMessage {
        
        Adjoint CreateEntangledPair_Reference(qAlice, qBob);
        return ProtocolMessage(MResetZ(qAlice) == One, MResetZ(qBob) == One);
    }
    
    operation SuperdenseCodingProtocol_Reference (message : ProtocolMessage) : ProtocolMessage {
        
        using ((q1, q2) = (Qubit(), Qubit())) {
            CreateEntangledPair_Reference(q1, q2);
            EncodeMessageInQubit_Reference(q1, message);
            return DecodeMessageFromQubits_Reference(q1, q2);            
        }
    }  
              
    operation SuperdenseCodingInvoke(b1 : Int , b2 : Int) : (Int,Int) {

        mutable bit1 = false;
        mutable bit2 = false;
        mutable result1 = 0;
        mutable result2 = 0;

        if (b1==1) {
            set bit1 = true;
        }
        if (b2==1) {
            set bit2 = true;
        }
        let result = SuperdenseCodingProtocol_Reference(ProtocolMessage(bit1,bit2));

        if (result::Bit1==true) {
            set result1 = 1;
        }
        if (result::Bit2==true) {
            set result2 = 1;
        }

        return (result1,result2);
    }
}
