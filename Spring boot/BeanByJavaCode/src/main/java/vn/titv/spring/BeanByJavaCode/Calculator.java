package vn.titv.spring.BeanByJavaCode;

//Giả sử đây là 1 library không thể truy cập
public class Calculator {

    public double canBacHai(double value) {
        return Math.sqrt(value);
    }

    public double binhPhuong(double value) {
        return Math.pow(value, 2);
    }
}
