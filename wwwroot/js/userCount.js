//create connection
var connectionUserCount = new signalR.HubConnectionBuilder()
    //.configureLogging(signalR.LogLevel.Information)
    .withUrl("/hubs/userCount", signalR.HttpTransportType.WebSockets)
    .build();
//connect to methods that are in the hub
connectionUserCount.on("updateTotalViews", (value) => {
    var newCountSpan = document.getElementById("totalViewsCounter");
    newCountSpan.innerText = value.toString();
});

connectionUserCount.on("updateTotalUsers", (value) => {
    var newCountSpan = document.getElementById("totalUsersCounter");
    newCountSpan.innerText = value.toString();
});

//invoke hub method
function newWindowLoadedOnClient() {
    connectionUserCount.invoke("NewWindowLoaded", "Salim").then((value) => console.log(value));
};

//start connection
function fulfilled() {
    console.log("connection successfull");
    newWindowLoadedOnClient();
}

function rejected() {
}

connectionUserCount.start().then(fulfilled, rejected);