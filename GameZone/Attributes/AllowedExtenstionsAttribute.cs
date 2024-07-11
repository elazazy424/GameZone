using System.ComponentModel.DataAnnotations;

namespace GameZone.Attributes
{
	public class AllowedExtenstionsAttribute : ValidationAttribute
	{
		private readonly string _allowedExtensions;

		public AllowedExtenstionsAttribute(string allowedExtensions)
		{
			_allowedExtensions = allowedExtensions;
		}
		protected override ValidationResult? IsValid
			(object? value, ValidationContext validationContext)
		{
			var file = value as IFormFile;
			if (file != null)
			{
				var extension = Path.GetExtension(file.FileName);
				var isAllowed = _allowedExtensions
								.Split(new[] { ',' })
								.Contains(extension, StringComparer.OrdinalIgnoreCase);
				if (!isAllowed)
				{
					return new ValidationResult($"Only {_allowedExtensions} are allowed!");
				}

			}
			return ValidationResult.Success;
		}
	}
}
