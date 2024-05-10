using Dalamud.Game;
using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;

namespace HuntBuddy;

public class Service {
	[PluginService]
	public static DalamudPluginInterface PluginInterface {
		get;
		set;
	} = null!;

	[PluginService]
	public static ICommandManager Commands {
		get;
		set;
	} = null!;

	[PluginService]
	public static IChatGui Chat {
		get;
		set;
	} = null!;

	[PluginService]
	public static IDataManager DataManager {
		get;
		set;
	} = null!;

	[PluginService]
	public static ISigScanner SigScanner {
		get;
		set;
	} = null!;

	[PluginService]
	public static IGameGui GameGui {
		get;
		set;
	} = null!;

	[PluginService]
	public static IClientState ClientState {
		get;
		set;
	} = null!;

	[PluginService]
	public static IFramework Framework {
		get;
		set;
	} = null!;

	[PluginService]
	public static IPluginLog PluginLog {
		get;
		set;
	} = null!;
}
