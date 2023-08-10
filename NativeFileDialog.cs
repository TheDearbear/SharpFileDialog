// .NET Standard 2.1 OR >= .NET Core 3.0
#if (!NETSTANDARD2_0 && NETSTANDARD2_0_OR_GREATER) || NETCOREAPP3_0_OR_GREATER
#define USE_NOTNULLWHEN
#endif

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;

namespace SharpFileDialog
{
    public static class NativeFileDialog
    {
        public static bool CurrentPlatformSupported => _provider is not null;

        static readonly INativeDialogProvider? _provider;

        static NativeFileDialog()
        {
            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            IEnumerable<Type> nativeProviders = currentAssembly.GetTypes().Where(type => type.GetInterface(nameof(INativeDialogProvider)) is not null);

            foreach (Type nativeProvider in nativeProviders)
            {
                if (Activator.CreateInstance(nativeProvider) is INativeDialogProvider provider)
                {
                    if (!provider.CurrentPlatformSupported)
                        continue;

                    if (_provider is null || _provider.Priority < provider.Priority)
                        _provider = provider;
                }
            }
        }

#if USE_NOTNULLWHEN
        public static bool OpenDialog(Filter[]? filters, string? defaultPath, [NotNullWhen(true)] out string? outPath)
#else
        public static bool OpenDialog(Filter[]? filters, string? defaultPath, out string? outPath)
#endif
        {
            INativeDialogProvider provider = EnsureProviderAvailable();

            return provider.OpenDialog(filters, defaultPath, out outPath);
        }

#if USE_NOTNULLWHEN
        public static bool OpenDialogMultiple(Filter[]? filters, string? defaultPath, [NotNullWhen(true)] out string[]? outPaths)
#else
        public static bool OpenDialogMultiple(Filter[]? filters, string? defaultPath, out string[]? outPaths)
#endif
        {
            INativeDialogProvider provider = EnsureProviderAvailable();

            return provider.OpenDialogMultiple(filters, defaultPath, out outPaths);
        }

#if USE_NOTNULLWHEN
        public static bool SaveDialog(Filter[]? filters, string? defaultPath, [NotNullWhen(true)] out string? outPath)
#else
        public static bool SaveDialog(Filter[]? filters, string? defaultPath, out string? outPath)
#endif
        {
            INativeDialogProvider provider = EnsureProviderAvailable();

            return provider.SaveDialog(filters, defaultPath, out outPath);
        }

#if USE_NOTNULLWHEN
        public static bool PickFolder(string? defaultPath, [NotNullWhen(true)] out string? outPath)
#else
        public static bool PickFolder(string? defaultPath, out string? outPath)
#endif
        {
            INativeDialogProvider provider = EnsureProviderAvailable();

            return provider.PickFolder(defaultPath, out outPath);
        }

        private static INativeDialogProvider EnsureProviderAvailable()
        {
            if (_provider is null)
                throw new PlatformNotSupportedException("Dialog provider for current platform is not available!");

            return _provider;
        }

        public struct Filter
        {
            public string Name;
            public string[] Extensions;
        }
    }
}
