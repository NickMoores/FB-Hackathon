var feedbackSubmission = {

    displayFeedbackForm: function (selection) {
        feedbackSubmission.createFeedbackForm(selection);
        //var req = new XMLHttpRequest();
        //req.open("GET", this.searchOnFlickr_, true);
        //req.onload = this.showPhotos_.bind(this);
        //req.send(null);
    },
    submitFeedback: function () {
        alert("submit feedback");
            //var xmlhttp = new XMLHttpRequest();

            //xmlhttp.onreadystatechange = function () {
            //    if (xmlhttp.readyState == XMLHttpRequest.DONE) {
            //        if (xmlhttp.status == 200) {
            //            document.getElementById("myDiv").innerHTML = xmlhttp.responseText;
            //        }
            //        else if (xmlhttp.status == 400) {
            //            alert('There was an error 400');
            //        }
            //        else {
            //            alert('something else other than 200 was returned');
            //        }
            //    }
            //};

            //xmlhttp.open("GET", "ajax_info.txt", true);
            //xmlhttp.send();
    },
    createFeedbackForm: function (selection) {
        //var html = document.createElement('div');
        //html.innerHTML = '<input id="clickMe" type="button" value="Click Me" />';
        //document.body.appendChild(html);
        var form = "";
        form += '<div style="position:fixed;bottom:10px;right:10px;height:200px;width:200px;background-color:#fff;z-index: 99999999;padding: 20px;box-shadow: 0 0 2px #666;">';


        form += '<form action="http://itnfelicityapi20170329025803.azurewebsites.net/Article/85D6FF0A-982F-47A5-9805-84A02735656C/feedback" method="post">';
        form += '<input name="InstallationID" type="hidden" value="' + feedbackSubmission.getInstallationID() + '"/>';
        form += '<input name="HighlightedText" type="hidden" value="' + selection + '"/>';
        form += '<textarea name="Comment" style="box-shadow: 0 0 1px #666 inset;width: 92%;height: 150px;padding: 4%;"></textarea>';
        form += '<input name="submit" type="submit" value="Submit Feedback" style="padding: 10px 20px;float: right;background-color: #ddd;color: #444;" />';
        form += '</form>';
        form += '</div>';


        chrome.tabs.executeScript(null,
            { code: "document.body.innerHTML += '"+form+"';" });

        //var newDiv = document.createElement("div"); 
        //var newContent = document.createTextNode("Hi there and greetings!"); 
        //newDiv.appendChild(newContent); //add the text node to the newly created div. 
        //document.body.appendChild(newDiv);

    },
    getInstallationID: function () {
        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000)
              .toString(16)
              .substring(1);
        }
        return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
          s4() + '-' + s4() + s4() + s4();
    }/*,
    getSelectionText: function() {
        var text = "";
        if (window.getSelection) {
            text = window.getSelection().toString();
        } else if (document.selection && document.selection.type != "Control") {
            text = document.selection.createRange().text;
        }
        return text;

        chrome.tabs.executeScript(null,
            { code: "document.body.innerHTML += '" + form + "';" });
    }*/
};