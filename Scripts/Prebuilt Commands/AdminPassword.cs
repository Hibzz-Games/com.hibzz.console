/* Description: Grants console admin access if the password entered matches
 * Author:		Hibnu Hishath (sliptrixx)
 * Date:		18 June, 2021 
 */

using UnityEngine;

namespace Hibzz.Console
{
	[CommandTooltip("Grants console admin access if the password entered matches")]
	[CreateAssetMenu(fileName = "AdminPasswordCmd", menuName = "Console/Built-in Commands/Admin Passsword")]
	public class AdminPassword : ConsoleCommand
	{
		[Tooltip("Please don't use \"-r\" as a password")]
		[SerializeField] private string password = "default";

		public AdminPassword()
		{
			CommandWord = "admin";
			IncludeInScan = false;	// Use something more secure if needed, this is a simple example
		}

		public override bool Process(string[] args)
		{
			// if there are no args given, return false
			if(args.Length < 1)
			{
				return false;
			}

			// if the incoming argument matches the set password, then set it
			if(password == args[0])
			{
				Console.RequestAdminAccess();
				Console.LogSuccess("Admin access granted");
				return true;
			}
			// or if the incoming argument matches the keyword "revoke", it revokes console admin access
			// hopefully no one set's the password as revoke
			else if(args[0] == "-r")
			{
				Console.RevokeAdminAccess();
				Console.LogInfo("Admin access removed");
				return true;
			}

			return false;
		}
	}
}