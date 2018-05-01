﻿// This is a simple *viewmodel* - JavaScript that defines the data and behavior of your UI 
function UserViewModel(userName) {
    this.userName = userName;
}

function AddLikeViewModel(messageID) {
    this.MessageID = messageID;
}

function AddLikeCommentViewModel(commentID) {
    this.CommentID = commentID;
}

function AddMessageViewModel(text) {
    this.Text = text;
}

function AddCommentViewModel(messageID, text) {
    this.MessageID = messageID;
    this.Text = text;
}

function DeleteCommentViewModel(messageID, commentID) {
    this.MessageID = messageID;
    this.commentID = commentID;
}

function DeleteMessageViewModel(messageID) {
    this.MessageID = messageID;
}

// Activates knockout.js 
ko.applyBindings(new UserViewModel("Luke Forstwalker"));

function deleteMessage(messageID) {
    if (confirm('Are you sure you want to delete this?')) {
        var model = new DeleteMessageViewModel(messageID);
        $.ajax({
            type: "POST",
            url: "Home/DeleteMessage",
            data: model,
            dataType: "json",
            success: function (response) {

                alert("success");
            },
            error: function (response) {
                alert("error");
            }
        });
    }
}

function deleteComment(messageID, commentID) {
    var model = new DeleteCommentViewModel(messageID, commentID);
    $.ajax({
        type: "POST",
        url: "Home/DeleteComment",
        data: model,
        dataType: "json",
        success: function (response) {

            alert("success");
        },
        error: function (response) {
            alert("error");
        }
    });
}

// This method loads the next "n" messages via AJAX.
function loadMore() {
    // to do ajax call to controller to retrieve more messages

    var model = new UserViewModel("Hallo");
    $.ajax({
        type: "POST",
        url: "Home/LoadMore",
        data: model,
        dataType: "json",
        success: function (response) {

            alert("success");
        },
        error: function (response) {
            alert("error");
        }
    });
}

function newComment(messageID, i) {
    var text = document.getElementById("newCommentText" + i);
    var model = new AddCommentViewModel(messageID, text.value);
    $.ajax({
        type: "Post",
        url: "Home/AddComment",
        data: model,
        dataType: "json",
        success: function (response) {
            text.value = '';
        },
        error: function (response) {
            alert("error");
        }
    });
}

function likeComment(commentID, i, j) {
    var model = new AddLikeCommentViewModel(commentID);
    $.ajax({
        type: "Post",
        url: "Home/AddLikeComment",
        data: model,
        dataType: "json",
        success: function (response) {
            text.value = '';
        },
        error: function (response) {
            alert("error");
        }
    });
}

function like(id, i) {
    var model = new AddLikeViewModel(id);
    $.ajax({
        type: "Post",
        url: "Home/AddLike",
        data: model,
        dataType: "json",
        success: function (response) {
            var p = document.getElementById("likeCount" + i);
            p.innerText = response;
        },
        error: function (response) {
            alert("error");
        }
    });
}

function unlike() {
    alert("noch nix aber vl unlike");
}

function newMessage(id) {

    var tb = document.getElementById(id);
    var model = new AddMessageViewModel(tb.value);

    $.ajax({
        type: "Post",
        url: "Home/AddMessage",
        data: model,
        dataType: "json",
        success: function (response) {
            tb.value = '';
        },
        error: function (response) {
            alert("error");
        }
    });
}

function countMessageChar(val, pID) {
    var length = val.value.length;
    var p = document.getElementById(pID);
    p.innerHTML = length;
}

function countCommentChar(val, i) {
    var length = val.value.length;
    var p = document.getElementById("newCommentCount" + i);
    p.innerHTML = length;
}
// Check whether the page has loaded and is ready.
$(document).ready(function () {

})