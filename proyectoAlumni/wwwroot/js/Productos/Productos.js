let productos;

$(document).ready(function () {
        productos = $('#Productos').DataTable(
        {
            ajax: {
                url: 'https://localhost:7178/api/Producto/BuscarProductos',
                dataSrc: ''
            },
            columns: [
                { data: "idProducto", title: "Id" },
                { data: "descripcion", title: "Descripcion" },
                { data: "stock", title: "Stock" },
                {
                    data: "imagen", render: function (data) {
                        if (data != null) 
                            return '<img src="data:image/jpeg;base64,' + data + '"width="100px" height="100px">';
                         else
                            return '<img src="/images/noimage.jpg" width="100px" height="100px">';
                    },
                    title: "Imagen"
                },
                {
                    data: function (data) {
                        return data.activo == true ? "Activo" : "No Activo"
                    }, title: "Activo"
                },
                {
                    data: function (data) {
                        var buttons = `<td><a href='javascript:EditarProducto(${JSON.stringify(data)})'/><i class="fa-solid fa-pen-to-square editar-producto"></i></td>` +
                                      `<td><a href='javascript:EliminarProductos(${JSON.stringify(data)})'/><i class="fa-solid fa-trash eliminar-producto"></i></td>`;

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


function GuardarProducto() {
    $("#ProductosAddPartial").html("");

    $.ajax({
        type: "GET",
        url: "/Productos/ProductosAddPartial",
        contentType: "application/json",
        dataType: "html",
        success: function (data) {
            $("#ProductosAddPartial").html(data);
            $("#GuardarProductos").modal('show')
        }
    })
}

function EliminarProductos(data) {
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
                url: "/Productos/EliminarProductos",
                contentType: "application/json",
                dataType: "html",
                data: JSON.stringify(data),
                success: function (data) {
                    Swal.fire(
                        'Eliminado',
                        'El usuario fue eliminado',
                        'success'
                    )
                    productos.ajax.reload()
                }
            })
        }
    })
}

function EditarProducto(data) {
    $("#ProductosAddPartial").html("");

    $.ajax({
        type: "POST",
        url: "/Productos/ProductosAddPartial",
        contentType: "application/json",
        dataType: "html",
        data: JSON.stringify(data),
        success: function (data) {
            $("#ProductosAddPartial").html(data);
            $("#GuardarProductos").modal('show')
        }
    })
}