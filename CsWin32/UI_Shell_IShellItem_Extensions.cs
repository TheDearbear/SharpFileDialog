using System;
using Windows.Win32.System.SystemServices;
using Windows.Win32.Foundation;
using Windows.Win32.UI.Shell;

#if NET6_0_OR_GREATER
using System.Runtime.Versioning;
#endif

namespace Windows.Win32
{
#if NET6_0_OR_GREATER
    [SupportedOSPlatform("windows5.1.2600")]
#endif
    internal static partial class UI_Shell_IShellItem_Extensions
    {
        /// <inheritdoc cref="IShellItem.BindToHandler(System.Com.IBindCtx, Guid*, Guid*, out object)"/>
        internal static unsafe HRESULT BindToHandler(this IShellItem @this, System.Com.IBindCtx pbc, in Guid bhid, in Guid riid, out object ppv)
        {
            fixed (Guid* riidLocal = &riid)
            {
                fixed (Guid* bhidLocal = &bhid)
                {
                    return @this.BindToHandler(pbc, bhidLocal, riidLocal, out ppv);
                }
            }
        }

        /// <inheritdoc cref="IShellItem.GetDisplayName(SIGDN, PWSTR*)"/>
        internal static unsafe HRESULT GetDisplayName(this IShellItem @this, SIGDN sigdnName, out PWSTR ppszName)
        {
            fixed (PWSTR* ppszNameLocal = &ppszName)
            {
                return @this.GetDisplayName(sigdnName, ppszNameLocal);
            }
        }

        /// <inheritdoc cref="IShellItem.GetAttributes(SFGAO_FLAGS, SFGAO_FLAGS*)"/>
        internal static unsafe HRESULT GetAttributes(this IShellItem @this, SFGAO_FLAGS sfgaoMask, out SFGAO_FLAGS psfgaoAttribs)
        {
            fixed (SFGAO_FLAGS* psfgaoAttribsLocal = &psfgaoAttribs)
            {
                return @this.GetAttributes(sfgaoMask, psfgaoAttribsLocal);
            }
        }
    }
}
