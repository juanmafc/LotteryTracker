document.getElementById("buttonGoToLottery").addEventListener("click", goToLotteryURL);
function goToLotteryURL() {        
    var updatedTabProperties = {
     url: "http://www.loteriasmundiales.com.ar/"
    };
    chrome.tabs.update(updatedTabProperties);    
}



document.getElementById("buttonSearchPreviousDaysResults").addEventListener("click", searchPreviousDaysResults);

function searchPreviousDaysResults() {
    var previousDaysCount = document.getElementById("previousDaysCount").value;
    
    chrome.tabs.query({active: true, currentWindow: true}, function(tabs) {        
        chrome.tabs.sendMessage( tabs[0].id, {daysCount: previousDaysCount} );
    });
}




chrome.runtime.onMessage.addListener( function(request, sender, sendResponse) {
    console.log(request.url);
    chrome.downloads.download({
        url: request.url,
        filename: "fileName.txt" // Optional
    });
})


