DELIMITER //

DROP PROCEDURE IF EXISTS UpdateEmployee;

CREATE PROCEDURE UpdateEmployee(
	IN p_id INT,
    IN p_name VARCHAR(100),
    IN p_department_id INT,
    IN p_salary DECIMAL(10,2),
    IN p_joining_date DATE
)
BEGIN
	IF NOT EXISTS (SELECT 1 FROM departments WHERE id = p_department_id) THEN
		SIGNAL SQLSTATE '45000'
		SET MESSAGE_TEXT = 'Department does not exist.';
    END IF;
    
    UPDATE employees
    SET name = p_name,
    department_id = p_department_id,
    salary = p_salary,
    joining_date = p_joining_date
    WHERE id = p_id;
END //

DELIMITER ;