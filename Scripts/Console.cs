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

		/// <summary>
		/// Display an error message
		/// </summary>
		/// <param name="message"> the message to display </param>
		public static void PostError(string message)
		{
			DeveloperConsoleUI.instance.messageUI.SendMessage(message, MessageUI.Type.Error);
		}

		/// <summary>
		/// Display a warning message
		/// </summary>
		/// <param name="message"> The message to display </param>
		public static void PostWarning(string message)
		{
			DeveloperConsoleUI.instance.messageUI.SendMessage(message, MessageUI.Type.Warning);
		}

		/// <summary>
		/// Display an "informational" message
		/// </summary>
		/// <param name="message"> The message to display </param>
		public static void PostInfo(string message)
		{
			DeveloperConsoleUI.instance.messageUI.SendMessage(message, MessageUI.Type.Info);		}

		/// <summary>
		/// Display a success message
		/// </summary>
		/// <param name="message"> The message to display </param>
		public static void PostSuccess(string message)
		{
			DeveloperConsoleUI.instance.messageUI.SendMessage(message, MessageUI.Type.Success);
		}

		/// <summary>
		/// Set the width of the console
		/// </summary>
		/// <param name="width"> The width of the console </param>
		public static void Width(float width)
		{
			DeveloperConsoleUI.instance.Width = width;
		}

		/// <summary>
		/// Set the height of the console
		/// </summary>
		/// <param name="height"> The height of the console </param>
		public static void Height(float height)
		{
			DeveloperConsoleUI.instance.Height = height;
		}

		/// <summary>
		/// Request a secure input from the user which can be handled in the 
		/// HandleSecureInput virtual function
		/// </summary>
		/// <param name="command">The console command requesting the secure input</param>
		public static void RequestSecureInput(ConsoleCommand command, string placeholder = "SECURE INPUT")
		{
			DeveloperConsoleUI.instance.secureInputRequester = command;

			DeveloperConsoleUI.instance.inputField.contentType = TMPro.TMP_InputField.ContentType.Password;
			DeveloperConsoleUI.instance.inputField.placeholder.GetComponent<TMPro.TMP_Text>().text = placeholder;
		}

		/// <summary>
		/// Defining a delegate that's called when a non command input is entered in the console
		/// </summary>
		/// <param name="input"> The input that was passed in </param>
		public delegate void OnNonCommandInputEnterDelegate(string input);

		/// <summary>
		/// The predicate that's called when the user enters a non-command input into the console
		/// </summary>
		/// <remarks> Use this to change the behavior on what should happen when the user enters a 
		/// non-command string into the console. By default, the console logs the input. </remarks>
		public static OnNonCommandInputEnterDelegate OnNonCommandInputEnter = 
			(string input) => 
			{
				Log(input);
			};

		#region Deprecated Functions

		[System.Obsolete("This function is deprecate and is slated to be removed in v1.3. Use PostError instead.")]
		public static void LogError(string message) { }

		[System.Obsolete("This function is deprecate and is slated to be removed in v1.3. Use PostWarning instead.")]
		public static void LogWarning(string message) { }

		[System.Obsolete("This function is deprecate and is slated to be removed in v1.3. Use PostInfo instead.")]
		public static void LogInfo(string message) { }

		[System.Obsolete("This function is deprecate and is slated to be removed in v1.3. Use PostSuccess instead.")]
		public static void LogSuccess(string message) { }

		#endregion
	}
}
