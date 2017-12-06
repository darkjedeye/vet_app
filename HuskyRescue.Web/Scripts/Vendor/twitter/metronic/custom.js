
function SetActiveMenu() {
	var url = window.location.pathname,
		urlRegExp = new RegExp(url.replace(/\/$/, ''));
	$('#sidebarUl li a').each(function () {
		if (urlRegExp.test(this.href)) {
			// add active class to the parent List Item of the clicked on link
			$(this).closest('li').addClass('active');
			// check if the link is a sub-menu
			if ($(this).parent().parent().closest('li').length > 0)
			{
				// if so add 'active' and 'open' classes to the parent menu List Item
				$(this).parent().parent().closest('li').addClass('active').addClass('open');

				// Insert span to indicate the selected parent menu with a left chevron of the content body's background color
				$(this).parent().parent().closest('li').children('a').append('<span class="selected"></span>')

				// change the arrow style for the parent menu from left to down
				$(this).parent().parent().closest('li').children('a').children('span.arrow').addClass('open');
			}
		}
	});
}

