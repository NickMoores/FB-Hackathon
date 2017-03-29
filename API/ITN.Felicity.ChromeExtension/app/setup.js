//var contexts = ["page","selection","link","editable","image","video",
//                "audio"];

var selectionClick = chrome.contextMenus.create({
    "title": "Create Feedback with felicity", "contexts": ["selection"],
    "onclick": function(info, tab) {
        feedbackSubmission.displayFeedbackForm(info.selectionText);
    }
});
