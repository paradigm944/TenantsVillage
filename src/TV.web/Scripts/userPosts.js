
$(document).ready(function () {

    var oTable = $('#myDataTable').dataTable({
        "bServerSide": true,
        "sAjaxSource": "@Url.Content(~/Search/UserPostsAjaxHandler)",
        "bProcessing": true,
        "aoColumns": [
                        {
                            "sName": "ID",
                            "bSearchable": false,
                            "bSortable": false,
                            "fnRender": function (oObj) {
                                return '<div class="row"><div class="span3"><a class="btn btn-mini" href=@Url.Content("~/Search/ViewPost/")' + oObj.aData[0] + '\>View</a><a class="btn btn-mini" href=@Url.Content("~/Post/Edit/")' + oObj.aData[0] + '\>Edit</a><a class="btn btn-mini" href=@Url.Content("~/Post/Delete/")' + oObj.aData[0] + '\>Delete</a><a class="btn btn-mini" href=@Url.Content("~/Post/UnDelete/")' + oObj.aData[0] + '\>UnDelete</a></div></div>';
                            }
                        },
			            { "sName": "Landlord" },
			            { "sName": "Title" },
			            { "sName": "Street" },
                        { "sName": "Completed" },
                        { "sName": "Deleted" }
        ]
    });
});
