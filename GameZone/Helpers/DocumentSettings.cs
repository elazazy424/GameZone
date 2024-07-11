namespace GameZone.Helpers
{
	public  class DocumentSettings
	{
		public static string UploadFile(IFormFile file, string folderName)
		{
			//1 get location of folder path
			var folderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assests", folderName);
			//2 get file name and make it unique
			var fileName = $"{Guid.NewGuid()}{Path.GetFileName(file.FileName)}";
			//3 get FILE path
			var filePath = Path.Combine(folderPath, fileName);
			//4 save file as streams
			using var fileStream = new FileStream(filePath, FileMode.Create);
			file.CopyTo(fileStream);
			return fileName;
		}
	}
}
