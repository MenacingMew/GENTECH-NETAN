Added enrollment credentials table
Added section column to student table
Added added enrolled_subjects table
Added Reference column to payment table

-- Add columns to admin
ALTER TABLE admin ADD COLUMN Middle_Name varchar(75) DEFAULT NULL AFTER Last_Name;
ALTER TABLE admin ADD COLUMN Suffix varchar(20) DEFAULT NULL AFTER Middle_Name;
ALTER TABLE admin ADD COLUMN Contact_Number varchar(20) DEFAULT NULL AFTER Email;
ALTER TABLE admin ADD COLUMN Address varchar(255) DEFAULT NULL AFTER Contact_Number;
ALTER TABLE admin ADD COLUMN Sex varchar(10) DEFAULT NULL AFTER Address;
ALTER TABLE admin ADD COLUMN Birth_Date date DEFAULT NULL AFTER Sex;

-- Add columns to faculty
ALTER TABLE faculty ADD COLUMN Middle_Name varchar(75) DEFAULT NULL AFTER Last_Name;
ALTER TABLE faculty ADD COLUMN Suffix varchar(20) DEFAULT NULL AFTER Middle_Name;
ALTER TABLE faculty ADD COLUMN Contact_Number varchar(20) DEFAULT NULL AFTER Email;
ALTER TABLE faculty ADD COLUMN Address varchar(255) DEFAULT NULL AFTER Contact_Number;
ALTER TABLE faculty ADD COLUMN Sex varchar(10) DEFAULT NULL AFTER Address;
ALTER TABLE faculty ADD COLUMN Birth_Date date DEFAULT NULL AFTER Sex;
ALTER TABLE faculty ADD COLUMN IsArchived tinyint(1) DEFAULT 0 AFTER Password;
