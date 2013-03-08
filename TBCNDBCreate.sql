SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS tbcndb DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE tbcndb ;

-- Table tbcndb.Address
CREATE  TABLE IF NOT EXISTS tbcndb.Address 
(
  Address_1 VARCHAR(255) NOT NULL ,
  City VARCHAR(45) NULL ,
  County VARCHAR(45) NULL ,
  PostCode VARCHAR(9) NULL ,
  Country VARCHAR(45) NULL ,
  PRIMARY KEY (Address_1) 
)
ENGINE = InnoDB;


-- (Link)Table tbcndb.Child_has_EmegencyContact
CREATE  TABLE IF NOT EXISTS tbcndb.Child_has_EmegencyContact 
(
  ContactID INT NOT NULL ,
  ChildID VARCHAR(8) NOT NULL ,
  PRIMARY KEY (ContactID, ChildID)
)
ENGINE = InnoDB;


-- Table tbcndb.EmegencyContact
CREATE  TABLE IF NOT EXISTS tbcndb.EmegencyContact 
(
  Contact_ID INT NOT NULL AUTO_INCREMENT ,
  Title VARCHAR(4) NULL ,
  Firs_tName VARCHAR(45) NOT NULL ,
  Last_Name VARCHAR(45) NOT NULL ,
  Relationship VARCHAR(45) NULL ,
  Home_Phone VARCHAR(12) NOT NULL ,
  Work_Phone VARCHAR(12) NULL ,
  Mobile_Phone VARCHAR(11) NULL ,
  Address VARCHAR(255) NOT NULL ,
  Work_Address VARCHAR(255) NOT NULL ,
  Gender ENUM('M', 'F'),
  Email VARCHAR(45) NULL CHECK (Email LIKE '*@*.*') , -- Do this at Database level?
  Child VARCHAR(8) NOT NULL ,
  PRIMARY KEY (Contact_ID) ,
  CONSTRAINT fk_Address
    FOREIGN KEY (Address )
    REFERENCES tbcndb.Address (Address_1 )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT fk_Work_Address
    FOREIGN KEY (Work_Address )
    REFERENCES tbcndb.Address (Address_1 )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT fk_Child
    FOREIGN KEY (Child )
    REFERENCES tbcndb.Child_has_EmegencyContact (ChildID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = InnoDB;


-- Table tbcndb.Medical_Informaiton
CREATE  TABLE IF NOT EXISTS tbcndb.Medical_Information 
(
  MedicalID INT NOT NULL ,
  Allergies TEXT NULL ,
  Medication TEXT NULL ,
  Other TEXT NULL ,
  PRIMARY KEY (MedicalID)
)
ENGINE = InnoDB;


-- Table tbcndb.Employee
CREATE  TABLE IF NOT EXISTS tbcndb.Employee 
(
  National_Insurance_Number VARCHAR(9) NOT NULL ,
  FirstName VARCHAR(45) NOT NULL ,
  LastName VARCHAR(45) NOT NULL ,
  Position VARCHAR(48) NOT NULL ,
  Gender ENUM('M', 'F') NOT NULL ,
  Image BLOB NULL,
  Date_Started DATE NOT NULL ,
  Date_Finished DATE NULL ,
  PVG_Date DATE NOT NULL ,
  Holidays_Entitled SMALLINT NOT NULL ,
  Holidays_Taken SMALLINT NULL ,
  HoursPerWeek SMALLINT NOT NULL ,
  HomeAddress VARCHAR(255) NOT NULL ,
  DOB DATE NOT NULL ,
  Salary DOUBLE NULL ,
  Home_Phone VARCHAR(12) NOT NULL ,
  Mobile_Phone VARCHAR(11) NULL ,
  Email VARCHAR(45) NOT NULL CHECK (Email LIKE '*@*.*') ,
  Training TEXT NULL ,
  Medical_Information INT NOT NULL ,
  Emergency_Contact INT NOT NULL ,
  Employeecol VARCHAR(45) NULL ,
  Employeecol1 VARCHAR(45) NULL ,
  PRIMARY KEY (National_Insurance_Number) ,
  CONSTRAINT fk_Emergency_Contact
    FOREIGN KEY (Emergency_Contact )
    REFERENCES tbcndb.EmegencyContact (Contact_ID )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT fk_Medical_Information
    FOREIGN KEY (Medical_Information )
    REFERENCES tbcndb.Medical_Informaiton (MedicalID )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT fk_Address
    FOREIGN KEY (HomeAddress )
    REFERENCES tbcndb.Address (Address_1 )
    ON DELETE RESTRICT
    ON UPDATE CASCADE ,
  CONSTRAINT CHECK (Holidays_Taken <= Holidays_Entitled) -- Use trigger for MySQL
)
ENGINE = InnoDB;


-- Table tbcndb.Department
CREATE  TABLE IF NOT EXISTS tbcndb.Department 
(
  Min_Age TINYINT NOT NULL ,
  Max_Age TINYINT NOT NULL ,
  Min_Ratio TINYINT NOT NULL ,
  Weekly_Fee DECIMAL NOT NULL CHECK (Weekly_Fee > 0),
  Daily_Fee DECIMAL NOT NULL CHECK (Daily_Fee > 0),
  Tea_Fee DECIMAL NULL CHECK (Tea_Fee > 0),
  PRIMARY KEY (Min_Age, Max_Age)
)
ENGINE = InnoDB;


-- Table tbcndb.Room
CREATE  TABLE IF NOT EXISTS tbcndb.Room 
(
  Name VARCHAR(45) NOT NULL ,
  Max_Capacity INT NOT NULL ,
  Minimum_Ratio INT NOT NULL ,
  Minimum_Age TINYINT NOT NULL ,
  Maximum_Age TINYINT NOT NULL ,
  Current_Capacity INT NOT NULL ,
  Description TEXT NULL ,
  Supervisors VARCHAR(9) NOT NULL ,
  PRIMARY KEY (Name) ,
  CONSTRAINT fk_Supervisors
    FOREIGN KEY (Supervisors )
    REFERENCES tbcndb.Employee (National_Insurance_Number )
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT fk_Department
    FOREIGN KEY (Maximum_Age , Minimum_Age )
    REFERENCES tbcndb.Department (Max_Age , Min_Age )
    ON DELETE RESTRICT
    ON UPDATE CASCADE
)
ENGINE = InnoDB;


-- (Link)Table tbcndb.Child_has_Parent_Guardian
CREATE  TABLE IF NOT EXISTS tbcndb.Child_has_Parent_Guardian 
(
  Parent_ID INT NOT NULL ,
  ChildID VARCHAR(8) NOT NULL ,
  PRIMARY KEY (Parent_ID, ChildID)
 )
ENGINE = InnoDB;


-- Table tbcndb.Child
CREATE  TABLE IF NOT EXISTS tbcndb.Child 
(
  Birth_Certificate_Number VARCHAR(8) NOT NULL ,
  First_Name VARCHAR(50) NOT NULL ,
  Last_Name VARCHAR(45) NOT NULL ,
  Image BLOB NULL,
  Gender ENUM('M','F') NOT NULL ,
  DOB DATE NOT NULL ,
  First_Language VARCHAR(45) NULL ,
  Room_Attending VARCHAR(45) NOT NULL ,
  Parent_Guardian INT NOT NULL ,
  Emergency_Contact INT NOT NULL ,
  Date_Applied DATE NOT NULL ,
  Date_Left DATE NULL ,
  Days_Per_Week TINYINT NOT NULL ,
  Extra_Days TINYINT NULL ,
  Teas TINYINT NULL ,
  Medical_Information INT NOT NULL ,
  PRIMARY KEY (Birth_Certificate_Number) ,
  CONSTRAINT fk_Room_Attending
    FOREIGN KEY (Room_Attending )
    REFERENCES tbcndb.Room (Name )
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT fk_Parent_Guardian
    FOREIGN KEY (Parent_Guardian )
    REFERENCES tbcndb.Child_has_Parent_Guardian (Parent_ID )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT fk_Emergency_Contact
    FOREIGN KEY (Emergency_Contact )
    REFERENCES tbcndb.Child_has_EmegencyContact (ContactID )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT fk_Medical_Information
    FOREIGN KEY (Medical_Information )
    REFERENCES tbcndb.Medical_Informaiton (MedicalID )
    ON DELETE RESTRICT
    ON UPDATE CASCADE
)
ENGINE = InnoDB;


-- Table tbcndb.Parent_Guardian
CREATE  TABLE IF NOT EXISTS tbcndb.Parent_Guardian 
(
  Parent_ID INT NOT NULL AUTO_INCREMENT ,
  First_Name VARCHAR(45) NOT NULL ,
  Last_Name VARCHAR(45) NOT NULL ,
  Title VARCHAR(4) NULL ,
  Gender ENUM('M', 'F') NOT NULL ,
  Home_Phone VARCHAR(12) NOT NULL ,
  Work_Phone VARCHAR(12) NOT NULL ,
  Mobile_Phone VARCHAR(11) NULL ,
  Home_Address VARCHAR(255) NOT NULL ,
  Work_Address VARCHAR(255) NOT NULL ,
  Spouse INT NULL ,
  Email VARCHAR(45) NULL CHECK (Email LIKE '*@*.*') ,
  Children VARCHAR(8) NOT NULL ,
  PRIMARY KEY (Parent_ID) ,
  CONSTRAINT fk_Spouse
    FOREIGN KEY (Spouse )
    REFERENCES tbcndb.Parent_Guardian (Parent_ID )
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT fk_Home_Address
    FOREIGN KEY (Home_Address )
    REFERENCES tbcndb.Address (Address_1 )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT fk_Work_Address
    FOREIGN KEY (Work_Address )
    REFERENCES tbcndb.Address (Address_1 )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT fk_Children
    FOREIGN KEY (Children)
    REFERENCES tbcndb.Child_has_Parent_Guardian (ChildID)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION ,
  CONSTRAINT SELECT (JOIN Emergency_Contact AND Parent_Guardian WHERE ParentID = ContactID) IS empty -- FIXME
)
ENGINE = InnoDB;

-- Table tbcndb.Invoice
CREATE  TABLE IF NOT EXISTS tbcndb.Invoice 
(
  InvoiceID INT NOT NULL AUTO_INCREMENT ,
  Child VARCHAR(8) NOT NULL ,
  Paying_Parent INT NOT NULL ,
  Month_Beginning DATE NOT NULL ,
  Weekly_Fee DECIMAL NOT NULL ,
  Month_Text ENUM('Jan', 'Feb', 'Mar', 'Apr', 'May', 'Jun', 'Jul', 'Aug', 'Sep', 'Oct', 'Nov', 'Dec') NOT NULL ,
  No_of_Weeks TINYINT NOT NULL ,
  Percent_Discount DECIMAL NOT NULL CHECK (Percent_Discount >= 0 AND Percent_Discount <= 100) , -- 'Incompatible with MySQL, use Trigger to emulate',
  Discount DECIMAL NOT NULL ,
  Net_Fee DECIMAL NOT NULL ,
  Extra_Days TINYINT NULL ,
  Teas TINYINT NULL ,
  Late_Pay DECIMAL NULL ,
  Arrears DECIMAL NULL ,
  Payment_Method ENUM('Card', 'Cash', 'Checque', 'BACS', 'Voucher') NOT NULL ,
  Total DECIMAL NOT NULL ,
  PRIMARY KEY (InvoiceID) ,
  CONSTRAINT fk_Child
    FOREIGN KEY (Child )
    REFERENCES tbcndb.Child (Birth_Certificate_Number )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_Paying_Parent
    FOREIGN KEY (Paying_Parent )
    REFERENCES tbcndb.Parent_Guardian (Parent_ID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
)
ENGINE = InnoDB;


-- Table tbcndb.Supplier.  Neglected - chosen to focus on smaller portion of problem
CREATE  TABLE IF NOT EXISTS tbcndb.Supplier 
(
  SupplierID INT NOT NULL AUTO_INCREMENT ,
  PRIMARY KEY (SupplierID)
)
ENGINE = InnoDB;


-- Table tbcndb.Supplier_Invoice.  Neglected - chosen to focus on smaller portion of problem
CREATE  TABLE IF NOT EXISTS tbcndb.Supplier_Invoice 
(
  Supplier_InvoiceID INT NOT NULL AUTO_INCREMENT ,
  PRIMARY KEY (Supplier_InvoiceID) 
)
ENGINE = InnoDB;

DELIMITER $$
-- DOB Constraint Trigger 
CREATE TRIGGER check_birth_date
  BEFORE INSERT ON Employee
  FOR EACH ROW
BEGIN
  IF( new.DOB < date '1900-01-01' or 
      new.DOB > sysdate )
  THEN
    CALL raise_application_error(-20001, 'DOB must be after 1900 and before the current date.');
  END IF;
END $$

-- Staff holiday constraints Trigger
CREATE TRIGGER check_staff_holidays
  BEFORE INSERT ON Employee
  FOR EACH ROW
BEGIN
  IF( Holidays_Taken > Holidays_Entitled )
  THEN
    CALL raise_application_error(-20001, 'Employee must not take more holidays than they\'re entitled to.');
  END IF;
END $$

DELIMITER ;

USE tbcndb ;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
