/**
function initialLoad() {
	var currDevice = "0"

	$.getJSON("../js/tempData.json", function(json) {
		for(var i in json["list"]) {       
			document.getElementById("eu-dev-list").innerHTML += '<div class="col-xs-6 col-sm-2 deviceChange" id="'+ json["list"][i]["id"]+'">'
			+ '<a href="javascript:void(0);" class="active">'
			+ '<div class="circle-icon"><i class="far fa-lightbulb fa-3x"></i></div>'
			+ '<strong>' + json["list"][i]["type"]+ '</strong>'
			+ '</a></div>'; 		
		}
		document.getElementById("eu-dev-info-basic").innerHTML += '<div class="col-sm-4 dev-model">Model: ' + json["list"][0]["model"]+ '</div>'
		+ '<div class="col-sm-4 dev-brand">Brand: ' + json["list"][0]["brand"]+ '</div>';	
	});
}

$( document ).ready(function() {
	$('.deviceChange').click(function(){
		var clickedID = this.id;
		$.getJSON("../js/tempData.json", function(json) {
			$('.dev-model').html(json["list"][clickedID]["model"]);
			$('.dev-brand').html(json["list"][clickedID]["brand"]);
		});
	});
});



initialLoad();
**/