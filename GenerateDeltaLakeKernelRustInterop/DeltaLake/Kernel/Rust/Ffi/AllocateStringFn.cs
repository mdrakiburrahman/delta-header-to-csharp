using System.Runtime.InteropServices;

namespace DeltaLake.Kernel.Rust.Ffi;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
[return: NativeTypeName("NullableCvoid")]
public unsafe delegate void* AllocateStringFn([NativeTypeName("struct KernelStringSlice")] KernelStringSlice kernel_str);
