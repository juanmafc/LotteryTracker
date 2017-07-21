
var resultsIframe; 
var pastDays = 0;
var previousDaysCount = 0;



function saveDateResultsAsReadableText(dateResults) {    
    var dateString = dateResults.date + "\r\n";    
    var results = dateResults.results;    

    var everyResultString = "";    
    for (var i = 0; i < results.length; i++) {
        var resultString = results[i].name.replace("\t", "");        
        for (var j = 0; j < 4; j++ ) {
            var winningNumber = results[i].results[j];
            if (winningNumber == " ") {
                resultString += "," + "NADA";    
            }
            else {
                resultString += "," + winningNumber;
            }            
        }        
        everyResultString += resultString  + "\r\n";
    }
    everyResultString += "\r\n";
    var blob = new Blob([dateString, everyResultString], {type: 'text/plain'});
    resultsFileWritter.write(blob); 
}


var previousDay;
function saveResultsAndGoToPreviousDay() {        
    
    var today;
    if (pastDays == 1) {        
        today = "";
        var currentDay = resultsIframe.contents().find("#Select1")[0];
        today += currentDay.options[currentDay.selectedIndex].text +"/";
        
        var currentMonth = resultsIframe.contents().find("#Select2")[0];
        today += currentMonth.options[currentMonth.selectedIndex].text +"/";

        var currentYear = resultsIframe.contents().find("#Select3")[0];
        today += currentYear.options[currentYear.selectedIndex].text;

        previousDay = resultsIframe.contents().find("#ultimo").attr("value");
    }
    else{
        today = previousDay;
        previousDay = resultsIframe.contents().find("#ultimo").attr("value");
    }

    var dateResults = {
        date : today,
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
    saveDateResultsAsReadableText(dateResults);
    resultsIframe.contents().find("#form1").submit();
}




function getPreviousDayResults() {
    //Alternative: while(lastDay != currentDay)
    if (pastDays < previousDaysCount ){
        pastDays++;        
        setTimeout(saveResultsAndGoToPreviousDay, 150);
        //NOTE: this line resultsIframe.contents().find("form")[0].submit(); would be executed INMEDIATLY after calling the previous method
    }
    else {
        chrome.runtime.sendMessage({url: resultsFile.toURL()});
        //Downloads are only supported on background
     }

}

function startPreviousDaysResultsSearch() {
    resultsIframe = $('body>center>table>tbody>tr>td>table>tbody>tr:nth-child(3)>td:nth-child(2)>table>tbody>tr:nth-child(2)>td>table>tbody>tr>td:nth-child(4)>iframe');                    
    resultsIframe.ready(function() {                    
        resultsIframe.bind("load", getPreviousDayResults);        
        resultsIframe[0].contentWindow.location.reload(true);        
    });    
}











function errorHandler(e) {
  var msg = '';

  switch (e.code) {
    case FileError.QUOTA_EXCEEDED_ERR:
      msg = 'QUOTA_EXCEEDED_ERR';
      break;
    case FileError.NOT_FOUND_ERR:
      msg = 'NOT_FOUND_ERR';
      break;
    case FileError.SECURITY_ERR:
      msg = 'SECURITY_ERR';
      break;
    case FileError.INVALID_MODIFICATION_ERR:
      msg = 'INVALID_MODIFICATION_ERR';
      break;
    case FileError.INVALID_STATE_ERR:
      msg = 'INVALID_STATE_ERR';
      break;
    default:
      msg = 'Unknown Error';
      break;
  };
  console.log('Error: ' + msg);
}


var resultsFile;
var resultsFileWritter;

function onInitFs(fs) {    

    fs.root.getFile('resultados.txt', {create: true}, function(fileEntry) {      
        // Create a FileWriter object for our FileEntry (log.txt).                
        resultsFile = fileEntry; 
        fileEntry.createWriter(function(fileWriter) {            
            fileWriter.onwriteend = function(e) {                
                //Currently not needed 
            };    

            fileWriter.onerror = function(e) {
                console.log('Write failed: ' + e.toString());
            };
            resultsFileWritter = fileWriter;
        }, errorHandler);


    }, errorHandler);  
}




function mesaggeListener(request, sender, sendResponse) { 
    console.log("Request:");
    console.log(request);
    if (request.daysCount != undefined){
        previousDaysCount = request.daysCount;
        window.requestFileSystem  = window.requestFileSystem || window.webkitRequestFileSystem;
        window.requestFileSystem(window.TEMPORARY, 1024*1024, onInitFs, errorHandler);
        startPreviousDaysResultsSearch();
    }
    else {
        if (request.downloadComplete) {            
            resultsFile.remove(function() {
                console.log('File removed.');
            }, errorHandler);
        }
    }
}





chrome.runtime.onMessage.addListener(mesaggeListener);