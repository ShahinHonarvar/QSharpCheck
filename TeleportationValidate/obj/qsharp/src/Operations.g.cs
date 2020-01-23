#pragma warning disable 1591
using System;
using Microsoft.Quantum.Core;
using Microsoft.Quantum.Intrinsic;
using Microsoft.Quantum.Simulation.Core;

[assembly: CallableDeclaration("{\"Kind\":{\"Case\":\"Operation\"},\"QualifiedName\":{\"Namespace\":\"TeleportationValidate\",\"Name\":\"Entangle_Reference\"},\"SourceFile\":\"/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs\",\"Position\":{\"Item1\":7,\"Item2\":4},\"SymbolRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":29}},\"ArgumentTuple\":{\"Case\":\"QsTuple\",\"Fields\":[[{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"qAlice\"]},\"Type\":{\"Case\":\"Qubit\"},\"InferredInformation\":{\"IsMutable\":false,\"HasLocalQuantumDependency\":false},\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":31},\"Item2\":{\"Line\":1,\"Column\":37}}}]},{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"qBob\"]},\"Type\":{\"Case\":\"Qubit\"},\"InferredInformation\":{\"IsMutable\":false,\"HasLocalQuantumDependency\":false},\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":47},\"Item2\":{\"Line\":1,\"Column\":51}}}]}]]},\"Signature\":{\"TypeParameters\":[],\"ArgumentType\":{\"Case\":\"TupleType\",\"Fields\":[[{\"Case\":\"Qubit\"},{\"Case\":\"Qubit\"}]]},\"ReturnType\":{\"Case\":\"UnitType\"},\"Information\":{\"Affiliation\":{\"Case\":\"SimpleSet\",\"Fields\":[{\"Case\":\"Adjointable\"}]},\"InferredInformation\":{\"IsSelfAdjoint\":false,\"IsIntrinsic\":false}}},\"Documentation\":[]}")]
[assembly: SpecializationDeclaration("{\"Kind\":{\"Case\":\"QsBody\"},\"TypeArguments\":{\"Case\":\"Null\"},\"Information\":{\"Affiliation\":{\"Case\":\"SimpleSet\",\"Fields\":[{\"Case\":\"Adjointable\"}]},\"InferredInformation\":{\"IsSelfAdjoint\":false,\"IsIntrinsic\":false}},\"Parent\":{\"Namespace\":\"TeleportationValidate\",\"Name\":\"Entangle_Reference\"},\"SourceFile\":\"/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs\",\"Position\":{\"Item1\":7,\"Item2\":4},\"HeaderRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":29}},\"Documentation\":[]}")]
[assembly: SpecializationDeclaration("{\"Kind\":{\"Case\":\"QsAdjoint\"},\"TypeArguments\":{\"Case\":\"Null\"},\"Information\":{\"Affiliation\":{\"Case\":\"SimpleSet\",\"Fields\":[{\"Case\":\"Adjointable\"}]},\"InferredInformation\":{\"IsSelfAdjoint\":false,\"IsIntrinsic\":false}},\"Parent\":{\"Namespace\":\"TeleportationValidate\",\"Name\":\"Entangle_Reference\"},\"SourceFile\":\"/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs\",\"Position\":{\"Item1\":7,\"Item2\":4},\"HeaderRange\":{\"Item1\":{\"Line\":2,\"Column\":8},\"Item2\":{\"Line\":2,\"Column\":11}},\"Documentation\":[\"automatically generated QsAdjoint specialization for TeleportationValidate.Entangle_Reference\"]}")]
[assembly: CallableDeclaration("{\"Kind\":{\"Case\":\"Operation\"},\"QualifiedName\":{\"Namespace\":\"TeleportationValidate\",\"Name\":\"SendMessage_Reference\"},\"SourceFile\":\"/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs\",\"Position\":{\"Item1\":15,\"Item2\":4},\"SymbolRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":32}},\"ArgumentTuple\":{\"Case\":\"QsTuple\",\"Fields\":[[{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"qAlice\"]},\"Type\":{\"Case\":\"Qubit\"},\"InferredInformation\":{\"IsMutable\":false,\"HasLocalQuantumDependency\":false},\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":34},\"Item2\":{\"Line\":1,\"Column\":40}}}]},{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"qMessage\"]},\"Type\":{\"Case\":\"Qubit\"},\"InferredInformation\":{\"IsMutable\":false,\"HasLocalQuantumDependency\":false},\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":50},\"Item2\":{\"Line\":1,\"Column\":58}}}]}]]},\"Signature\":{\"TypeParameters\":[],\"ArgumentType\":{\"Case\":\"TupleType\",\"Fields\":[[{\"Case\":\"Qubit\"},{\"Case\":\"Qubit\"}]]},\"ReturnType\":{\"Case\":\"TupleType\",\"Fields\":[[{\"Case\":\"Bool\"},{\"Case\":\"Bool\"}]]},\"Information\":{\"Affiliation\":{\"Case\":\"EmptySet\"},\"InferredInformation\":{\"IsSelfAdjoint\":false,\"IsIntrinsic\":false}}},\"Documentation\":[]}")]
[assembly: SpecializationDeclaration("{\"Kind\":{\"Case\":\"QsBody\"},\"TypeArguments\":{\"Case\":\"Null\"},\"Information\":{\"Affiliation\":{\"Case\":\"EmptySet\"},\"InferredInformation\":{\"IsSelfAdjoint\":false,\"IsIntrinsic\":false}},\"Parent\":{\"Namespace\":\"TeleportationValidate\",\"Name\":\"SendMessage_Reference\"},\"SourceFile\":\"/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs\",\"Position\":{\"Item1\":15,\"Item2\":4},\"HeaderRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":32}},\"Documentation\":[]}")]
[assembly: CallableDeclaration("{\"Kind\":{\"Case\":\"Operation\"},\"QualifiedName\":{\"Namespace\":\"TeleportationValidate\",\"Name\":\"ReconstructMessage_Reference\"},\"SourceFile\":\"/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs\",\"Position\":{\"Item1\":23,\"Item2\":4},\"SymbolRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":39}},\"ArgumentTuple\":{\"Case\":\"QsTuple\",\"Fields\":[[{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"qBob\"]},\"Type\":{\"Case\":\"Qubit\"},\"InferredInformation\":{\"IsMutable\":false,\"HasLocalQuantumDependency\":false},\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":41},\"Item2\":{\"Line\":1,\"Column\":45}}}]},{\"Case\":\"QsTuple\",\"Fields\":[[{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"b1\"]},\"Type\":{\"Case\":\"Bool\"},\"InferredInformation\":{\"IsMutable\":false,\"HasLocalQuantumDependency\":false},\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":56},\"Item2\":{\"Line\":1,\"Column\":58}}}]},{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"b2\"]},\"Type\":{\"Case\":\"Bool\"},\"InferredInformation\":{\"IsMutable\":false,\"HasLocalQuantumDependency\":false},\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":67},\"Item2\":{\"Line\":1,\"Column\":69}}}]}]]}]]},\"Signature\":{\"TypeParameters\":[],\"ArgumentType\":{\"Case\":\"TupleType\",\"Fields\":[[{\"Case\":\"Qubit\"},{\"Case\":\"TupleType\",\"Fields\":[[{\"Case\":\"Bool\"},{\"Case\":\"Bool\"}]]}]]},\"ReturnType\":{\"Case\":\"UnitType\"},\"Information\":{\"Affiliation\":{\"Case\":\"EmptySet\"},\"InferredInformation\":{\"IsSelfAdjoint\":false,\"IsIntrinsic\":false}}},\"Documentation\":[]}")]
[assembly: SpecializationDeclaration("{\"Kind\":{\"Case\":\"QsBody\"},\"TypeArguments\":{\"Case\":\"Null\"},\"Information\":{\"Affiliation\":{\"Case\":\"EmptySet\"},\"InferredInformation\":{\"IsSelfAdjoint\":false,\"IsIntrinsic\":false}},\"Parent\":{\"Namespace\":\"TeleportationValidate\",\"Name\":\"ReconstructMessage_Reference\"},\"SourceFile\":\"/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs\",\"Position\":{\"Item1\":23,\"Item2\":4},\"HeaderRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":39}},\"Documentation\":[]}")]
[assembly: CallableDeclaration("{\"Kind\":{\"Case\":\"Operation\"},\"QualifiedName\":{\"Namespace\":\"TeleportationValidate\",\"Name\":\"StandardTeleport_Reference\"},\"SourceFile\":\"/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs\",\"Position\":{\"Item1\":34,\"Item2\":4},\"SymbolRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":37}},\"ArgumentTuple\":{\"Case\":\"QsTuple\",\"Fields\":[[{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"qAlice\"]},\"Type\":{\"Case\":\"Qubit\"},\"InferredInformation\":{\"IsMutable\":false,\"HasLocalQuantumDependency\":false},\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":39},\"Item2\":{\"Line\":1,\"Column\":45}}}]},{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"qBob\"]},\"Type\":{\"Case\":\"Qubit\"},\"InferredInformation\":{\"IsMutable\":false,\"HasLocalQuantumDependency\":false},\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":55},\"Item2\":{\"Line\":1,\"Column\":59}}}]},{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"qMessage\"]},\"Type\":{\"Case\":\"Qubit\"},\"InferredInformation\":{\"IsMutable\":false,\"HasLocalQuantumDependency\":false},\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":69},\"Item2\":{\"Line\":1,\"Column\":77}}}]}]]},\"Signature\":{\"TypeParameters\":[],\"ArgumentType\":{\"Case\":\"TupleType\",\"Fields\":[[{\"Case\":\"Qubit\"},{\"Case\":\"Qubit\"},{\"Case\":\"Qubit\"}]]},\"ReturnType\":{\"Case\":\"UnitType\"},\"Information\":{\"Affiliation\":{\"Case\":\"EmptySet\"},\"InferredInformation\":{\"IsSelfAdjoint\":false,\"IsIntrinsic\":false}}},\"Documentation\":[]}")]
[assembly: SpecializationDeclaration("{\"Kind\":{\"Case\":\"QsBody\"},\"TypeArguments\":{\"Case\":\"Null\"},\"Information\":{\"Affiliation\":{\"Case\":\"EmptySet\"},\"InferredInformation\":{\"IsSelfAdjoint\":false,\"IsIntrinsic\":false}},\"Parent\":{\"Namespace\":\"TeleportationValidate\",\"Name\":\"StandardTeleport_Reference\"},\"SourceFile\":\"/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs\",\"Position\":{\"Item1\":34,\"Item2\":4},\"HeaderRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":37}},\"Documentation\":[]}")]
[assembly: CallableDeclaration("{\"Kind\":{\"Case\":\"Operation\"},\"QualifiedName\":{\"Namespace\":\"TeleportationValidate\",\"Name\":\"SetAllToZero\"},\"SourceFile\":\"/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs\",\"Position\":{\"Item1\":43,\"Item2\":4},\"SymbolRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":23}},\"ArgumentTuple\":{\"Case\":\"QsTuple\",\"Fields\":[[{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"register\"]},\"Type\":{\"Case\":\"ArrayType\",\"Fields\":[{\"Case\":\"Qubit\"}]},\"InferredInformation\":{\"IsMutable\":false,\"HasLocalQuantumDependency\":false},\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":24},\"Item2\":{\"Line\":1,\"Column\":32}}}]}]]},\"Signature\":{\"TypeParameters\":[],\"ArgumentType\":{\"Case\":\"ArrayType\",\"Fields\":[{\"Case\":\"Qubit\"}]},\"ReturnType\":{\"Case\":\"UnitType\"},\"Information\":{\"Affiliation\":{\"Case\":\"EmptySet\"},\"InferredInformation\":{\"IsSelfAdjoint\":false,\"IsIntrinsic\":false}}},\"Documentation\":[]}")]
[assembly: SpecializationDeclaration("{\"Kind\":{\"Case\":\"QsBody\"},\"TypeArguments\":{\"Case\":\"Null\"},\"Information\":{\"Affiliation\":{\"Case\":\"EmptySet\"},\"InferredInformation\":{\"IsSelfAdjoint\":false,\"IsIntrinsic\":false}},\"Parent\":{\"Namespace\":\"TeleportationValidate\",\"Name\":\"SetAllToZero\"},\"SourceFile\":\"/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs\",\"Position\":{\"Item1\":43,\"Item2\":4},\"HeaderRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":23}},\"Documentation\":[]}")]
[assembly: CallableDeclaration("{\"Kind\":{\"Case\":\"Operation\"},\"QualifiedName\":{\"Namespace\":\"TeleportationValidate\",\"Name\":\"Measurement\"},\"SourceFile\":\"/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs\",\"Position\":{\"Item1\":53,\"Item2\":4},\"SymbolRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":22}},\"ArgumentTuple\":{\"Case\":\"QsTuple\",\"Fields\":[[{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"num\"]},\"Type\":{\"Case\":\"Int\"},\"InferredInformation\":{\"IsMutable\":false,\"HasLocalQuantumDependency\":false},\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":24},\"Item2\":{\"Line\":1,\"Column\":27}}}]},{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"theta\"]},\"Type\":{\"Case\":\"Double\"},\"InferredInformation\":{\"IsMutable\":false,\"HasLocalQuantumDependency\":false},\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":35},\"Item2\":{\"Line\":1,\"Column\":40}}}]},{\"Case\":\"QsTupleItem\",\"Fields\":[{\"VariableName\":{\"Case\":\"ValidName\",\"Fields\":[\"phi\"]},\"Type\":{\"Case\":\"Double\"},\"InferredInformation\":{\"IsMutable\":false,\"HasLocalQuantumDependency\":false},\"Position\":{\"Case\":\"Null\"},\"Range\":{\"Item1\":{\"Line\":1,\"Column\":51},\"Item2\":{\"Line\":1,\"Column\":54}}}]}]]},\"Signature\":{\"TypeParameters\":[],\"ArgumentType\":{\"Case\":\"TupleType\",\"Fields\":[[{\"Case\":\"Int\"},{\"Case\":\"Double\"},{\"Case\":\"Double\"}]]},\"ReturnType\":{\"Case\":\"Int\"},\"Information\":{\"Affiliation\":{\"Case\":\"EmptySet\"},\"InferredInformation\":{\"IsSelfAdjoint\":false,\"IsIntrinsic\":false}}},\"Documentation\":[]}")]
[assembly: SpecializationDeclaration("{\"Kind\":{\"Case\":\"QsBody\"},\"TypeArguments\":{\"Case\":\"Null\"},\"Information\":{\"Affiliation\":{\"Case\":\"EmptySet\"},\"InferredInformation\":{\"IsSelfAdjoint\":false,\"IsIntrinsic\":false}},\"Parent\":{\"Namespace\":\"TeleportationValidate\",\"Name\":\"Measurement\"},\"SourceFile\":\"/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs\",\"Position\":{\"Item1\":53,\"Item2\":4},\"HeaderRange\":{\"Item1\":{\"Line\":1,\"Column\":11},\"Item2\":{\"Line\":1,\"Column\":22}},\"Documentation\":[]}")]
#line hidden
namespace TeleportationValidate
{
    public partial class Entangle_Reference : Adjointable<(Qubit,Qubit)>, ICallable
    {
        public Entangle_Reference(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Qubit,Qubit)>, IApplyData
        {
            public In((Qubit,Qubit) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits
            {
                get
                {
                    yield return Data.Item1;
                    yield return Data.Item2;
                }
            }
        }

        String ICallable.Name => "Entangle_Reference";
        String ICallable.FullName => "TeleportationValidate.Entangle_Reference";
        protected IUnitary<(Qubit,Qubit)> MicrosoftQuantumIntrinsicCNOT
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumIntrinsicH
        {
            get;
            set;
        }

        public override Func<(Qubit,Qubit), QVoid> Body => (__in__) =>
        {
            var (qAlice,qBob) = __in__;
#line 10 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
            MicrosoftQuantumIntrinsicH.Apply(qAlice);
#line 11 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
            MicrosoftQuantumIntrinsicCNOT.Apply((qAlice, qBob));
#line hidden
            return QVoid.Instance;
        }

        ;
        public override Func<(Qubit,Qubit), QVoid> AdjointBody => (__in__) =>
        {
            var (qAlice,qBob) = __in__;
#line hidden
            MicrosoftQuantumIntrinsicCNOT.Adjoint.Apply((qAlice, qBob));
#line hidden
            MicrosoftQuantumIntrinsicH.Adjoint.Apply(qAlice);
#line hidden
            return QVoid.Instance;
        }

        ;
        public override void Init()
        {
            this.MicrosoftQuantumIntrinsicCNOT = this.Factory.Get<IUnitary<(Qubit,Qubit)>>(typeof(Microsoft.Quantum.Intrinsic.CNOT));
            this.MicrosoftQuantumIntrinsicH = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Intrinsic.H));
        }

