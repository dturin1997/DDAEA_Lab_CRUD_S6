CREATE PROC [dbo].[USP_GetProducto]
@Nombre VARCHAR(50)='',
@Activo BIT=NULL
AS
BEGIN
SELECT Id, Nombre, Precio, FechaCreacion,Activo
FROM productos
WHERE (Nombre Like '%'+@Nombre+'%' OR @Nombre='')
AND (Activo=@Activo OR @Activo IS NULL)
END

CREATE PROC [dbo].[USP_InsertProducto]
@Id int=0,
@Nombre VARCHAR(50)='',
@Precio INT=0,
@FechaCreacion Date='20230425',
@Activo BIT=NULL
AS
BEGIN
INSERT INTO productos(Id,Nombre,Precio,FechaCreacion,Activo)
VALUES (@Id,@Nombre,@Precio,@FechaCreacion,@Activo)
END

CREATE PROC [dbo].[USP_UpdateProducto]
@Id int=0,
@Nombre VARCHAR(50)='',
@Precio INT=0,
@FechaCreacion Date='20230425',
@Activo BIT=NULL
AS
BEGIN
UPDATE productos
SET Nombre = @Nombre, Precio = @Precio,FechaCreacion = @FechaCreacion, Activo = @Activo
WHERE Id = @Id
END

CREATE PROC [dbo].[USP_DeleteProducto]
@Id int=0,
@Activo BIT=NULL
AS
BEGIN
UPDATE productos
SET Activo = @Activo
WHERE Id = @Id
END


[USP_GetProducto] ''
[USP_InsertProducto] 3, LaptopXL, 2000, '20230425',1
[USP_UpdateProducto] 3, LaptopXL, 2000, '20230425',1
[USP_UpdateProducto] 4, ParlanteXL, 95, '20230526',0
[USP_DeleteProducto] 4, 0