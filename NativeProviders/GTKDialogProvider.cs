using Gdk;
using Gtk;
using System;

namespace SharpFileDialog.NativeProviders;

internal class GTKDialogProvider : INativeDialogProvider
{
    public bool CurrentPlatformSupported => InitCheck();
    public int Priority => 10;

    public bool OpenDialog(NativeFileDialog.Filter[]? filters, string? defaultPath, out string? outPath)
    {
        ThrowOnPlatformUnsupported();

        var dialog = new FileChooserNative("Open", null, FileChooserAction.Open, "_Open", "_Cancel");

        /* Build the filter list */
        if (filters is not null)
            AddFiltersToDialog(dialog, filters);

        /* Set the default path */
        if (defaultPath is not null)
            SetDefaultPath(dialog, defaultPath);

        outPath = dialog.Run() == (int)ResponseType.Accept ? dialog.Filename : null;
        Destroy(dialog);
        return outPath is not null;
    }

    public bool OpenDialogMultiple(NativeFileDialog.Filter[]? filters, string? defaultPath, out string[]? outPaths)
    {
        ThrowOnPlatformUnsupported();

        var dialog = new FileChooserNative("Open", null, FileChooserAction.Open, "_Open", "_Cancel")
        {
            SelectMultiple = true
        };

        /* Build the filter list */
        if (filters is not null)
            AddFiltersToDialog(dialog, filters);

        /* Set the default path */
        if (defaultPath is not null)
            SetDefaultPath(dialog, defaultPath);

        outPaths = dialog.Run() == (int)ResponseType.Accept ? dialog.Filenames : null;
        Destroy(dialog);
        return outPaths is not null;
    }

    public bool SaveDialog(NativeFileDialog.Filter[]? filters, string? defaultPath, out string? outPath)
    {
        ThrowOnPlatformUnsupported();

        var dialog = new FileChooserNative("Save As", null, FileChooserAction.Save, "_Save", "_Cancel")
        {
            DoOverwriteConfirmation = true
        };

        /* Build the filter list */
        if (filters is not null)
            AddFiltersToDialog(dialog, filters);

        /* Set the default path */
        if (defaultPath is not null)
            SetDefaultPath(dialog, defaultPath);

        outPath = dialog.Run() == (int)ResponseType.Accept ? dialog.Filename : null;
        Destroy(dialog);
        return outPath is not null;
    }

    public bool PickFolder(string? defaultPath, out string? outPath)
    {
        ThrowOnPlatformUnsupported();

        var dialog = new FileChooserNative("Select Folder", null, FileChooserAction.SelectFolder, "_Select Folder", "_Cancel")
        {
            DoOverwriteConfirmation = true
        };

        /* Set the default path */
        if (defaultPath is not null)
            SetDefaultPath(dialog, defaultPath);

        outPath = dialog.Run() == (int)ResponseType.Accept ? dialog.Filename : null;
        Destroy(dialog);
        return outPath is not null;
    }

    static void ThrowOnPlatformUnsupported()
    {
        if (!InitCheck())
        {
            throw new PlatformNotSupportedException("Current platform does not support GTK or its version is not supported!");
        }
    }

    static bool InitCheck()
    {
        string[] args = Environment.GetCommandLineArgs();
        string name = args.Length > 0 ? args[0] : string.Empty;
        string[] gtkArgs = Array.Empty<string>();

        return Application.InitCheck(name, ref gtkArgs);
    }

    static void SetDefaultPath(IFileChooser widget, string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            return;

        widget.SetCurrentFolder(path);
    }

    static void AddFiltersToDialog(IFileChooser widget, NativeFileDialog.Filter[] filters)
    {
        if (filters.Length == 0)
            return;

        foreach (var filter in filters)
        {
            var fileFilter = new FileFilter
            {
                Name = filter.Name
            };

            foreach (var extension in filter.Extensions)
                fileFilter.AddPattern("*." + extension);

            widget.AddFilter(fileFilter);
        }

        /* always append a wildcard option to the end*/

        var wildcard = new FileFilter { Name = "Any File" };
        wildcard.AddPattern("*");
        widget.AddFilter(wildcard);
    }

    static void Destroy(NativeDialog obj)
    {
        while (Events.Pending())
            Main.Iteration();

        obj.Destroy();
    }
}