        public override IApplyData __dataIn((Qubit,Qubit) data) => new In(data);
        public override IApplyData __dataOut(QVoid data) => data;
        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Qubit qAlice, Qubit qBob)
        {
            return __m__.Run<Entangle_Reference, (Qubit,Qubit), QVoid>((qAlice, qBob));
        }
    }

    public partial class SendMessage_Reference : Operation<(Qubit,Qubit), (Boolean,Boolean)>, ICallable
    {
        public SendMessage_Reference(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Qubit,Qubit)>, IApplyData
        {
            public In((Qubit,Qubit) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits
            {
                get
                {
                    yield return Data.Item1;
                    yield return Data.Item2;
                }
            }
        }

        public class Out : QTuple<(Boolean,Boolean)>, IApplyData
        {
            public Out((Boolean,Boolean) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => null;
        }

        String ICallable.Name => "SendMessage_Reference";
        String ICallable.FullName => "TeleportationValidate.SendMessage_Reference";
        protected IUnitary<(Qubit,Qubit)> MicrosoftQuantumIntrinsicCNOT
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumIntrinsicH
        {
            get;
            set;
        }

        protected ICallable<Qubit, Result> MicrosoftQuantumIntrinsicM
        {
            get;
            set;
        }

        public override Func<(Qubit,Qubit), (Boolean,Boolean)> Body => (__in__) =>
        {
            var (qAlice,qMessage) = __in__;
#line 17 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
            MicrosoftQuantumIntrinsicCNOT.Apply((qMessage, qAlice));
#line 18 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
            MicrosoftQuantumIntrinsicH.Apply(qMessage);
#line 19 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
            return ((MicrosoftQuantumIntrinsicM.Apply(qMessage) == Result.One), (MicrosoftQuantumIntrinsicM.Apply(qAlice) == Result.One));
        }

        ;
        public override void Init()
        {
            this.MicrosoftQuantumIntrinsicCNOT = this.Factory.Get<IUnitary<(Qubit,Qubit)>>(typeof(Microsoft.Quantum.Intrinsic.CNOT));
            this.MicrosoftQuantumIntrinsicH = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Intrinsic.H));
            this.MicrosoftQuantumIntrinsicM = this.Factory.Get<ICallable<Qubit, Result>>(typeof(Microsoft.Quantum.Intrinsic.M));
        }

        public override IApplyData __dataIn((Qubit,Qubit) data) => new In(data);
        public override IApplyData __dataOut((Boolean,Boolean) data) => new Out(data);
        public static System.Threading.Tasks.Task<(Boolean,Boolean)> Run(IOperationFactory __m__, Qubit qAlice, Qubit qMessage)
        {
            return __m__.Run<SendMessage_Reference, (Qubit,Qubit), (Boolean,Boolean)>((qAlice, qMessage));
        }
    }

    public partial class ReconstructMessage_Reference : Operation<(Qubit,(Boolean,Boolean)), QVoid>, ICallable
    {
        public ReconstructMessage_Reference(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Qubit,(Boolean,Boolean))>, IApplyData
        {
            public In((Qubit,(Boolean,Boolean)) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits
            {
                get
                {
                    yield return Data.Item1;
                }
            }
        }

        String ICallable.Name => "ReconstructMessage_Reference";
        String ICallable.FullName => "TeleportationValidate.ReconstructMessage_Reference";
        protected IUnitary<Qubit> MicrosoftQuantumIntrinsicX
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumIntrinsicZ
        {
            get;
            set;
        }

        public override Func<(Qubit,(Boolean,Boolean)), QVoid> Body => (__in__) =>
        {
            var (qBob,(b1,b2)) = __in__;
#line 25 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
            if (b1)
            {
#line 26 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
                MicrosoftQuantumIntrinsicZ.Apply(qBob);
            }

#line 28 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
            if (b2)
            {
#line 29 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
                MicrosoftQuantumIntrinsicX.Apply(qBob);
            }

#line hidden
            return QVoid.Instance;
        }

        ;
        public override void Init()
        {
            this.MicrosoftQuantumIntrinsicX = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Intrinsic.X));
            this.MicrosoftQuantumIntrinsicZ = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Intrinsic.Z));
        }

        public override IApplyData __dataIn((Qubit,(Boolean,Boolean)) data) => new In(data);
        public override IApplyData __dataOut(QVoid data) => data;
        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Qubit qBob, Boolean b1, Boolean b2)
        {
            return __m__.Run<ReconstructMessage_Reference, (Qubit,(Boolean,Boolean)), QVoid>((qBob, (b1, b2)));
        }
    }

    public partial class StandardTeleport_Reference : Operation<(Qubit,Qubit,Qubit), QVoid>, ICallable
    {
        public StandardTeleport_Reference(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Qubit,Qubit,Qubit)>, IApplyData
        {
            public In((Qubit,Qubit,Qubit) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits
            {
                get
                {
                    yield return Data.Item1;
                    yield return Data.Item2;
                    yield return Data.Item3;
                }
            }
        }

        String ICallable.Name => "StandardTeleport_Reference";
        String ICallable.FullName => "TeleportationValidate.StandardTeleport_Reference";
        protected IAdjointable<(Qubit,Qubit)> Entangle_Reference
        {
            get;
            set;
        }

        protected ICallable<(Qubit,(Boolean,Boolean)), QVoid> ReconstructMessage_Reference
        {
            get;
            set;
        }

        protected ICallable<(Qubit,Qubit), (Boolean,Boolean)> SendMessage_Reference
        {
            get;
            set;
        }

        public override Func<(Qubit,Qubit,Qubit), QVoid> Body => (__in__) =>
        {
            var (qAlice,qBob,qMessage) = __in__;
#line 36 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
            Entangle_Reference.Apply((qAlice, qBob));
#line 37 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
            var classicalBits = SendMessage_Reference.Apply((qAlice, qMessage));
#line 41 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
            ReconstructMessage_Reference.Apply((qBob, classicalBits));
#line hidden
            return QVoid.Instance;
        }

        ;
        public override void Init()
        {
            this.Entangle_Reference = this.Factory.Get<IAdjointable<(Qubit,Qubit)>>(typeof(Entangle_Reference));
            this.ReconstructMessage_Reference = this.Factory.Get<ICallable<(Qubit,(Boolean,Boolean)), QVoid>>(typeof(ReconstructMessage_Reference));
            this.SendMessage_Reference = this.Factory.Get<ICallable<(Qubit,Qubit), (Boolean,Boolean)>>(typeof(SendMessage_Reference));
        }

        public override IApplyData __dataIn((Qubit,Qubit,Qubit) data) => new In(data);
        public override IApplyData __dataOut(QVoid data) => data;
        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, Qubit qAlice, Qubit qBob, Qubit qMessage)
        {
            return __m__.Run<StandardTeleport_Reference, (Qubit,Qubit,Qubit), QVoid>((qAlice, qBob, qMessage));
        }
    }

    public partial class SetAllToZero : Operation<IQArray<Qubit>, QVoid>, ICallable
    {
        public SetAllToZero(IOperationFactory m) : base(m)
        {
        }

        String ICallable.Name => "SetAllToZero";
        String ICallable.FullName => "TeleportationValidate.SetAllToZero";
        protected ICallable<Qubit, Result> MicrosoftQuantumIntrinsicM
        {
            get;
            set;
        }

        protected IUnitary<Qubit> MicrosoftQuantumIntrinsicX
        {
            get;
            set;
        }

        public override Func<IQArray<Qubit>, QVoid> Body => (__in__) =>
        {
            var register = __in__;
#line 46 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
            foreach (var i in new Range(0L, 2L))
#line hidden
            {
#line 47 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
                if ((MicrosoftQuantumIntrinsicM.Apply(register[i]) != Result.Zero))
                {
#line 48 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
                    MicrosoftQuantumIntrinsicX.Apply(register[i]);
                }
            }

#line hidden
            return QVoid.Instance;
        }

        ;
        public override void Init()
        {
            this.MicrosoftQuantumIntrinsicM = this.Factory.Get<ICallable<Qubit, Result>>(typeof(Microsoft.Quantum.Intrinsic.M));
            this.MicrosoftQuantumIntrinsicX = this.Factory.Get<IUnitary<Qubit>>(typeof(Microsoft.Quantum.Intrinsic.X));
        }

        public override IApplyData __dataIn(IQArray<Qubit> data) => data;
        public override IApplyData __dataOut(QVoid data) => data;
        public static System.Threading.Tasks.Task<QVoid> Run(IOperationFactory __m__, IQArray<Qubit> register)
        {
            return __m__.Run<SetAllToZero, IQArray<Qubit>, QVoid>(register);
        }
    }

    public partial class Measurement : Operation<(Int64,Double,Double), Int64>, ICallable
    {
        public Measurement(IOperationFactory m) : base(m)
        {
        }

        public class In : QTuple<(Int64,Double,Double)>, IApplyData
        {
            public In((Int64,Double,Double) data) : base(data)
            {
            }

            System.Collections.Generic.IEnumerable<Qubit> IApplyData.Qubits => null;
        }

        String ICallable.Name => "Measurement";
        String ICallable.FullName => "TeleportationValidate.Measurement";
        protected Allocate Allocate
        {
            get;
            set;
        }

        protected ICallable<Qubit, Result> MicrosoftQuantumIntrinsicM
        {
            get;
            set;
        }

        protected IUnitary<(Double,Qubit)> MicrosoftQuantumIntrinsicR1
        {
            get;
            set;
        }

        protected Release Release
        {
            get;
            set;
        }

        protected ICallable<IQArray<Qubit>, QVoid> MicrosoftQuantumIntrinsicResetAll
        {
            get;
            set;
        }

        protected IUnitary<(Double,Qubit)> MicrosoftQuantumIntrinsicRy
        {
            get;
            set;
        }

        protected ICallable<IQArray<Qubit>, QVoid> SetAllToZero
        {
            get;
            set;
        }

        protected ICallable<(Qubit,Qubit,Qubit), QVoid> StandardTeleport_Reference
        {
            get;
            set;
        }

        public override Func<(Int64,Double,Double), Int64> Body => (__in__) =>
        {
            var (num,theta,phi) = __in__;
#line 56 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
            var count = 0L;
#line hidden
            {
#line 58 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
                var qubits = Allocate.Apply(3L);
#line hidden
                Exception __arg1__ = null;
                try
                {
#line 60 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
                    var qAlice = qubits[0L];
#line 61 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
                    var qBob = qubits[1L];
#line 62 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
                    var qMessage = qubits[2L];
#line 64 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
                    foreach (var i in new Range(1L, num))
#line hidden
                    {
#line 66 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
                        SetAllToZero.Apply(qubits);
#line 67 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
                        MicrosoftQuantumIntrinsicRy.Apply((theta, qMessage));
#line 68 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
                        MicrosoftQuantumIntrinsicR1.Apply((phi, qMessage));
#line 70 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
                        StandardTeleport_Reference.Apply((qAlice, qBob, qMessage));
#line 72 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
                        if ((MicrosoftQuantumIntrinsicM.Apply(qBob) == Result.Zero))
                        {
#line 72 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
                            count = (count + 1L);
                        }
                    }

#line 75 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
                    MicrosoftQuantumIntrinsicResetAll.Apply(qubits);
                }
#line hidden
                catch (Exception __arg2__)
                {
                    __arg1__ = __arg2__;
                    throw __arg1__;
                }
#line hidden
                finally
                {
                    if (__arg1__ != null)
                    {
                        throw __arg1__;
                    }

#line hidden
                    Release.Apply(qubits);
                }
            }

#line 78 "/var/autofs/home/s_home/sh726/Desktop/TeleportationValidate/Operations.qs"
            return count;
        }

        ;
        public override void Init()
        {
            this.Allocate = this.Factory.Get<Allocate>(typeof(Microsoft.Quantum.Intrinsic.Allocate));
            this.MicrosoftQuantumIntrinsicM = this.Factory.Get<ICallable<Qubit, Result>>(typeof(Microsoft.Quantum.Intrinsic.M));
            this.MicrosoftQuantumIntrinsicR1 = this.Factory.Get<IUnitary<(Double,Qubit)>>(typeof(Microsoft.Quantum.Intrinsic.R1));
            this.Release = this.Factory.Get<Release>(typeof(Microsoft.Quantum.Intrinsic.Release));
            this.MicrosoftQuantumIntrinsicResetAll = this.Factory.Get<ICallable<IQArray<Qubit>, QVoid>>(typeof(Microsoft.Quantum.Intrinsic.ResetAll));
            this.MicrosoftQuantumIntrinsicRy = this.Factory.Get<IUnitary<(Double,Qubit)>>(typeof(Microsoft.Quantum.Intrinsic.Ry));
            this.SetAllToZero = this.Factory.Get<ICallable<IQArray<Qubit>, QVoid>>(typeof(SetAllToZero));
            this.StandardTeleport_Reference = this.Factory.Get<ICallable<(Qubit,Qubit,Qubit), QVoid>>(typeof(StandardTeleport_Reference));
        }

        public override IApplyData __dataIn((Int64,Double,Double) data) => new In(data);
        public override IApplyData __dataOut(Int64 data) => new QTuple<Int64>(data);
        public static System.Threading.Tasks.Task<Int64> Run(IOperationFactory __m__, Int64 num, Double theta, Double phi)
        {
            return __m__.Run<Measurement, (Int64,Double,Double), Int64>((num, theta, phi));
        }
    }
}