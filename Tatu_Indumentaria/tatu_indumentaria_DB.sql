/*-- CREAR BASE DE DATOS --*/
CREATE DATABASE IF NOT EXISTS tatu_indumentaria_PRUEBA;
USE tatu_indumentaria_PRUEBA;

/*-- CREAMOS LAS TABLAS--*/

/*-- CREAMOS LA TABLA DE PAISES */
CREATE TABLE IF NOT EXISTS pais (
	id_pais SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT, /* -- PERMITIRA ALMACENAR 65.535 PAISES, YA QUE VA DE 0 A 65.535*/
	nombre_pais VARCHAR(30) NOT NULL,
	CONSTRAINT pk_id_pais PRIMARY KEY(id_pais),
	CONSTRAINT uk_nombre_pais UNIQUE KEY(nombre_pais)
);

/* -- CREAMOS TABLA PARA LAS PROVINCIAS --*/
CREATE TABLE IF NOT EXISTS provincia (
	id_provincia SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT, /* -- PERMITIRA ALMACENAR 65.535 PROVINCIAS, YA QUE VA DE 0 A 65.535*/
	nombre_provincia VARCHAR(30) NOT NULL,
	id_pais SMALLINT UNSIGNED,
	CONSTRAINT pk_id_provincia PRIMARY KEY(id_provincia),
	CONSTRAINT fk_provincia_id_pais FOREIGN KEY(id_pais) REFERENCES pais(id_pais) ON DELETE RESTRICT, /* -- provincia_id_pais_fk - Nombre de la restriccion -- */
	CONSTRAINT uk_provincia_pais UNIQUE (nombre_provincia, id_pais)
);											/*delete en cascada es decir, si borro un pais, borro todas las provincias relacionadas a ese pais*/


/* -- CREAMOS LA TABLA PARA LAS CIUDADES --  */
CREATE TABLE IF NOT EXISTS ciudad (
	id_ciudad SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT, /* -- PERMITIRA ALMACENAR 65.535 CIUDADES, YA QUE VA DE 0 A 65.535*/
	nombre_ciudad VARCHAR(50) NOT NULL,
	codigo_postal VARCHAR(5),
	id_provincia SMALLINT UNSIGNED,
	CONSTRAINT pk_id_ciudad PRIMARY KEY (id_ciudad),
	CONSTRAINT fk_ciudad_id_provincia FOREIGN KEY (id_provincia) REFERENCES provincia(id_provincia) ON DELETE RESTRICT,
	CONSTRAINT uk_ciudad_provincia UNIQUE (nombre_ciudad, id_provincia)
);

/* -- TABLA CLIENTE -- */
CREATE TABLE IF NOT EXISTS cliente(
	id_cliente INT UNSIGNED NOT NULL AUTO_INCREMENT, /*CAPACIDAD: 4.294 millones de clientes - UNSIGNED YA QUE NO HAY ID NEGATIVOS*/
	dni VARCHAR(20)NOT NULL,
	nombre VARCHAR(50)NOT NULL,
	apellido VARCHAR(50)NOT NULL,
	direccion VARCHAR(100),
	fecha_nacimiento DATE,
	telefono VARCHAR(25),
	email VARCHAR(100),
	clave VARCHAR(40),
	genero VARCHAR (10),
	estado TINYINT(1),
	id_ciudad SMALLINT UNSIGNED,
	CONSTRAINT pk_id_cliente PRIMARY KEY(id_cliente),
	CONSTRAINT uk_dni UNIQUE KEY(dni),
	CONSTRAINT fk_cliente_id_ciudad FOREIGN KEY(id_ciudad) REFERENCES ciudad(id_ciudad) ON DELETE RESTRICT /* SI ELIMINO UNA CIUDAD, NO ME ELIMINA EL CLIENTE, PONE SU ID_CIUDAD EN NULL */
);



/* -------------- TABLA EMPLEADOS -------------------- */
CREATE TABLE IF NOT EXISTS empleado(
	id_empleado INT UNSIGNED NOT NULL AUTO_INCREMENT, /*CAPACIDAD: 4.294 millones de clientes - UNSIGNED YA QUE NO HAY ID NEGATIVOS*/
	dni VARCHAR(20)NOT NULL,
	nombre VARCHAR(50)NOT NULL,
	apellido VARCHAR(50)NOT NULL,
	direccion VARCHAR(100),
	fecha_nacimiento DATE,
	telefono VARCHAR(25),
	email VARCHAR(100),
	clave VARCHAR(40),
	genero VARCHAR (10),
	estado TINYINT(1),
	id_ciudad SMALLINT UNSIGNED,
	CONSTRAINT pk_id_empleado PRIMARY KEY(id_empleado),
	CONSTRAINT uk_dni UNIQUE KEY(dni),
	CONSTRAINT fk_empleado_id_ciudad FOREIGN KEY(id_ciudad) REFERENCES ciudad(id_ciudad) ON DELETE RESTRICT /* SI ELIMINO UNA CIUDAD, NO ME ELIMINA EL CLIENTE, PONE SU ID_CIUDAD EN NULL */

);

