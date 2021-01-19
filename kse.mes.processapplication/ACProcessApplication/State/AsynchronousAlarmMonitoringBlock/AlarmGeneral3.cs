using gip.core.autocomponent;
using gip.core.datamodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace kse.mes.processapplication
{
	[DataContract]
	[ACSerializeableInfo]
	[ACClassInfo(Const.PackName_VarioAutomation, "en{'AlarmPositioning'}de{'AlarmPositioning'}", Global.ACKinds.TACClass, Global.ACStorableTypes.NotStorable, true, false)]
	[ACPropertyEntity(100, "Bit08", "en{'Weight to dose too small'}de{'Weight to dose too small'}")]
	[ACPropertyEntity(101, "Bit09", "en{'Desired accuracy smaller than weigher accuracy'}de{'Desired accuracy smaller than weigher accuracy'}")]
	[ACPropertyEntity(102, "Bit10", "en{'Not used'}de{'Not used'}")]
	[ACPropertyEntity(103, "Bit11", "en{'Accuracy less than or equal to zero'}de{'Accuracy less than or equal to zero'}")]
	[ACPropertyEntity(104, "Bit12", "en{'Not used'}de{'Not used'}")]
	[ACPropertyEntity(105, "Bit13", "en{'Not used'}de{'Not used'}")]
	[ACPropertyEntity(106, "Bit14", "en{'Not used'}de{'Not used'}")]
	[ACPropertyEntity(107, "Bit15", "en{'Dosability less than 0 or greater than 15'}de{'Dosability less than 0 or greater than 15'}")]
	[ACPropertyEntity(108, "Bit00", "en{'Not used'}de{'Not used'}")]
	[ACPropertyEntity(109, "Bit01", "en{'Not used'}de{'Not used'}")]
	[ACPropertyEntity(110, "Bit02", "en{'Not used'}de{'Not used'}")]
	[ACPropertyEntity(111, "Bit03", "en{'Not used'}de{'Not used'}")]
	[ACPropertyEntity(112, "Bit04", "en{'Not used'}de{'Not used'}")]
	[ACPropertyEntity(113, "Bit05", "en{'Not used'}de{'Not used'}")]
	[ACPropertyEntity(114, "Bit06", "en{'Not used'}de{'Not used'}")]
	[ACPropertyEntity(115, "Bit07", "en{'Not used'}de{'Not used'}")]
	// @aagincic: AutoGenerated file form AlarmGeneral3.csv definition
    public class AlarmGeneral3 :  BitAccessForInt16
	{
		#region c'tors
        public AlarmGeneral3()
        {
        }

        public AlarmGeneral3(IACType acValueType)
            : base(acValueType)
        {
        }
        #endregion

		#region Customized Bits

		 
		public bool Bit00_NotUsed
		{
			get { return Bit00; }
			set { Bit00 = value; }
		}
		 
		public bool Bit01_NotUsed
		{
			get { return Bit01; }
			set { Bit01 = value; }
		}
		 
		public bool Bit02_NotUsed
		{
			get { return Bit02; }
			set { Bit02 = value; }
		}
		 
		public bool Bit03_NotUsed
		{
			get { return Bit03; }
			set { Bit03 = value; }
		}
		 
		public bool Bit04_NotUsed
		{
			get { return Bit04; }
			set { Bit04 = value; }
		}
		 
		public bool Bit05_NotUsed
		{
			get { return Bit05; }
			set { Bit05 = value; }
		}
		 
		public bool Bit06_NotUsed
		{
			get { return Bit06; }
			set { Bit06 = value; }
		}
		 
		public bool Bit07_NotUsed
		{
			get { return Bit07; }
			set { Bit07 = value; }
		}
		 
		public bool Bit08_WeightToDoseTooSmall
		{
			get { return Bit08; }
			set { Bit08 = value; }
		}
		 
		public bool Bit09_DesiredAccuracySmallerThanWeigherAccuracy
		{
			get { return Bit09; }
			set { Bit09 = value; }
		}
		 
		public bool Bit10_NotUsed
		{
			get { return Bit10; }
			set { Bit10 = value; }
		}
		 
		public bool Bit11_AccuracyLessThanOrEqualToZero
		{
			get { return Bit11; }
			set { Bit11 = value; }
		}
		 
		public bool Bit12_NotUsed
		{
			get { return Bit12; }
			set { Bit12 = value; }
		}
		 
		public bool Bit13_NotUsed
		{
			get { return Bit13; }
			set { Bit13 = value; }
		}
		 
		public bool Bit14_NotUsed
		{
			get { return Bit14; }
			set { Bit14 = value; }
		}
		 
		public bool Bit15_DosabilityLessThan0OrGreaterThan15
		{
			get { return Bit15; }
			set { Bit15 = value; }
		}
		
		#endregion
		
	}
}
