var referenciaAlBoton = document.getElementById("buttonGoToLottery");
referenciaAlBoton.addEventListener("click", goToLotteryURL);



function goToLotteryURL() {        
    var updatedTabProperties = {
     url: "http://www.loteriasmundiales.com.ar/"
    };
    chrome.tabs.update(updatedTabProperties);    
}



