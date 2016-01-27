Parent = {}
Parent.ParentSearch=
    {
        Search : function()
        {
            
            //$("div#gridContent").removeClass("hide").addClass("show");
            
            //var searchStrArr = [];
            //var id = $("#Id").val();
            //var phone = $("#Phone").val();
            //var name = $("#FullName").val();
            //var postCode = $("#PostCode").val();          

            //var data = {
            //    'Id': id,
            //    'Phone': phone,
            //    'FullName': name,
            //    'PostCode': postCode,
            //};
           
            //$.ajax({
            //    type: 'POST',
            //    async: false,  
            //    data: data,               
            //    dataType: "html",
            //    cache: false,
            //    url: "/ParentSearch/ParentSearchDetail", 
            //    success: function (response) {
                    
            //        alert("Response=" + response);
            //        $("div#gridContainer").html('');
            //        $("div#gridContainer").html(response);
                                  
            //    },
            //    error: function (jqXHR, textStatus, errorThrown) {
            //        alert("error=" + errorThrown);                    
            //    },
            //    complete: function (xhr, data) {
            //        if (xhr.status != 0)
            //            alert('success');
            //        else
            //            alert('fail');
            //    }
            //});
        },
        init: function()
        {
            //$("input#btnSearch").on("click", Parent.ParentSearch.Search);
            $("#btnSearch").on("click", function () {
                var searchStrArr = [];
                var id = $("#Id").val();
                var phone = $("#Phone").val();
                var name = $("#txtSearchName").val();
                var postCode = $("#PostCode").val();
                var token = $('[name=__RequestVerificationToken]').val();
                var data = {
                    'Id': id,
                    'Phone': phone,
                    'Name': name,
                    'PostCode': postCode,
                    __RequestVerificationToken: token
                };

                $.ajax({
                    type: 'POST',
                    async: false,
                    data: data,
                    dataType: "html",
                    url: "/ParentSearch/ParentSearchDetail",
                    success: function (response) {
                        $("div#gridContainer").html('');
                        $("div#gridContainer").html(response);                       

                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        if (xhr.status == 404) {
                            alert(errorThrown);
                        }
                    },
                    complete: function () {
                       
                    }
                });
            });
           
            $("#txtSearchName").autocomplete(
               {
                   source: function (request, response) {
                       $.ajax({
                           async: false,
                           cache: false,
                           type: "GET",
                           url: "/ParentSearch/GetParentNames",
                           data: { "term": request.term },
                           dataType: "json",
                           success: function (data) {
                               response(data);                             
                           }
                       });
                   }
               });
        }
    }

Parent.ParentSearch.init();