// Basic example
$(document).ready(function () {
    $('#customTable').DataTable({
        "pagingType": 'numbers',
        "pageLength": 10,
        responsive : true
    });
        
    new $.fn.dataTable.FixedHeader(table);
});