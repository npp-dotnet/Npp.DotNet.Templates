// Visit https://npp-dotnet.github.io/Npp.DotNet.Plugin to learn more.

namespace _ProjectName;

using Npp.DotNet.Plugin;
using System.Runtime.InteropServices;

partial class Main : IDotNetPlugin
{
    #region "Implement the plugin interface"
    /// <summary>
    /// This method runs when Notepad++ calls the 'setInfo' API function.
    /// You can assume the application window handle is valid here.
    /// </summary>
    public void OnSetInfo()
    {
        // TODO: provide setup code, i.e., assign plugin commands to shortcut keys, load configuration data, etc.
        // For example:
        (int maj, int min, int patch) = PluginData.Notepad.GetNppVersion();

        Utils.SetCommand(
            $"Read the release notes for Notepad++ {maj}.{min}.{patch}",
            () =>
            {
                var exePath = PluginData.Notepad.GetNppPath();
                if (!PluginData.Notepad.OpenFile(Path.Combine(exePath, "change.log")))
                {
                    Win32.MsgBoxDialog(
                        PluginData.NppData.NppHandle,
                        $"No \"change.log\" in \"{exePath}\"!\0",
                        "File not found\0",
                        (uint)Win32.MsgBox.ICONERROR);
                }
            });

        Utils.MakeSeparator();

        Utils.SetCommand(
            "About",
            () => Win32.MsgBoxDialog(
                PluginData.NppData.NppHandle,
                $"This is {PluginName} version {AssemblyVersionString}\0",
                $"About {PluginName}\0",
                (uint)(Win32.MsgBox.ICONASTERISK | Win32.MsgBox.OK)),
            new ShortcutKey(ctrl: Win32.TRUE, alt: Win32.FALSE, shift: Win32.TRUE, ch: 123 /* F12 */));

        // TODO: Add a command to manage plugin settings:
        // 1. Enter your project's *.csproj directory and run: `dotnet new npp-plugin-ini`
        // 2. Uncomment the following:
        /*
                Utils.SetCommand(
                    "Open settings file",
                    () => {
                      var config = new IniFile();
                      config.OpenFile();
                    },
                    new ShortcutKey(ctrl: Win32.FALSE, alt: Win32.TRUE, shift: Win32.FALSE, ch: 116)); // ALT + F5
        */
    }

    /// <summary>
    /// This method runs when Notepad++ calls the 'beNotified' API function.
    /// </summary>
    public void OnBeNotified(ScNotification notification)
    {
        // TODO: provide callbacks for editor events and notifications.
        // For example:
        if (notification.Header.HwndFrom == PluginData.NppData.NppHandle)
        {
            uint code = notification.Header.Code;
            switch ((NppMsg)code)
            {
                case NppMsg.NPPN_READY:
                    // TODO: perform late-phase initialization
                    break;
                case NppMsg.NPPN_TBMODIFICATION:
                    PluginData.FuncItems.RefreshItems();
                    // TODO: register toolbar icon(s)
                    break;
                case NppMsg.NPPN_SHUTDOWN:
                    // clean up resources
                    PluginData.PluginNamePtr = IntPtr.Zero;
                    PluginData.FuncItems.Dispose();
                    break;
            }
        }
    }

    /// <summary>
    /// This method runs when Notepad++ calls the 'onMessageProc' API function.
    /// </summary>
    public NativeBool OnMessageProc(uint msg, UIntPtr wParam, IntPtr lParam)
    {
        // TODO: provide callbacks for Win32 window messages.
        return Win32.TRUE;
    }
    #endregion

    #region "Initialize your plugin's properties"
    /// <summary>
    /// The main constructor must be static to ensure data is initialized *before*
    /// the Notepad++ application calls any unmanaged methods.
    /// At the very least, assign a unique name to 'Npp.DotNet.Plugin.PluginData.PluginNamePtr',
    /// otherwise the default name -- "Npp.DotNet.Plugin" -- will be used.
    /// </summary>
    static Main()
    {
        Instance = new Main();
        PluginData.PluginNamePtr = Marshal.StringToHGlobalUni($"{PluginName}\0");
    }

    /// <summary>
    /// Object reference to the main class -- must be initialized statically!
    /// </summary>
    static readonly IDotNetPlugin Instance;

    /// <summary>
    /// The unique name of the plugin -- appears in the 'Plugins' drop-down menu
    /// </summary>
    static readonly string PluginName = "_ProjectName";

    /// <inheritdoc cref="Npp.DotNet.Plugin.Extensions.NppUtils.AssemblyVersionString"/>
    static string AssemblyVersionString
    {
        get
        {
            string version = "1.0.0.0";
            try
            {
                string assemblyName = typeof(Main).Namespace!;
                version =
                    System.Diagnostics.FileVersionInfo.GetVersionInfo(
                        Path.Combine(
                            PluginData.Notepad.GetPluginsHomePath(), assemblyName, $"{assemblyName}.dll")
                        )
                    .FileVersion!;
            }
            catch { }
            return version;
        }
    }
    #endregion
}
