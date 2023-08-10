using System;
using System.Runtime.InteropServices;
using Windows.Win32.Foundation;
using Windows.Win32.UI.Shell.Common;

#if NET6_0_OR_GREATER
using System.Runtime.Versioning;
#endif

namespace Windows.Win32.UI.Shell
{
    [Guid("D57C7288-D4AD-4768-BE02-9D969532D960"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComImport()]
#if NET6_0_OR_GREATER
    [SupportedOSPlatform("windows6.0.6000")]
#endif
    internal interface IFileOpenDialog : IFileDialog
    {
        new HRESULT Show(HWND hwndOwner);

        unsafe new HRESULT SetFileTypes(uint cFileTypes, COMDLG_FILTERSPEC* rgFilterSpec);

        new HRESULT SetFileTypeIndex(uint iFileType);

        new HRESULT GetFileTypeIndex(out uint piFileType);

        new HRESULT Advise(IFileDialogEvents pfde, out uint pdwCookie);

        new HRESULT Unadvise(uint dwCookie);

        new HRESULT SetOptions(FILEOPENDIALOGOPTIONS fos);

        unsafe new HRESULT GetOptions(FILEOPENDIALOGOPTIONS* pfos);

        new HRESULT SetDefaultFolder(IShellItem psi);

        new HRESULT SetFolder(IShellItem psi);

        new HRESULT GetFolder(out IShellItem ppsi);

        new HRESULT GetCurrentSelection(out IShellItem ppsi);

        new HRESULT SetFileName(PCWSTR pszName);

        unsafe new HRESULT GetFileName(PWSTR* pszName);

        new HRESULT SetTitle(PCWSTR pszTitle);

        new HRESULT SetOkButtonLabel(PCWSTR pszText);

        new HRESULT SetFileNameLabel(PCWSTR pszLabel);

        new HRESULT GetResult(out IShellItem ppsi);

        new HRESULT AddPlace(IShellItem psi, FDAP fdap);

        new HRESULT SetDefaultExtension(PCWSTR pszDefaultExtension);

        new HRESULT Close(HRESULT hr);

        unsafe new HRESULT SetClientGuid(Guid* guid);

        new HRESULT ClearClientData();

        new HRESULT SetFilter(IShellItemFilter pFilter);

        /// <summary>Gets the user's choices in a dialog that allows multiple selection.</summary>
        /// <param name="ppenum">
        /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitemarray">IShellItemArray</a>**</b> The address of a pointer to an <b>IShellItemArray</b> through which the items selected in the dialog can be accessed.</para>
        /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifileopendialog-getresults#parameters">Read more on docs.microsoft.com</see>.</para>
        /// </param>
        /// <returns>
        /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
        /// </returns>
        /// <remarks>
        /// <para>This method can be used whether the selection consists of a single item or multiple items. <b>IFileOpenDialog::GetResults</b> can be called after the dialog has closed or during the handling of an IFileDialogEvents::OnFileOk event. Calling this method at any other time will fail.</para>
        /// <para><a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-imodalwindow-show">Show</a> must return a success code for a result to be available to <b>IFileOpenDialog::GetResults</b>.</para>
        /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifileopendialog-getresults#">Read more on docs.microsoft.com</see>.</para>
        /// </remarks>
        HRESULT GetResults(out IShellItemArray ppenum);

        /// <summary>Gets the currently selected items in the dialog. These items may be items selected in the view, or text selected in the file name edit box.</summary>
        /// <param name="ppsai">
        /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitemarray">IShellItemArray</a>**</b> The address of a pointer to an <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitemarray">IShellItemArray</a> through which the selected items can be accessed.</para>
        /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifileopendialog-getselecteditems#parameters">Read more on docs.microsoft.com</see>.</para>
        /// </param>
        /// <returns>
        /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
        /// </returns>
        /// <remarks>This method can be used for single item or multiple item selections. If the user has entered new text in the file name field, this can be a time-consuming operation. When the application calls this method, the application parses the text in the <c>filename</c> field. For example, if this is a network share, the operation could take some time. However, this operation will not block the UI, since the user should able to stop the operation, which will result in <b>IFileOpenDialog::GetSelectedItems</b> returning a failure code).</remarks>
        HRESULT GetSelectedItems(out IShellItemArray ppsai);
    }
}
