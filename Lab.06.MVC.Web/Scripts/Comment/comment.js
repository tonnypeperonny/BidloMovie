function CommentManager(options) {

    self.addCommentButtonID = options.addCommentButtonID,
    self.commentID = null;
    self.commentRatin = null;
    self.addCommentFormID = options.addCommentFormID;

    self.addCommentButtonID.click(function(event) {
       
        event.preventDefault();
        self.addCommentButtonID.reset();
    });

    self.eventsSubscribe = function() {
       

    };

    self.init = function() {
        self.eventsSubscribe();
    };

    self.init();
}

