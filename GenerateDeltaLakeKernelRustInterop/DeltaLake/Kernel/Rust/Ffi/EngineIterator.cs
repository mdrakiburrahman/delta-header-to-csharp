using System;

namespace DeltaLake.Kernel.Rust.Ffi;

public unsafe partial struct EngineIterator
{
    public void* data;

    [NativeTypeName("const void *(*)(void *)")]
    public IntPtr get_next;
}
