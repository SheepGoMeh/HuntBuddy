using System;

using Dalamud.Plugin.Ipc;

namespace HuntBuddy.Ipc;

public class EspConsumer: ConsumerBase {
	public override string RequiredPlugin { get; } = "XivEsp";
	protected override bool Validate() {
		this.getUnifiedSearch.InvokeFunc();
		return true;
	}

	private ICallGateSubscriber<string> getUnifiedSearch = null!;
	private ICallGateSubscriber<string, object> setSubstringSearch = null!;

	private void Subscribe() {
		try {
			this.getUnifiedSearch = Service.PluginInterface.GetIpcSubscriber<string>("XivEsp.GetSearch");
			this.setSubstringSearch = Service.PluginInterface.GetIpcSubscriber<string, object>("XivEsp.SetSubstring");
		}
		catch (Exception ex) {
			Service.PluginLog.Debug($"Failed to subscribe to XivEsp\nReason: {ex}");
		}
	}

	public EspConsumer() => this.Subscribe();

	public bool CanSetSearch {
		get {
			try {
				string current = this.getUnifiedSearch.InvokeFunc();
				char type = current[0];
				return type is 'N' or 'S';
			}
			catch {
				return false;
			}
		}
	}
	public bool SearchFor(string target) {
		try {
			if (this.CanSetSearch) {
				this.setSubstringSearch.InvokeAction(target);
				return true;
			}
			else {
				Service.Chat.Print("Cannot override complex (glob/regex) XivEsp search");
				return false;
			}
		}
		catch (Exception ex) {
			Service.PluginLog.Error($"XivEsp is not responding to IPC: {ex}");
			Service.Chat.PrintError("XivEsp plugin is not responding");
			return false;
		}
	}
}
