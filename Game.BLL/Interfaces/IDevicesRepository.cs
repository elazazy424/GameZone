using Game.DAL.Entity;

namespace Game.BLL.Interfaces
{
	public interface IDevicesRepository
	{
		Task<IEnumerable<Device>> GetAllDevicesAsync();
		Task<Device> GetDeviceByIdAsync(int id);
		Task<Device> CreateDeviceAsync(Device device);
		Task<Device> UpdateDeviceAsync(Device device);
		Task DeleteDeviceAsync(int id);
        Task<List<int>> GetExistingDeviceIdsAsync(IEnumerable<int> deviceIds);

    }
}
