using AutoMapper;


namespace HuskyRescue.Core.Mappers.Logging
{
	public class LogUserActivity : Profile
	{
		public override string ProfileName
		{
			get { return "LoggingLogMapping"; }
		}

		protected override void Configure()
		{
			Mapper.CreateMap<ViewModel.Logging.LogUserActivity, Model.LogUserActivity>();
			Mapper.CreateMap<Model.LogUserActivity, ViewModel.Logging.LogUserActivity>();
		}
	}
}
