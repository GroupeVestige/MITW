using System;
using System.IO;

namespace Stub.Modules
{
	// Token: 0x02000003 RID: 3
	internal class config
	{
		// Token: 0x04000001 RID: 1
		public static string MutexValue = "%MUTEX%";

		// Token: 0x04000002 RID: 2
		public static string FileName = "%FILENAME%";

		// Token: 0x04000003 RID: 3
		public static string FileLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), config.FileName);

		// Token: 0x04000004 RID: 4
		public static string Url = "%URL%";

		// Token: 0x04000005 RID: 5
		public static bool AutoRun = false;

		// Token: 0x04000006 RID: 6
		public static bool HideFile = false;

		// Token: 0x04000007 RID: 7
		public static bool MutexControl = false;

		// Token: 0x04000008 RID: 8
		public static bool AntiCIS = false;

		// Token: 0x04000009 RID: 9
		public static bool AntiVM = false;

		// Token: 0x0400000A RID: 10
		public static bool AntiDebug = false;

		// Token: 0x0400000B RID: 11
		public static bool AntiAnyRun = false;
	}
}
