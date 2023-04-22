$(document).ready(function () {
    $("#submitBtn").on('click', function () {
        var name = $("#name").val()
        console.log("OK")
        fetchData(`https://api.genderize.io?name=${name}`)
        
    })


    async function fetchData(url) {
      await  axios.get(url)
            .then(function (response) {
                // handle success
                console.log(response.data);
                var prob = response.data.probability * 100;
                $("#result").html('');
                    $("#result").html(`
                        <br> Name:${response.data.name}
                        <br> Gender Prediction: ${response.data.gender}
                        <br> Gender Probability: ${prob}%
                `);
            })
            .catch(function (error) {
                // handle error
                console.log(error);
                $("#body").html(`
                    "Error Occured:Please Refresh the Page"
                `)
            })
            .then(function () {
                // always executed
            });

    }
})