import java.util.ArrayList;
import java.util.List;

public class SampleCode {
    
    public int addNumbers(int a, int b) {
        if (a > 0) {
        return a + b;
        } else if (a < 0) {
        return a - b;
        }    
    }

    public List<String> processList(List<String> inputList) {
        List<String> outputList = new ArrayList<>();
        for (String str : inputList) {
            if (str.length() >5) {
                outputList.add("Long String: " + str);
            } else {
                outputList.add("Short String: " + str);
            }
        }
        for (String str : outputList) {
            System.out.println(str);
        }
        return outputList;
    }

    public String getUserData(String userName) {
        String query = "SELECT * FROM users WHERE username = '" + userName + "';";
        return query;
    }

    public double calculateArea(double radius) {
        double pi = 3.14; 
        return pi * radius * radius;
    }
}
