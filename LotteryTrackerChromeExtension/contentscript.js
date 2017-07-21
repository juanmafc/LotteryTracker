
var resultsIframe; 
var i = 0;
var previousDaysCount = 0;

function saveResultsAndGoToPreviousDay() {    
    //Save winner numbers

    var date = resultsIframe.contents().find("#ultimo").attr("value");
    console.log(date);


    var dateResults = {
        date : date,
        results : []
    };
    
    resultsIframe.contents().find(".cab_tit").each(function( index ) {
        if (index >= 5) {            
            var lottery = {
                name: $(this).text(),
                results : []
            };            
            dateResults.results.push(lottery);
        }
    });        
    
    var lotteryIndex = -1;
    resultsIframe.contents().find(".cab_num").each(function( index ) {        
        if (index % 4 == 0) {
            lotteryIndex++;
        }
        dateResults.results[lotteryIndex].results.push(this.innerText);                
    });
    console.log(dateResults);
    resultsIframe.contents().find("#form1").submit();
}

function getPreviousDayResults() {
    //Alternative: while(lastDay != currentDay)
    if (i < previousDaysCount ){
        i++;        
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