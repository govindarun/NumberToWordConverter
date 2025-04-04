document.addEventListener("DOMContentLoaded", function () {
    const convertButton = document.getElementById("btnConvert");
    const numberInput = document.getElementById("txtNumber");
  const numberNameElement = document.getElementById("numberName");

    convertButton.addEventListener("click", function () {
        const number = numberInput.value.trim();

        if (!number) {
            numberNameElement.textContent = "Please enter a valid number.";
            return;
        }

      fetch(`NumberToWord?inputNumber=${encodeURIComponent(number)}`)
        .then(response => {
          if (!response.ok) {
            response.text()
              .then(data => {
                const error = JSON.parse(data);
                numberNameElement.textContent = "Error: " + error.message;
              });
          }
          return response.text();
        })
        .then(data => {
          numberNameElement.textContent = data;
        });
    });
});
