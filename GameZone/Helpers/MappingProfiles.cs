using AutoMapper;
using Game.DAL.Entity;
using GameZone.ViewModels;

namespace GameZone.Helpers
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<Gamee, CreateGameFormViewModel>().ReverseMap();



			CreateMap<EditGameFormViewModel, Gamee>()
			.ForMember(dest => dest.Cover, opt => opt.Ignore()) // Ignore Cover initially
			.ForMember(dest => dest.GameDevices, opt => opt.Ignore()); // Ignore GameDevices initially

			CreateMap<Gamee, EditGameFormViewModel>()
				.ForMember(dest => dest.Cover, opt => opt.Ignore()) // Ignore Cover initially
				.ForMember(dest => dest.SelectedDevices, opt => opt.MapFrom(src => src.GameDevices.Select(d => d.DeviceId).ToList()));
		}
	}
}
