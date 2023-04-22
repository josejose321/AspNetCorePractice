var results = document.getElementById("results");
var next = null;
var previous = null;
var current = null;
var image = "";
$(document).ready(function () {
    //$("#table").dataTable();
    var data;
    console.log("Ok Ready")
    getPokemon(current = 'https://pokeapi.co/api/v2/pokemon')
})
async function getPokemon(url) {
    await axios.get(url)
        .then(function (response) {
            // handle success
            console.log(response.data);
            displayPokemon(response.data);
        })
        .catch(function (error) {
            // handle error
            console.log(error);
        })
        .then(function () {
            // always executed
        });
}
 function getPokemonDetails(url) {
     axios
        .get(url)
        .then(function (response) {
            // handle success
            console.log(response.data);
            displayPokemonDetails(response.data);
        })
        .catch(function (error) {
            // handle error
            console.log(error);
        })
        .then(function () {
            // always executed
        });
}
function displayPokemonDetails(data) {
    let abilities = getAbilities(data.abilities);
    let types = getTypes(data.types);
    let moves = getMoves(data.moves)
    let stats = getStats(data.stats)

    

    $("#pokemon_details").empty();

    $("#pokemon_name").html(`<strong>${data.name} Details</strong>`)
    console.log(data.name)
    //< img src = "${data.sprites.back_default}" class="card-img-top float-center" alt = "Italian Trulli" >
    $("#pokemon_details").append(
        `
                <div class="card">
                          <img src="${data.sprites.front_default}" class="rounded border" alt="Italian Trulli">
                  <div class="card-body">
                        No#:    ${data.id} <br/>
                        Name:   ${data.name} <br/>
                        Height: ${data.height} <br/>
                        Weight: ${data.weight} <br/>
                        Abilities: ${abilities} <br/>
                        Base Stats: <br/> 
                        <ul>
                            ${stats}
                        </ul>
                        Type:${types} <br/>
                            Moves:<br/>
                        <ul id="moves">
                            ${moves}
                        </ul>
                </div>
           </div>
          
            
            
        `)

}
function getAbilities(abilities) {
    let data = "";
    abilities.forEach(ability => {
        data += " " + ability.ability.name;
    })
    return data;
}
function getStats(stats) {
    let data = "";
    stats.forEach(stat => {
        data += "<li>" + stat.stat.name + ":" + stat.base_stat + "</li>"
    })
    return data;
}
function getTypes(types) {
    let data = "";
    types.forEach(type => {
        data += " " + type.type.name;
    })
    return data
}
function getMoves(moves) {
    let data = "";
    console.log(moves)
    moves.forEach(move => {
        data += "<li>" + move.move.name + "</li>";
    })
    return data;
}
$("#nextBtn").on('click', function () {

    if (next != null) {
        getPokemon(current = next);
    } else {

    }
})
$("#prevBtn").on('click', function () {

    if (previous != null) {
        getPokemon(current = previous);
    } else {

    }
})
$("#search").on("change", function () {
    let search = $("#search").val();
    if (search !== "") {
        console.log(search)
        getPokemon(current = 'https://pokeapi.co/api/v2/pokemon/' + search);
    } else {
        getPokemon(current)
    }
})
function displayPokemon(data) {

    next = data.next;
    previous = data.previous;
    
    $("#table").empty();
    $("#cards").empty();
    $("#pokemon_count").val("Total Pokemon:" + data.results)

   
    //$("#table").dataTable();
    var datatable = "";
    var card = "";
    //results.innerHTML = JSON.stringify(data)
    data.results.forEach(pokemon => {
        //results.innerHTML += `Pokemon Name: ` + pokemon.name + `URL: `+ pokemon.url + `<br/>`

        //datatable +=
        //`<tr>` +
        //    `<td>` + pokemon.name + `</td>` +
        //    `<td>` + pokemon.url + `</td>` +
        //    `<td>` + `<a href="${pokemon.url}" class="btn btn-primary">Show</a>` + `</td>` +
        //`</tr>`;
        //let image = loadPokeImg(pokemon.url);
        //console.log(pokemon.url)
        //let pokemon_img = loadPokeImg(pokemon.url)
        card +=
            `
                <div class="col-md-3">
                    <div class="card" style="width: 15rem;">
                            <img class="card-img-top float-center bg-info" src="https://www.pngmart.com/files/2/Pokeball-PNG-Image.png" alt="No Photo">
                        <div class="card-body bg-light">
                            <h5 class="card-title text-center">${pokemon.name}</h5>
                            <center>
                            <button class="btn btn-outline-primary btn-block d-flex justify-content-center" onclick="getPokemonDetails('${pokemon.url}')"  id="pokemonBtn" data-bs-toggle="modal" data-bs-target="#viewPokemonModal">Moredetails</button>
                            </center>
                        </div>
                    </div>
               </div>
            `;
    })
    //$("#table").append(datatable);
    $("#cards").append(card);
}
  function loadPokeImg(url) {
    axios
        .get(url)
        .then(function (response) {
            // handle success
            console.log(response.data.sprites.front_default);
            return response.data.sprites.front_default;
        })
        .catch(function (error) {
            // handle error
            console.log(error);
        })
        .then(function () {
            // always executed
        });
    return  "";
}