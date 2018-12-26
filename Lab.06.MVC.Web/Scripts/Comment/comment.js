function CommentManager(options) {

    self.self.commentID = null;
    self.commentRating = null;
    self.MovieID = parseInt(options.MovieID);
    self.addCommentFormID = options.addCommentFormID;
    self.addCommentButtonID = options.addCommentButtonID;

    self.addCommentEvent = function () {

        $("form[id=addCommentForm]").on("submit",
            function(event) {
                event.preventDefault();

                var commentModel = {
                    MovieID: self.MovieID,
                    UserComment: $("input[id=commentInput]").val()
                };
                
                var saveResult = self.saveCommentToDB(commentModel);
                $("#commentInput").val("");
                
                if (saveResult) {
                    self.updateMovieComments();
                }
            }
        );
    };

    self.showNewCommentsEvent = function() {
        $("a[id=showNewCommentsBtn]").on("click",
            function() {
                self.updateMovieComments();
            });
    };

    self.updateCommentsPerTime = function () {
        $(document).ready(function () {
            setInterval(function () {
                self.updateMovieComments();
            }, 10000);
        });
    };

    self.saveCommentToDB = function (commentModel) {
        var succeed = false;

        $.ajax({
            url: "../Comments/AddComment",
            type: "POST",
            async: false,
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(commentModel),
            dataType: "json",
            success: function() {
                succeed = true;
            }
        });

        return succeed;
    };

    self.renderCommentsPartialView = function () {

        $.ajax({
            url: "../Comments/GetAllMovieComments",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify({movieID: self.MovieID }),
            dataType: "html"
        }).done(function (data) {
            $('#commentsPartialView').html(data);
        });
        
    };

    self.updateMovieComments = function() {
        $("div[class = movieComments]").remove();
        self.renderCommentsPartialView();
    };

    self.eventsChekIn = function () {
        self.addCommentEvent();
        self.showNewCommentsEvent();
        //self.updateCommentsPerTime();
    };

    self.init = function () {
        self.eventsChekIn();
        self.renderCommentsPartialView();
    };

    self.init();
}

