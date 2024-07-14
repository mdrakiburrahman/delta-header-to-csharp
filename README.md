# Convert Delta Kernel Header to CSharp

## Links
* Root blog: [link](https://sharovarskyi.com/blog/posts/clangsharp-dotnet-interop-bindings/)
* Tool README: [link](https://github.com/dotnet/ClangSharp/tree/main)

Note: Although I have a devcontainer in the repo, `ClangSharp` doesn't work on Linux - see [here](https://github.com/dotnet/ClangSharp/issues/423). 
I could only get it to work on Windows.

This is fine, the build machine, if needed, can just be Windows type.

## Steps followed

```powershell
# Create a dummy project
#
dotnet new console -o GenerateDeltaLakeKernelRustInterop -n GenerateDeltaLakeKernelRustInterop

# Search the CLang compiler
#
winget search clang

# Name               Id                Version Match          Source
# ------------------------------------------------------------------
# LLVM               LLVM.LLVM         18.1.8  Command: clang winget
# clangd             LLVM.clangd       17.0.3  Tag: clang     winget
# CrossWorks for ARM Rowley.CrossWorks 4.8     Tag: clang     winget
# ClangFormat        LLVM.ClangFormat  18.1.6                 winget

winget install LLVM.LLVM --version 18.1.8

# To uninstall
#
winget uninstall LLVM.LLVM

# Check, with workaround for PowerShell
#
$env:PATH += ";C:\Program Files\LLVM\bin"
clang --version
# clang version 18.1.8
# Target: x86_64-pc-windows-msvc
# Thread model: posix
# InstalledDir: C:\Program Files\LLVM\bin

# https://github.com/dotnet/ClangSharp/issues/468

# Install the global dotnet tool
# 
# >>> https://www.nuget.org/packages/ClangSharpPInvokeGenerator
#
dotnet tool install --global ClangSharpPInvokeGenerator --version 18.1.0

# To uninstall
#
dotnet tool uninstall --global ClangSharpPInvokeGenerator

# View available config
#
ClangSharpPInvokeGenerator -c help

# Workarounds
#
# To get it to work on windows:
#
# 1. Removed #include <stdlib.h> from delta_kernel_ffi.h.
#
#    Thankfully, it doesn't use anything from there.
#
#    If a future release needs anything from there, I need to figure out how to get stdlib.h on Windows.
#    Or, I should open a PR to delta-kernel-rs and remove it.
#
# 2. Deleted the #if defined(DEFINE_DEFAULT_ENGINE)...#endif around:
#
#    - EngineBuilder
#    - ArrowFFIData.
#
#    Otherwise ClangSharpPInvokeGenerator doesn't build it.
#
#    This workaround is fine, although I'm not sure why these build flags are there in the first place.
#

# Clean, fire generation, test build
#
rm -Recurse GenerateDeltaLakeKernelRustInterop\DeltaLake, GenerateDeltaLakeKernelRustInterop\bin, GenerateDeltaLakeKernelRustInterop\obj
ClangSharpPInvokeGenerator `
    -c <# configuration for the generator#> `
    multi-file `
    generate-file-scoped-namespaces `
    generate-helper-types `
    generate-disable-runtime-marshalling `
    exclude-fnptr-codegen `
    exclude-anonymous-field-helpers `
    exclude-com-proxies exclude-default-remappings `
    --file ".\Delta-Kernel\delta_kernel_ffi.h" <# file we want to generate bindings for #>  `
    --include-directory "C:\Program Files\LLVM\lib\clang\18\include" <# include clang headers from LLVM installation earlier #> `
    -n "DeltaLake.Kernel.Rust.Ffi" <# namespace of the bindings #> `
    --methodClassName FfiNativeMethodsHandler <# class name where to put methods #> `
    --libraryPath delta_kernel_ffi <# name of the DLL where code will be referenced from via PInvoke #> `
    -o .\GenerateDeltaLakeKernelRustInterop\DeltaLake\Kernel\Rust\Ffi <# output folder #>
dotnet build .\GenerateDeltaLakeKernelRustInterop\GenerateDeltaLakeKernelRustInterop.csproj

#   Determining projects to restore...
#   All projects are up-to-date for restore.
#   GenerateDeltaLakeKernelRustInterop -> E:\git\delta-header-to-csharp\GenerateDeltaLakeKernelRustInterop\bin\Debug\net8.0\GenerateDeltaLakeKernelRustInterop.dll

# Build succeeded.
#     0 Warning(s)
#     0 Error(s)

# Time Elapsed 00:00:00.81
```
