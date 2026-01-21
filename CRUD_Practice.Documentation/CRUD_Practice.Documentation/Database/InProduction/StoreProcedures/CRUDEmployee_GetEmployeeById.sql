DELIMITER //

DROP PROCEDURE IF EXISTS GetEmployeeById;

CREATE PROCEDURE GetEmployeeById(
    IN p_id INT
)
BEGIN
    SELECT e.id, e.name, e.department_id, d.name AS department_name, e.salary, e.joining_date
    FROM employees e
    LEFT JOIN departments d ON e.department_id = d.id
    WHERE e.id = p_id;
END//

DELIMITER ;
