using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web;
using System.Web.Services;

namespace MilkShake
{
	/// <summary>
	/// Summary description for Service1.
	/// </summary>
	public class MilkShake : System.Web.Services.WebService
	{
		private MilkShakeEngine.Engine mile;
		  private const string k = "qcs9fmt24V6B5t73uhhNjqnwbMf0en4s2U3I51tdffegs4fG+HtJyK$vab274LfedA3S2rvjfkqo78upjanZkXgyhC55yOuPxDdFe63Q5W4laudifEbR1z3x5T8 9Y";
		//private const string k = "c9m2VBt3hNqwM0nsUI1dfg4GHJKvb7LeASrjko8paZXyC5OPDF6QWluiERzxT Y";

		public MilkShake()
		{
			//CODEGEN: This call is required by the ASP.NET Web Services Designer
			InitializeComponent();

			string lk = "";

			for (int n = 1; n <= k.Length; n++)
			{
				if (n % 2 == 0) lk += k.Substring(n - 1, 1);
			}

			mile = new MilkShakeEngine.Engine(lk);
		}

		#region Component Designer generated code
		
		//Required by the Web Services Designer 
		private IContainer components = null;
				
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if(disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);		
		}
		
		#endregion


		[WebMethod]
		public string encryptText(string Text)
		{
			return mile.encrypt(Text);
		}

		[WebMethod]
		public string decryptText(string Text)
		{
			return mile.decrypt(Text);
		}
	}
}
