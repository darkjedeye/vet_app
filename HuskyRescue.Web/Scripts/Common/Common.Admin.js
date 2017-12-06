var App = function () {
	var handleSidebarMenu = function () {
		//jQuery('.page-sidebar').on('click', 'a', function (event) {
		//	// this   == "a"
		//	// parent == "dd"
		//	// next   == "div.content"
		//	if ($(this).next().children().hasClass('sub-menu') == false) {
		//		if ($('.btn-navbar').hasClass('collapsed') == false) {
		//			$('.btn-navbar').click();
		//		}
		//		return;
		//	}

		//	// this   == "a"
		//	// parent == "dd"
		//	// next   == "div.content"
		//	// child  == "ul"
		//	if ($(this).next().children().hasClass('sub-menu.always-open')) {
		//		return;
		//	}
		//	// dl.accordion.page-sidebar-menu.sidebar
		//	var parent = $(this).parent().parent();

		//	// remove open class and close the menu
		//	parent.children('dd.open').children('a').children('.arrow').removeClass('open');
		//	parent.children('dd.open').removeClass('open');

		//	// this   == "a"
		//	// parent == "dd"
		//	// next   == "div.content"
		//	var subMenu = jQuery(this).next();

		//	if (subMenu.is(":visible")) {
		//		// remove open arros from all menu items
		//		jQuery('.arrow', jQuery(this)).removeClass("open");
		//		// remove open from "dd"
		//		jQuery(this).parent().removeClass("open");
		//	} else {
		//		// add open class to the "span" next to the "a"
		//		jQuery('.arrow', jQuery(this)).addClass("open");
		//		// add open class to the "section"
		//		jQuery(this).parent().addClass("open");
		//	}

		//	event.preventDefault();
		//});
	};

	// Helper function to calculate sidebar height for fixed sidebar layout.
	var calculateFixedSidebarViewportHeight = function () {
		var sidebarHeight = $(window).height() - $('.header').height() + 1;
		if ($('body').hasClass("page-footer-fixed")) {
			sidebarHeight = sidebarHeight - $('.footer').outerHeight();
		}

		return sidebarHeight;
	};

	var handleSidebarAndContentHeight = function () {
		var content = $('.page-content');
		var sidebar = $('.page-sidebar');
		var body = $('body');
		var height;

		if (body.hasClass("page-footer-fixed") === true && body.hasClass("page-sidebar-fixed") === false) {
			var availableHeight = $(window).height() - $('.footer').outerHeight();
			if (content.height() < availableHeight) {
				content.attr('style', 'min-height:' + availableHeight + 'px !important');
			}
		} else {
			if (body.hasClass('page-sidebar-fixed')) {
				height = calculateFixedSidebarViewportHeight();
			} else {
				height = sidebar.height() + 20;
			}
			if (height >= content.height()) {
				content.attr('style', 'min-height:' + height + 'px !important');
			}
		}
	};

	return {
		init: function () {
			handleSidebarMenu(); // handles main menu
			ConfigureFoundation();
			$(document).foundation('accordion', 'reflow');
			setGritterMessageFromCookie();
		},

		// wrapper function to scroll(focus) to an element
		scrollTo: function (el, offeset) {
			var pos = (el && el.size() > 0) ? el.offset().top : 0;
			jQuery('html,body').animate({
				scrollTop: pos + (offeset ? offeset : 0)
			}, 'slow');
		},

		// function to scroll to the top
		scrollTop: function () {
			App.scrollTo();
		}
	};
}();
