using AutoMapper;


namespace HuskyRescue.Core.Mappers.Logging
{
	public class Log : Profile
	{
		public override string ProfileName
		{
			get { return "LoggingLogMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Logging.Log, Model.Log>();
			Mapper.CreateMap<Model.Log, ViewModel.Logging.Log>();
		}
	}
}
