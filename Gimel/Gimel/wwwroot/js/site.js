// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function () {


    ////////////////FOR THE STARTING OF THE POWER TEST////////////////
    const startPowerButton = document.getElementById("startPowerButton");
    const powerscoreData = document.getElementById("powerscore");

    if (startPowerButton) {
        startPowerButton.addEventListener("click", function () {

            fetch('/TestStart?handler=StartPower')
                .then(response => {
                    if (!response.ok) {
                        throw new Error(`HTTP error! status: ${response.status}`);
                    }
                    return response.json();
                })
                .then(data => {
                    console.log("Test started:", data);
                    pollForPower();
                })
                .catch(error => {
                    console.error("Error starting test:", error);
                });
        });
        

    }
    function pollForPower() {
        const pollInterval = 2000; 
        const maxAttempts = 50;
        let attempts = 0;

        powerscoreData.innerHTML = '';
        const initialDisplay = document.createElement("h1");
        initialDisplay.textContent = "0";
        powerscoreData.appendChild(initialDisplay);
        const intervalId = setInterval(() => {
            fetch('/PunchPower?handler=PowerTest')
                .then(response => {
                    if (!response.ok) {
                        throw new Error(`HTTP error! status: ${response.status}`);
                    }
                    return response.json();
                })
                .then(data => {
                    console.log("Polling data:", data);

                    if (data !== "0") { 
                        clearInterval(intervalId);
                        powerscoreData.innerHTML = '';
                        const display = document.createElement("h1");
                        display.textContent = data;
                        powerscoreData.appendChild(display);
                        
                    } else {
                        console.log("Data not ready yet, polling again...");
                    }
                })
                .catch(error => {
                    console.error("Error polling for data:", error);
                    clearInterval(intervalId); // Stop polling on error
                });

            attempts++;
            if (attempts >= maxAttempts) {
                console.error("Polling timed out.");
                clearInterval(intervalId);
            }
        }, pollInterval);
    }   
    ////////////////END OF STARTING OF THE POWER TEST////////////////

    ////////////////FOR THE STARTING OF THE REACTION TIME TEST////////////////
    const startReactButton = document.getElementById("startReactButton");
    const rtimescoreData = document.getElementById("rtimescore");

    if (startReactButton) {
        startReactButton.addEventListener("click", function () {
            fetch('/TestStart?handler=StartReact')
                .then(response => {
                    if (!response.ok) {
                        throw new Error(`HTTP error! status: ${response.status}`);
                    }
                    return response.json();
                })
                .then(data => {
                    console.log(data);
                    pollForRTime()
                })
                .catch(error => {
                    console.error('Error:', error);
                });

        });
    }
    function pollForRTime() {
        const pollInterval = 2000;
        const maxAttempts = 50;
        let attempts = 0;

        rtimescoreData.innerHTML = '';
        const initialDisplay = document.createElement("h1");
        initialDisplay.textContent = "0";
        rtimescoreData.appendChild(initialDisplay);
        const intervalId = setInterval(() => {
            fetch('/ReactionTime?handler=ReactionTest')
                .then(response => {
                    if (!response.ok) {
                        throw new Error(`HTTP error! status: ${response.status}`);
                    }
                    return response.json();
                })
                .then(data => {
                    console.log("Polling data:", data);

                    if (data !== "0") {
                        clearInterval(intervalId);
                        rtimescoreData.innerHTML = '';
                        const display = document.createElement("h1");
                        display.textContent = data;
                        rtimescoreData.appendChild(display);

                    } else {
                        console.log("Data not ready yet, polling again...");
                    }
                })
                .catch(error => {
                    console.error("Error polling for data:", error);
                    clearInterval(intervalId); // Stop polling on error
                });

            attempts++;
            if (attempts >= maxAttempts) {
                console.error("Polling timed out.");
                clearInterval(intervalId);
            }
        }, pollInterval);
    }
    ////////////////END OF THE REACTION TIME TEST////////////////

    ////////////////FOR THE STARTING OF THE PUNCH COUNT TEST////////////////
    const startCountButton = document.getElementById("startCountButton");
    const countscoreData = document.getElementById("countscore");

    if (startCountButton) {
        startCountButton.addEventListener("click", function () {
            fetch('/TestStart?handler=StartCount')
                .then(response => {
                    if (!response.ok) {
                        throw new Error(`HTTP error! status: ${response.status}`);
                    }
                    return response.json();
                })
                .then(data => {
                    console.log(data);
                    pollForCount()
                })
                .catch(error => {
                    console.error('Error:', error);
                });

        });
    }
    function pollForCount() {
        const pollInterval = 2000;
        const maxAttempts = 50;
        let attempts = 0;

        countscoreData.innerHTML = '';
        const initialDisplay = document.createElement("h1");
        initialDisplay.textContent = "0";
        countscoreData.appendChild(initialDisplay);
        const intervalId = setInterval(() => {
            fetch('/PunchCount?handler=CountTest')
                .then(response => {
                    if (!response.ok) {
                        throw new Error(`HTTP error! status: ${response.status}`);
                    }
                    return response.json();
                })
                .then(data => {
                    console.log("Polling data:", data);

                    if (data !== "0") {
                        clearInterval(intervalId);
                        countscoreData.innerHTML = '';
                        const display = document.createElement("h1");
                        display.textContent = data;
                        countscoreData.appendChild(display);

                    } else {
                        console.log("Data not ready yet, polling again...");
                    }
                })
                .catch(error => {
                    console.error("Error polling for data:", error);
                    clearInterval(intervalId); // Stop polling on error
                });

            attempts++;
            if (attempts >= maxAttempts) {
                console.error("Polling timed out.");
                clearInterval(intervalId);
            }
        }, pollInterval);
    }
    ////////////////END OF THE PUNCH COUNT TEST////////////////

    ////////////////RESET BUTTONS FOR EACH OF THE TESTS////////////////
    const resetPowerButton = document.getElementById("resetPowerButton");
    const resetCountButton = document.getElementById("resetCountButton");
    const resetRTimeButton = document.getElementById("resetRTimeButton");
    const getTestButton = document.getElementById("getResponse");
    if (resetPowerButton) {
        resetPowerButton.addEventListener("click", function () {
            fetch('/PunchPower?handler=Reset')
                .then(response => {
                    if (!response.ok) {
                        throw new Error(`HTTP error! status: ${response.status}`);
                    }
                    return response.json();
                })
                .then(data => {
                    console.log(data);
                    powerscoreData.innerHTML = "";
                    const initialDisplay = document.createElement("h1");
                    document.querySelector("#nameEntry p").textContent = "";
                    initialDisplay.textContent = "0";
                    powerscoreData.appendChild(initialDisplay);
                })
                .catch(error => {
                    console.error('Error:', error);
                });

        });
    }

    if (resetCountButton) {
        resetCountButton.addEventListener("click", function () {
            fetch('/PunchCount?handler=Reset')
                .then(response => {
                    if (!response.ok) {
                        throw new Error(`HTTP error! status: ${response.status}`);
                    }
                    return response.json();
                })
                .then(data => {
                    console.log(data);
                    countscoreData.innerHTML = '';
                    const initialDisplay = document.createElement("h1");
                    document.querySelector("#nameEntry p").textContent = "";
                    initialDisplay.textContent = "0";
                    countscoreData.appendChild(initialDisplay);
                })
                .catch(error => {
                    console.error('Error:', error);
                });

        });
    }
    if (resetRTimeButton) {
        resetRTimeButton.addEventListener("click", function () {
            fetch('/ReactionTime?handler=Reset')
                .then(response => {
                    if (!response.ok) {
                        throw new Error(`HTTP error! status: ${response.status}`);
                    }
                    return response.json();
                })
                .then(data => {
                    console.log(data);
                    rtimescoreData.innerHTML = '';
                    const initialDisplay = document.createElement("h1");
                    document.querySelector("#nameEntry p").textContent = "";
                    initialDisplay.textContent = "0";
                    rtimescoreData.appendChild(initialDisplay);
                })
                .catch(error => {
                    console.error('Error:', error);
                });

        });
    }
    ////////////////END OF THE RESET BUTTONS////////////////

    ////////////////TEST BUTTON THAT WILL BE REMOVED////////////////
    if (getTestButton) {
        getTestButton.addEventListener("click", function () {
            fetch('/Search?handler=Response')
                .then(response => {
                    if (!response.ok) {
                        throw new Error(`HTTP error! status: ${response.status}`);
                    }
                    return response.json();
                })
                .then(data => {
                    console.log(data);
                })
                .catch(error => {
                    console.error('Error:', error);
                });

        });
    }
    ////////////////THIS BUTTON PRESS DISPLAYS THE TABLE FOR THE POWER LEADERBOARD////////////////
    const powerLeader = document.getElementById("showPowerLeaderboardBtn");
    const powerLeaderboardSection = document.getElementById("powerLeaderboardSection");
    const powerLeaderboardTable = document.getElementById("powerLeaderboardTable");

    if (powerLeader) {
        powerLeader.addEventListener("click", () => {
            powerLeaderboardSection.style.display = "block";
            countLeaderboardSection.style.display = "none";
            rtimeLeaderboardSection.style.display = "none";
            fetch('/LeaderBoards?handler=PowerLeader')
                .then(response => {
                    if (!response.ok) {
                        throw new Error(`HTTP error! status: ${response.status}`);
                    }
                    return response.json();
                })
                .then(data => {
                    powerLeaderboardTable.innerHTML = '';

                    data.forEach(entry => {
                        const row = document.createElement("tr");

                        const nameCell = document.createElement("td");
                        nameCell.textContent = entry.name;

                        const powerCell = document.createElement("td");
                        powerCell.textContent = entry.power;

                        const speedCell = document.createElement("td");
                        speedCell.textContent = entry.speed;

                        const receivedTimeCell = document.createElement("td");
                        receivedTimeCell.textContent = entry.recievedTime;

                        row.appendChild(nameCell);
                        row.appendChild(powerCell);
                        row.appendChild(speedCell);
                        row.appendChild(receivedTimeCell);

                        powerLeaderboardTable.appendChild(row);
                    });
                })
                .catch(error => {
                    console.error("Error fetching Power Leaderboard:", error);
                });
        });
    }
    ////////////////THIS IS THE END FOR THE POWER LEADERBOARD////////////////

    ////////////////THIS BUTTON PRESS DISPLAYS THE TABLE FOR THE COUNT LEADERBOARD////////////////
    const countLeader = document.getElementById("showCountLeaderboardBtn");
    const countLeaderboardSection = document.getElementById("countLeaderboardSection");
    const countLeaderboardTable = document.getElementById("countLeaderboardTable");

    if (countLeader) {
        countLeader.addEventListener("click", () => {
            countLeaderboardSection.style.display = "block";
            powerLeaderboardSection.style.display = "none";
            rtimeLeaderboardSection.style.display = "none";

            fetch('/LeaderBoards?handler=CountLeader')
                .then(response => {
                    if (!response.ok) {
                        throw new Error(`HTTP error! status: ${response.status}`);
                    }
                    return response.json();
                })
                .then(data => {
                    countLeaderboardTable.innerHTML = '';

                    data.forEach(entry => {
                        const row = document.createElement("tr");

                        const nameCell = document.createElement("td");
                        nameCell.textContent = entry.name;

                        const bothCell = document.createElement("td");
                        bothCell.textContent = entry.both;

                        const rhandCell = document.createElement("td");
                        rhandCell.textContent = entry.rHand;

                        const lhandCell = document.createElement("td");
                        lhandCell.textContent = entry.lHand;

                        const receivedTimeCell = document.createElement("td");
                        receivedTimeCell.textContent = entry.recievedTime;

                        row.appendChild(nameCell);
                        row.appendChild(bothCell);
                        row.appendChild(rhandCell);
                        row.appendChild(lhandCell);
                        row.appendChild(receivedTimeCell);

                        countLeaderboardTable.appendChild(row);
                    });
                })
                .catch(error => {
                    console.error("Error fetching Power Leaderboard:", error);
                });
        });
    }
    ////////////////THIS IS THE END FOR THE COUNT LEADERBOARD////////////////

    ////////////////THIS BUTTON PRESS DISPLAYS THE TABLE FOR THE REACTION TIME LEADERBOARD////////////////
    const rtimeLeader = document.getElementById("showReactionTimeLeaderboardBtn");
    const rtimeLeaderboardSection = document.getElementById("rtimeLeaderboardSection");
    const rtimeLeaderboardTable = document.getElementById("rtimeLeaderboardTable");

    if (rtimeLeader) {
        rtimeLeader.addEventListener("click", () => {
            rtimeLeaderboardSection.style.display = "block";
            powerLeaderboardSection.style.display = "none";
            countLeaderboardSection.style.display = "none";
            fetch('/LeaderBoards?handler=ReactionLeader')
                .then(response => {
                    if (!response.ok) {
                        throw new Error(`HTTP error! status: ${response.status}`);
                    }
                    return response.json();
                })
                .then(data => {
                    rtimeLeaderboardTable.innerHTML = '';

                    data.forEach(entry => {
                        const row = document.createElement("tr");

                        const nameCell = document.createElement("td");
                        nameCell.textContent = entry.name;

                        const ptimeCell = document.createElement("td");
                        ptimeCell.textContent = entry.punchTime;

                        const speedCell = document.createElement("td");
                        speedCell.textContent = entry.speed;

                        const receivedTimeCell = document.createElement("td");
                        receivedTimeCell.textContent = entry.recievedTime;

                        row.appendChild(nameCell);
                        row.appendChild(ptimeCell);
                        row.appendChild(speedCell);
                        row.appendChild(receivedTimeCell);

                        rtimeLeaderboardTable.appendChild(row);
                    });
                })
                .catch(error => {
                    console.error("Error fetching Power Leaderboard:", error);
                });
        });
    }
    ////////////////THIS IS THE END FOR THE REACTION TIME LEADERBOARD////////////////

    ////////////////THIS IS THE START FOR SEACH////////////////
    const searchButton = document.getElementById("DisplayStats");

    const powerSearchSection = document.getElementById("powerSearchSection");
    const powerSearchTable = document.getElementById("powerSearchTable");

    const countSearchSection = document.getElementById("countSearchSection");
    const countSearchTable = document.getElementById("countSearchTable");

    const rtimeSearchSection = document.getElementById("rtimeSearchSection");
    const rtimeSearchTable = document.getElementById("rtimeSearchTable");



    if (searchButton)
    {
            searchButton.addEventListener("click", () => {
                powerSearchSection.style.display = "block";
                countSearchSection.style.display = "block";
                rtimeSearchSection.style.display = "block";

                fetch('/Search?handler=SearchShow')
                    .then(response => {
                        if (!response.ok) {
                            throw new Error(`HTTP error! status: ${response.status}`);
                        }
                        return response.json();
                    })
                    .then(data => {                     
                        powerSearchTable.innerHTML = '';
                        countSearchTable.innerHTML = '';
                        rtimeSearchTable.innerHTML = '';

                        data.powerLeaders.forEach(entry => {
                            const prow = document.createElement("tr");

                            const powerCell = document.createElement("td");
                            powerCell.textContent = entry.power;

                            const pspeedCell = document.createElement("td");
                            pspeedCell.textContent = entry.speed;

                            const preceivedTimeCell = document.createElement("td");
                            preceivedTimeCell.textContent = entry.recievedTime;

                            prow.appendChild(powerCell);
                            prow.appendChild(pspeedCell);
                            prow.appendChild(preceivedTimeCell);

                            powerSearchTable.appendChild(prow);
                        });

                        data.countLeaders.forEach(entry => {
                            const crow = document.createElement("tr");

                            const bothCell = document.createElement("td");
                            bothCell.textContent = entry.both;

                            const rhandCell = document.createElement("td");
                            rhandCell.textContent = entry.rHand;

                            const lhandCell = document.createElement("td");
                            lhandCell.textContent = entry.lHand;

                            const creceivedTimeCell = document.createElement("td");
                            creceivedTimeCell.textContent = entry.recievedTime;

                            crow.appendChild(bothCell);
                            crow.appendChild(rhandCell);
                            crow.appendChild(lhandCell);
                            crow.appendChild(creceivedTimeCell);

                            countSearchTable.appendChild(crow);
                        });

                        data.rTimeLeaders.forEach(entry => {
                            const ptrow = document.createElement("tr");

                            const ptimeCell = document.createElement("td");
                            ptimeCell.textContent = entry.punchTime;

                            const ptspeedCell = document.createElement("td");
                            ptspeedCell.textContent = entry.speed;

                            const rtreceivedTimeCell = document.createElement("td");
                            rtreceivedTimeCell.textContent = entry.recievedTime;

                            ptrow.appendChild(ptimeCell);
                            ptrow.appendChild(ptspeedCell);
                            ptrow.appendChild(rtreceivedTimeCell);

                            rtimeSearchTable.appendChild(ptrow);
                        });
                    })
                    .catch(error => {
                        console.error("Error fetching search results:", error);
                    });
            });
    }
});