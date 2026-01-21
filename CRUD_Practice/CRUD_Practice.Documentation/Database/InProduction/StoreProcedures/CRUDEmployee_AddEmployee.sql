DELIMITER //

DROP PROCEDURE IF EXISTS AddEmployee //

CREATE PROCEDURE AddEmployee(
	IN p_name VARCHAR(100),
    IN p_department_id INT,
    IN p_salary DECIMAL(10,2),
    IN p_joining_date DATE,
    OUT p_employee_id INT
)
BEGIN
	IF NOT EXISTS ( SELECT 1 FROM departments WHERE id = p_department_id) THEN
    SIGNAL SQLSTATE '45000'
    SET MESSAGE_TEXT = 'Department does not exist.';
    END IF;

	INSERT INTO employees (name, department_id, salary, joining_date)
    VALUES(p_name, p_department_id, p_salary, p_joining_date);

	SET p_employee_id = LAST_INSERT_ID();
END //

DELIMITER ;