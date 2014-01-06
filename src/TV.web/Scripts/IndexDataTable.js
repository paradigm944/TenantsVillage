
$(document).ready(function () {

    jQuery.fn.dataTableExt.oApi.fnSetFilteringDelay = function (oSettings, iDelay) {
        var _that = this;

        if (iDelay === undefined) {
            iDelay = 1250;
        }

        this.each(function (i) {
            $.fn.dataTableExt.iApiIndex = i;
            var
                $this = this,
                oTimerId = null,
                sPreviousSearch = null,
                anControl = $('input', _that.fnSettings().aanFeatures.f);

            anControl.unbind('keyup').bind('keyup', function () {
                var $$this = $this;

                if (sPreviousSearch === null || sPreviousSearch != anControl.val()) {
                    window.clearTimeout(oTimerId);
                    sPreviousSearch = anControl.val();
                    oTimerId = window.setTimeout(function () {
                        $.fn.dataTableExt.iApiIndex = i;
                        _that.fnFilter(anControl.val());
                    }, iDelay);
                }
            });

            return this;
        });
        return this;
    };

    

    var oTable = $('#myDataTable').dataTable({
        "bServerSide": true,
        "bStateSave" : true,
        "sAjaxSource": "Search/AjaxHandler",
        "bProcessing": true,
        "aoColumns": [
                        {
                            "sName": "ID",
                            "bSearchable": false,
                            "bSortable": false,
                            "fnRender": function (oObj) {
                                return '<a class="btn btn-sm btn-primary" style="color: white; height: 25px; padding-bottom: 3px;" id="viewLink" href=\"Search/ViewPost/' + oObj.aData[0] + '\">View</a> &nbsp; <button id="bookmarkButton" class="btn btn-sm btn-warning" onclick="Bookmark(' + oObj.aData[0] + ')">bookmark</button>';
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
    }).fnSetFilteringDelay();
});
