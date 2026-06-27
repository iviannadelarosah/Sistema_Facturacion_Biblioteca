Sistema de facturación de una biblioteca donde cada *Empleado* hace una factura del servicio o los servicios que haya solicitado el cliente con el estado *Pendiente* para que cuando el cliente realice el pago de la factura, dicha factura el *Admin* lo pasa a estado *Pago*.

**Roles:**  Admin y Empleado.
**Acciones: **Crear (Empledo y Admin), Editar (Admin) y Eliminar (Admin)


> Nota
- Para el rol Admin se deben de ajustar directamente en la base de datos.
- Se debe de ajustar la conexión a su base de datos en el archivo appsettings.json.

**Script para cambiar el rol de Empleado a Admin del usuario**

    USE BibliotecaDB;
    
    UPDATE Usuarios
    SET Rol = 'Admin'
    WHERE IdUsuario = numerodesuusuario;




