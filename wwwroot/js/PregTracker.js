const lmpDateInput = document.getElementById("lmp-date");
const outputField = document.getElementById("output-field");
const calculateBtn = document.getElementById("calculate-btn");

calculateBtn.addEventListener("click", () => {
    const lmpDate = new Date(lmpDateInput.value);
    const currentDate = new Date();
    const weeksPregnant = Math.floor((currentDate - lmpDate) / (7 * 24 * 60 * 60 * 1000));
    const daysPregnant = Math.floor((currentDate - lmpDate) / (24 * 60 * 60 * 1000)) % 7;
    outputField.value = `${weeksPregnant} weeks, ${daysPregnant} days`;
});