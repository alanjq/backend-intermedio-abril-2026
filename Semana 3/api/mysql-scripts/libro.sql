CREATE TABLE `libros`.`libro` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `titulo` VARCHAR(100) NULL,
  `descripcion` VARCHAR(100) NULL,
  `portada` VARCHAR(100) NULL,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `titulo_UNIQUE` (`titulo` ASC) VISIBLE);
