using System;

namespace DeltaLake.Kernel.Rust.Ffi;

public unsafe partial struct EnginePredicate
{
    public void* predicate;

    [NativeTypeName("uintptr_t (*)(void *, struct KernelExpressionVisitorState *)")]
    public IntPtr visitor;
}
