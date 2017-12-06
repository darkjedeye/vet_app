using System.Web;
using System.Web.Optimization;

namespace HuskyRescue.Web
{
	public class BundleConfig
	{
		// For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
		public static void RegisterBundles(BundleCollection bundles)
		{

			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
				"~/Scripts/jquery.validate*"));

			bundles.Add(new ScriptBundle("~/bundles/top/js").Include( // included at the top of the _layout.cshtml page per ZURB foundation documents
				"~/Scripts/Vendor/Misc/modernizr-{version}.js"));

			bundles.Add(new ScriptBundle("~/bundles/main/js").Include(
				"~/Scripts/Vendor/jQuery/jquery-{version}.js",
				"~/Scripts/Vendor/jQuery/jquery-migrate-{version}.js",
				"~/Scripts/Vendor/jQuery/UI/jquery-ui-{version}.js",
				//"~/Scripts/Vendor/jQuery/Validation/jquery.unobtrusive.js",
				"~/Scripts/Vendor/jQuery/Plugins/jquery.cookie.js",
				"~/Scripts/Vendor/jQuery/Plugins/jquery.unobtrusive-ajax.js", // used for ajax in various places
				"~/Scripts/Vendor/jQuery/Plugins/jquery.easing.{version}.js", // used in public page theme
				"~/Scripts/Vendor/jQuery/Plugins/jquery.gritter.js", //  jQuery Growl look-a-like plugin http://boedesign.com/blog/2009/07/11/growl-for-jquery-gritter/
				"~/Scripts/Vendor/jQuery/Plugins/jquery.maskedinput-{version}.js",
				"~/Scripts/Vendor/jQuery/Plugins/jquery.loading.{version}.js", // used on contact form
				"~/Scripts/Vendor/jQuery/Plugins/jquery.blockUI.js", // simulate synchronous behavior when using AJAX, without locking the browser http://www.malsup.com/jquery/block/
				"~/Scripts/Vendor/jQuery/Plugins/jquery.pulsate.js", // Pulse Animation http://jsoverson.github.io/jquery.pulse.js/
				"~/Scripts/Vendor/jQuery/Plugins/jquery.placeholder.js",

				"~/Scripts/Vendor/twitter/plugins/moment.js", //  date library for parsing, validating, manipulating, and formatting dates http://momentjs.com/
				"~/Scripts/Vendor/Misc/fastclick.js",
				"~/Scripts/Vendor/Misc/json2.js",
				"~/Scripts/Vendor/Misc/jsrender.js",
				"~/Scripts/Vendor/Misc/jstz.js",
				
				"~/Scripts/Vendor/foundation/foundation.js",
				//"~/Scripts/Vendor/foundation/foundation.migrate.js",
				"~/Scripts/Vendor/foundation/foundation.abide.js",
				"~/Scripts/Vendor/foundation/foundation.accordion.js",
				"~/Scripts/Vendor/foundation/foundation.alerts.js",
				"~/Scripts/Vendor/foundation/foundation.clearing.js",
				"~/Scripts/Vendor/foundation/foundation.dropdown.js",
				"~/Scripts/Vendor/foundation/foundation.equalizer.js",
				"~/Scripts/Vendor/foundation/foundation.interchange.js",
				//"~/Scripts/Vendor/foundation/foundation.forms.js",
				"~/Scripts/Vendor/foundation/foundation.joyride.js",
				"~/Scripts/Vendor/foundation/foundation.magellan.js",
				"~/Scripts/Vendor/foundation/foundation.offcanvas.js",
				"~/Scripts/Vendor/foundation/foundation.orbit.js",
				//"~/Scripts/Vendor/foundation/foundation.placeholder.js",
				"~/Scripts/Vendor/foundation/foundation.reveal.js",
				//"~/Scripts/Vendor/foundation/foundation.divSection.js",
				"~/Scripts/Vendor/foundation/foundation.slider.js",
				"~/Scripts/Vendor/foundation/foundation.tab.js",
				"~/Scripts/Vendor/foundation/foundation.tooltip.js",
				"~/Scripts/Vendor/foundation/foundation.topbar.js",

				"~/Scripts/Common/PhoneNumberMask.js",
				"~/Scripts/Common/ZipCodeMask.js",
				"~/Scripts/Common/Common.js",
				"~/Scripts/Common/Common.Public.js"));

			bundles.Add(new StyleBundle("~/bundles/main/css").Include(
				"~/Content/Styles/Vendor/foundation/normalize.css",
				"~/Content/Styles/Vendor/foundation/foundation.css",
				"~/Content/Styles/Vendor/foundation/foundation.custom.css",
				"~/Content/Styles/Vendor/foundation/foundation-icons.css",
				"~/Content/Styles/Vendor/font-awesome.css",
				"~/Content/Styles/Vendor/jQuery/Plugins/jquery.gritter.css",
				"~/Content/Styles/Vendor/Google/GSS.css"));

