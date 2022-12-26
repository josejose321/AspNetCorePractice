$(document).ready(function () {
    console.log("Ok Ready")
        axios.get('https://api.coindesk.com/v1/bpi/currentprice.json')
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
    function displayValues(data) {
        console.log(data)
        $("#body").html(`
        <div class="row">
            <div class="col-sm">
                Description
            </div>
            <div class="col-sm">
                Rate
            </div>
        </div>
        <div class="row">
            <div class="col-sm">
                ${data.USD.description}
            </div>
            <div class="col-sm">
               ${data.USD.code}  ${data.USD.symbol}${data.USD.rate}
            </div>
        </div>
        <div class="row">
            <div class="col-sm">
                ${data.EUR.description}
            </div>
            <div class="col-sm">
               ${data.EUR.code}  ${data.EUR.symbol}${data.EUR.rate}
            </div>
        </div>
        <div class="row">
            <div class="col-sm">
                ${data.GBP.description}
            </div>
            <div class="col-sm">
               ${data.GBP.code}  ${data.GBP.symbol}${data.GBP.rate}
            </div>
        </div>
    `)
    }
})
