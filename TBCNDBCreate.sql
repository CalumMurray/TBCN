CREATE DATABASE IF NOT EXISTS 12ac3d03;

USE 12ac3d03;

-- Table 12ac3d03.Address
CREATE  TABLE IF NOT EXISTS 12ac3d03.Address 
(
  Address_1 VARCHAR(255) NOT NULL ,
  City VARCHAR(45) NULL ,
  County VARCHAR(45) NULL ,
  PostCode VARCHAR(9) NULL ,
  Country VARCHAR(45) NULL ,
  PRIMARY KEY (Address_1) 
)
ENGINE = InnoDB;


-- (Link)Table 12ac3d03.Child_has_Emergency_Contact
CREATE  TABLE IF NOT EXISTS 12ac3d03.Child_has_Emergency_Contact 
(
  ContactID INT NOT NULL ,
  ChildID VARCHAR(8) NOT NULL ,
  PRIMARY KEY (ContactID, ChildID)
)
ENGINE = InnoDB;


-- Table 12ac3d03.Medical_Information
CREATE  TABLE IF NOT EXISTS 12ac3d03.Medical_Information 
(
  MedicalID INT NOT NULL ,
  Allergies TEXT NULL ,
  Medication TEXT NULL ,
  Other TEXT NULL ,
  PRIMARY KEY (MedicalID)
)
ENGINE = InnoDB;







-- Table 12ac3d03.Department
CREATE  TABLE IF NOT EXISTS 12ac3d03.Department 
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


-- Table 12ac3d03.Room
CREATE  TABLE IF NOT EXISTS 12ac3d03.Room 
(
  RoomName VARCHAR(45) NOT NULL ,
  Max_Capacity INT NOT NULL ,
  Minimum_Ratio INT NOT NULL ,
  Minimum_Age TINYINT NOT NULL ,
  Maximum_Age TINYINT NOT NULL ,
  Current_Capacity INT NOT NULL ,
  Description TEXT NULL ,
  Supervisors VARCHAR(9) NULL,
  PRIMARY KEY (RoomName),
  CONSTRAINT fk_Supervisors
    FOREIGN KEY (Supervisors )
    REFERENCES 12ac3d03.Employee (National_Insurance_Number )
    ON DELETE SET NULL
    ON UPDATE CASCADE ,
  CONSTRAINT fk_Department
    FOREIGN KEY (Maximum_Age , Minimum_Age )
    REFERENCES 12ac3d03.department (Max_Age , Min_Age )
    ON DELETE RESTRICT
    ON UPDATE CASCADE
)
ENGINE = InnoDB;

-- Table 12ac3d03.Employee
CREATE  TABLE IF NOT EXISTS 12ac3d03.Employee 
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
  Hours_Per_Week SMALLINT NOT NULL ,
  Home_Address VARCHAR(255) NOT NULL ,
  DOB DATE NOT NULL ,
  Salary DOUBLE NULL ,
  Home_Phone VARCHAR(12) NOT NULL ,
  Mobile_Phone VARCHAR(11) NULL ,
  Email VARCHAR(45) NOT NULL CHECK (Email LIKE '*@*.*') ,
  Training TEXT NULL ,
  Medical_Information INT NOT NULL ,
  Emergency_Contact INT NOT NULL ,
  PRIMARY KEY (National_Insurance_Number) ,
 CONSTRAINT fk_Employee_Emergency_Contact
    FOREIGN KEY (Emergency_Contact )
    REFERENCES 12ac3d03.Emergency_Contact (Contact_ID )
    ON DELETE CASCADE -- Cascade but use participation constraint to keep 1?
    ON UPDATE CASCADE,
  CONSTRAINT fk_Employee_Medical_Information
    FOREIGN KEY (Medical_Information )
    REFERENCES 12ac3d03.Medical_Information (MedicalID )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT fk_Address1
    FOREIGN KEY (Home_Address )
    REFERENCES 12ac3d03.Address (Address_1 )
    ON DELETE RESTRICT
    ON UPDATE CASCADE ,
  CONSTRAINT CHECK (Holidays_Taken <= Holidays_Entitled) -- Use trigger for MySQL
  -- CONSTRAINT (PROJECT Emergency_Contact OVER Contact) DIFFERENCE (PROJECT Employee OVER Emergency_Contact) IS empty -- At least 1 parent
)
ENGINE = InnoDB;

-- (Link)Table 12ac3d03.Child_has_Parent_Guardian
CREATE  TABLE IF NOT EXISTS 12ac3d03.Child_has_Parent_Guardian 
(
  Parent_ID INT NOT NULL ,
  ChildID VARCHAR(8) NOT NULL ,
  PRIMARY KEY (Parent_ID, ChildID)
 )
