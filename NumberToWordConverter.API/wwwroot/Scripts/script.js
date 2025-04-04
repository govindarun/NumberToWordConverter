document.addEventListener("DOMContentLoaded", function () {
    const convertButton = document.getElementById("btnConvert");
    const numberInput = document.getElementById("txtNumber");
    const resultElement = document.getElementById("result");

    convertButton.addEventListener("click", function () {
        const number = numberInput.value.trim();

        if (!number) {
            resultElement.textContent = "Please enter a valid number.";
            return;
        }

        fetch(`NumberToWord?inputNumber=${encodeURIComponent(number)}`)
            .then(response => {
                if (!response.ok) {
                    throw new Error("Failed to fetch data.");
                }
                return response.text();
            })
            .then(data => {
                resultElement.textContent = data;
            })
            .catch(error => {
                resultElement.textContent = "Error: " + error.message;
            });
    });
});
