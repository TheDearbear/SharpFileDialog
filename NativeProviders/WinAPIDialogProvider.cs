using System;
using Windows.Win32;
using Windows.Win32.System.Com;
using Windows.Win32.Foundation;
using Windows.Win32.UI.Shell;
using Windows.Win32.UI.Shell.Common;
using System.Runtime.InteropServices;

#if NET6_0_OR_GREATER
using System.Runtime.Versioning;
#endif

namespace SharpFileDialog.NativeProviders
{
#if NET6_0_OR_GREATER
    [SupportedOSPlatform("windows6.0.6000")]
#endif
    internal class WinAPIDialogProvider : INativeDialogProvider
    {
        public bool CurrentPlatformSupported => RuntimeInformation.IsOSPlatform(OSPlatform.Windows) &&
            (Environment.OSVersion.Version.Major > 6 ||
            (Environment.OSVersion.Version.Major == 6 && (Environment.OSVersion.Version.Minor > 0 || Environment.OSVersion.Version.Build >= 6000)));
        public int Priority => 20;

        public bool OpenDialog(NativeFileDialog.Filter[]? filters, string? defaultPath, out string? outPath)
        {
            int comInitResult = InitializeCOM();
            Exception? error = null;
            outPath = null;

            Guid clsid = new("DC1C5A9C-E88A-4dde-A5A1-60F82A20AEF7");
            HRESULT result = PInvoke.CoCreateInstance(in clsid, null, CLSCTX.CLSCTX_ALL, out IFileOpenDialog dialog);
            if (result.Failed)
            {
                error = new COMException("Could not create dialog.", result);
                goto end;
            }

            if (filters is not null)
                AddFiltersToDialog(dialog, filters);

            if (defaultPath is not null)
                SetDefaultPath(dialog, defaultPath);

            try
            {
                result = dialog.Show(HWND.Null);
                if (result.Failed)
                {
                    error = new COMException("File dialog box show failed.", result);
                    goto end;
                }
            }
            catch (COMException e)
            {
                if (e.HResult != PInvoke.HRESULT_FROM_WIN32(WIN32_ERROR.ERROR_CANCELLED))
                {
                    error = e;
                }
                goto end;
            }

            result = dialog.GetResult(out var shellItem);
            if (result.Failed)
            {
                error = new COMException("Could not get ShellItem from dialog.", result);
                goto end;
            }

            shellItem.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out var name);
            outPath = name.ToString();
            unsafe { PInvoke.CoTaskMemFree(name); }

            Marshal.FinalReleaseComObject(shellItem);

        end:
            if (dialog is not null)
                Marshal.FinalReleaseComObject(dialog);

            if (comInitResult >= 0)
                PInvoke.CoUninitialize();

            if (error is not null)
                throw error;

            return outPath is not null;
        }

