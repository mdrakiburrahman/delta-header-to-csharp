using System.Runtime.InteropServices;

namespace DeltaLake.Kernel.Rust.Ffi;

[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
public unsafe delegate void CScanCallback([NativeTypeName("NullableCvoid")] void* engine_context, [NativeTypeName("struct KernelStringSlice")] KernelStringSlice path, [NativeTypeName("int64_t")] long size, [NativeTypeName("const struct Stats *")] Stats* stats, [NativeTypeName("const struct DvInfo *")] DvInfo* dv_info, [NativeTypeName("const struct CStringMap *")] CStringMap* partition_map);
