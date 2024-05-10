using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

using Dalamud.Game.Command;
using Dalamud.Plugin.Services;

using HuntBuddy.Attributes;

namespace HuntBuddy;

public class PluginCommandManager<THost>: IDisposable {
	private readonly ICommandManager commandManager;
	private readonly (string, CommandInfo)[] pluginCommands;
	private readonly THost host;

	public PluginCommandManager(THost host, ICommandManager commandManager) {
		this.commandManager = commandManager;
		this.host = host;

		this.pluginCommands = host!.GetType().GetMethods(
				BindingFlags.NonPublic | BindingFlags.Public |
				BindingFlags.Static | BindingFlags.Instance)
			.Where(method => method.GetCustomAttribute<CommandAttribute>() != null)
			.SelectMany(this.GetCommandInfoTuple)
			.ToArray();

		this.AddCommandHandlers();
	}

	// http://codebetter.com/patricksmacchia/2008/11/19/an-easy-and-efficient-way-to-improve-net-code-performances/
	// Benchmarking this myself gave similar results, so I'm doing this to somewhat counteract using reflection to access command attributes.
	// I like the convenience of attributes, but in principle it's a bit slower to use them as opposed to just initializing CommandInfos directly.
	// It's usually sub-1 millisecond anyways, though. It probably doesn't matter at all.
	private void AddCommandHandlers() {
		foreach ((string, CommandInfo) t in this.pluginCommands) {
			(string command, CommandInfo commandInfo) = t;
			this.commandManager.AddHandler(command, commandInfo);
		}
	}

	private void RemoveCommandHandlers() {
		foreach ((string, CommandInfo) t in this.pluginCommands) {
			(string command, _) = t;
			this.commandManager.RemoveHandler(command);
		}
	}

	private IEnumerable<(string, CommandInfo)> GetCommandInfoTuple(MethodInfo method) {
		CommandInfo.HandlerDelegate handlerDelegate = (CommandInfo.HandlerDelegate)Delegate.CreateDelegate(
			typeof(CommandInfo.HandlerDelegate),
			this.host,
			method);

		CommandAttribute? command = handlerDelegate.Method.GetCustomAttribute<CommandAttribute>();
		AliasesAttribute? aliases = handlerDelegate.Method.GetCustomAttribute<AliasesAttribute>();
		HelpMessageAttribute? helpMessage = handlerDelegate.Method.GetCustomAttribute<HelpMessageAttribute>();
		DoNotShowInHelpAttribute? doNotShowInHelp =
			handlerDelegate.Method.GetCustomAttribute<DoNotShowInHelpAttribute>();

		CommandInfo commandInfo = new CommandInfo(handlerDelegate) {
			HelpMessage = helpMessage?.HelpMessage ?? string.Empty, ShowInHelp = doNotShowInHelp == null,
		};

		// Create list of tuples that will be filled with one tuple per alias, in addition to the base command tuple.
		List<(string, CommandInfo)> commandInfoTuples =
			new List<(string, CommandInfo)> { (command!.Command, commandInfo) };
		if (aliases == null) {
			return commandInfoTuples;
		}

		// ReSharper disable once LoopCanBeConvertedToQuery
		foreach (string t in aliases.Aliases) {
			commandInfoTuples.Add((t, commandInfo));
		}

		return commandInfoTuples;
	}

	public void Dispose() {
		this.RemoveCommandHandlers();
		GC.SuppressFinalize(this);
	}
}
