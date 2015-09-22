create table 'categoria'(
	id bigint(20) auto_increment PRIMARY KEY,
	nombre varchar(50) not null unique,
);

#DROP TABLE articulo;
CREATE TABLE articulo(
    id BIGINT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL UNIQUE,
    categoria BIGINT,
    precio DECIMAL);