        public bool OpenDialogMultiple(NativeFileDialog.Filter[]? filters, string? defaultPath, out string[]? outPaths)
        {
            int comInitResult = InitializeCOM();
            Exception? error = null;
            outPaths = null;

            Guid clsid = new("DC1C5A9C-E88A-4dde-A5A1-60F82A20AEF7");
            HRESULT result = PInvoke.CoCreateInstance(in clsid, null, CLSCTX.CLSCTX_ALL, out IFileOpenDialog dialog);
            if (result.Failed)
            {
                error = new COMException("Could not create dialog.", result);
                goto end;
            }

            if (filters is not null)
                AddFiltersToDialog(dialog, filters);

            if (defaultPath is not null)
                SetDefaultPath(dialog, defaultPath);

            dialog.GetOptions(out var options);
            dialog.SetOptions(options | FILEOPENDIALOGOPTIONS.FOS_ALLOWMULTISELECT);

            try
            {
                result = dialog.Show(HWND.Null);
                if (result.Failed)
                {
                    error = new COMException("File dialog box show failed.", result);
                    goto end;
                }
            }
            catch (COMException e)
            {
                if (e.HResult != PInvoke.HRESULT_FROM_WIN32(WIN32_ERROR.ERROR_CANCELLED))
                {
                    error = e;
                }
                goto end;
            }

            result = dialog.GetResults(out var shellItems);
            if (result.Failed)
            {
                error = new COMException("Could not get ShellItemArray from dialog.", result);
                goto end;
            }

            shellItems.GetCount(out uint count);
            outPaths = new string[count];
            for (uint i = 0; i < count; i++)
            {
                shellItems.GetItemAt(i, out var item);
                item.GetDisplayName(SIGDN.SIGDN_DESKTOPABSOLUTEPARSING, out var name);
                outPaths[i] = name.ToString();
                unsafe { PInvoke.CoTaskMemFree(name); }
            }

            Marshal.FinalReleaseComObject(shellItems);

        end:
            if (dialog is not null)
                Marshal.FinalReleaseComObject(dialog);

            if (comInitResult >= 0)
                PInvoke.CoUninitialize();

            if (error is not null)
                throw error;

            return outPaths is not null;
        }

        public bool PickFolder(string? defaultPath, out string? outPath)
        {
            int comInitResult = InitializeCOM();
            Exception? error = null;
            outPath = null;

            Guid clsid = new("DC1C5A9C-E88A-4dde-A5A1-60F82A20AEF7");
            HRESULT result = PInvoke.CoCreateInstance(in clsid, null, CLSCTX.CLSCTX_ALL, out IFileOpenDialog dialog);
            if (result.Failed)
            {
                error = new COMException("Could not create dialog.", result);
                goto end;
            }

            if (defaultPath is not null)
                SetDefaultPath(dialog, defaultPath);

            dialog.GetOptions(out var options);
            dialog.SetOptions(options | FILEOPENDIALOGOPTIONS.FOS_PICKFOLDERS);

            try
            {
                result = dialog.Show(HWND.Null);
                if (result.Failed)
                {
                    error = new COMException("File dialog box show failed.", result);
                    goto end;
                }
            }
            catch (COMException e)
            {
                if (e.HResult != PInvoke.HRESULT_FROM_WIN32(WIN32_ERROR.ERROR_CANCELLED))
                {
                    error = e;
                }
                goto end;
            }

            result = dialog.GetResult(out var shellItem);
            if (result.Failed)
            {
                error = new COMException("Could not get ShellItem from dialog.", result);
                goto end;
            }

            shellItem.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out var name);
            outPath = name.ToString();
            unsafe { PInvoke.CoTaskMemFree(name); }

            Marshal.FinalReleaseComObject(shellItem);

        end:
            if (dialog is not null)
                Marshal.FinalReleaseComObject(dialog);

            if (comInitResult >= 0)
                PInvoke.CoUninitialize();

            if (error is not null)
                throw error;

