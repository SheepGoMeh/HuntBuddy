using System;

namespace HuntBuddy.Attributes;

[AttributeUsage(AttributeTargets.Method)]
public class HelpMessageAttribute: Attribute {
	public string HelpMessage {
		get;
	}

	public HelpMessageAttribute(string helpMessage) => this.HelpMessage = helpMessage;
}
