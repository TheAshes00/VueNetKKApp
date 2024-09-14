CREATE TABLE `donuts`.`donut` (
  `Pk` INT NOT NULL AUTO_INCREMENT,
  `Type` VARCHAR(45) NULL,
  PRIMARY KEY (`Pk`));
  
  CREATE TABLE `donuts`.`Users` (
  `Pk` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(80) NULL,
  `Surename` VARCHAR(80) NULL,
  `PkAuth` INT NOT NULL UNIQUE,
  FOREIGN KEY (PkAuth)  REFERENCES Auth(Pk),
  PRIMARY KEY (`Pk`));
  

  CREATE TABLE `donuts`.`Auth` (
  `Pk` INT NOT NULL AUTO_INCREMENT,
  `Username` VARCHAR(255) NULL UNIQUE,
  `Password` VARCHAR(255) NULL,
  PRIMARY KEY (`Pk`));
  
  CREATE TABLE `donuts`.`Sale` (
  `Pk` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(150),
  `Address` VARCHAR(250) ,
  `PkDonut` INT NOT NULL,
  `Quantity` INT NOT NULL,
  `SaleDate` DATETIME DEFAULT CURRENT_TIMESTAMP,
  `PkAuth` INT NOT NULL,
  PRIMARY KEY (`Pk`),
  FOREIGN KEY (PkDonut)  REFERENCES Donut(Pk),
  FOREIGN KEY (PkAuth)  REFERENCES Auth(Pk)
  );
  
  

  /* 
  En caso de querer manejo de clientes recurrentes,
  se debera agregar esta tabla y la tabla sales debera 
  contener una referencia a esta tabla
  
   CREATE TABLE `donuts`.`Customer` (
  `Pk` INT NOT NULL AUTO_INCREMENT,
  `Name` VARCHAR(255) NULL,
  `Address` VARCHAR(255) NULL,
  PRIMARY KEY (`Pk`));
   */
  
  INSERT INTO donuts.donut (Type) VALUES
('Glazed Original'),
('Chocolate Iced Glazed'),
('Chocolate Iced Glazed with Sprinkles'),
('Strawberry Iced with Sprinkles'),
('Glazed Cruller'),
('Cinnamon Sugar'),
('Powdered Cake'),
('Glazed Raspberry Filled'),
('Glazed Lemon Filled'),
('Glazed Blueberry Cake'),
('Maple Iced Glazed'),
('Chocolate Iced Custard Filled'),
('Chocolate Iced Kreme Filled'),
('Double Dark Chocolate'),
('Glazed Chocolate Cake');
  
   