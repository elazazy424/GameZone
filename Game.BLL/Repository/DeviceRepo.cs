using Game.BLL.Interfaces;
using Game.DAL.Data;
using Game.DAL.Entity;
using Microsoft.EntityFrameworkCore;

namespace Game.BLL.Repository
{
	public class DeviceRepo : IDevicesRepository
	{
		private readonly ApplicationDbContext _context;
		public DeviceRepo(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<Device> CreateDeviceAsync(Device device)
		{
			var newDevice = new Device
			{
				Name = device.Name,
				Icon = device.Icon
			};
			_context.Devices.Add(newDevice);
			await _context.SaveChangesAsync();
			return newDevice;
		}

		public async Task DeleteDeviceAsync(int id)
		{
			var device = await _context.Devices.FindAsync(id);
			if (device != null)
			{
				_context.Devices.Remove(device);
				await _context.SaveChangesAsync();
			}
			else
			{
				throw new Exception("Device not found");
			}	
		}

		public async Task<IEnumerable<Device>> GetAllDevicesAsync()
		{
			var devices = await _context.Devices.ToListAsync();
			return devices;
		}

		public async Task<Device> GetDeviceByIdAsync(int id)
		{
			var device = await _context.Devices.FindAsync(id);
			if (device == null)
			{
				throw new Exception("Device not found");
			}
			return device;
		}

		public async Task<Device> UpdateDeviceAsync(Device device)
		{
			var deviceToUpdate = await _context.Devices.FindAsync(device.Id);
			if (deviceToUpdate != null)
			{
				deviceToUpdate.Name = device.Name;
				deviceToUpdate.Icon = device.Icon;
				await _context.SaveChangesAsync();
				return deviceToUpdate;
			}
			else
			{
				throw new Exception("Device not found");
			}
		}

        public async Task<List<int>> GetExistingDeviceIdsAsync(IEnumerable<int> deviceIds)
        {
            return await _context.Devices
                                 .Where(d => deviceIds.Contains(d.Id))
                                 .Select(d => d.Id)
                                 .ToListAsync();
        }
    }
}
