package com.example.sp25_tangocan_net1717;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.RadioGroup;
import android.widget.Toast;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import com.example.sp25_tangocan_net1717.Adapter.StudentAdapter;
import com.example.sp25_tangocan_net1717.Model.Gender;
import com.example.sp25_tangocan_net1717.Model.Major;
import com.example.sp25_tangocan_net1717.Model.Student;
import com.example.sp25_tangocan_net1717.api.StudentRepository;
import com.example.sp25_tangocan_net1717.api.StudentService;
import com.google.android.material.floatingactionbutton.FloatingActionButton;

import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class StudentManagerActivity extends AppCompatActivity {
    private ListView listViewStudents;
    private FloatingActionButton btnAddStudent;
    private StudentAdapter studentAdapter;
    private List<Student> studentList;
    private StudentService studentService;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_student_manager);

        listViewStudents = findViewById(R.id.listViewStudents);
        btnAddStudent = findViewById(R.id.btnAddStudent);

        studentList = new ArrayList<>();
        studentAdapter = new StudentAdapter(this, studentList);
        listViewStudents.setAdapter(studentAdapter);

        StudentRepository studentRepository = new StudentRepository();
        studentService = studentRepository.getStudentService();

        loadStudents();

        btnAddStudent.setOnClickListener(v -> showAddStudentDialog());
    }

    private void loadStudents() {
        studentService.getAllStudents().enqueue(new Callback<List<Student>>() {
            @Override
            public void onResponse(Call<List<Student>> call, Response<List<Student>> response) {
                if (response.isSuccessful() && response.body() != null) {
                    studentList.clear();
                    studentList.addAll(response.body());
                    studentAdapter.notifyDataSetChanged();
                }
            }

            @Override
            public void onFailure(Call<List<Student>> call, Throwable t) {
                Toast.makeText(StudentManagerActivity.this, "Lỗi tải dữ liệu", Toast.LENGTH_SHORT).show();
            }
        });
    }

    public void deleteStudent(String studentId) {
        Call<Void> call = studentService.deleteStudent(studentId);
        call.enqueue(new Callback<Void>() {
            @Override
            public void onResponse(Call<Void> call, Response<Void> response) {
                Toast.makeText(StudentManagerActivity.this, "Delete successfully", Toast.LENGTH_LONG).show();
                removeStudentFromList(studentId);
            }

            @Override
            public void onFailure(Call<Void> call, Throwable t) {
                Toast.makeText(StudentManagerActivity.this, "Delete Fail", Toast.LENGTH_LONG).show();
                t.printStackTrace();
            }
        });
    }

    private void removeStudentFromList(String studentId) {
        studentList.removeIf(student -> student.getId().equals(studentId));
        studentAdapter.notifyDataSetChanged();
        Log.d("DEBUG", "Xóa student: " + studentId);
    }

    private void showAddStudentDialog() {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Thêm Sinh Viên");

        View view = LayoutInflater.from(this).inflate(R.layout.dialog_add_student, null);
        builder.setView(view);

        EditText edtName = view.findViewById(R.id.edtName);
        EditText edtEmail = view.findViewById(R.id.edtEmail);
        EditText edtPhone = view.findViewById(R.id.edtPhone);
        EditText edtDate = view.findViewById(R.id.edtDate);
        EditText edtAddress = view.findViewById(R.id.edtAddress);
        EditText edtMajorId = view.findViewById(R.id.edtMajorId);
        RadioGroup rgGender = view.findViewById(R.id.rgGender);

        builder.setPositiveButton("Thêm", (dialog, which) -> {
            String name = edtName.getText().toString();
            String email = edtEmail.getText().toString();
            String date = edtDate.getText().toString();
            String address = edtAddress.getText().toString();
            String phone = edtPhone.getText().toString();


            String majorIdStr = edtMajorId.getText().toString().trim();
            String majorId = majorIdStr.isEmpty() ? "1" : majorIdStr;

            Gender gender = Gender.OTHER; // Mặc định OTHER
            int selectedGenderId = rgGender.getCheckedRadioButtonId();

            if (selectedGenderId == R.id.rbMale) {
                gender = Gender.MALE;
            } else if (selectedGenderId == R.id.rbFemale) {
                gender = Gender.FEMALE;
            }

            String studentId = UUID.randomUUID().toString();

            Student newStudent = new Student(studentId, name, date, gender, email, majorId, address, phone);

            studentService.createStudent(newStudent).enqueue(new Callback<Student>() {
                @Override
                public void onResponse(Call<Student> call, Response<Student> response) {
                    if (response.isSuccessful()) {
                        loadStudents();
                        Toast.makeText(StudentManagerActivity.this, "Thêm thành công", Toast.LENGTH_SHORT).show();
                    }
                }

                @Override
                public void onFailure(Call<Student> call, Throwable t) {
                    Toast.makeText(StudentManagerActivity.this, "Lỗi khi thêm", Toast.LENGTH_SHORT).show();
                }
            });
        });

        builder.setNegativeButton("Hủy", null);
        builder.show();
    }

    public void showMap(Student student){
        Intent intent = new Intent(StudentManagerActivity.this, MapActivity.class);
        Double latitude = Double.parseDouble(student.getAddress().split(",")[0].trim());
        Double longitude = Double.parseDouble(student.getAddress().split(",")[1].trim());
        intent.putExtra("latitude", latitude);
        intent.putExtra("longitude", longitude);
        startActivity(intent);
    }



    public void showEditStudentDialog(Student student) {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Chỉnh sửa sinh viên");

        View view = LayoutInflater.from(this).inflate(R.layout.dialog_add_student, null);
        builder.setView(view);

        EditText edtName = view.findViewById(R.id.edtName);
        EditText edtEmail = view.findViewById(R.id.edtEmail);
        EditText edtPhone = view.findViewById(R.id.edtPhone);
        EditText edtDate = view.findViewById(R.id.edtDate);
        EditText edtAddress = view.findViewById(R.id.edtAddress);
        EditText edtMajorId = view.findViewById(R.id.edtMajorId);
        RadioGroup rgGender = view.findViewById(R.id.rgGender);

        edtName.setText(student.getName());
        edtEmail.setText(student.getEmail());
        edtPhone.setText(student.getPhone());
        edtDate.setText(student.getDate());
        edtAddress.setText(student.getAddress());
        edtMajorId.setText(student.getMajorId());

        if (student.getGender() == Gender.MALE) {
            rgGender.check(R.id.rbMale);
        } else if (student.getGender() == Gender.FEMALE) {
            rgGender.check(R.id.rbFemale);
        } else {
            rgGender.check(R.id.rbOther);
        }

        builder.setPositiveButton("Lưu", (dialog, which) -> {
            student.setName(edtName.getText().toString());
            student.setEmail(edtEmail.getText().toString());
            student.setPhone(edtPhone.getText().toString());
            student.setDate(edtDate.getText().toString());
            student.setAddress(edtAddress.getText().toString());
            student.setMajorId(edtMajorId.getText().toString());

            int selectedGenderId = rgGender.getCheckedRadioButtonId();
            if (selectedGenderId == R.id.rbMale) {
                student.setGender(Gender.MALE);
            } else if (selectedGenderId == R.id.rbFemale) {
                student.setGender(Gender.FEMALE);
            } else {
                student.setGender(Gender.OTHER);
            }

            studentService.updateStudent(student.getId(), student).enqueue(new Callback<Student>() {
                @Override
                public void onResponse(Call<Student> call, Response<Student> response) {
                    if (response.isSuccessful()) {
                        loadStudents();
                        Toast.makeText(StudentManagerActivity.this, "Cập nhật thành công", Toast.LENGTH_SHORT).show();
                    }
                }

                @Override
                public void onFailure(Call<Student> call, Throwable t) {
                    Toast.makeText(StudentManagerActivity.this, "Lỗi khi cập nhật", Toast.LENGTH_SHORT).show();
                }
            });
        });

        builder.setNegativeButton("Hủy", null);
        builder.show();
    }

}
