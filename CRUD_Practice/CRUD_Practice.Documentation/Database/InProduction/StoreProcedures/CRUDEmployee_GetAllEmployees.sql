DELIMITER //

DROP PROCEDURE IF EXISTS GetAllEmployees;

CREATE PROCEDURE GetAllEmployees()
BEGIN
	SELECT e.id, e.name, d.id, d.name AS department_name, e.salary, e.joining_date
    FROM employees e
    LEFT JOIN departments d ON e.department_id = d.id;
END //

DELIMITER ;