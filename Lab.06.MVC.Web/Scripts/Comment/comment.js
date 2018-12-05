function CommentManager(options) {


    self.self.commentID = null;
    self.commentRating = null;
    self.MovieID = parseInt(options.MovieID);
    self.addCommentFormID = options.addCommentFormID;
    self.addCommentButtonID = options.addCommentButtonID;

    self.addCommentEvent = function () {

        $("form[id=addCommentForm]").on("submit",
            function (event) {
                event.preventDefault();

                var commentModel = {
                    MovieID: self.MovieID,
                    UserComment: $("input[id=commentInput]").val(),
                };

                self.saveCommentToDB(commentModel);

                $("#commentInput").val("");
            }
        );
    };

    self.saveCommentToDB = function (commentModel) {

        var request = $.ajax({
            url: "../Comments/AddComment",
        type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(commentModel),
                    dataType: "json"
    });

    request.done(function (data) {
        alert(data.responseText);
    });

    request.fail(function (data) {
        alert(data.responseText);
    });
};

self.eventsChekIn = function () {
    self.addCommentEvent();
};

self.init = function () {
    self.eventsChekIn();
};

self.init();
}

