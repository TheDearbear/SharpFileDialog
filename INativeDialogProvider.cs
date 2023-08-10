namespace SharpFileDialog
{
    internal interface INativeDialogProvider
    {
        bool CurrentPlatformSupported { get; }
        int Priority { get; }

        bool OpenDialog(NativeFileDialog.Filter[]? filters, string? defaultPath, out string? outPath);

        bool OpenDialogMultiple(NativeFileDialog.Filter[]? filters, string? defaultPath, out string[]? outPaths);

        bool SaveDialog(NativeFileDialog.Filter[]? filters, string? defaultPath, out string? outPath);

        bool PickFolder(string? defaultPath, out string? outPath);
    }
}
