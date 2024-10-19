package org.example;

import java.util.List;

public interface PaymentProcessor {
    List<Transaction> doPayment(List<Employee> employees);
}
