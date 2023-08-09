using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Windows.Win32.Foundation;

namespace Windows.Win32.UI.Shell;

[Guid("84BCCD23-5FDE-4CDB-AEA4-AF64B83D78AB"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComImport()]
[SupportedOSPlatform("windows6.0.6000")]
internal interface IFileSaveDialog : IFileDialog
{
    /// <summary>Sets an item to be used as the initial entry in a Save As dialog.</summary>
    /// <param name="psi">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitem">IShellItem</a>*</b> Pointer to an <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitem">IShellItem</a> that represents the item.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesavedialog-setsaveasitem#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>The name of the item is displayed in the file name edit box, and the containing folder is opened in the view. This would generally be used when the application is saving an item that already exists. For new items, use <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifiledialog-setfilename">IFileDialog::SetFileName</a>.</remarks>
    HRESULT SetSaveAsItem(IShellItem psi);

    /// <summary>Provides a property store that defines the default values to be used for the item being saved.</summary>
    /// <param name="pStore">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/propsys/nn-propsys-ipropertystore">IPropertyStore</a>*</b> Pointer to the interface that represents the property store that contains the associated metadata.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesavedialog-setproperties#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>
    /// <para>This method can be called at any time before the dialog is opened or while the dialog is showing. If an item has inherent properties, this method should be called with those properties before showing the dialog. When using <b>Save As</b>, the application should provide the properties of the item being saved to the <b>Save</b> dialog. Those properties should be retreived from the original item by calling <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ishellitem2-getpropertystore">GetPropertyStore</a> with the <a href="https://docs.microsoft.com/windows/desktop/api/propsys/ne-propsys-getpropertystoreflags">GPS_HANDLERPROPERTIESONLY</a> flag. To retrieve the properties of the saved item (which may have been modified by the user) after the dialog closes, call <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifilesavedialog-getproperties">IFileSaveDialog::GetProperties</a>. To turn on property collection and indicate which properties should be displayed in the <b>Save</b> dialog, use <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifilesavedialog-setcollectedproperties">IFileSaveDialog::SetCollectedProperties</a>.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesavedialog-setproperties#">Read more on docs.microsoft.com</see>.</para>
    /// </remarks>
    HRESULT SetProperties(PropertiesSystem.IPropertyStore pStore);

    /// <summary>Specifies which properties will be collected in the save dialog.</summary>
    /// <param name="pList">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/propsys/nn-propsys-ipropertydescriptionlist">IPropertyDescriptionList</a>*</b> Pointer to the interface that represents the list of properties to collect. This parameter can be <b>NULL</b>.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesavedialog-setcollectedproperties#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <param name="fAppendDefault">
    /// <para>Type: <b>BOOL</b> <b>TRUE</b> to show default properties for the currently selected filetype in addition to the properties specified by <i>pList</i>. <b>FALSE</b> to show only properties specified by <i>pList</i>.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesavedialog-setcollectedproperties#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>
    /// <para>The calling application can use the <a href="https://docs.microsoft.com/windows/desktop/api/propsys/nf-propsys-psgetpropertydescriptionlistfromstring">PSGetPropertyDescriptionListFromString</a> function to construct an <a href="https://docs.microsoft.com/windows/desktop/api/propsys/nn-propsys-ipropertydescriptionlist">IPropertyDescriptionList</a> from a string such as "prop:Comments;Subject;". For more information about property schemas, see <a href="https://docs.microsoft.com/windows/desktop/properties/building-property-handlers-property-schemas">Property Schemas</a>. <b>IFileSaveDialog::SetCollectedProperties</b> can be called at any time before the dialog is displayed or while it is visible. If different properties are to be collected depending on the chosen filetype, then <b>IFileSaveDialog::SetCollectedProperties</b> can be called in response to <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifiledialogevents-ontypechange">OnTypeChange</a>. <div class="alert"><b>Note</b>  By default, no properties are collected in the save dialog.</div> <div> </div></para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesavedialog-setcollectedproperties#">Read more on docs.microsoft.com</see>.</para>
    /// </remarks>
    HRESULT SetCollectedProperties(PropertiesSystem.IPropertyDescriptionList pList, BOOL fAppendDefault);

    /// <summary>Retrieves the set of property values for a saved item or an item in the process of being saved.</summary>
    /// <param name="ppStore">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/propsys/nn-propsys-ipropertystore">IPropertyStore</a>**</b> Address of a pointer to an <a href="https://docs.microsoft.com/windows/desktop/api/propsys/nn-propsys-ipropertystore">IPropertyStore</a> that receives the property values.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesavedialog-getproperties#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>
    /// <para>This method can be called while the dialog is showing to retrieve the current set of values in the metadata collection pane. It can also be called after the dialog has closed, to retrieve the final set of values. The call to this method will fail unless property collection has been turned on with a call to <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifilesavedialog-setcollectedproperties">IFileSaveDialog::SetCollectedProperties</a>.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesavedialog-getproperties#">Read more on docs.microsoft.com</see>.</para>
    /// </remarks>
    HRESULT GetProperties(out PropertiesSystem.IPropertyStore ppStore);

    /// <summary>Applies a set of properties to an item using the Shell's copy engine.</summary>
    /// <param name="psi">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitem">IShellItem</a>*</b> Pointer to the <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitem">IShellItem</a> that represents the file being saved. This is usually the item retrieved by <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifiledialog-getresult">GetResult</a>.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesavedialog-applyproperties#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <param name="pStore">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/propsys/nn-propsys-ipropertystore">IPropertyStore</a>*</b> Pointer to the <a href="https://docs.microsoft.com/windows/desktop/api/propsys/nn-propsys-ipropertystore">IPropertyStore</a> that represents the property values to be applied to the file. This can be the property store returned by <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifilesavedialog-getproperties">IFileSaveDialog::GetProperties</a>.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesavedialog-applyproperties#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <param name="hwnd">
    /// <para>Type: <b>HWND</b> The handle of the application window.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesavedialog-applyproperties#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <param name="pSink">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ifileoperationprogresssink">IFileOperationProgressSink</a>*</b> Pointer to an optional <b>IFileOperationProgressSink</b> that the calling application can use if they want to be notified of the progress of the property stamping. This value may be <b>NULL</b>.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesavedialog-applyproperties#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>
    /// <para>This method should be used when the application has turned on property collection (<a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nf-shobjidl_core-ifilesavedialog-setcollectedproperties">IFileSaveDialog::SetCollectedProperties</a>), but does not persist the properties themselves into the saved file. <div class="alert"><b>Note</b>  The file represented by the item specified in <i>psi</i> must exist in physical storage before making the call to <b>IFileSaveDialog::ApplyProperties</b>, so it must have been previously saved at some point.</div> <div> </div></para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ifilesavedialog-applyproperties#">Read more on docs.microsoft.com</see>.</para>
    /// </remarks>
    HRESULT ApplyProperties(IShellItem psi, PropertiesSystem.IPropertyStore pStore, HWND hwnd, IFileOperationProgressSink pSink);
}
