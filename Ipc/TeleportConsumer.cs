using System;
using Dalamud.Logging;
using Dalamud.Plugin.Ipc;

namespace HuntBuddy.Ipc
{
	public class TeleportConsumer
	{
		private ICallGateSubscriber<uint, byte, bool> _consumerTeleport = null!;

		private void Subscribe()
		{
			try
			{
				this._consumerTeleport = Plugin.PluginInterface.GetIpcSubscriber<uint, byte, bool>("Teleport");
			}
			catch (Exception ex)
			{
				PluginLog.LogDebug($"Failed to subscribe to Teleporter\nReason: {ex}");
			}
		}

		public TeleportConsumer() => this.Subscribe();

		public bool Teleport(uint aetheryteId)
		{
			try
			{
				return this._consumerTeleport.InvokeFunc(aetheryteId, 0);
			}
			catch
			{
				Plugin.Chat.PrintError("Teleporter plugin is not responding");
				return false;
			}
		}
	}
}