var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/api/book",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "title", "width": "15%" },
            { "data": "author", "width": "15%" },
            { "data": "description", "width": "20%" },
            { "data": "isbn", "width": "15%" },
            { "data": "price", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
        <div class="text-center">
            <a href="/booklist/Upsert?id=${data}" class="btn btn-success mx-1">
                <i class="fas fa-edit"></i>
            </a>
            <a class="btn btn-danger mx-1" onclick="Delete('/api/book?id=${data}')">
                <i class="fas fa-trash-alt"></i>
            </a>
        </div>`;
                }
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Are you sure you want to delete?",
        icon: "warning",
        buttons: true,
        text: "You will not be able to restore the data!",
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}