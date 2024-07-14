using System.Runtime.InteropServices;

namespace DeltaLake.Kernel.Rust.Ffi;

public unsafe partial struct ExternResultusize
{
    public ExternResultusize_Tag tag;

    [NativeTypeName("__AnonymousRecord_delta_kernel_ffi_L490_C3")]
    public _Anonymous_e__Union Anonymous;

    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct _Anonymous_e__Union
    {
        [FieldOffset(0)]
        [NativeTypeName("__AnonymousRecord_delta_kernel_ffi_L491_C5")]
        public _Anonymous1_e__Struct Anonymous1;

        [FieldOffset(0)]
        [NativeTypeName("__AnonymousRecord_delta_kernel_ffi_L494_C5")]
        public _Anonymous2_e__Struct Anonymous2;

        public partial struct _Anonymous1_e__Struct
        {
            [NativeTypeName("uintptr_t")]
            public ulong ok;
        }

        public unsafe partial struct _Anonymous2_e__Struct
        {
            [NativeTypeName("struct EngineError *")]
            public EngineError* err;
        }
    }
}
