let Servicios;
$(document).ready(function () {
    Servicios = $('#Servicios').DataTable(
        {
            ajax: {
                url: 'https://localhost:7178/api/Servicios/BuscarServicios',
                dataSrc: ''
            },
            columns: [
                { data: "idServicio", title: "Id" },
                { data: "nombre", title: "Nombre" },
                {
                    data: function (data) {
                        return data.activo == true ? "Activo" : "No Activo"
                    }, title: "Activo"
                },
                {
                    data: function (data) {
                        var buttons = `<td><a href='javascript:EditarServicio(${JSON.stringify(data)})'/><i class="fa-solid fa-pen-to-square editar-usuario"></i></td>` +
                            `<td><a href='javascript:EliminarServicio(${JSON.stringify(data)})'/><i class="fa-solid fa-trash eliminar-usuario"></i></td>`;

                        return buttons
                    }
                }
            ],
            language: {
                url: 'https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json'
            }
        }
    )
})


function GuardarServicios() {
    $("#ServiciosAddPartial").html("");

    $.ajax({
        type: "GET",
        url: "/Servicios/ServiciosAddPartial",
        contentType: "application/json",
        dataType: "html",
        success: function (data) {
            $("#ServiciosAddPartial").html(data);
            $("#GuardarServicios").modal('show')
        }
    })
}

function EliminarServicio(data) {
    Swal.fire({
        title: "Estas por eliminar un servicio`",
        text: "Eliminar servicio?",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Eliminar',
        cancelButtonText: 'Cancelar'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: "/Servicios/EliminarServicio",
                contentType: "application/json",
                dataType: "html",
                data: JSON.stringify(data),
                success: function (data) {
                    Swal.fire(
                        'Eliminado',
                        'El servicio fue eliminado',
                        'success'
                    )
                    Servicios.ajax.reload()
                }
            })
        }
    })
}

function EditarServicio(data) {
    $("#ServiciosAddPartial").html("");

    $.ajax({
        type: "POST",
        url: "/Servicios/ServiciosAddPartial",
        contentType: "application/json",
        dataType: "html",
        data: JSON.stringify(data),
        success: function (data) {
            $("#ServiciosAddPartial").html(data);
            $("#GuardarServicios").modal('show')
        }
    })
}