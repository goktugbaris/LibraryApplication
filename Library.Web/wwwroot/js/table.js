//$(document).ready(function () {

//    GetBooks();


//    function GetBooks() {
//        $.ajax({
//            url: '/Book/GetBooks',
//            type: 'Get',
//            dataType: 'json',
//            success: OnSuccess
//        })
//    }

//    function OnSuccess(response) {
//        $('#dataTableData').DataTable({
//            bProcessing: true,
//            bLengthChange: true,
//            lengthMenu: [[5, 15, 25, -1], [5, 15, 25, "All"]],
//            bfilter: true,
//            bsort: true,
//            bPaginate: true,
//            data: response,
//            columns: [
//                {
//                    data: 'Id',
//                    render: function (data, type, row, meta) {
//                        return row.id
//                    }
//                },
//                {
//                    data: 'Name',
//                    render: function (data, type, row, meta) {
//                        return row.name
//                    }
//                },
//                {
//                    data: 'Author',
//                    render: function (data, type, row, meta) {
//                        return row.author
//                    }
//                },
//                {
//                    data: 'In Library',
//                    render: function (data, type, row, meta) {
//                        return row.inLibrary
//                    }
//                },
//            ]
//        })
//    }
//})

$(document).ready(function () {
    $('#addBookForm').submit(function (e) {
        e.preventDefault();

        $.ajax({
            url: '@Url.Action("AddBook")',
            method: 'POST',
            data: $(this).serialize(),
            success: function () {
                location.reload();
            },
            error: function () {
                alert('An error occurred while adding the book.');
            }
        });
    });
});