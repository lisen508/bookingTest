using System;
using System.Collections.Generic;
using System.Text;

namespace BookingPlatform.Core.TableModels
{
	public class PatientinfoBooklist
	{
		public List<PatientinfoBooklists> PatientinfoBooklistinfo = new List<PatientinfoBooklists>();
	}
		public class PatientinfoBooklists
    {
		///<summary>
		///
		///</summary>
		public string ID { get; set; }

		public string Telephone { get; set; }

		public string ApplyID { get; set; }
		
		///<summary>
		///第三方系统ID
		///</summary>
		public string SystemID { get; set; }

		public string OutInPatientNo { get; set; }
	

		///<summary>
		///检查项目名称
		///</summary>
		public string IDCard { get; set; }
		

	
	}
}
