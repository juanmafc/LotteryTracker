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

    var resultsFileId = -1;

    chrome.downloads.onChanged.addListener(function(downloadDelta) {
        var changedId = downloadDelta.id;
        if (changedId == resultsFileId) {
            chrome.downloads.search({id: changedId}, function(downloadItem) {
                console.log(downloadItem);
                if (downloadItem[0].state == "complete") {
                    //If results download is completeled                    
                    //Instead of using sendResponse, send a new message
                    chrome.tabs.query({active: true, currentWindow: true}, function(tabs) {        
                        chrome.tabs.sendMessage( tabs[0].id, {downloadComplete: true} );
                    });
                }                
            });
        }
    });

    chrome.downloads.download({
        url: request.url,
        filename: "resultados.txt" // Optional
    }, function(downloadId){
        resultsFileId = downloadId;
        console.log(downloadId);        
    });  

            
    
})


