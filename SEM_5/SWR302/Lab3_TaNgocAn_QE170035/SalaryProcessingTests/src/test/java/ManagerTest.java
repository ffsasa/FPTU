import org.example.Manager;
import org.example.Transaction;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.Mock;
import org.mockito.junit.jupiter.MockitoExtension;
import org.mockito.stubbing.Answer;

import java.util.ArrayList;
import java.util.List;

import static org.junit.jupiter.api.Assertions.*;
import static org.mockito.Mockito.doAnswer;
import static org.mockito.Mockito.when;

@ExtendWith(MockitoExtension.class)
public class ManagerTest {

    @Mock
    private Manager manager;

    //SCENARIO 1
    @Test
    public void doPayment_NoEmployee() {
        // Arrange
        List<Employee> employeeList = new ArrayList<>(); // No employees

        when(manager.doPayment(employeeList)).thenReturn(List.of());

        // Act
        List<Transaction> transaction = manager.doPayment(employeeList);

        // Assert
        assertEquals(0, transaction.size()); //No transactions occurred.
    }

    //SCENARIO 2
    @Test
    public void doPayment_TwoEmployee() {
        List<Transaction> transactions = new ArrayList<>();
        List<Employee> employeeList = new ArrayList<>();

        // Add Employee objects to the list
        employeeList.add(new Employee(1));
        employeeList.add(new Employee(2));

        //Setup
        doAnswer((Answer<List>) invocation -> {
            List<Employee> employeesPassed = invocation.getArgument(0);
            // Payment to employees
            for (Employee employee : employeesPassed) {
                if(!employee.isPaid()){
                    employee.setPaid(true);
                    transactions.add(new Transaction(employee.getId())); // Add transaction
                }
            }
            return transactions;
        }).when(manager).doPayment(employeeList);

        // Act
        List<Transaction> transaction = manager.doPayment(employeeList);

        // Assert
        assertEquals(2, transaction.size()); // 2 transactions occurred

        assertTrue(transaction.stream().anyMatch(t -> t.getEmployeeId() == 1)); // Conducted transaction with employee 1
        assertTrue(transaction.stream().anyMatch(t -> t.getEmployeeId() == 2)); // Conducted transaction with employee 2

        assertTrue(employeeList.get(0).isPaid()); // Employee 1 has paid
        assertTrue(employeeList.get(1).isPaid()); // Employee 2 has paid
    }

    //SCENARIO 3
    @Test
    public void doPayment_ThereEmployee_OneFail() {

        List<Transaction> transactions = new ArrayList<>();
        List<Employee> employeeList = new ArrayList<>();

        // Add Employee objects to the list
        employeeList.add(new Employee(1));
        employeeList.add(new Employee(2));
        employeeList.add(new Employee(3));

        //Setup
        doAnswer((Answer<List>) invocation -> {
            List<Employee> employeesPassed = invocation.getArgument(0);
            // Payment to employees
            for (Employee employee : employeesPassed) {
                if(!employee.isPaid() && employee.getId() != 3){ // Employee 3 failed
                    employee.setPaid(true);
                    transactions.add(new Transaction(employee.getId())); // Add transaction
                }
            }
            return transactions;
        }).when(manager).doPayment(employeeList);

        // Act
        List<Transaction> transaction = manager.doPayment(employeeList);

        // Assert
        assertEquals(2, transaction.size()); // 2 transactions occurred

        assertTrue(transaction.stream().anyMatch(t -> t.getEmployeeId() == 1)); // Conducted transaction with employee 1
        assertTrue(transaction.stream().anyMatch(t -> t.getEmployeeId() == 2)); // Conducted transaction with employee 2
        assertFalse(transaction.stream().anyMatch(t -> t.getEmployeeId() == 3)); // Did not conduct transaction with employee 3

        assertTrue(employeeList.get(0).isPaid()); // Employee 1 has paid
        assertTrue(employeeList.get(1).isPaid()); // Employee 2 has paid
        assertFalse(employeeList.get(2).isPaid()); // Employee 3 has not paid
    }

    //SCENARIO 4
    @Test
    public void doPayment_TwoEmployee_OneAlreadyPaid() {

        List<Transaction> transactions = new ArrayList<>();
        List<Employee> employeeList = new ArrayList<>();

        // Add Employee objects to the list
        employeeList.add(new Employee(1));
        employeeList.add(new Employee(2));
        employeeList.get(1).setPaid(true); // Employee 2 has already paid in advance

        //Setup
        doAnswer((Answer<List>) invocation -> {
            List<Employee> employeesPassed = invocation.getArgument(0);
            // Payment to employees
            for (Employee employee : employeesPassed) {
                if(!employee.isPaid()){
                    employee.setPaid(true);
                    transactions.add(new Transaction(employee.getId())); // Add transaction
                }
            }
            return transactions;
        }).when(manager).doPayment(employeeList);

        // Act
        List<Transaction> transaction = manager.doPayment(employeeList);

        // Assert
        assertEquals(1, transaction.size()); // 1 transaction occurred
        assertTrue(transaction.stream().anyMatch(t -> t.getEmployeeId() == 1)); // Conducted transaction with employee 1
        assertTrue(employeeList.get(0).isPaid()); // Employee 1 has paid
    }
}