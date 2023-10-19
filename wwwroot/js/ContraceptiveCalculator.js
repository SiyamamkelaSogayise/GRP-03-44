
    function calculate() {
        var lastContraceptiveDate = document.getElementById("men_date").value;
    var frequency = document.getElementById("men_min").value;
    var contraceptiveType = document.getElementById("men_max").value;

    var nextContraceptiveDate = new Date(lastContraceptiveDate);

    if (contraceptiveType === 'monthly') {
        nextContraceptiveDate.setMonth(nextContraceptiveDate.getMonth() + parseInt(frequency));
        } else if (contraceptiveType === 'weekly') {
        nextContraceptiveDate.setDate(nextContraceptiveDate.getDate() + 7 * parseInt(frequency));
        } else if (contraceptiveType === 'daily') {
        nextContraceptiveDate.setDate(nextContraceptiveDate.getDate() + parseInt(frequency));
        }

    var months = [
    'January',
    'February',
    'March',
    'April',
    'May',
    'June',
    'July',
    'August',
    'September',
    'October',
    'November',
    'December'
    ];

    document.getElementById("result_1").innerHTML = "Next contraceptive date is on <b><u>" + nextContraceptiveDate.getDate() + " " + months[nextContraceptiveDate.getMonth()] + " " + nextContraceptiveDate.getFullYear() + "</b></u>.";
document.getElementById("result_2").innerHTML = "This is as per the " + contraceptiveType + " cycle every " + frequency + " " + contraceptiveType + "s.";
}
