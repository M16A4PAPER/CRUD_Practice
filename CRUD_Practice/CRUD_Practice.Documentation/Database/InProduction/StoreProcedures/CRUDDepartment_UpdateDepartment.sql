DELIMITER //

DROP PROCEDURE IF EXISTS UpdateDepartment;

CREATE PROCEDURE UpdateDepartment(
    IN p_id INT,
    IN p_name VARCHAR(100),
    IN p_location VARCHAR(100)
)
BEGIN
    UPDATE departments
    SET name = p_name,
        location = p_location
    WHERE id = p_id;
END//

DELIMITER ;
