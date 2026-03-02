var dataTable;
$(document).ready(function () {
    loadDataTable();
});
function loadDataTable() {
    datatable = $('#tblData').DataTable({
        //api call 
        "ajax";{
        "url": "api/book",
           "type": "Get",
        "datatype": "json";

    },
        "column" : [
            { "data": "title", "width": "15%" },
            { "data": "author", "width": "15%" },
            { "data": "description", "width": "15%" },
            { "data": "isbn", "width": "10%" },
            { "data": "price", "width": "10%" },
            {
                "data": "id",
                "render": function (data)}
                return`
                <div class = "text-center">
                <a href = "booklist/upsert"
                `

        ]
    }