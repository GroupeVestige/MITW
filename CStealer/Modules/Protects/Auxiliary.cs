using System;
using System.Collections.Generic;
using System.Management;

namespace Stub.Modules.Protects
{
	// Token: 0x02000005 RID: 5
	internal class Auxiliary
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002188 File Offset: 0x00000388
		public static List<string> GetGPUs()
		{
			List<string> list = new List<string>();
			try
			{
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController"))
				{
					foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
					{
						ManagementObject managementObject = (ManagementObject)managementBaseObject;
						bool flag = managementObject["Name"] != null;
						if (flag)
						{
							list.Add(managementObject["Name"].ToString());
						}
					}
				}
			}
			catch
			{
			}
			return list;
		}
	}
}
