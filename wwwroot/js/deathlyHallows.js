var cloackSpan = document.getElementById("cloackCounter");
var wandSpan = document.getElementById("wandCounter");
var stoneCounter = document.getElementById("stoneCounter");


//create connection
var connectionDeathlyHallows = new signalR.HubConnectionBuilder()
    //.configureLogging(signalR.LogLevel.Information)
    .withUrl("/hubs/deathlyHallows")
    .build();
//connect to methods that are in the hub
connectionDeathlyHallows.on("updateDeathlyAllowCount", (cloack,stone,wand) => {
    cloackSpan.innerText = cloack.toString();
    wandSpan.innerText = wand.toString();
    stoneCounter.innerText = stone.toString();
});

//invoke hub method
function fulfilled() {
    connectionDeathlyHallows.invoke("GetRaceStatus").then((raceCounter) => {
        cloackSpan.innerText = raceCounter.cloack.toString();
        wandSpan.innerText = raceCounter.wand.toString();
        stoneCounter.innerText = raceCounter.stone.toString();
    });
    console.log("connection successfull");
    newWindowLoadedOnClient();
}

function rejected() {
}

connectionDeathlyHallows.start().then(fulfilled, rejected);