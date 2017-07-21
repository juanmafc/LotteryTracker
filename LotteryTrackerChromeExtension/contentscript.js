
var resultsIframe; 
var i = 0;
var previousDaysCount = 0;

function saveResultsAndGoToPreviousDay() {    
    //Save winner numbers
    resultsIframe.contents().find("form")[0].submit();    
}

function getPreviousDayResults() {
    //Alternative: while(lastDay != currentDay)
    if (i < previousDaysCount ){
        i++;
        var resultado = 10;
        setTimeout(saveResultsAndGoToPreviousDay, 150);
        //NOTE: this line resultsIframe.contents().find("form")[0].submit(); would be executed INMEDIATLY after calling the previous method
    }
}

function startPreviousDaysResultsSearch() {
    resultsIframe = $('body>center>table>tbody>tr>td>table>tbody>tr:nth-child(3)>td:nth-child(2)>table>tbody>tr:nth-child(2)>td>table>tbody>tr>td:nth-child(4)>iframe');                    
    resultsIframe.ready(function() {                    
        resultsIframe.bind("load", getPreviousDayResults);        
        resultsIframe[0].contentWindow.location.reload(true);        
    });    
}

function mensajesListener(request, sender, sendResponse) {        
    previousDaysCount = request.daysCount;
    startPreviousDaysResultsSearch();
}

chrome.runtime.onMessage.addListener(mensajesListener);