SELECT * FROM child
INNER JOIN child_has_parent_guardian ON child.child_id = child_has_parent_guardian.child_id
INNER JOIN parent_guardian ON parent_guardian.parent_id = child_has_parent_guardian.parent_id
INNER JOIN child_has_emergency_contact ON child.child_id = child_has_emergency_contact.child_id
INNER JOIN emergency_contact ON emergency_contact.contact_id = child_has_emergency_contact.contact_id
INNER JOIN attendance ON attendance.child_id = child.child_id
INNER JOIN address ON parent_guardian.home_address AND parent_guardian.work_address = address.address_1
WHERE child.child_id = @name OR child.First_Name = @name OR child.Last_Name = @name OR (child.First_Name = @firstname AND child.Last_Name = @firstname);