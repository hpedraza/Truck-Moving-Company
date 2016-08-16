var AddMoverService = function () {

    var addMover = function (dto, done, fail) {
        $.post("/api/AddAMover", dto)
        .done(done)
        .fail(fail);
    };

    return {
        addMover: addMover
    }

}();