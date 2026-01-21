DELIMITER //

DROP PROCEDURE IF EXISTS AddDepartment;

CREATE PROCEDURE AddDepartment(
    IN p_name VARCHAR(100),
    IN p_location VARCHAR(100),
    OUT p_department_id INT
)
BEGIN
    INSERT INTO departments (name, location)
    VALUES (p_name, p_location);

    SET p_department_id = LAST_INSERT_ID();
END//

DELIMITER ;
