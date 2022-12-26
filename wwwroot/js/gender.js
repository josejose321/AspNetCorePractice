$(document).ready(function () {
    $("#submitBtn").on('click', function (e) {
        e.prevenDefault();
        var name = $("#name").val();
        fetchData(`https://api.genderize.io?name=${name}`)
    })


    function fetchData(url) {
        axios.get(url)
            .then(function (response) {
                // handle success
                console.log(response.data);
                /*                $("#coindesk").html(JSON.stringify(response.data))*/
                $("#time").html(response.data.time.updated)
                $("#chartname").html(response.data.chartName)
                displayValues(response.data.bpi)
                $("#disclaimer").html(`Desclaimer:${response.data.disclaimer}`)
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