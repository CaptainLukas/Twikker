// This is a simple *viewmodel* - JavaScript that defines the data and behavior of your UI 
function UserViewModel(userName, userMail) {
    this.userName = userName;
    this.userMail = userMail;
}

// Activates knockout.js 
ko.applyBindings(new UserViewModel("Luke Forstwalker", "Luke.Forstwalker@star-wars.com"));

// Check whether the page has loaded and is ready.
$(document).ready(function () {

    // This method loads the next "n" messages via AJAX.
    function loadMore() {
        // to do ajax call to controller to retrieve more messages

    }
})