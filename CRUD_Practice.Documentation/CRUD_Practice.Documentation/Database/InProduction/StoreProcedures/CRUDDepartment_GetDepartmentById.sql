DELIMITER //

DROP PROCEDURE IF EXISTS GetDepartmentById;

CREATE PROCEDURE GetDepartmentById(
    IN p_id INT
)
BEGIN
    SELECT * FROM departments
    WHERE id = p_id;
END//

DELIMITER ;
