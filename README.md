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
	static void Main()
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
  - WinAPI (Auto add extension on file save supported)
  - GTK

## Adding your own provider
You can use custom provider by setting property 'NativeFileDialog.Provider' or bundled providers with method 'NativeFileDialog.SetDefaultProvider()'.  
To create custom provider create new class, inherit interface `INativeDialogProvider` and add implementations.
