namespace Delta.Kernel.Rust.Ffi;

public partial struct EngineError
{
    [NativeTypeName("enum KernelError")]
    public KernelError etype;
}
