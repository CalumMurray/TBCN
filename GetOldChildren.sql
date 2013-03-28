SELECT
 child.*, child_age 
FROM child 
INNER JOIN ( 
	SELECT DATE_FORMAT(NOW(), '%Y') - DATE_FORMAT(child.dob, '%Y') - (DATE_FORMAT(NOW(), '00-%m-%d') < DATE_FORMAT(child.dob, '00-%m-%d')) AS child_age
	FROM child 
) 
AS child_age
INNER JOIN room ON child.room_attending = room.`Name`
WHERE child_age > room.Maximum_Age;
