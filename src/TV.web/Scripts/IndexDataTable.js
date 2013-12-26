
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
                        {
                            "sName": "Rating",
                            "fnRender": function (oObj) {
                                var htmlString = "";
                                var loopIndex = oObj.aData[4]
                                while (loopIndex > 0) {
                                    if (loopIndex == .5) {
                                        htmlString = htmlString + '<i class="fa fa-star-half-full" style="color:gold;"></i>';
                                        return htmlString;
                                    }
                                    htmlString = htmlString + '<i class="fa fa-star" style="color:gold;"></i>';
                                    loopIndex--;
                                }
                                return htmlString;
                            }
                        }
        ]
    });
});
