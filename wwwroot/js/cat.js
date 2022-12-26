$(document).ready(function () {
    console.log("Ok Ready")
    setInterval(function () {
        axios.get('https://catfact.ninja/fact')
            .then(function (response) {
                // handle success
                console.log(response.data);
                $("#fact").html("Fact: "+response.data.fact)
            })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
            .then(function () {
                // always executed
            });
    },5000)
})