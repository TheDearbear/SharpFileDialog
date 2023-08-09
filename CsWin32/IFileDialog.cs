using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Windows.Win32.Foundation;
using Windows.Win32.UI.Shell.Common;

namespace Windows.Win32.UI.Shell;

[Guid("42F85136-DB7E-439C-85F1-E4075D135FC8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComImport()]
[SupportedOSPlatform("windows6.0.6000")]
internal interface IFileDialog : IModalWindow
{
    new HRESULT Show(HWND hwndOwner);

    /// <summary>Sets the file types that the dialog can open or save.</summary>
    /// <param name="cFileTypes">
    /// <para>Type: <b>UINT</b> The number of elements in the array specified by <i>rgFilterSpec</i>.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setfiletypes#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <param name="rgFilterSpec">
    /// <para>Type: <b>const <a href="https://docs.microsoft.com/windows/desktop/api/shtypes/ns-shtypes-comdlg_filterspec">COMDLG_FILTERSPEC</a>*</b> A pointer to an array of <a href="https://docs.microsoft.com/windows/desktop/api/shtypes/ns-shtypes-comdlg_filterspec">COMDLG_FILTERSPEC</a> structures, each representing a file type.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setfiletypes#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If the method succeeds, it returns S_OK. Otherwise, it returns an HRESULT error code, including the following: </para>
    /// <para>This doc was truncated.</para>
    /// </returns>
    /// <remarks>
    /// <para>When using the <b>Open</b> dialog, the file types declared there are used to filter the view. When using the <b>Save</b> dialog, these values determine which file name extension is appended to the file name. This method must be called before the dialog is shown and can only be called once for each dialog instance. File types cannot be modified once the Common Item dialog box is displayed.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setfiletypes#">Read more on docs.microsoft.com</see>.</para>
    /// </remarks>
    unsafe HRESULT SetFileTypes(uint cFileTypes, COMDLG_FILTERSPEC* rgFilterSpec);

    /// <summary>Sets the file type that appears as selected in the dialog.</summary>
    /// <param name="iFileType">
    /// <para>Type: <b>UINT</b> The index of the file type in the file type array passed to <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setfiletypes">IFileDialog::SetFileTypes</a> in its <i>cFileTypes</i> parameter. Note that this is a one-based index, not zero-based.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setfiletypeindex#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>This method must be called before the dialog is showing.</remarks>
    HRESULT SetFileTypeIndex(uint iFileType);

    /// <summary>Gets the currently selected file type.</summary>
    /// <param name="piFileType">
    /// <para>Type: <b>UINT*</b> A pointer to a <b>UINT</b> value that receives the index of the selected file type in the file type array passed to <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setfiletypes">IFileDialog::SetFileTypes</a> in its <i>cFileTypes</i> parameter. <div class="alert"><b>Note</b>  This is a one-based index rather than zero-based.</div> <div> </div></para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-getfiletypeindex#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks><b>IFileDialog::GetFileTypeIndex</b> can be called either while the dialog is open or after it has closed.</remarks>
    HRESULT GetFileTypeIndex(out uint piFileType);

    /// <summary>Assigns an event handler that listens for events coming from the dialog.</summary>
    /// <param name="pfde">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ifiledialogevents">IFileDialogEvents</a>*</b> A pointer to an <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ifiledialogevents">IFileDialogEvents</a> implementation that will receive events from the dialog.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-advise#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <param name="pdwCookie">
    /// <para>Type: <b>DWORD*</b> A pointer to a <b>DWORD</b> that receives a value identifying this event handler. When the client is finished with the dialog, that client must call the <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifiledialog-unadvise">IFileDialog::Unadvise</a> method with this value.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-advise#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-advise">Learn more about this API from docs.microsoft.com</see>.</para>
    /// </remarks>
    HRESULT Advise(IFileDialogEvents pfde, out uint pdwCookie);

    /// <summary>Removes an event handler that was attached through the IFileDialog::Advise method.</summary>
    /// <param name="dwCookie">
    /// <para>Type: <b>DWORD</b> The <b>DWORD</b> value that represents the event handler. This value is obtained through the <i>pdwCookie</i> parameter of the <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifiledialog-advise">IFileDialog::Advise</a> method.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-unadvise#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-unadvise">Learn more about this API from docs.microsoft.com</see>.</para>
    /// </remarks>
    HRESULT Unadvise(uint dwCookie);

    /// <summary>Sets flags to control the behavior of the dialog.</summary>
    /// <param name="fos">
    /// <para>Type: <b>FILEOPENDIALOGOPTIONS</b> One or more of the <a href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/ne-shobjidl_core-_fileopendialogoptions">FILEOPENDIALOGOPTIONS</a> values.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setoptions#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>Generally, this method should take the value that was retrieved by <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifiledialog-getoptions">IFileDialog::GetOptions</a> and modify it to include or exclude options by setting the appropriate flags.</remarks>
    HRESULT SetOptions(FILEOPENDIALOGOPTIONS fos);

    /// <summary>Gets the current flags that are set to control dialog behavior.</summary>
    /// <param name="pfos">
    /// <para>Type: <b>FILEOPENDIALOGOPTIONS*</b> When this method returns successfully, points to a value made up of one or more of the <a href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/ne-shobjidl_core-_fileopendialogoptions">FILEOPENDIALOGOPTIONS</a> values.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-getoptions#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-getoptions">Learn more about this API from docs.microsoft.com</see>.</para>
    /// </remarks>
    unsafe HRESULT GetOptions(FILEOPENDIALOGOPTIONS* pfos);

    /// <summary>Sets the folder used as a default if there is not a recently used folder value available.</summary>
    /// <param name="psi">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitem">IShellItem</a>*</b> A pointer to the interface that represents the folder.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setdefaultfolder#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setdefaultfolder">Learn more about this API from docs.microsoft.com</see>.</para>
    /// </remarks>
    HRESULT SetDefaultFolder(IShellItem psi);

    /// <summary>Sets a folder that is always selected when the dialog is opened, regardless of previous user action.</summary>
    /// <param name="psi">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitem">IShellItem</a>*</b> A pointer to the interface that represents the folder.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setfolder#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>
    /// <para>This folder overrides any "most recently used" folder. If this method is called while the dialog is displayed, it causes the dialog to navigate to the specified folder. In general, we do not recommended the use of this method. If you call <b>SetFolder</b> before you display the dialog box, the most recent location that the user saved to or opened from is not shown. Unless there is a very specific reason for this behavior, it is not a good or expected user experience and should therefore be avoided. In almost all instances, <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setdefaultfolder">IFileDialog::SetDefaultFolder</a> is the better method. As of Windows 7, if the path of the folder specified through <i>psi</i> is the default path of a <a href="https://docs.microsoft.com/previous-versions/windows/desktop/legacy/bb776911(v=vs.85)">known folder</a>, the known folder's current path is used in the dialog. That path might not be the same as the path specified in <i>psi</i>; for instance, if the known folder has been redirected. If the known folder is a library (virtual folders Documents, Music, Pictures, and Videos), the library's path is used in the dialog. If the specified library is hidden (as they are by default as of Windows 8.1), the library's default save location is used in the dialog, such as the Microsoft OneDrive Documents folder for the Documents library. Because of these mappings, the folder location used in the dialog might not be exactly as you specified when you called this method.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setfolder#">Read more on docs.microsoft.com</see>.</para>
    /// </remarks>
    HRESULT SetFolder(IShellItem psi);

    /// <summary>Gets either the folder currently selected in the dialog, or, if the dialog is not currently displayed, the folder that is to be selected when the dialog is opened.</summary>
    /// <param name="ppsi">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitem">IShellItem</a>**</b> The address of a pointer to the interface that represents the folder.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-getfolder#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>The calling application is responsible for releasing the retrieved <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitem">IShellItem</a> when it is no longer needed.</remarks>
    HRESULT GetFolder(out IShellItem ppsi);

    /// <summary>Gets the user's current selection in the dialog.</summary>
    /// <param name="ppsi">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitem">IShellItem</a>**</b> The address of a pointer to the interface that represents the item currently selected in the dialog. This item can be a file or folder selected in the view window, or something that the user has entered into the dialog's edit box. The latter case may require a parsing operation (cancelable by the user) that blocks the current thread.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-getcurrentselection#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>The calling application is responsible for releasing the retrieved <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitem">IShellItem</a> when it is no longer needed.</remarks>
    HRESULT GetCurrentSelection(out IShellItem ppsi);

    /// <summary>Sets the file name that appears in the File name edit box when that dialog box is opened.</summary>
    /// <param name="pszName">
    /// <para>Type: <b>LPCWSTR</b> A pointer to the name of the file.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setfilename#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setfilename">Learn more about this API from docs.microsoft.com</see>.</para>
    /// </remarks>
    HRESULT SetFileName(PCWSTR pszName);

    /// <summary>Retrieves the text currently entered in the dialog's File name edit box.</summary>
    /// <param name="pszName">
    /// <para>Type: <b>WCHAR**</b> The address of a pointer to a buffer that, when this method returns successfully, receives the text.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-getfilename#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>
    /// <para>The text in the <b>File name</b> edit box does not necessarily reflect the item the user chose.  To get the item the user chose, use <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifiledialog-getresult">IFileDialog::GetResult</a>. The calling application is responsible for releasing the retrieved buffer by using the <a href="https://docs.microsoft.com/windows/desktop/api/combaseapi/nf-combaseapi-cotaskmemfree">CoTaskMemFree</a> function.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-getfilename#">Read more on docs.microsoft.com</see>.</para>
    /// </remarks>
    unsafe HRESULT GetFileName(PWSTR* pszName);

    /// <summary>Sets the title of the dialog.</summary>
    /// <param name="pszTitle">
    /// <para>Type: <b>LPCWSTR</b> A pointer to a buffer that contains the title text.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-settitle#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-settitle">Learn more about this API from docs.microsoft.com</see>.</para>
    /// </remarks>
    HRESULT SetTitle(PCWSTR pszTitle);

    /// <summary>Sets the text of the Open or Save button.</summary>
    /// <param name="pszText">
    /// <para>Type: <b>LPCWSTR</b> A pointer to a buffer that contains the button text.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setokbuttonlabel#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setokbuttonlabel">Learn more about this API from docs.microsoft.com</see>.</para>
    /// </remarks>
    HRESULT SetOkButtonLabel(PCWSTR pszText);

    /// <summary>Sets the text of the label next to the file name edit box.</summary>
    /// <param name="pszLabel">
    /// <para>Type: <b>LPCWSTR</b> A pointer to a buffer that contains the label text.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setfilenamelabel#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setfilenamelabel">Learn more about this API from docs.microsoft.com</see>.</para>
    /// </remarks>
    HRESULT SetFileNameLabel(PCWSTR pszLabel);

    /// <summary>Gets the choice that the user made in the dialog.</summary>
    /// <param name="ppsi">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitem">IShellItem</a>**</b> The address of a pointer to an <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitem">IShellItem</a> that represents the user's choice.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-getresult#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>
    /// <para><b>IFileDialog::GetResult</b> can be called after the dialog has closed or during the handling of an <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifiledialogevents-onfileok">OnFileOk</a> event. Calling this method at any other time will fail. If multiple items were chosen, this method will fail. In the case of multiple items, call <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifileopendialog-getresults">GetResults</a></para>
    /// <para><a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-imodalwindow-show">Show</a> must return a success code for a result to be available to <b>IFileDialog::GetResult</b>.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-getresult#">Read more on docs.microsoft.com</see>.</para>
    /// </remarks>
    HRESULT GetResult(out IShellItem ppsi);

    /// <summary>Adds a folder to the list of places available for the user to open or save items.</summary>
    /// <param name="psi">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitem">IShellItem</a>*</b> A pointer to an <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitem">IShellItem</a> that represents the folder to be made available to the user. This can only be a folder.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-addplace#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <param name="fdap">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/ne-shobjidl_core-fdap">FDAP</a></b> Specifies where the folder is placed within the list. See <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/ne-shobjidl_core-fdap">FDAP</a>.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-addplace#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks><a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-shsettemporarypropertyforitem">SHSetTemporaryPropertyForItem</a> can be used to set a temporary <a href="https://docs.microsoft.com/windows/desktop/properties/props-system-itemnamedisplay">PKEY_ItemNameDisplay</a> property on the item represented by the <i>psi</i> parameter. The value for this property will be used in place of the item's UI name.</remarks>
    HRESULT AddPlace(IShellItem psi, FDAP fdap);

    /// <summary>Sets the default extension to be added to file names.</summary>
    /// <param name="pszDefaultExtension">
    /// <para>Type: <b>LPCWSTR</b> A pointer to a buffer that contains the extension text. This string should not include a leading period. For example, "jpg" is correct, while ".jpg" is not.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setdefaultextension#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>If this method is called before showing the dialog, the dialog will update the default extension automatically when the user chooses a new file type (see <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setfiletypes">SetFileTypes</a>).</remarks>
    HRESULT SetDefaultExtension(PCWSTR pszDefaultExtension);

    /// <summary>Closes the dialog.</summary>
    /// <param name="hr">
    /// <para>Type: <b>HRESULT</b> The code that will be returned by <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-imodalwindow-show">Show</a> to indicate that the dialog was closed before a selection was made.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-close#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>
    /// <para>An application can call this method from a callback method or function while the dialog is open. The dialog will close and the <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-imodalwindow-show">Show</a> method will return with the <b>HRESULT</b> specified in <i>hr</i>. If this method is called, there is no result available for the <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifiledialog-getresult">IFileDialog::GetResult</a> or <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifileopendialog-getresults">GetResults</a> methods, and they will fail if called.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-close#">Read more on docs.microsoft.com</see>.</para>
    /// </remarks>
    HRESULT Close(HRESULT hr);

    /// <summary>Enables a calling application to associate a GUID with a dialog's persisted state.</summary>
    /// <param name="guid">
    /// <para>Type: <b>REFGUID</b> The GUID to associate with this dialog state.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setclientguid#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>
    /// <para>A dialog's state can include factors such as the last visited folder and the position and size of the dialog. Typically, this state is persisted based on the name of the executable file. By specifying a GUID, an application can have different persisted states for different versions of the dialog within the same application (for example, an import dialog and an open dialog).</para>
    /// <para><b>IFileDialog::SetClientGuid</b> should be called immediately after creation of the dialog object.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setclientguid#">Read more on docs.microsoft.com</see>.</para>
    /// </remarks>
    unsafe HRESULT SetClientGuid(Guid* guid);

    /// <summary>Instructs the dialog to clear all persisted state information.</summary>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>Persisted information can be associated with an application or a GUID. If a GUID was set by using <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setclientguid">IFileDialog::SetClientGuid</a>, that GUID is used to clear persisted information.</remarks>
    HRESULT ClearClientData();

    /// <summary>SetFilter is no longer available for use as of Windows 7.</summary>
    /// <param name="pFilter">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitemfilter">IShellItemFilter</a>*</b> A pointer to the <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitemfilter">IShellItemFilter</a> that is to be set.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setfilter#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>
    /// <para>This method can be used if the application needs to perform special filtering to remove some items from the dialog box's view.  <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ishellitemfilter-includeitem">IncludeItem</a> will be called for each item that would normally be included in the view. <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ishellitemfilter-getenumflagsforitem">GetEnumFlagsForItem</a> is not used. To filter by file type, <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setfiletypes">IFileDialog::SetFileTypes</a> should be used, because in folders with a large number of items it may offer better performance than applying an <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitemfilter">IShellItemFilter</a>.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setfilter#">Read more on docs.microsoft.com</see>.</para>
    /// </remarks>
    HRESULT SetFilter(IShellItemFilter pFilter);
}
