ALTER TABLE `libros`.`libro` 
ADD INDEX `idautor_idx` (`idautor` ASC) VISIBLE;
;
ALTER TABLE `libros`.`libro` 
ADD CONSTRAINT `idautor`
  FOREIGN KEY (`idautor`)
  REFERENCES `libros`.`autor` (`id`)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;

-- Cambiar el tipo de dato de descripción a text
ALTER TABLE `libros`.`libro` 
CHANGE COLUMN `descripcion` `descripcion` TEXT NULL DEFAULT NULL ;