/* -- TABLAS PARA RELACIONAR CON PRODUCTOS */

/* TABLA CATEGORIA */
CREATE TABLE IF NOT EXISTS categoria (
	id_categoria SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
	nombre_categoria VARCHAR(50) NOT NULL,
	CONSTRAINT pk_id_categoria PRIMARY KEY(id_categoria),
	CONSTRAINT uk_nombre_categoria UNIQUE KEY(nombre_categoria)
);

/* TABLA MARCA */
CREATE TABLE IF NOT EXISTS marca(
	id_marca SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
	nombre_marca VARCHAR(50) NOT NULL,
	CONSTRAINT pk_id_marca PRIMARY KEY(id_marca),
	CONSTRAINT uk_nombre_marca UNIQUE KEY(nombre_marca)
);

/* TABLA TALLE */
CREATE TABLE IF NOT EXISTS talle(
	id_talle SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
	nombre_talle VARCHAR(5)NOT NULL,
	CONSTRAINT pk_id_talle PRIMARY KEY(id_talle),
	CONSTRAINT uk_talle UNIQUE KEY(nombre_talle)
);

/* TABLA COLOR */
CREATE TABLE IF NOT EXISTS color(
	id_color SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
	nombre_color VARCHAR(30)NOT NULL,
	CONSTRAINT pk_id_color PRIMARY KEY(id_color),
	CONSTRAINT uk_color UNIQUE KEY(nombre_color)
);

/* TABLA MODELO */
CREATE TABLE IF NOT EXISTS modelo(
	id_modelo SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
	nombre_modelo VARCHAR(50)NOT NULL,
	CONSTRAINT pk_id_modelo PRIMARY KEY(id_modelo),
	CONSTRAINT uk_nombre_modelo UNIQUE KEY(nombre_modelo)
);

/*  TABLA PRODUCTOS */ 
CREATE TABLE IF NOT EXISTS producto(
	id_producto INT UNSIGNED NOT NULL AUTO_INCREMENT,
	codigo_producto VARCHAR(100) NOT NULL,
	descripcion VARCHAR(50),
	genero VARCHAR(10),
	temporada VARCHAR(30),
	id_categoria SMALLINT UNSIGNED,
	id_marca SMALLINT UNSIGNED,
	id_modelo SMALLINT UNSIGNED,
	CONSTRAINT pk_id_producto PRIMARY KEY(id_producto),
	CONSTRAINT uk_codigo_producto UNIQUE KEY(codigo_producto),
	CONSTRAINT fk_producto_id_categoria FOREIGN KEY(id_categoria) REFERENCES categoria(id_categoria) ON DELETE RESTRICT,
	CONSTRAINT fk_producto_id_marca FOREIGN KEY(id_marca) REFERENCES marca(id_marca) ON DELETE RESTRICT,
	CONSTRAINT fk_producto_id_modelo FOREIGN KEY(id_modelo) REFERENCES modelo(id_modelo) ON DELETE RESTRICT
);

/* TABLA IMAGEN */
CREATE TABLE IF NOT EXISTS imagen(
	id_imagen INT UNSIGNED NOT NULL AUTO_INCREMENT,
	imagen_url LONGBLOB NOT NULL,
	id_producto INT UNSIGNED,
	id_color SMALLINT UNSIGNED,
	CONSTRAINT pk_id_imagen PRIMARY KEY(id_imagen),
	CONSTRAINT uk_producto_color UNIQUE KEY(id_producto, id_color),
/*	CONSTRAINT uk_id_color UNIQUE KEY(id_color), */
	CONSTRAINT fk_imagen_id_producto FOREIGN KEY(id_producto) REFERENCES producto(id_producto) ON DELETE RESTRICT,
	CONSTRAINT fk_imagen_id_color FOREIGN KEY(id_color) REFERENCES color(id_color) ON DELETE RESTRICT
);
	
