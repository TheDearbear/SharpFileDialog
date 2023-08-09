using System;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using Windows.Win32.Foundation;
using Windows.Win32.System.Com;
using Windows.Win32.System.SystemServices;

namespace Windows.Win32.UI.Shell;

[Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown), ComImport()]
[SupportedOSPlatform("windows5.1.2600")]
internal interface IShellItem
{
    /// <summary>Binds to a handler for an item as specified by the handler ID value (BHID).</summary>
    /// <param name="pbc">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/objidl/nn-objidl-ibindctx">IBindCtx</a>*</b> A pointer to an <a href="https://docs.microsoft.com/windows/desktop/api/objidl/nn-objidl-ibindctx">IBindCtx</a> interface on a bind context object. Used to pass optional parameters to the handler. The contents of the bind context are handler-specific. For example, when binding to <b>BHID_Stream</b>, the <a href="https://docs.microsoft.com/windows/desktop/Stg/stgm-constants">STGM</a> flags in the bind context indicate the mode of access desired (read or read/write).</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitem-bindtohandler#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <param name="bhid">Type: <b>REFGUID</b></param>
    /// <param name="riid">
    /// <para>Type: <b>REFIID</b> IID of the object type to retrieve.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitem-bindtohandler#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <param name="ppv">
    /// <para>Type: <b>void**</b> When this method returns, contains a pointer of type <i>riid</i> that is returned by the handler specified by <i>rbhid</i>.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitem-bindtohandler#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitem-bindtohandler">Learn more about this API from docs.microsoft.com</see>.</para>
    /// </remarks>
    unsafe HRESULT BindToHandler(IBindCtx pbc, Guid* bhid, Guid* riid, [MarshalAs(UnmanagedType.IUnknown)] out object ppv);

    /// <summary>Gets the parent of an IShellItem object.</summary>
    /// <param name="ppsi">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitem">IShellItem</a>**</b> The address of a pointer to the parent of an <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitem">IShellItem</a> interface.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitem-getparent#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> Returns S_OK if successful, or an error value otherwise.</para>
    /// </returns>
    /// <remarks>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitem-getparent">Learn more about this API from docs.microsoft.com</see>.</para>
    /// </remarks>
    HRESULT GetParent(out IShellItem ppsi);

    /// <summary>Gets the display name of the IShellItem object.</summary>
    /// <param name="sigdnName">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/ne-shobjidl_core-sigdn">SIGDN</a></b> One of the <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/ne-shobjidl_core-sigdn">SIGDN</a> values that indicates how the name should look.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitem-getdisplayname#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <param name="ppszName">
    /// <para>Type: <b>LPWSTR*</b> A value that, when this function returns successfully, receives the address of a pointer to the retrieved display name.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitem-getdisplayname#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> If this method succeeds, it returns <b>S_OK</b>. Otherwise, it returns an <b>HRESULT</b> error code.</para>
    /// </returns>
    /// <remarks>It is the responsibility of the caller to free the string pointed to by <i>ppszName</i> when it is no longer needed. Call <a href="https://docs.microsoft.com/windows/desktop/api/combaseapi/nf-combaseapi-cotaskmemfree">CoTaskMemFree</a> on *<i>ppszName</i> to free the memory.</remarks>
    unsafe HRESULT GetDisplayName(SIGDN sigdnName, PWSTR* ppszName);

    /// <summary>Gets a requested set of attributes of the IShellItem object.</summary>
    /// <param name="sfgaoMask">
    /// <para>Type: <b>SFGAOF</b> Specifies the attributes to retrieve. One or more of the <a href="https://docs.microsoft.com/windows/desktop/shell/sfgao">SFGAO</a> values. Use a bitwise OR operator to determine the attributes to retrieve.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitem-getattributes#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <param name="psfgaoAttribs">
    /// <para>Type: <b>SFGAOF*</b> A pointer to a value that, when this method returns successfully, contains the requested attributes. One or more of the <a href="https://docs.microsoft.com/windows/desktop/shell/sfgao">SFGAO</a> values. Only those attributes specified by <i>sfgaoMask</i> are returned; other attribute values are undefined.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitem-getattributes#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> Returns S_OK if the attributes returned exactly match those requested in <i>sfgaoMask</i>, S_FALSE if the attributes do not exactly match, or a standard COM error value otherwise.</para>
    /// </returns>
    /// <remarks>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitem-getattributes">Learn more about this API from docs.microsoft.com</see>.</para>
    /// </remarks>
    unsafe HRESULT GetAttributes(SFGAO_FLAGS sfgaoMask, SFGAO_FLAGS* psfgaoAttribs);

    /// <summary>Compares two IShellItem objects.</summary>
    /// <param name="psi">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitem">IShellItem</a>*</b> A pointer to an <a href="https://docs.microsoft.com/windows/desktop/api/shobjidl_core/nn-shobjidl_core-ishellitem">IShellItem</a> object to compare with the existing <b>IShellItem</b> object.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitem-compare#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <param name="hint">
    /// <para>Type: <b><a href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/ne-shobjidl_core-_sichintf">SICHINTF</a></b> One of the <a href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/ne-shobjidl_core-_sichintf">SICHINTF</a> values that determines how to perform the comparison. See <b>SICHINTF</b> for the list of possible values for this parameter.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitem-compare#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <param name="piOrder">
    /// <para>Type: <b>int*</b> This parameter receives the result of the comparison. If the two items are the same this parameter equals zero; if they are different the parameter is nonzero.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitem-compare#parameters">Read more on docs.microsoft.com</see>.</para>
    /// </param>
    /// <returns>
    /// <para>Type: <b>HRESULT</b> Returns S_OK if the items are the same, S_FALSE if they are different, or an error value otherwise.</para>
    /// </returns>
    /// <remarks>
    /// <para>The data type used in the second parameter, SICHINTF, is defined as:</para>
    /// <para></para>
    /// <para>This doc was truncated.</para>
    /// <para><see href="https://docs.microsoft.com/windows/win32/api/shobjidl_core/nf-shobjidl_core-ishellitem-compare#">Read more on docs.microsoft.com</see>.</para>
    /// </remarks>
    HRESULT Compare(IShellItem psi, uint hint, out int piOrder);
}
