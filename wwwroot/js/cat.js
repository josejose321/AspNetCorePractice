$(document).ready(function () {
    let url = "https://catfact.ninja/fact"
    console.log("Ok Ready")
    fetchData(url);
    $("#catForm").on("submit", function (e) {
        e.preventDefault();
        fetchData(url);
    })


    function fetchData(url = 'https://catfact.ninja/fact') {
        axios.get(url)
            .then(function (response) {
                // handle success
                console.log(response.data);
                displayCatFact(response.data.fact);
            })
            .catch(function (error) {
                // handle error
                console.log(error);
                displayCatFact(error)
            })
            .then(function () {
                // always executed
            });
    }

    function displayCatFact(fact) {
        var typed = new Typed('#fact', {
            strings: ["Fact:...", fact],
            typeSpeed: 30
        });
    }
})