/* TABLA PARA LA VARIANTE DE LOS PRODUCTOS */
CREATE TABLE IF NOT EXISTS variante_producto(
	id_variante_producto INT UNSIGNED NOT NULL AUTO_INCREMENT,
	id_producto INT UNSIGNED,
	id_talle SMALLINT UNSIGNED,
	id_color SMALLINT UNSIGNED,
	stock_unitario MEDIUMINT UNSIGNED,
	precio_unitario DECIMAL(10,2),
	CONSTRAINT pk_id_variante_producto PRIMARY KEY(id_variante_producto),
	/* CAMPOS UNICOS*/
	CONSTRAINT uk_producto_talle_color UNIQUE KEY(id_producto,id_talle,id_color),
/*	CONSTRAINT uk_talle_color UNIQUE KEY(),
	CONSTRAINT uk_id_color UNIQUE KEY(id_color),*/
	/* CAMPOR FORANEOS */
	CONSTRAINT fk_variante_producto_id_producto FOREIGN KEY(id_producto) REFERENCES producto(id_producto) ON DELETE RESTRICT,
	CONSTRAINT fk_variante_producto_id_talle FOREIGN KEY(id_talle) REFERENCES talle(id_talle) ON DELETE RESTRICT,
	CONSTRAINT fk_variante_producto_id_color FOREIGN KEY(id_color) REFERENCES color(id_color) ON DELETE RESTRICT
);

/*---- CAMPOS NECESARIOS PARA LA TABLA DE VENTAS */

/* TABLA MEDIO DE PAGO*/
CREATE TABLE IF NOT EXISTS medio_pago(
	id_medio_pago 	SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
	nombre_medio_pago	VARCHAR(30)NOT NULL,
	CONSTRAINT pk_id_medio_pago PRIMARY KEY(id_medio_pago),
	CONSTRAINT uk_nombre_medio_pago UNIQUE KEY(nombre_medio_pago)
);

/* TABLA PARA LA EMPRESA DE ENVIOS*/
CREATE TABLE IF NOT EXISTS empresa_envio(
	id_empresa_envio SMALLINT UNSIGNED NOT NULL AUTO_INCREMENT,
	nombre_empresa VARCHAR(50)NOT NULL,
	CONSTRAINT pk_id_empresa_envio PRIMARY KEY(id_empresa_envio),
	CONSTRAINT uk_nombre_empresa UNIQUE KEY(nombre_empresa)
);

/* TABLA PARA LOS ENVIOS*/
CREATE TABLE IF NOT EXISTS envio(
	id_envio INT UNSIGNED NOT NULL AUTO_INCREMENT,
	codigo_envio VARCHAR(30) NOT NULL,
	descripcion_envio VARCHAR(100),
	fecha_envio DATE NOT NULL,
	direccion_envio VARCHAR(100) NOT NULL,
	monto_envio DECIMAL(10,2),
	estado_envio VARCHAR(20),
	id_empresa_envio SMALLINT UNSIGNED,
	CONSTRAINT pk_id_envio PRIMARY KEY(id_envio),
	CONSTRAINT uk_codigo_envio UNIQUE KEY(codigo_envio),
	CONSTRAINT fk_envio_id_empresa_envio FOREIGN KEY(id_empresa_envio) REFERENCES empresa_envio(id_empresa_envio) ON DELETE RESTRICT
);

/*---- TABLA VENTAS ----*/
CREATE TABLE IF NOT EXISTS venta(
	id_venta INT UNSIGNED NOT NULL AUTO_INCREMENT,
	codigo_venta VARCHAR(50) NOT NULL,
	fecha_venta DATE NOT NULL,
	descripcion_venta VARCHAR(50),
	id_cliente INT UNSIGNED,
	id_empleado INT UNSIGNED,
	id_medio_pago SMALLINT UNSIGNED,
	id_envio INT UNSIGNED,
	CONSTRAINT pk_id_venta PRIMARY KEY(id_venta),
	CONSTRAINT uk_codigo_venta UNIQUE KEY	(codigo_venta),
	CONSTRAINT fk_venta_id_empleado FOREIGN KEY(id_empleado) REFERENCES empleado(id_empleado) ON DELETE RESTRICT,
	CONSTRAINT fk_venta_id_cliente FOREIGN KEY(id_cliente) REFERENCES cliente(id_cliente) ON DELETE RESTRICT,
	CONSTRAINT fk_venta_id_medio_pago FOREIGN KEY(id_medio_pago) REFERENCES medio_pago(id_medio_pago) ON DELETE RESTRICT,
	CONSTRAINT fk_venta_id_envio FOREIGN KEY(id_envio) REFERENCES envio(id_envio) ON DELETE RESTRICT
);

