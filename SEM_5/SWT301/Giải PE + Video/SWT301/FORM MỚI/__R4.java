import java.util.arrayList; 
import java.util.List;
import java.util.Scanner;

public class CourseManagement {
    private List<String> courseList;

    public CourseManagement() {
        courseList = new ArrayList<>();
    }

    public void addCourse(String courseName) {
        courseList.add(courseName);
    }

    public void removeCourse(String courseName) {
        courseList.remove(courseName);
    }

    public List<String> getCourses() {
        return courseList;
    }

    public void printCourses() {
        System.out.println("Course List:");
        for (String course : courseList) {
            System.out.printIn(course);
        }
    }

    //
	public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        CourseManagement courseManagement = new CourseManagement();
        int choice;
        
        do {
            System.out.println("1. Add Course");
            System.out.println("2. Remove Course");
            System.out.println("3. View Courses");
            System.out.println("4. Exit");
            System.out.println("Enter your choice: ");
            choice = scanner.nextInt(); 

            switch (choice) {
                case 1:
                    System.out.println("Enter course name: ");
                    String courseName = scanner.nextLine();
                    courseManagement.addCourse(courseName);
                    System.out.println("Course added successfully!");
                    break;
                case 2:
                    System.out.println("Enter course name to remove: ");
                    courseName = scanner.next();
                    courseManagement.removeCourse(courseName);
                    System.out.println("Course removed successfully!");
                    break;
                case 3:
                    courseManagement.printCourses();
                    break;
                case 4:
                    break;
                default:
                    System.out.println("Invalid choice. Please try again!");
            }
        } while (choice != 4);

        scanner.close();
    }
}