			bundles.Add(new StyleBundle("~/bundles/adminF/css").Include(
				"~/Content/Styles/Vendor/foundation/normalize.css",
				"~/Content/Styles/Vendor/foundation/foundation.css",
				"~/Content/Styles/Vendor/foundation/foundation-icons.css",
				"~/Content/Styles/Vendor/font-awesome.css",
				"~/Content/Styles/Vendor/jQuery/themes/base/jquery-ui.css",
				"~/Content/Styles/Vendor/jQuery/Plugins/jquery.gritter.css",
				"~/Content/Styles/Vendor/jQuery/Plugins/jquery.easy-pie-chart.css",
				"~/Content/Styles/Vendor/jqwidgets/jqx.base.css",
				"~/Content/Styles/Vendor/jqwidgets/jqx.metro.css",
				"~/Content/Styles/Vendor/foundation/foundation.admin.css"
				));

			bundles.Add(new ScriptBundle("~/bundles/adminF/js").Include(
				"~/Scripts/Vendor/jQuery/jquery-{version}.js",
				"~/Scripts/Vendor/jQuery/jquery-migrate-{version}.js",
				"~/Scripts/Vendor/jQuery/UI/jquery-ui-{version}.js",
				"~/Scripts/Vendor/jQuery/Plugins/jquery.cookie.js",
				"~/Scripts/Vendor/jQuery/Plugins/jquery.unobtrusive-ajax.js", // used for ajax in various places
				"~/Scripts/Vendor/jQuery/Plugins/jquery.easing.{version}.js", // used in public page theme
				"~/Scripts/Vendor/jQuery/Plugins/jquery.loading.{version}.js", // used on contact form
				"~/Scripts/Vendor/jQuery/Plugins/jquery.maskedinput-{version}.js",
				"~/Scripts/Vendor/jQuery/Plugins/jquery.blockUI.js", // simulate synchronous behavior when using AJAX, without locking the browser http://www.malsup.com/jquery/block/
				"~/Scripts/Vendor/jQuery/Plugins/jquery.slimscroll.js", // transforms any div into a scrollable area with a nice scrollbar http://rocha.la/jQuery-slimScroll
				"~/Scripts/Vendor/jQuery/Plugins/jquery.pulsate.js", // Pulse Animation http://jsoverson.github.io/jquery.pulse.js/
				"~/Scripts/Vendor/jQuery/Plugins/jquery.placeholder.js",
				"~/Scripts/Vendor/twitter/plugins/moment.js", //  date library for parsing, validating, manipulating, and formatting dates http://momentjs.com/
				"~/Scripts/Vendor/jQuery/Plugins/jquery.gritter.js", //  jQuery Growl look-a-like plugin http://boedesign.com/blog/2009/07/11/growl-for-jquery-gritter/
				"~/Scripts/Vendor/jQuery/Plugins/jquery.easy-pie-chart.js",
				"~/Scripts/Vendor/jQuery/Plugins/jquery.sparkline.js",
				"~/Scripts/Vendor/jqwidgets/jqx-all.js",

				"~/Scripts/Vendor/Misc/fastclick.js", 
				"~/Scripts/Vendor/Misc/json2.js",
				"~/Scripts/Vendor/Misc/jsrender.js",
				"~/Scripts/Vendor/Misc/jstz.js",

				"~/Scripts/Vendor/foundation/foundation.js",
				//"~/Scripts/Vendor/foundation/foundation.migrate.js",
				"~/Scripts/Vendor/foundation/foundation.abide.js",
				"~/Scripts/Vendor/foundation/foundation.accordion.js",
				"~/Scripts/Vendor/foundation/foundation.alerts.js",
				"~/Scripts/Vendor/foundation/foundation.clearing.js",
				"~/Scripts/Vendor/foundation/foundation.dropdown.js",
				"~/Scripts/Vendor/foundation/foundation.equalizer.js",
				"~/Scripts/Vendor/foundation/foundation.interchange.js",
				//"~/Scripts/Vendor/foundation/foundation.forms.js",
				"~/Scripts/Vendor/foundation/foundation.joyride.js",
				"~/Scripts/Vendor/foundation/foundation.magellan.js",
				"~/Scripts/Vendor/foundation/foundation.offcanvas.js",
				"~/Scripts/Vendor/foundation/foundation.orbit.js",
				//"~/Scripts/Vendor/foundation/foundation.placeholder.js",
				"~/Scripts/Vendor/foundation/foundation.reveal.js",
				//"~/Scripts/Vendor/foundation/foundation.divSection.js",
				"~/Scripts/Vendor/foundation/foundation.slider.js",
				"~/Scripts/Vendor/foundation/foundation.tab.js",
				"~/Scripts/Vendor/foundation/foundation.tooltip.js",
				"~/Scripts/Vendor/foundation/foundation.topbar.js",

				"~/Scripts/Common/Common.js",
				"~/Scripts/Common/Common.Admin.js"));

