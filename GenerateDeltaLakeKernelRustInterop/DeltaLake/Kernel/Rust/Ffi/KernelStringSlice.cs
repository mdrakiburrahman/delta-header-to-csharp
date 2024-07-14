// -----------------------------------------------------------------------------
// <copyright company="The Delta Lake Project Authors">
// Copyright (2024) The Delta Lake Project Authors.  All rights reserved.
// Licensed under the Apache license. See LICENSE file in the project root for full license information.
// </copyright>
// -----------------------------------------------------------------------------

namespace DeltaLake.Kernel.Rust.Ffi;

public unsafe partial struct KernelStringSlice
{
    [NativeTypeName("const char *")]
    public sbyte* ptr;

    [NativeTypeName("uintptr_t")]
    public ulong len;
}
