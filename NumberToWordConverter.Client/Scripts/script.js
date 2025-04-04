document.addEventListener("DOMContentLoaded", function () {
    const convertButton = document.getElementById("convertButton");
    const numberInput = document.getElementById("numberInput");
    const resultElement = document.getElementById("result");

    convertButton.addEventListener("click", function () {
        const number = numberInput.value.trim();

        if (!number) {
            resultElement.textContent = "Please enter a valid number.";
            return;
        }

        fetch(`https://localhost:44351/NumberToWord?inputNumber=${encodeURIComponent(number)}`)
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
