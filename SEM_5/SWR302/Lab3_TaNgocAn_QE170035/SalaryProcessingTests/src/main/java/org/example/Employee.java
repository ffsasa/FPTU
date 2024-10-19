package org.example;

public class Employee {
        private final int id;
        private boolean isPaid;

        public Employee(int id) {
            this.id = id;
            this.isPaid = false;
        }

        public int getId() {
            return id;
        }

        public boolean isPaid() {
            return isPaid;
        }

        public void setPaid(boolean paid) {
            isPaid = paid;
        }
}