            return outPath is not null;
        }

        public bool SaveDialog(NativeFileDialog.Filter[]? filters, string? defaultPath, out string? outPath)
        {
            HRESULT comInitResult = InitializeCOM();
            Exception? error = null;
            outPath = null;

            Guid clsid = new("C0B4E2F3-BA21-4773-8DBA-335EC946EB8B");
            HRESULT result = PInvoke.CoCreateInstance(in clsid, null, CLSCTX.CLSCTX_ALL, out IFileSaveDialog dialog);
            if (result.Failed)
            {
                error = new COMException("Could not create dialog.", result);
                goto end;
            }

            if (filters is not null)
                AddFiltersToDialog(dialog, filters);

            if (defaultPath is not null)
                SetDefaultPath(dialog, defaultPath);

            try
            {
                result = dialog.Show(HWND.Null);
                if (result.Failed)
                {
                    error = new COMException("File dialog box show failed.", result);
                    goto end;
                }
            }
            catch (COMException e)
            {
                if (e.HResult != PInvoke.HRESULT_FROM_WIN32(WIN32_ERROR.ERROR_CANCELLED))
                {
                    error = e;
                }
                goto end;
            }

            result = dialog.GetResult(out var shellItem);
            if (result.Failed)
            {
                error = new COMException("Could not get ShellItem from dialog.", result);
                goto end;
            }

            shellItem.GetDisplayName(SIGDN.SIGDN_FILESYSPATH, out var name);
            outPath = name.ToString();
            unsafe { PInvoke.CoTaskMemFree(name); }

            Marshal.FinalReleaseComObject(shellItem);

        end:
            if (dialog is not null)
                Marshal.FinalReleaseComObject(dialog);

            if (comInitResult.Succeeded)
                PInvoke.CoUninitialize();

            if (error is not null)
                throw error;

            return outPath is not null;
        }

        private static void SetDefaultPath(IFileDialog dialog, string defaultPath)
        {
            if (string.IsNullOrWhiteSpace(defaultPath))
                return;

            HRESULT result = SHCreateItemFromParsingName(defaultPath, null, out IShellItem folder);

            // Valid non results.
            if (result == PInvoke.HRESULT_FROM_WIN32(WIN32_ERROR.ERROR_FILE_NOT_FOUND) ||
                result == PInvoke.HRESULT_FROM_WIN32(WIN32_ERROR.ERROR_INVALID_DRIVE))
                return;

            if (result.Failed)
                throw new COMException("Error creating ShellItem", result);

            // Could also call SetDefaultFolder(), but this guarantees defaultPath -- more consistency across API.
            dialog.SetFolder(folder);
            Marshal.FinalReleaseComObject(folder);
        }

        private static void AddFiltersToDialog(IFileDialog dialog, NativeFileDialog.Filter[] filters)
        {
            if (filters.Length == 0) return;

            const string WILDCARD_NAME = "Any File";
            const string WILDCARD = "*.*";

            // filter.Length plus 1 because we hardcode the *.* wildcard after the while loop
            COMDLG_FILTERSPEC[] specList = new COMDLG_FILTERSPEC[filters.Length + 1];

            for (int i = 0; i < filters.Length; i++)
            {
                string filter = "*." + string.Join(";*.", filters[i].Extensions);

                unsafe
                {
                    fixed (char* pFilter = filter)
                        specList[i].pszSpec = new PCWSTR(pFilter);
                    fixed (char* pName = filters[i].Name)
                        specList[i].pszName = new PCWSTR(pName);
                }
            }

            // Add wildcard
            unsafe
            {
                fixed (char* pWildcard = WILDCARD)
                    specList[filters.Length].pszSpec = new PCWSTR(pWildcard);
                fixed (char* pWildcardName = WILDCARD_NAME)
                    specList[filters.Length].pszName = new PCWSTR(pWildcardName);
            }

            dialog.SetFileTypes(specList);
        }

        private static HRESULT InitializeCOM()
        {
            const int RPC_E_CHANGED_MODE = -2147417850;

            HRESULT comInitResult = PInvoke.CoInitializeEx(COINIT.COINIT_APARTMENTTHREADED | COINIT.COINIT_DISABLE_OLE1DDE);
            if (comInitResult != RPC_E_CHANGED_MODE && comInitResult.Failed)
            {
                throw new COMException("CoInitializeEx failed.", comInitResult);
            }

            return comInitResult;
        }

        /// <inheritdoc cref="PInvoke.SHCreateItemFromParsingName(string, IBindCtx, in Guid, out object)"/>
        private static HRESULT SHCreateItemFromParsingName<T>(string pszPath, IBindCtx? pbc, out T item) where T : class
        {
            HRESULT result = PInvoke.SHCreateItemFromParsingName(pszPath, pbc, typeof(T).GUID, out object ppv);
            item = (T)ppv;
            return result;
        }
    }
}
