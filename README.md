# SharpFileDialog
This library is a rewrite of [nativefiledialog](https://github.com/mlabbe/nativefiledialog) for dotnet.

## Usage
Include `SharpFileDialog` namespace and run methods from static class `NativeFileDialog`  
If you want to use filters just create and fill array of `NativeFileDialog.Filter` structs

## Example
```csharp
using SharpFileDialog;
    
class Example
{
	void Main()
	{
		if (NativeFileDialog.PickFolder(null, out string? folder))
			Console.WriteLine("Selected Folder: " + folder);
		else
			Console.WriteLine("Dialog was closed");
	}
}
```

## Providers
Currently supported dialog providers:
  - WinAPI
  - GTK+

## Adding your own provider
There is no way to add your own provider without recompiling library because class `NativeFileDialog` searches for providers inside library, but not outside  
But if you really need to add it, just create new class in project that inherits interface `INativeDialogProvider` and add implementations
