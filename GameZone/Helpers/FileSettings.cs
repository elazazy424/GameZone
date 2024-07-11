namespace GameZone.Helpers
{
	public static class FileSettings
	{
        //images path
        public const string ImagesPath = "/assests/images";
        public const string  AllowedExtensions = ".jpg,.jpeg,.png";
		public const int MaxFileSizeInMB = 1;
		public const int MaxFileSizeInBytes = MaxFileSizeInMB * 2024 * 2024;
	}
}
