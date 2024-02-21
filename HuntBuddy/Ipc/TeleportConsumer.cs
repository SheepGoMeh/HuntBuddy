using System;

using Dalamud.Plugin.Ipc;

namespace HuntBuddy.Ipc;

public class TeleportConsumer: ConsumerBase {
	public override string RequiredPlugin { get; } = "TeleporterPlugin";
	protected override bool Validate() {
		this.consumerMessageSetting.InvokeFunc();
		return true;
	}

	private ICallGateSubscriber<bool> consumerMessageSetting = null!;
	private ICallGateSubscriber<uint, byte, bool> consumerTeleport = null!;

	private void Subscribe() {
		try {
			this.consumerTeleport = Service.PluginInterface.GetIpcSubscriber<uint, byte, bool>("Teleport");
			this.consumerMessageSetting = Service.PluginInterface.GetIpcSubscriber<bool>("Teleport.ChatMessage");
		}
		catch (Exception ex) {
			Service.PluginLog.Debug($"Failed to subscribe to Teleporter\nReason: {ex}");
		}
	}

	public TeleportConsumer() => this.Subscribe();

	public bool Teleport(uint aetheryteId) {
		try {
			return this.consumerTeleport.InvokeFunc(aetheryteId, 0);
		}
		catch {
			Service.Chat.PrintError("Teleporter plugin is not responding");
			return false;
		}
	}
}
