using System.Runtime.InteropServices;

namespace DeltaLake.Kernel.Rust.Ffi;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
[return: NativeTypeName("struct EngineError *")]
public unsafe delegate EngineError* AllocateErrorFn([NativeTypeName("enum KernelError")] KernelError etype, [NativeTypeName("struct KernelStringSlice")] KernelStringSlice msg);
