DELIMITER $$
DROP DATABASE IF EXISTS dbproductos;
$$
DELIMITER $$
CREATE DATABASE IF NOT EXISTS dbproductos;
USE dbproductos;
$$
DELIMITER $$
CREATE TABLE IF NOT EXISTS tbl_productos (
  id int NOT NULL AUTO_INCREMENT,
  nombre varchar(45) NOT NULL,
  codigo_barra varchar(45) NOT NULL,
  precio double NOT NULL,
  disponible int(1) NOT NULL DEFAULT 1,
  detalle varchar(100) NULL DEFAULT "Detalle del articulo",
  imagen text NULL,
  PRIMARY KEY (id)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
$$
DELIMITER ;
DELIMITER $$
DROP PROCEDURE IF EXISTS spInsertarProduto;
$$
DELIMITER $$
CREATE PROCEDURE spInsertarProduto
(
in p_nombre varchar(45),
in p_codigo_barra varchar(45),
in p_precio double,
in p_disponible int(1),
in p_detalle varchar(100),
in p_imagen text
)
BEGIN
  INSERT INTO tbl_productos(nombre, codigo_barra, precio, disponible, detalle, imagen) 
  VALUES (p_nombre, p_codigo_barra, p_precio, p_disponible, p_detalle, p_imagen);
END
-- CALL spInsertarProduto(@nombre, @codigo_barra, @precio, @disponible, @detalle, @imagen);
$$
DELIMITER $$
DROP PROCEDURE IF EXISTS spActualizarProduto;
$$
DELIMITER $$
CREATE PROCEDURE spActualizarProduto
(
in p_id int,
in p_nombre varchar(45),
in p_codigo_barra varchar(45),
in p_precio double,
in p_disponible int(1),
in p_detalle varchar(100),
in p_imagen text
)
BEGIN
  UPDATE tbl_productos SET 
  nombre = p_nombre,
  codigo_barra = p_codigo_barra,
  precio = p_precio,
  disponible = p_disponible,
  detalle = p_detalle,
  imagen = p_imagen
  WHERE id = p_id;
END
-- CALL spActualizarProduto(@id, @nombre, @codigo_barra, @precio, @disponible, @detalle, @imagen);
$$
DELIMITER $$
DROP PROCEDURE IF EXISTS spEliminarProduto;
$$
DELIMITER $$
CREATE PROCEDURE spEliminarProduto(in p_id int)
BEGIN
  IF p_id > 0 THEN
    DELETE FROM tbl_productos WHERE id = p_id;
  ELSE
    DELETE FROM tbl_productos; 
  END IF;
END
-- CALL spEliminarProduto(@id);
$$
DELIMITER $$
DROP PROCEDURE IF EXISTS spConsularProdutos;
$$
DELIMITER $$
CREATE PROCEDURE spConsularProdutos(in p_id int)
BEGIN
  IF p_id > 0 THEN
    SELECT id, nombre, codigo_barra, precio, disponible, detalle, imagen
    FROM tbl_productos
    WHERE id = p_id;
  ELSE
    SELECT id, nombre, codigo_barra, precio, disponible, detalle, imagen
    FROM tbl_productos;
  END IF;
END
-- CALL spConsularProdutos(@id);
$$
DELIMITER ;
CALL spConsularProdutos(NULL);