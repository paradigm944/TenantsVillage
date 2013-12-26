
$(document).ready(function () {

    var oTable = $('#myDataTable').dataTable({
        "bServerSide": true,
        "sAjaxSource": "Search/AjaxHandler",
        "bProcessing": true,
        "aoColumns": [
                        {
                            "sName": "ID",
                            "bSearchable": false,
                            "bSortable": false,
                            "fnRender": function (oObj) {
                                return '<a class="btn btn-sm btn-primary" style="color: white; height: 25px; padding-bottom: 3px;" id="viewLink" href=\"Search/ViewPost/' + oObj.aData[0] + '\">View</a>';
                            }
                        },
			            { "sName": "Landlord" },
			            { "sName": "Title" },
			            { "sName": "Street" },
                        {"sName:": "Rating"}
        ]
    });
});
