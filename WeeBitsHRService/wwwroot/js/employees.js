$.getScript('/lib/plugins/datatables/datatables-reports.min.js', function () {
    $.getScript('/lib/plugins/datatables/pdfmake/pdfmake.min.js', function () {
        $.getScript('/lib/plugins/datatables/vfs_fonts/vfs_fonts.js', function () {
            $(function () {

                // Get image location
                var url = window.location.protocol + "//" + window.location.host;

                // Store report name and date for export
                var reportName = document.title.replace('- WeeBits Computer - HR', ' ') +
                    new Date().toLocaleDateString('en-GB', {
                        day: '2-digit', month: 'short', year: 'numeric'
                    }).replace(/ /g, '-');

                $('.table').DataTable({
                    "order": [],
                    colReorder: true,
                    dom: 'lBfrtip',
                    buttons: [
                        {
                            extend: 'copyHtml5',
                            footer: true,
                            exportOptions: {
                                columns: ':visible'
                            },
                            text: '<i class="fa fa-copy"></i> Copy Data',
                        },
                        {
                            extend: 'excelHtml5',
                            footer: true,
                            exportOptions: {
                                columns: [0, ':visible']
                            },
                            text: '<i class="fa fa-file-excel" style="color:green"></i> Export to Excel',
                            title: reportName,
                            filename: reportName
                        },
                        {
                            extend: 'print',
                            footer: true,
                            exportOptions: {
                                columns: [0, ':visible']
                            },
                            title: reportName,
                            text: '<i class="fa fa-print" style="color: blue"></i> Print/Export to PDF',
                            customize: function (win) {
                                $(win.document.body)
                                    .prepend(
                                        '<img src="' + url + '/img/logo.png" style="position:absolute; bottom:0; right:0;" width="150" />'
                                    );

                                $(win.document.body).find('table')
                                    .addClass('compact')
                                    .css('font-size', 'inherit');
                            }
                        },
                        {
                            extend: 'colvis',
                            text: 'Select Columns <i class="fa fa-caret-down"></i>',
                            columnText: function (dt, idx, title) { return title == '' ? 'Buttons' : title; }
                        }
                    ]
                });
            });
        });
    });
});