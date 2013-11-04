
$(document).ready(function () {

    var oTable = $('#myDataTable').dataTable({
    	"bServerSide": true,
    	"sAjaxSource": "Search/AjaxHandler", 
    	"bProcessing": true,
    	"aoColumns": [
                        {   "sName": "ID",
                            "bSearchable": false,
                            "bSortable": false,
                            "fnRender": function (oObj) {
                                return '<a href=\"Search/ViewPost/' + oObj.aData[0] + '\">View</a>';
                            }
                        },
                        { "sName": "Title" },
			            { "sName": "LandLord" },
			            { "sName": "LandLord Email" },
			            { "sName": "Date Posted" }
		            ]
    });
});
