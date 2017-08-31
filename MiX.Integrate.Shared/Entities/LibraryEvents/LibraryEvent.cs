using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiX.Integrate.Shared.Entities.LibraryEvents
{
	/// <summary>Describes a library event</summary>
	public class LibraryEvent
	{
		public LibraryEvent()
		{
		}

		//public virtual ICollection<LibraryEventAction> Actions { get; set; }
		//public ActiveMessageAction ActiveMessageAction { get; }
		//public ActiveTrackingAction ActiveTrackingAction { get; }
		//public AlarmAction AlarmAction { get; }
		//public virtual ICollection<LibraryEventCondition> Conditions { get; set; }
		//[System.ComponentModel.DataAnnotations.RequiredAttribute(AllowEmptyStrings = false, ErrorMessage = "Field is required")]
		//[System.ComponentModel.DataAnnotations.StringLengthAttribute(200, ErrorMessage = "Field has maximum length of 200")]
		public string Description { get; set; }
		public long Id { get; set; }
		public string DisplayUnits { get; set; }
		public string FormatType { get; set; }
		public string ValueName { get; set; }

		//public RecordingAction RecordingAction { get; }
		//public Relay1Action Relay1Action { get; }
		//public Relay2Action Relay2Action { get; }
		//public CalculationType? ReturnCalculationType { get; set; }
		//public virtual LibraryParameterSummary ReturnParameter { get; set; }
		//public WarningAction WarningAction { get; }
	}
}
