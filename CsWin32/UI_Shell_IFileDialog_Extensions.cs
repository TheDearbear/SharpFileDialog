using System;
using Windows.Win32.Foundation;
using Windows.Win32.UI.Shell;
using Windows.Win32.UI.Shell.Common;

#if NET6_0_OR_GREATER
using System.Runtime.Versioning;
#endif

namespace Windows.Win32
{
#if NET6_0_OR_GREATER
    [SupportedOSPlatform("windows6.0.6000")]
#endif
    internal static partial class UI_Shell_IFileDialog_Extensions
    {
        /// <inheritdoc cref="IFileDialog.SetFileTypes(uint, COMDLG_FILTERSPEC*)"/>
        internal static unsafe HRESULT SetFileTypes(this IFileDialog @this, ReadOnlySpan<COMDLG_FILTERSPEC> rgFilterSpec)
        {
            fixed (COMDLG_FILTERSPEC* rgFilterSpecLocal = rgFilterSpec)
            {
                return @this.SetFileTypes((uint)rgFilterSpec.Length, rgFilterSpecLocal);
            }
        }

        /// <inheritdoc cref="IFileDialog.GetOptions(FILEOPENDIALOGOPTIONS*)"/>
        internal static unsafe HRESULT GetOptions(this IFileDialog @this, out FILEOPENDIALOGOPTIONS pfos)
        {
            fixed (FILEOPENDIALOGOPTIONS* pfosLocal = &pfos)
            {
                return @this.GetOptions(pfosLocal);
            }
        }

        /// <inheritdoc cref="IFileDialog.SetFileName(PCWSTR)"/>
        internal static unsafe HRESULT SetFileName(this IFileDialog @this, string pszName)
        {
            fixed (char* pszNameLocal = pszName)
            {
                return @this.SetFileName(pszNameLocal);
            }
        }

        /// <inheritdoc cref="IFileDialog.GetFileName(PWSTR*)"/>
        internal static unsafe HRESULT GetFileName(this IFileDialog @this, out PWSTR pszName)
        {
            fixed (PWSTR* pszNameLocal = &pszName)
            {
                return @this.GetFileName(pszNameLocal);
            }
        }

        /// <inheritdoc cref="IFileDialog.SetTitle(PCWSTR)"/>
        internal static unsafe HRESULT SetTitle(this IFileDialog @this, string pszTitle)
        {
            fixed (char* pszTitleLocal = pszTitle)
            {
                return @this.SetTitle(pszTitleLocal);
            }
        }

        /// <inheritdoc cref="IFileDialog.SetOkButtonLabel(PCWSTR)"/>
        internal static unsafe HRESULT SetOkButtonLabel(this IFileDialog @this, string pszText)
        {
            fixed (char* pszTextLocal = pszText)
            {
                return @this.SetOkButtonLabel(pszTextLocal);
            }
        }

        /// <inheritdoc cref="IFileDialog.SetFileNameLabel(PCWSTR)"/>
        internal static unsafe HRESULT SetFileNameLabel(this IFileDialog @this, string pszLabel)
        {
            fixed (char* pszLabelLocal = pszLabel)
            {
                return @this.SetFileNameLabel(pszLabelLocal);
            }
        }

        /// <inheritdoc cref="IFileDialog.SetDefaultExtension(PCWSTR)"/>
        internal static unsafe HRESULT SetDefaultExtension(this IFileDialog @this, string pszDefaultExtension)
        {
            fixed (char* pszDefaultExtensionLocal = pszDefaultExtension)
            {
                return @this.SetDefaultExtension(pszDefaultExtensionLocal);
            }
        }

        /// <inheritdoc cref="IFileDialog.SetClientGuid(Guid*)"/>
        internal static unsafe HRESULT SetClientGuid(this IFileDialog @this, in Guid guid)
        {
            fixed (Guid* guidLocal = &guid)
            {
                return @this.SetClientGuid(guidLocal);
            }
        }
    }
}
