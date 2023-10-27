
function validateField() {
	var x = document.forms["Field"]["fname"].value;
	if (x == null || x == " ") {
		alert("please enter your name");
		return false;
	}
}