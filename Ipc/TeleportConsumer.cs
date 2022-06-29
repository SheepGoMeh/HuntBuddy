using System;
using Dalamud.Logging;
using Dalamud.Plugin.Ipc;

namespace HuntBuddy.Ipc
{
	public class TeleportConsumer
	{
		public bool Subscribed { get; private set; }

		private ICallGateSubscriber<uint, byte, bool> consumerTeleport = null!;

		private void Subscribe()
		{
			try
			{
				this.consumerTeleport = Plugin.PluginInterface.GetIpcSubscriber<uint, byte, bool>("Teleport");

				this.Subscribed = true;
			}
			catch (Exception ex)
			{
				this.Subscribed = false;
				PluginLog.LogDebug($"Failed to subscribe to Teleporter\nReason: {ex}");
			}
		}

		public TeleportConsumer() => this.Subscribe();

		public bool Teleport(uint aetheryteId)
		{
			try
			{
				return this.consumerTeleport.InvokeFunc(aetheryteId, 0);
			}
			catch
			{
				Plugin.Chat.PrintError("Teleporter plugin is not responding");
				return false;
			}
		}
	}
}