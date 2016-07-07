

$(document).ready(function () {
    $("#moverPOST").click(function () {
        var postData = getmodel();
        var url = "/Home/PostMover";
        if (postData.FirstName === "" || postData.LastName === "")
        {
            // post validation error
            if (postData.FirstName === "" && postData.LastName === "")
            {

            }else {
                if (postData.FirstName === null) {

                } else {

                }
            }

            // Do not run ajax post
            return;
        }

        $.ajax(
            {
                url: url,
                type: "POST",
                data: postData,
                success: function (data) {
                    // look at dom and manipulate it with json object
                    //var d = JSON.parse(data);

                    $("#firstName").val('');
                    $("#lastName").val('');
                    var moverArray = [data['FirstName'], data['LastName'], data['CrewName']];

                    var length = moverArray.length;

                    var row = '<tr>';
                    for (var i = 0; i < moverArray.length; i++) {
                        if (i < moverArray.length - 1) {
                            row = row.concat('<td>', moverArray[i],'</td>');
                        }
                        else {
                            row = row.concat('<td><select class = "form-control"><option>', moverArray[i], '</option></select></td>');
                            row = row.concat('<td>', '<form>', '<input type="hidden" name="firstName" value="', data['FirstName'], '"/><input type="hidden" name="lastName" value="', data['LastName'], '"/><button class="btn btn-xs btn-info" type="submit" style="width: 70px;">Edit</button>  <button class="btn btn-xs btn-danger deleteMover" type="button">Delete</button></td></tr></form>');
                        }
                    }

                    var table = $("#tableBody");
                    table.append(row);



                }
            });
    });


    function getmodel() {
        var fname = $("#firstName").val();
        var lname = $("#lastName").val();
        var crewName = $("#crewName").val();

        return {
            FirstName: fname,
            LastName: lname,
            CrewName: crewName
        };
    }

});