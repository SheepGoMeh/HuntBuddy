using Dalamud.IoC;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;

namespace HuntBuddy;

public class Service {
	[PluginService]
	public static IDalamudPluginInterface PluginInterface {
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
	public static IObjectTable ObjectTable {
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

	[PluginService]
	public static ITextureProvider TextureProvider {
		get;
		set;
	} = null!;

	[PluginService]
	public static ICondition Condition {
		get;
		set;
	} = null!;
}
