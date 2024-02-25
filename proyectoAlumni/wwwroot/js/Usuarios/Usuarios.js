
let Usuarios;
$(document).ready(function ()
{
        Usuarios = $('#Usuarios').DataTable(
        {
            ajax: {
                url: 'https://localhost:7178/api/Usuarios/BuscarUsuarios',
                dataSrc: ''
            },
            columns: [
                {data: "idUsuario", title: "Id"},
                {data: "nombre", title : "Nombre"},
                {data: "apellido", title: "Apellido"},
                {
                    data: function (data)
                    {
                        return moment(data.fecha_Nacimiento).format('DD/MM/YYYY');
                    }, title: "Fecha de Nacimiento"
                },
                { data: "mail", title: "Email" },
                {
                    data: function (data)
                    {
                       return data.activo == true ? "Activo" : "No Activo"
                    }, title: "Activo"
                },
                { data: 'roles.nombre', title: 'Rol' },
                {
                    data: function (data)
                    {
                            var buttons = `<td><a href='javascript:EditarUsuario(${JSON.stringify(data)})'/><i class="fa-solid fa-pen-to-square editar-usuario"></i></td>` +
                                          `<td><a href='javascript:EliminarUsuario(${JSON.stringify(data)})'/><i class="fa-solid fa-trash eliminar-usuario"></i></td>`;

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


function GuardarUsuario()
{
    $("#UsuariosAddPartial").html("");

    $.ajax({
        type: "GET",
        url: "/Usuarios/UsuariosAddPartial",
        contentType: "application/json",
        dataType: "html",
        success: function (data) {
            $("#UsuariosAddPartial").html(data);
            $("#GuardarUsuario").modal('show')
        }
    })
}

function EliminarUsuario(data)
{
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
                url: "/Usuarios/EliminarUsuario",
                contentType: "application/json",
                dataType: "html",
                data: JSON.stringify(data),
                success: function (data) {
                    Swal.fire(
                        'Eliminado',
                        'El usuario fue eliminado',
                        'success'
                    )
                    Usuarios.ajax.reload()
                }
            })
        }
    })
}

function EditarUsuario(data) {
    $("#UsuariosAddPartial").html("");

    $.ajax({
        type: "POST",
        url: "/Usuarios/UsuariosAddPartial",
        contentType: "application/json",
        dataType: "html",
        data: JSON.stringify(data),
        success: function (data) {
            $("#UsuariosAddPartial").html(data);
            $("#GuardarUsuario").modal('show')
        }
    })
}