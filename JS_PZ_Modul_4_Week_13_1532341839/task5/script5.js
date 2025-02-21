document.addEventListener("DOMContentLoaded", function() {
    const countries = [
        "Afghanistan", "Albania", "Algeria", "Andorra", "Angola", 
        "Antigua and Barbuda", "Argentina", "Armenia", "Australia", "Austria",
        "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", 
        "Belgium", "Belize", "Benin", "Bhutan", "Bolivia",
        "Cambodia", "Cameroon", "Canada", "Cape Verde", "Central African Republic", 
        "Chad", "Chile", "China", "Colombia", "Comoros",
        "Denmark", "Djibouti", "Dominica", "Dominican Republic",
        "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", 
        "Eritrea", "Estonia", "Eswatini", "Ethiopia",
        "Fiji", "Finland", "France",
        "Gabon", "Gambia", "Georgia", "Germany", "Ghana", 
        "Greece", "Grenada", "Guatemala", "Guinea", "Guinea-Bissau",
        "Haiti", "Honduras", "Hungary",
        "Iceland", "India", "Indonesia", "Iran", "Iraq", 
        "Ireland", "Israel", "Italy",
        "Jamaica", "Japan", "Jordan"
    ];

    const input = document.getElementById("npt");
    const hintsContainer = document.querySelector(".hints");

    input.addEventListener("input", function() {
        const userInput = input.value.trim().toLowerCase();
        hintsContainer.innerHTML = "";

        if (userInput.length > 0) {
            const filteredCountries = [];
            for (let i = 0; i < countries.length; i++) {
                if (countries[i].toLowerCase().startsWith(userInput)) {
                    filteredCountries.push(countries[i]);
                }
                if (filteredCountries.length >= 10) {
                    break;
                }
            }

            for (let i = 0; i < filteredCountries.length; i++) {
                const hint = document.createElement("div");
                hint.classList.add("hint");
                hint.textContent = filteredCountries[i];

                hint.addEventListener("click", function() {
                    input.value = filteredCountries[i];
                    hintsContainer.innerHTML = "";
                });

                hintsContainer.appendChild(hint);
            }
        }
    });
});