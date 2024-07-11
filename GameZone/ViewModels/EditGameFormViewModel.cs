
using GameZone.Attributes;
using GameZone.Helpers;

namespace GameZone.ViewModels
{
    public class EditGameFormViewModel : GameFormViewModel
    {
        public int Id { get; set; }

		[AllowedExtenstions(FileSettings.AllowedExtensions),
		   MaxFileSize(FileSettings.MaxFileSizeInBytes)]
		public IFormFile? Cover { get; set; } = default!;
		public string? CoverName { get; set; }
	}
}
