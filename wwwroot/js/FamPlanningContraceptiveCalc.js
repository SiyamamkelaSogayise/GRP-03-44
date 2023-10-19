function calculate() {
    var men_day = document.getElementById("men_date").value;
    var men_min = document.getElementById("men_min").value;
    var men_max = document.getElementById("men_max").value;

    var m1 = men_min - 18;
    var m2 = men_max - 11;

    var men_date = new Date(men_day);

    var ovul_1 = new Date(men_date);
    var ovul_2 = new Date(men_date);

    ovul_1.setDate(ovul_1.getDate() + m1);
    ovul_2.setDate(ovul_2.getDate() + m2);

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

    document.getElementById("result_1").innerHTML = "Ovulation falls on the <b><u>" + m1 + " - " + m2 + "</b></u>th day of the menstrual cycle.";
    document.getElementById("result_2").innerHTML = "This corresponds to the dates between <b><u>" + ovul_1.getDate() + " " + months[ovul_1.getMonth()] + " – " + ovul_2.getDate() + " " + months[ovul_2.getMonth()] + "</b></u>.";
}