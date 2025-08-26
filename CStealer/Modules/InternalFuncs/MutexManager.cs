using System;
using Microsoft.Win32;

namespace Stub.Modules.InternalFuncs
{
	// Token: 0x0200000A RID: 10
	internal class MutexManager
	{
		// Token: 0x06000019 RID: 25 RVA: 0x00002CF8 File Offset: 0x00000EF8
		public static void Initialize()
		{
			string text = "SOFTWARE\\" + config.MutexValue;
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(text);
			bool flag = registryKey != null;
			if (flag)
			{
				registryKey.Close();
				Environment.FailFast("");
			}
			else
			{
				Registry.CurrentUser.CreateSubKey(text);
			}
		}
	}
}
