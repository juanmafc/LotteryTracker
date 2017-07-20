var referenciaAlBoton = document.getElementById("buttonIrLoteria");
referenciaAlBoton.addEventListener("click", goToLoteriaURL);



function goToLoteriaURL() {        
    var updatedTabProperties = {
     url: "http://www.loteriasmundiales.com.ar/"
    };
    chrome.tabs.update(updatedTabProperties);    
}



