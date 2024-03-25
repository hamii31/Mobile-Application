using PetAdoptionMobileApplication.Common.Enums;

namespace PetAdoptionMobileApplication.Common.DTOs
{
	public class PetInfoDTO : PetListDTO
	{
		public Guid Id { get; set; }
		public bool IsFav { get; set; }
		public string Description { get; set; }
		public Gender Gender { get; set; }
		public DateTime BirthDate { get; set; }
		public AdoptionStatus AdoptionStatus { get; set; }

		public string GenderDisplay => Gender.ToString();
		public string GenderImage => Gender switch { Gender.Male => "Male", Gender.Female => "Female" };

		public string Age
		{
			get
			{
				var difference = DateTime.Now - BirthDate;
				var days = difference.Days;

				switch (days)
				{
					case < 30:
						return days + "days";
					case >=30 and <= 31:
						return "1 month";
					case < 365:
						return Math.Floor(difference.TotalDays / 30) + "months";
					case 365:
						return "1 year";
					default:
						return Math.Floor(difference.TotalDays / 30) + "years";
				}
			}
		}

	}
}
