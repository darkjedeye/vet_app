using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Http;

namespace HuskyRescue.Web
{
	public class RouteConfig
	{
		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
			routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
			routes.MapRoute("RoughRiders", "RoughRiders", new { controller = "Events", action = "RoughRiders" });

			routes.MapRoute("Golf", "Golf", new { controller = "Events", action = "GolfTournament" });
			routes.MapRoute("GolfRegister", "GolfRegister", new { controller = "Events", action = "GolfTournamentRegister" });
			routes.MapRoute("GolfSponsors", "GolfSponsors", new { controller = "Events", action = "GolfTournamentSponsors" });
			routes.MapRoute("GolfAuction", "GolfAuction", new { controller = "Events", action = "GolfTournamentAuction" });

			routes.MapRoute("Raffle", "RollsRoyce", new { controller = "Events", action = "Raffle" });
			routes.MapRoute("RaffleTickets", "RollsRoyce/Tickets", new { controller = "Events", action = "RaffleTickets" });
			routes.MapRoute("RaffleGallery", "RollsRoyce/Gallery", new { controller = "Events", action = "RaffleGallery" });
			routes.MapRoute("RafflePrizes", "RollsRoyce/Prizes", new { controller = "Events", action = "RafflePrizes" });
			routes.MapRoute("RaffleThankYou", "RollsRoyce/ThankYou", new { controller = "Events", action = "RaffleThankYou" });
			routes.MapRoute("RaffleFinePrint", "RollsRoyce/Rules", new { controller = "Events", action = "RaffleFinePrint" });

			routes.MapRoute("Donate", "Donate", new { controller = "Donation", action = "Index" });

			routes.MapRoute("imagethumb", "Image/Thumbnail/{*url}", new { controller = "Image", action = "Thumbnail" });

			routes.MapRoute(
				"Default", // Route name
				"{controller}/{action}/{id}", // URL with parameters
				new { controller = "Home", action = "Index", id = UrlParameter.Optional }, // Parameter defaults
				new[] { "HuskyRescue.Web.Controllers" }
			);

			routes.MapRoute("", "EventRegistration/{action}", new { action = "CreateGolfReg" });

		}
	}
}