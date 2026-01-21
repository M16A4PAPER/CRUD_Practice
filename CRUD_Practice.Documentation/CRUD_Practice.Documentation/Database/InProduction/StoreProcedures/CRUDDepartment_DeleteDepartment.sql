DELIMITER //

DROP PROCEDURE IF EXISTS DeleteDepartment;

CREATE PROCEDURE DeleteDepartment(
    IN p_id INT,
    OUT p_deleted_count INT
)
BEGIN
    DELETE FROM departments
    WHERE id = p_id;
    
    SET p_deleted_count = ROW_COUNT();
END//

DELIMITER ;
