using System;
using Dalamud.Logging;
using Dalamud.Plugin.Ipc;

namespace HuntBuddy.Ipc
{
	public class TeleportConsumer
	{
		private bool isAvailable;
		private long timeSinceLastCheck;

		public bool IsAvailable
		{
			get
			{
				if (this.timeSinceLastCheck + 5000 > Environment.TickCount64)
				{
					return this.isAvailable;
				}

				try
				{
					this.consumerMessageSetting.InvokeFunc();
					this.isAvailable = true;
					this.timeSinceLastCheck = Environment.TickCount64;
				}
				catch
				{
					this.isAvailable = false;
				}

				return this.isAvailable;
			}
		}

		private ICallGateSubscriber<bool> consumerMessageSetting = null!;
		private ICallGateSubscriber<uint, byte, bool> consumerTeleport = null!;

		private void Subscribe()
		{
			try
			{
				this.consumerTeleport = Plugin.PluginInterface.GetIpcSubscriber<uint, byte, bool>("Teleport");
				this.consumerMessageSetting = Plugin.PluginInterface.GetIpcSubscriber<bool>("Teleport.ChatMessage");
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