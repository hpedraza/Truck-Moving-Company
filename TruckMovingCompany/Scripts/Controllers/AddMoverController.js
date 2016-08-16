var AddMoverController = function (addMoverService) {
    var mover;

    var init = function () {
        $(".js-add-mover").on("click", AddMover);
    };

    var AddMover = function () {

        mover = {
            FirstName: $("#firstName").val(),
            LastName: $("#lastName").val(),
            CrewName: $("#crewName").val()
        }

        if (!(mover.FirstName.length < 2 || mover.LastName.length < 2 || mover.CrewName == null))
            addMoverService.addMover(mover, done, fail);
        else
            validateForm(mover);
    };

    var validateForm = function (mover) {
        $("#already-exists-name-validation").css("display", "none");

        if (mover.FirstName.length < 2) {
            $("#first-name-validation").css("display", "block");
        } else { $("#first-name-validation").css("display", "none"); }

        if (mover.LastName.length < 2) {
            $("#last-name-validation").css("display", "block");
        } else { $("#last-name-validation").css("display", "none"); }

        if (mover.CrewName == null) {
            $("#crew-name-validation").css("display", "block");
        } else { $("#crew-name-validation").css("display", "none"); }
    };

    var clear = function () {
        $("#first-name-validation").css("display", "none");
        $("#last-name-validation").css("display", "none");
        $("#crew-name-validation").css("display", "none");
    };

    var done = function (moverId) {
        /*-- Need to look into Backbone.js and underscore.js --*/
        if (moverId === -1) {
            $("#already-exists-name-validation").text("Name already exists in database.");
            $("#already-exists-name-validation").css("display", "block");

            clear();
        }
        else if (moverId === -2) {
            $("#already-exists-name-validation").text("Please fill in all fields.");
            $("#already-exists-name-validation").css("display", "block");
        }

        if (moverId > -1) {
            {
                $("#firstName").val('');
                $("#lastName").val('');
                $("#already-exists-name-validation").css("display", "none");
                clear();

                var row = '<tr>';
                row = row.concat('<td>', mover.FirstName, '</td>');
                row = row.concat('<td>', mover.LastName, '</td>');
                row = row.concat('<td><select class = "form-control"><option>', mover.CrewName, '</option></select></td>');
                row = row.concat('<td>', '<form>', '<input type="hidden"  value="', moverId.toString(), '"/><button class="btn btn-xs btn-info" type="submit" style="width: 70px;">Edit</button>  <button class="btn btn-xs btn-danger deleteMover" type="button">Delete</button></td></tr></form>');

                var table = $("#tableBody");
                table.append(row);
            }
        }
    }

        var fail = function () {
            alert("Something failed!");
        };

        return {
            init: init
        }

}(AddMoverService);