ENGINE = InnoDB;


-- Table 12ac3d03.Child
CREATE  TABLE IF NOT EXISTS 12ac3d03.Child 
(
  Birth_Certificate_Number VARCHAR(8) NOT NULL ,
  First_Name VARCHAR(50) NOT NULL ,
  Last_Name VARCHAR(45) NOT NULL ,
  Image BLOB NULL,
  Gender ENUM('M','F') NOT NULL ,
  DOB DATE NOT NULL ,
  First_Language VARCHAR(45) NULL ,
  Room_Attending VARCHAR(45) NULL ,
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
    REFERENCES 12ac3d03.Room (RoomName )
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT fk_Parent_Guardian
    FOREIGN KEY (Parent_Guardian )
    REFERENCES 12ac3d03.Child_has_Parent_Guardian (Parent_ID )
    ON DELETE CASCADE -- Cascade, but use Participation to keep 1
    ON UPDATE CASCADE,
  CONSTRAINT fk_Emergency_Contact2
    FOREIGN KEY (Emergency_Contact )
    REFERENCES 12ac3d03.Child_has_Emergency_Contact (ContactID )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT fk_Medical_Information2
    FOREIGN KEY (Medical_Information )
    REFERENCES 12ac3d03.Medical_Information (MedicalID )
    ON DELETE RESTRICT
    ON UPDATE CASCADE
  -- CONSTRAINT (PROJECT Child OVER Parent_Guardian) DIFFERENCE (PROJECT Parent_Guardian OVER ParentID) IS empty --at least 1 parent
)
ENGINE = InnoDB;


-- Table 12ac3d03.Parent_Guardian
CREATE  TABLE IF NOT EXISTS 12ac3d03.Parent_Guardian 
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
    REFERENCES 12ac3d03.Parent_Guardian (Parent_ID )
    ON DELETE SET NULL
    ON UPDATE CASCADE,
  CONSTRAINT fk_Parent_Home_Address
    FOREIGN KEY (Home_Address )
    REFERENCES 12ac3d03.Address (Address_1 )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT fk_Parent_Work_Address
    FOREIGN KEY (Work_Address )
    REFERENCES 12ac3d03.Address (Address_1 )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT fk_Parents_Children
    FOREIGN KEY (Children)
    REFERENCES 12ac3d03.Child_has_Parent_Guardian (ChildID)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
  -- CONSTRAINT SELECT (JOIN Emergency_Contact AND Parent_Guardian WHERE ParentID = ContactID) IS empty -- Parent can't be Emergency_Contact
 
)
ENGINE = InnoDB;

-- Table 12ac3d03.Invoice
CREATE  TABLE IF NOT EXISTS 12ac3d03.Invoice 
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
  CONSTRAINT fk_Invoice_Child
    FOREIGN KEY (Child )
    REFERENCES 12ac3d03.Child (Birth_Certificate_Number )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT fk_Paying_Parent
    FOREIGN KEY (Paying_Parent )
    REFERENCES 12ac3d03.Parent_Guardian (Parent_ID )
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
 
)
ENGINE = InnoDB;


-- Table 12ac3d03.Supplier.  Neglected - chosen to focus on smaller portion of problem
CREATE  TABLE IF NOT EXISTS 12ac3d03.Supplier 
(
  SupplierID INT NOT NULL AUTO_INCREMENT ,
  PRIMARY KEY (SupplierID)
)
ENGINE = InnoDB;


-- Table 12ac3d03.Supplier_Invoice.  Neglected - chosen to focus on smaller portion of problem
CREATE  TABLE IF NOT EXISTS 12ac3d03.Supplier_Invoice 
(
  Supplier_InvoiceID INT NOT NULL AUTO_INCREMENT ,
  PRIMARY KEY (Supplier_InvoiceID) 
)
ENGINE = InnoDB;

-- Table 12ac3d03.Emergency_Contact
CREATE  TABLE IF NOT EXISTS 12ac3d03.Emergency_Contact 
(
  Contact_ID INT NOT NULL  ,
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
   CONSTRAINT fk_EC_Address
    FOREIGN KEY (Address )
    REFERENCES 12ac3d03.Address (Address_1 )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT fk_EC_Work_Address
    FOREIGN KEY (Work_Address )
    REFERENCES 12ac3d03.Address (Address_1 )
    ON DELETE RESTRICT
    ON UPDATE CASCADE,
  CONSTRAINT fk_EC_Child
    FOREIGN KEY (Child )
    REFERENCES 12ac3d03.Child_has_Emergency_Contact (ChildID )
    ON DELETE CASCADE
    ON UPDATE CASCADE
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

