SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

DROP DATABASE `12ac3d03`;

CREATE SCHEMA IF NOT EXISTS `12ac3d03` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
SHOW WARNINGS;
USE `12ac3d03` ;
-- -----------------------------------------------------
-- Table `12ac3d03`.`Address`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `12ac3d03`.`Address` (
  `Address_1` VARCHAR(255) NOT NULL ,
  `City` VARCHAR(45) NULL ,
  `County` VARCHAR(45) NULL ,
  `PostCode` VARCHAR(9) NULL ,
  `Country` VARCHAR(45) NULL ,
  PRIMARY KEY (`Address_1`) ,
  UNIQUE INDEX `Address_1_UNIQUE` (`Address_1` ASC) )
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `12ac3d03`.`Child_has_Emergency_Contact`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `12ac3d03`.`Child_has_Emergency_Contact` (
  `Contact_ID` INT NOT NULL ,
  `Child_ID` INT NOT NULL ,
  PRIMARY KEY (`Contact_ID`, `Child_ID`) ,
  INDEX `ChildID_idx` (`Child_ID` ASC) ,
  INDEX `ChildID_UNIQUE` (`Child_ID` ASC) ,
  UNIQUE INDEX `EmegencyContact_EmegencyContact_ID_UNIQUE` (`Contact_ID` ASC) ,
CONSTRAINT `fk_Link_Children_ECs`
	FOREIGN KEY (`Contact_ID`)
	REFERENCES `Emergency_Contact`(`Contact_ID`)
	ON DELETE CASCADE
	ON UPDATE CASCADE ,
CONSTRAINT `fk_Link_ECs_Children`
	FOREIGN KEY (`Child_ID`)
	REFERENCES `Child` (`Child_ID`)
	ON DELETE CASCADE
	ON UPDATE CASCADE)
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `12ac3d03`.`Emergency_Contact`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `12ac3d03`.`Emergency_Contact` (
  `Contact_ID` INT NOT NULL AUTO_INCREMENT ,
  `Title` VARCHAR(4) NULL ,
  `Firs_tName` VARCHAR(45) NOT NULL ,
  `Last_Name` VARCHAR(45) NOT NULL ,
  `Relationship` VARCHAR(45) NULL ,
  `Home_Phone` VARCHAR(12) NOT NULL ,
  `Work_Phone` VARCHAR(12) NULL ,
  `Mobile_Phone` VARCHAR(11) NULL ,
  `Address` VARCHAR(255) NOT NULL ,
  `Work_Address` VARCHAR(255) NULL ,
  `Gender` ENUM('M', 'F') NULL ,
  `Email` VARCHAR(45) NULL ,
  PRIMARY KEY (`Contact_ID`) ,
  INDEX `EmegencyContact_ID_UNIQUE` (`Contact_ID` ASC) ,
  INDEX `fk_EC_Address_idx` (`Address` ASC) ,
  INDEX `fk_EC_Work_Address_idx` (`Work_Address` ASC) ,
  CONSTRAINT `fk_EC_Address`
    FOREIGN KEY (`Address` )
    REFERENCES `12ac3d03`.`Address` (`Address_1` )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_EC_Work_Address`
    FOREIGN KEY (`Work_Address` )
    REFERENCES `12ac3d03`.`Address` (`Address_1` )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_EC_Child`
    FOREIGN KEY (`Contact_ID` )
    REFERENCES `12ac3d03`.`Child_has_Emergency_Contact` (`Contact_ID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `12ac3d03`.`Medical_Information`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `12ac3d03`.`Medical_Information` (
  `Medical_ID` INT NOT NULL ,
  `Allergies` TEXT NULL ,
  `Medication` TEXT NULL ,
  `Other` TEXT NULL ,
  `Doctor` VARCHAR(45) NOT NULL ,
  `Doctor_Address` VARCHAR(45) NOT NULL ,
  PRIMARY KEY (`Medical_ID`) ,
  UNIQUE INDEX `MedicalID_UNIQUE` (`Medical_ID` ASC) )
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `12ac3d03`.`Employee`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `12ac3d03`.`Employee` (
  `National_Insurance_Number` VARCHAR(9) NOT NULL ,
  `FirstName` VARCHAR(45) NOT NULL ,
  `LastName` VARCHAR(45) NOT NULL ,
  `Gender` ENUM('M', 'F') NOT NULL ,
  `Date_Started` DATE NOT NULL  ,
  `Date_Finished` DATE NULL  ,
  `PVG_Date` DATE NOT NULL  ,
  `Holidays_Entitled` SMALLINT NOT NULL ,
  `Holidays_Taken` SMALLINT NULL ,
  `HoursPerWeek` SMALLINT NOT NULL ,
  `HomeAddress` VARCHAR(255) NOT NULL ,
  `DateOfBirth` DATE NOT NULL  ,
  `Salary` DOUBLE NULL ,
  `Home_Phone` VARCHAR(12) NOT NULL ,
  `Mobile_Phone` VARCHAR(11) NULL ,
  `Email` VARCHAR(45) NOT NULL ,
  `Training` TEXT NULL ,
  `Medical_Information` INT NOT NULL ,
  `Emergency_Contact` INT NOT NULL ,
  PRIMARY KEY (`National_Insurance_Number`) ,
  UNIQUE INDEX `nationalInsurance_UNIQUE` (`National_Insurance_Number` ASC) ,
  INDEX `Emergency_Contact_idx` (`Emergency_Contact` ASC) ,
  INDEX `Medical_Information_idx` (`Medical_Information` ASC) ,
  INDEX `Address_idx` (`HomeAddress` ASC) ,
  CONSTRAINT `fk_Employee_Emergency_Contact`
    FOREIGN KEY (`Emergency_Contact` )
    REFERENCES `12ac3d03`.`Emergency_Contact` (`Contact_ID` )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Employee_Medical_Information`
    FOREIGN KEY (`Medical_Information` )
    REFERENCES `12ac3d03`.`Medical_Information` (`Medical_ID` )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Employee_Address`
    FOREIGN KEY (`HomeAddress` )
    REFERENCES `12ac3d03`.`Address` (`Address_1` )
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `12ac3d03`.`Department`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `12ac3d03`.`Department` (
  `Min_Age` INT NOT NULL ,
  `Max_Age` INT NOT NULL ,
  `Weekly_Fee` DECIMAL NOT NULL ,
  `Daily_Fee` DECIMAL NOT NULL ,
  `Tea_Fee` DECIMAL NULL ,
  PRIMARY KEY (`Min_Age`, `Max_Age`) )
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `12ac3d03`.`Room`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `12ac3d03`.`Room` (
  `Name` VARCHAR(45) NOT NULL ,
  `Max Capacity` INT NOT NULL ,
  `Minimum_Ratio` INT NOT NULL ,
  `Minimum_Age` INT NOT NULL ,
  `Maximum_Age` INT NOT NULL ,
  `Current_Capacity` INT NOT NULL ,
  `Description` TEXT NULL ,
  `Department_Min` INT NOT NULL ,
  `Department_Max` INT NOT NULL ,
  PRIMARY KEY (`Name`)  ,
  UNIQUE INDEX `roomName_UNIQUE` (`Name` ASC) ,
  CONSTRAINT `fk_Room_Department`
	FOREIGN KEY (`Department_Min` , `Department_Max` )
	REFERENCES `12ac3d03`.`Department` (`Min_Age` , `Max_Age` )
    ON DELETE NO ACTION
    ON UPDATE CASCADE)
;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `12ac3d03`.`Child_has_Parent_Guardian`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `12ac3d03`.`Child_has_Parent_Guardian` (
  `Parent_ID` INT NOT NULL ,
  `Child_ID` INT NOT NULL ,
  PRIMARY KEY (`Parent_ID`, `Child_ID`) ,
  INDEX `ChildID_UNIQUE` (`Child_ID` ASC) ,
  INDEX `Parent_ID_UNIQUE` (`Parent_ID` ASC) ,
CONSTRAINT `fk_Link_Children_Parents`
	FOREIGN KEY (`Parent_ID`)
	REFERENCES `Parent_Guardian`(`Parent_ID`)
	ON DELETE CASCADE
	ON UPDATE CASCADE ,
CONSTRAINT `fk_Link_Parents_Children`
	FOREIGN KEY (`Child_ID`)
	REFERENCES `Child` (`Child_ID`)
	ON DELETE CASCADE
	ON UPDATE CASCADE
)
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `12ac3d03`.`Child`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `12ac3d03`.`Child` (
  `Child_ID` INT NOT NULL AUTO_INCREMENT ,
  `First_Name` VARCHAR(50) NOT NULL ,
  `Last_Name` VARCHAR(45) NOT NULL ,
  `Gender` ENUM('M', 'F') NOT NULL ,
  `DOB` DATE NOT NULL  ,
  `First_Language` VARCHAR(45) NULL ,
  `Room_Attending` VARCHAR(45) NOT NULL ,
  `Sibling` INT NULL ,
  `Date_Applied` DATE NOT NULL ,
  `Date_Left` DATE NULL ,
  `Days_Per_Week` TINYINT NOT NULL ,
  `Extra_Days` TINYINT NULL ,
  `Teas` TINYINT NULL ,
  `Medical_Information` INT NOT NULL ,
  PRIMARY KEY (`Child_ID`) ,
  UNIQUE INDEX `Child_ID_UNIQUE` (`Child_ID` ASC) ,
  INDEX `fk_Child_Room1_idx` (`Room_Attending` ASC) ,
  INDEX `fk_Child_Sibling_idx` (`Sibling` ASC) ,
  INDEX `fk_Child_Medical_Information_idx` (`Medical_Information` ASC) ,
  CONSTRAINT `fk_Room_Attending`
    FOREIGN KEY (`Room_Attending` )
    REFERENCES `12ac3d03`.`Room` (`Name` )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Child_Parent_Guardian`
    FOREIGN KEY (`Child_ID` )
    REFERENCES `12ac3d03`.`Child_has_Parent_Guardian` (`Child_ID` )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Sibling`
    FOREIGN KEY (`Sibling` )
    REFERENCES `12ac3d03`.`Child` (`Child_ID` )
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Child_Emergency_Contact`
    FOREIGN KEY (`Child_ID` )
    REFERENCES `12ac3d03`.`Child_has_Emergency_Contact` (`Child_ID` )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Child_Medical_Information`
    FOREIGN KEY (`Medical_Information` )
    REFERENCES `12ac3d03`.`Medical_Information` (`Medical_ID` )
    ON DELETE RESTRICT
    ON UPDATE CASCADE)
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `12ac3d03`.`Parent_Guardian`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `12ac3d03`.`Parent_Guardian` (
  `Parent_ID` INT NOT NULL AUTO_INCREMENT ,
  `First_Name` VARCHAR(45) NOT NULL ,
  `Last_Name` VARCHAR(45) NOT NULL ,
  `Title` VARCHAR(4) NULL ,
  `Gender` ENUM('M', 'F') NOT NULL ,
  `Home_Phone` VARCHAR(12) NOT NULL ,
  `Work_Phone` VARCHAR(12) NOT NULL ,
  `Mobile_Phone` VARCHAR(11) NULL ,
  `Home_Address` VARCHAR(255) NOT NULL ,
  `Work_Address` VARCHAR(255) NOT NULL ,
  `Spouse` INT NULL ,
  `Email` VARCHAR(45) NULL ,
  PRIMARY KEY (`Parent_ID`) ,
  UNIQUE INDEX `Parent_ID_UNIQUE` (`Parent_ID` ASC) ,
  INDEX `fk_Spouse_idx` (`Spouse` ASC) ,
  INDEX `fk_Parent_Home_Address_idx` (`Home_Address` ASC) ,
  INDEX `fk_Parent_Work_Address_idx` (`Work_Address` ASC) ,
  CONSTRAINT `fk_Spouse`
    FOREIGN KEY (`Spouse` )
    REFERENCES `12ac3d03`.`Parent_Guardian` (`Parent_ID` )
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Parent_Home_Address`
    FOREIGN KEY (`Home_Address` )
    REFERENCES `12ac3d03`.`Address` (`Address_1` )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT `fk_Parent_Work_Address`
    FOREIGN KEY (`Work_Address` )
    REFERENCES `12ac3d03`.`Address` (`Address_1` )
    ON DELETE RESTRICT
    ON UPDATE CASCADE ,
  CONSTRAINT `fk_Parent_Children`
    FOREIGN KEY (`Parent_ID`)
    REFERENCES `12ac3d03`.`Child_has_Parent_Guardian` (`Parent_ID`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `12ac3d03`.`Invoice`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `12ac3d03`.`Invoice` (
  `InvoiceID` INT NOT NULL AUTO_INCREMENT ,
  `Child` INT NOT NULL ,
  `Paying_Parent` INT NOT NULL ,
  `Month_Beginning` DATE NOT NULL  ,
  `Weekly_Fee` DECIMAL NOT NULL ,
  `Month` ENUM('JAN', 'FEB', 'MAR', 'APR', 'MAY', 'JUN', 'JUL', 'AUG', 'SEP', 'OCT', 'NOV', 'DEC') NOT NULL ,
  `No_of_Weeks` TINYINT NOT NULL ,
  `Percent_Discount` DECIMAL NOT NULL COMMENT '0 - 100' ,
  `Discount` DECIMAL NOT NULL ,
  `Net_Fee` DECIMAL NOT NULL ,
  `Extra_Days` TINYINT NULL ,
  `Teas` TINYINT NULL ,
  `Late_Pay` DECIMAL NULL ,
  `Arrears` DECIMAL NULL ,
  `Payment_Method` ENUM('Card','Cash', 'Checque', 'BACS', 'Voucher') NOT NULL ,
  `Total` DECIMAL NOT NULL ,
  PRIMARY KEY (`InvoiceID`) ,
  UNIQUE INDEX `InvoiceID_UNIQUE` (`InvoiceID` ASC) ,
  INDEX `fk_Paying_Parent_idx` (`Paying_Parent` ASC) ,
  CONSTRAINT `fk_Invoice_Child`
    FOREIGN KEY (`Child` )
    REFERENCES `12ac3d03`.`Child` (`Child_ID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Paying_Parent`
    FOREIGN KEY (`Paying_Parent` )
    REFERENCES `12ac3d03`.`Parent_Guardian` (`Parent_ID` )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;

SHOW WARNINGS;

CREATE  TABLE IF NOT EXISTS `12ac3d03`.`Attendance` (
	Child_ID INT NOT NULL ,
	Monday BOOL ,
	Tuesday BOOL ,
	Wednesday BOOL ,
	Thursday BOOL ,
	Friday BOOL ,
	PRIMARY KEY (`Child_ID`) ,
	CONSTRAINT `fk_Child_Attendance`
	  FOREIGN KEY (`Child_ID`)
	  REFERENCES `12ac3d03`.`Child` (`Child_ID` )
	  ON DELETE CASCADE
      ON UPDATE CASCADE
)
ENGINE = InnoDB;

-- -----------------------------------------------------
-- Table `12ac3d03`.`Supplier`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `12ac3d03`.`Supplier` (
  `SupplierID` INT NOT NULL AUTO_INCREMENT ,
  PRIMARY KEY (`SupplierID`) ,
  UNIQUE INDEX `SupplierID_UNIQUE` (`SupplierID` ASC) )
ENGINE = InnoDB;

SHOW WARNINGS;

-- -----------------------------------------------------
-- Table `12ac3d03`.`Supplier_Invoice`
-- -----------------------------------------------------
CREATE  TABLE IF NOT EXISTS `12ac3d03`.`Supplier_Invoice` (
  `Supplier_InvoiceID` INT NOT NULL AUTO_INCREMENT ,
  UNIQUE INDEX `Supplier_InvoiceID_UNIQUE` (`Supplier_InvoiceID` ASC) ,
  PRIMARY KEY (`Supplier_InvoiceID`) )
ENGINE = InnoDB;

SHOW WARNINGS;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;