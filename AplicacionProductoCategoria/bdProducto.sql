create database bdproducto;
use bdproducto;

create table categoria(
id_categoria int primary key auto_increment,
nombre varchar(40)
);

create table producto(
id_producto int primary key auto_increment,
descripcion varchar(40),
precio float,
stock int,
id_categoria int,
foreign key (id_categoria) references categoria(id_categoria)
);
//procedimiento para Categoria
delimiter $
create procedure guardarCategoria(
in nom varchar(40)
)
begin
	insert into categoria ( nombre) values(nom);
end $

delimiter $
create procedure buscarCategoria(in buscar varchar(40))
begin	
	select *from categoria where nombre like concat('%',buscar,'%');
end $


delimiter $
create procedure listarCategoria(
)
begin
	select *from categoria;
end $
delimiter $
create procedure modificarCategoria(
in id_c int,
in nom varchar (40)
)
begin 
update categoria set nombre=nom
where id_categoria=id_c;
end $

delimiter $
create procedure eliminarCategoria (
in id_c int
)
begin
delete from categoria where id_categoria=id_c;

end $
//procedimiento para Producto
delimiter $
create procedure guardarProducto(
in des varchar(40),
in pre float,
in sto int,
in id_c int
)
begin
	insert into producto (descripcion, precio, stock, id_categoria) values( des, pre, sto, id_c);
end $

delimiter $
create procedure modificarProducto(
in id_p int,
in des varchar(40),
in pre float,
in stoc int,
in id_c int 
)
begin
	update producto set descripcion=des, precio=pre, stock=stoc, id_categoria=id_c
	where id_producto=id_p;
end $

delimiter $
create procedure eliminarProducto(in id_p int)
begin
delete from producto where id_producto=id_p;
end $

delimiter $
create procedure buscarProducto(in buscar varchar(40))
begin
select id_producto, descripcion, precio, stock, categoria.nombre
from categoria inner join producto on categoria.id_categoria = producto.id_categoria
where descripcion like concat('%',buscar,'%');
end $



