let roles;
$(document).ready(function () {
    roles = $('#Roles').DataTable(
        {
            ajax: {
                url: 'https://localhost:7178/api/Roles/BuscarRoles',
                dataSrc: ''
            },
            columns: [
                { data: "idRole", title: "Id" },
                { data: "nombre", title: "Nombre" },
                {
                    data: function (data) {
                        return data.activo == true ? "Activo" : "No Activo"
                    }, title: "Activo"
                },
                {
                    data: function (data) {
                        var buttons = `<td><a href='javascript:EditarRol(${JSON.stringify(data)})'/><i class="fa-solid fa-pen-to-square editar-usuario"></i></td>` +
                            `<td><a href='javascript:EliminarRol(${JSON.stringify(data)})'/><i class="fa-solid fa-trash eliminar-usuario"></i></td>`;

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


function GuardarRol() {
    $("#RolesAddPartial").html("");

    $.ajax({
        type: "GET",
        url: "/Roles/RolesAddPartial",
        contentType: "application/json",
        dataType: "html",
        success: function (data) {
            $("#RolesAddPartial").html(data);
            $("#GuardarRol").modal('show')
        }
    })
}


function EliminarRol(data) {
    Swal.fire({
        title: "Estas por eliminar a un usuario`",
        text: "Eliminar usuario?",
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
                url: "/Roles/EliminarRol",
                contentType: "application/json",
                dataType: "html",
                data: JSON.stringify(data),
                success: function (data) {
                    Swal.fire(
                        'Eliminado',
                        'El usuario fue eliminado',
                        'success'
                    )
                    roles.ajax.reload()
                }
            })
        }
    })
}

function EditarRol(data) {
    $("#RolesAddPartial").html("");

    $.ajax({
        type: "POST",
        url: "/Roles/RolesAddPartial",
        contentType: "application/json",
        dataType: "html",
        data: JSON.stringify(data),
        success: function (data) {
            $("#RolesAddPartial").html(data);
            $("#GuardarRol").modal('show')
        }
    })
}