using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntBuddy.Ipc;
public abstract class ConsumerBase {
	public const int MS_PER_AVAILABILITY_RECHECK = 5000;

	public abstract string RequiredPlugin { get; }

	private bool isAvailable;
	private long timeSinceLastCheck;

	public bool IsAvailable {
		get {
			if (Environment.TickCount64 > this.timeSinceLastCheck + MS_PER_AVAILABILITY_RECHECK) {
				if (Service.PluginInterface.InstalledPlugins.Any(p => p.IsLoaded && p.InternalName == this.RequiredPlugin)) {
					try {
						this.isAvailable = this.Validate();
					}
					catch {
						this.isAvailable = false;
					}
				}
				else {
					this.isAvailable = false;
				}
				this.timeSinceLastCheck = Environment.TickCount64;
			}

			return this.isAvailable;
		}
	}

	protected abstract bool Validate();
}
