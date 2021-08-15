using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hibzz.Console
{
	/// <summary>
	/// A class with static variables and functions that gives useful information 
	/// about the current status of the developer console
	/// </summary>
	/// <remarks>
	/// Remarks: The info in this class isn't guaranteed to be right if there are no DeveloperConsole on the scene
	/// </remarks>
	public class Console
	{
		/// <summary>
		/// Is the mouse hovering the console UI
		/// </summary>
		public static bool IsHovered = false;

		/// <summary>
		/// Is the console textbox focuesed at the moment
		/// </summary>
		public static bool IsTextboxFocused = false;

		/// <summary>
		/// A dictionary to store cache results and intermediary values that can be used in the next process
		/// </summary>
		public static Dictionary<string, Object> CacheDictionary = new Dictionary<string, Object>();

		/// <summary>
		/// Static class that adds a log to the singleton instance
		/// </summary>
		/// <param name="message"> the message to add </param>
		public static void Log(string message)
		{
			DeveloperConsoleUI.instance.AddLog(message, DeveloperConsoleUI.instance.DefaultColor);
		}

		/// <summary>
		/// Static function that adds a log to the singleton instance
		/// </summary>
		/// <param name="message"> The message to add </param>
		/// <param name="color"> The color of the message </param>
		public static void Log(string message, Color color)
		{
			DeveloperConsoleUI.instance.AddLog(message, color);
		}

		/// <summary>
		/// Static function that clears the singleton log
		/// </summary>
		public static void Clear()
		{
			DeveloperConsoleUI.instance.ClearLogs();
		}

		/// <summary>
		/// Request admin access to the console which grants permission to execute admin-only commands
		/// </summary>
		public static void RequestAdminAccess()
		{
			DeveloperConsoleUI.instance.DeveloperConsole.RequestAdminAccess();
		}

		/// <summary>
		/// Revoke admin access to console preventing users from execute admin-only commands
		/// </summary>
		public static void RevokeAdminAccess()
		{
			DeveloperConsoleUI.instance.DeveloperConsole.RevokeAdminAccesss();
		}
	}
}
