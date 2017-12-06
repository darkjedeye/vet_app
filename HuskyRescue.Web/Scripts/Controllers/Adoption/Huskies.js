function equalheight() {
	$('.equalheight').each(function (index) {
		var maxHeight = 0;
		$(this).children('heightset').each(function (index) {
			if ($(this).height() > maxHeight)
				maxHeight = $(this).height();
		});
		$(this).children('heightset').height(maxHeight);
	});
}
$(window).bind("load", equalheight);
$(window).bind("resize", equalheight);

function displayAnimal() {
	// get the id of the animal from the div's 'id' property that fired this function
	var animalId = this.id;
	var selectedAnimal = null;
	// find the animal in the animalObj (JSON) using the animalId
	for (var count = 0; count < animalsObj.length; count++) {
		if (animalsObj[count].animalID === animalId) {
			selectedAnimal = animalsObj[count];
			break;
		}
	}

	if (selectedAnimal != null) {
		$('#animalDetailModal').foundation('reveal', 'open');
		$('#petName').text(selectedAnimal.animalName);
		var fixed = '';
		if (selectedAnimal.animalSex == 'Female' && selectedAnimal.animalAltered == 'Yes') {
			fixed = 'spayed';
		}
		if (selectedAnimal.animalSex == 'Female' && selectedAnimal.animalAltered != 'Yes') {
			fixed = 'not spayed';
		}
		if (selectedAnimal.animalSex == 'Male' && selectedAnimal.animalAltered == 'Yes') {
			fixed = 'neutered';
		}
		if (selectedAnimal.animalSex == 'Male' && selectedAnimal.animalAltered != 'Yes') {
			fixed = 'not neutered';
		}
		var petSexAge = selectedAnimal.animalBreed;
		if (selectedAnimal.animalSex != '') petSexAge += ' :: ' + selectedAnimal.animalSex;
		if (fixed != '') petSexAge += ' (' + fixed + ') ';
		if (selectedAnimal.animalGeneralAge != '') petSexAge += ' :: ' + selectedAnimal.animalGeneralAge;
		
		$('#petSexAge').text(petSexAge);
		$('#petBio').html(selectedAnimal.animalDescription);
		$('#petAttributes').empty();
		var attributes = $('#petAttributes').append('<ul></ul>').find('ul');
		if (selectedAnimal.animalNeedsFoster.length > 0) {
			attributes.append('<li>Foster home needed: ' + selectedAnimal.animalNeedsFoster + '</li>');
		}
		if (selectedAnimal.animalStatus.length > 0) {
			attributes.append('<li>Adoption status: ' + selectedAnimal.animalStatus + '</li>');
		}
		if (selectedAnimal.animalColor.length > 0) {
			 attributes.append('<li>Coat color: ' + selectedAnimal.animalColor + '</li>');
		}
		if (selectedAnimal.animalCratetrained.length > 0) {
			attributes.append('<li>Crate trained: ' + selectedAnimal.animalCratetrained + '</li>');
		}
		if (selectedAnimal.animalEnergyLevel.length > 0) {
			attributes.append('<li>Energy level: ' + selectedAnimal.animalEnergyLevel + '</li>');
		}
		if (selectedAnimal.animalExerciseNeeds.length > 0) {
			attributes.append('<li>Exercise needs: ' + selectedAnimal.animalExerciseNeeds + '</li>');
		}
		if (selectedAnimal.animalEyeColor.length > 0) {
			attributes.append('<li>Eye color: ' + selectedAnimal.animalEyeColor + '</li>');
		}
		if (selectedAnimal.animalHousetrained.length > 0) {
			attributes.append('<li>House trained: ' + selectedAnimal.animalHousetrained + '</li>');
		}
		if (selectedAnimal.animalLeashtrained.length > 0) {
			attributes.append('<li>Leash trained: ' + selectedAnimal.animalLeashtrained + '</li>');
		}
		if (selectedAnimal.animalMixedBreed.length > 0) {
			attributes.append('<li>Mixed breed: ' + selectedAnimal.animalMixedBreed + '</li>');
		}
		if (selectedAnimal.animalOKWithAdults.length > 0) {
			attributes.append('<li>OK with adults: ' + selectedAnimal.animalOKWithAdults + '</li>');
		}
		if (selectedAnimal.animalOKWithCats.length > 0) {
			attributes.append('<li>OK with cats: ' + selectedAnimal.animalOKWithCats + '</li>');
		}
		if (selectedAnimal.animalOKWithDogs.length > 0) {
			attributes.append('<li>OK with other dogs: ' + selectedAnimal.animalOKWithDogs + '</li>');
		}
		if (selectedAnimal.animalOKWithKids.length > 0) {
			attributes.append('<li>OK with kids: ' + selectedAnimal.animalOKWithKids + '</li>');
		}
		if (selectedAnimal.animalSpecialneeds.length > 0) {
			if (selectedAnimal.animalSpecialneeds == 'Yes') {
				attributes.append('<li>Special needs: ' + selectedAnimal.animalSpecialneeds + ' (contact us for details)</li>');
			} else {
				attributes.append('<li>Special needs: ' + selectedAnimal.animalSpecialneeds + '</li>');
			}
		}
		
		// setup HTML for animal pictures
		$('#petPictures').empty();
		
		for (var pictureCount = 0; pictureCount < selectedAnimal.animalPictures.length; pictureCount++) {
			//  <div data-src="images/image_1.jpg"></div>
			var pictureObject = selectedAnimal.animalPictures[pictureCount];
			var pictureDiv = '<div data-src="' + pictureObject.urlSecureFullsize + '"></div>';
			//var pictureDiv = '<div data-src="' + pictureObject.urlSecureFullsize + '" data-thumb="'+ pictureObject.urlSecureThumbnail +'"></div>';
			$('#petPictures').append(pictureDiv);
		}

		// start the picture slide show
		$('#petPictures').camera({
			portrait: true
			//,thumbnails: true
		});
	}
}

$('.animalCell').on('mouseover', function () { $(this).addClass('animalCellHover'); });
$('.animalCell').on('mouseout', function () { $(this).removeClass('animalCellHover'); });
$('.animalCell').on('click', displayAnimal);

$('#revealClose').on('click', function() { $('#animalDetailModal').foundation('reveal', 'close'); });