			#region action specific bundles
			bundles.Add(new ScriptBundle("~/bundles/admin/index1/js").Include(
				"~/Scripts/Controllers/Admin/Index.js"));

			bundles.Add(new ScriptBundle("~/bundles/admin/RescueCount/js").Include(
				"~/Scripts/Controllers/Admin/RescueCount.js"));

			bundles.Add(new ScriptBundle("~/bundles/Donation/Donate/js").Include(
				"~/Scripts/Controllers/Donation/Donate.js"));


			bundles.Add(new ScriptBundle("~/bundles/adoption/apply/js").Include(
				"~/Scripts/Controllers/Adoption/AdoptionApplication.js"));

			bundles.Add(new ScriptBundle("~/bundles/adoption/huskies/js").Include(
				"~/Scripts/Vendor/jQuery/Plugins/camera.js",
				"~/Scripts/Controllers/Adoption/huskies.js"));

			bundles.Add(new StyleBundle("~/bundles/adoption/huskies/css").Include(
				"~/Content/Styles/Vendor/jQuery/Plugins/camera.css",
				"~/Content/Styles/Controllers/Adoption/Huskies.css"));

			bundles.Add(new StyleBundle("~/bundles/blog/css").Include(
				"~/Content/Styles/Controllers/Blog/Blog.css"));

			bundles.Add(new ScriptBundle("~/bundles/events/addsponsor/js").Include(
				"~/Scripts/Controllers/Events/EventAddSponsor.js"));

			bundles.Add(new ScriptBundle("~/bundles/events/calendar/js").Include(
				"~/Scripts/Vendor/Misc/fullcalendar.js",
				"~/Scripts/Vendor/Misc/gcal.js",
				"~/Scripts/Controllers/Events/Calendar.js"));
			bundles.Add(new StyleBundle("~/bundles/events/calendar/css").Include(
				"~/Content/Styles/Vendor/Misc/fullcalendar.css",
				"~/Content/Styles/Vendor/Misc/fullcalendar.print.css"));

			bundles.Add(new ScriptBundle("~/bundles/events/create/js").Include(
				"~/Scripts/Controllers/Events/Create.js"));

			bundles.Add(new ScriptBundle("~/bundles/events/golf/js").Include(
				"~/Scripts/Controllers/Events/golf.js"));

			bundles.Add(new ScriptBundle("~/bundles/events/roughriders/js").Include(
				"~/Scripts/Controllers/Events/roughriders.js"));

			bundles.Add(new ScriptBundle("~/bundles/events/raffle/js").Include(
				"~/Scripts/Vendor/jQuery/Plugins/jquery.countdown.js",
				"~/Scripts/Controllers/Events/raffle.js"));
			bundles.Add(new StyleBundle("~/bundles/events/raffle/css").Include(
				"~/Content/Styles/Vendor/jQuery/Plugins/jquery.countdown.css",
				"~/Content/Styles/Controllers/Events/Raffle.css"));

			bundles.Add(new ScriptBundle("~/bundles/camera/js").Include(
				"~/Scripts/Vendor/jQuery/Plugins/jquery.mobile.customized.min.js",
				"~/Scripts/Vendor/jQuery/Plugins/camera.js"));
			bundles.Add(new StyleBundle("~/bundles/camera/css").Include(
				"~/Content/Styles/Vendor/jQuery/Plugins/camera.css"));

			bundles.Add(new StyleBundle("~/bundles/events/sponsorshiptype/css").Include(
				"~/Content/Styles/Controllers/Events/SponsorshipTypesPublic.css"));

			bundles.Add(new ScriptBundle("~/bundles/fileupload/js").Include(
				"~/Scripts/Vendor/jQuery/Plugins/jquery.fineuploader-{version}.js",
				"~/Scripts/Controllers/Files/FileUpload.js"));
			bundles.Add(new StyleBundle("~/bundles/fileupload/css").Include(
				"~/Content/Styles/Vendor/jQuery/Plugins/fineuploader.css"));

			bundles.Add(new ScriptBundle("~/bundles/home/index/js").Include(
				"~/Scripts/Vendor/jQuery/Plugins/camera.js",
				"~/Scripts/Controllers/Home/Index.js"));
			bundles.Add(new StyleBundle("~/bundles/home/index/css").Include(
				"~/Content/Styles/Vendor/jQuery/Plugins/camera.css"));

			bundles.Add(new ScriptBundle("~/bundles/info/contact/js").Include(
				"~/Scripts/Vendor/jQuery/Plugins/jquery.maskedinput-{version}.js",
				"~/Scripts/Controllers/Info/ContactForm.js"));

			bundles.Add(new ScriptBundle("~/bundles/log/index1/js").Include(
				"~/Scripts/Controllers/Log/GetLog.js"));

			bundles.Add(new ScriptBundle("~/bundles/person/detail/js").Include(
				"~/Scripts/Controllers/Person/PersonViewModel.js"));

			#endregion

			BundleTable.EnableOptimizations = false;
		}
	}
}
