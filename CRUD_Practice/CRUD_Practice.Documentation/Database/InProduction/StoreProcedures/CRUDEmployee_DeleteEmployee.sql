DELIMITER //

DROP PROCEDURE IF EXISTS DeleteEmployee;

CREATE PROCEDURE DeleteEmployee(
	IN p_id INT,
    OUT p_deleted_count INT
)
BEGIN
	DELETE FROM employees
    WHERE id = p_id;
    
    SET p_deleted_count = ROW_COUNT();
END //

DELIMITER ;