/*----- DETALLE VENTA ------*/
CREATE TABLE IF NOT EXISTS detalle_venta(
	id_detalle_venta INT UNSIGNED NOT NULL AUTO_INCREMENT,
	id_venta INT UNSIGNED,
	id_variante_producto INT UNSIGNED,
	cantidad SMALLINT UNSIGNED NOT NULL,
	descuento DECIMAL(10,2),
	subtotal DECIMAL(10,2),
	CONSTRAINT pk_id_detalle_venta PRIMARY KEY(id_detalle_venta),
	
	CONSTRAINT uk_venta_variante_producto UNIQUE KEY(id_venta,id_variante_producto),
/*	CONSTRAINT uk_id_variante_producto UNIQUE KEY(id_variante_producto),*/
	
	CONSTRAINT fk_detalle_venta_id_venta FOREIGN KEY(id_venta) REFERENCES venta(id_venta) ON DELETE RESTRICT,
	CONSTRAINT fk_detalle_venta_variante_producto FOREIGN KEY(id_variante_producto) REFERENCES variante_producto(id_variante_producto)ON DELETE RESTRICT
);

/* ---------- TABLA DE PROVEEDORES--------*/
CREATE TABLE IF NOT EXISTS proveedor(
	id_proveedor INT UNSIGNED NOT NULL AUTO_INCREMENT,
	nombre_proveedor VARCHAR(50) NOT NULL,
	descripcion_proveedor VARCHAR(150),
	direccion_proveedor VARCHAR(50),
	telefono VARCHAR(50),
	email VARCHAR(50),
	estado TINYINT(1),
	id_ciudad SMALLINT UNSIGNED,
	CONSTRAINT pk_id_proveedor PRIMARY KEY(id_proveedor),
	CONSTRAINT uk_nombre_proveedor UNIQUE KEY(nombre_proveedor),
	CONSTRAINT fk_proveedor_id_ciudad FOREIGN KEY(id_ciudad) REFERENCES ciudad(id_ciudad) ON DELETE RESTRICT
	 
);

/* ----- TABLA DE COMPRAS ------*/

CREATE TABLE IF NOT EXISTS compra(
	id_compra INT UNSIGNED NOT NULL AUTO_INCREMENT,
	descripcion VARCHAR(150) NOT NULL,
	precio_flete DECIMAL(10,2),
	fecha_compra DATE NOT NULL,
	cantidad_unidades INT UNSIGNED NOT NULL,
	id_proveedor INT UNSIGNED,
	
	CONSTRAINT pk_id_compra PRIMARY KEY(id_compra),
	CONSTRAINT uk_fecha_compra_proveedor UNIQUE KEY(fecha_compra, id_proveedor),
/*	CONSTRAINT uk_id_proveedor UNIQUE KEY(id_proveedor),*/
	CONSTRAINT fk_compra_id_proveedor FOREIGN KEY(id_proveedor) REFERENCES proveedor(id_proveedor)ON DELETE RESTRICT
	);
	
/* -------- TABLA DETALLE DE COMPRAS --------- */
CREATE TABLE IF NOT EXISTS detalle_compra(
	id_detalle_compra INT UNSIGNED NOT NULL AUTO_INCREMENT,
	id_variante_producto INT UNSIGNED,
	cantidad_unidades INT UNSIGNED NOT NULL,
	precio_unitario DECIMAL(10,2),
	id_compra INT UNSIGNED,
	CONSTRAINT pk_id_detalle_compra PRIMARY KEY(id_detalle_compra),
	
	CONSTRAINT uk_id_variante_producto_compra UNIQUE KEY(id_variante_producto,id_compra),
/*	CONSTRAINT uk_id_compra UNIQUE KEY(id_compra),*/
	
	CONSTRAINT fk_detalle_compra_id_variante_producto FOREIGN KEY(id_variante_producto) REFERENCES variante_producto(id_variante_producto)ON DELETE RESTRICT,
	CONSTRAINT fk_detalle_compra_id_compra FOREIGN KEY(id_compra) REFERENCES compra(id_compra)ON DELETE RESTRICT
	);


CREATE TABLE IF NOT EXISTS usuario(
	id_usuario INT UNSIGNED not null auto_increment,
	nombre_usuario VARCHAR(50),
	clave VARCHAR(50),
	rol VARCHAR(50),
	primary key (id_usuario)
	);
	


/*  DEJAMOS COMO EJEMPLO PERO SE AGREGO A LA CREACION DE LA TABLA

ALTER TABLE ciudad 
ADD CONSTRAINT uk_ciudad_provincia UNIQUE (nombre_ciudad, id_provincia);

*/


/*DEJAMOS SETEADO UN USER ADMIN*/
insert into usuario (nombre_usuario,clave,rol) values ('admin','123456','administrador');


