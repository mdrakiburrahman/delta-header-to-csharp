// -----------------------------------------------------------------------------
// <copyright company="The Delta Lake Project Authors">
// Copyright (2021) The Delta Lake Project Authors.  All rights reserved.
// Licensed under the Apache license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------------

using System.Runtime.InteropServices;

namespace DeltaLake.Kernel.Rust.Ffi;

public unsafe partial struct ExternResultArrowFFIData
{
    public ExternResultArrowFFIData_Tag tag;

    [NativeTypeName("__AnonymousRecord_delta_kernel_ffi_L691_C3")]
    public _Anonymous_e__Union Anonymous;

    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct _Anonymous_e__Union
    {
        [FieldOffset(0)]
        [NativeTypeName("__AnonymousRecord_delta_kernel_ffi_L692_C5")]
        public _Anonymous1_e__Struct Anonymous1;

        [FieldOffset(0)]
        [NativeTypeName("__AnonymousRecord_delta_kernel_ffi_L695_C5")]
        public _Anonymous2_e__Struct Anonymous2;

        public unsafe partial struct _Anonymous1_e__Struct
        {
            [NativeTypeName("struct ArrowFFIData *")]
            public ArrowFFIData* ok;
        }

        public unsafe partial struct _Anonymous2_e__Struct
        {
            [NativeTypeName("struct EngineError *")]
            public EngineError* err;
        }
    }
}
