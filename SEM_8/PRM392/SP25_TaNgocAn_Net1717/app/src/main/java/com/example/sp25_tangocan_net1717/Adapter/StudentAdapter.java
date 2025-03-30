package com.example.sp25_tangocan_net1717.Adapter;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.TextView;

import com.example.sp25_tangocan_net1717.Model.Student;
import com.example.sp25_tangocan_net1717.R;
import com.example.sp25_tangocan_net1717.StudentManagerActivity;

import java.util.List;

public class StudentAdapter extends ArrayAdapter<Student> {
    private Context context;
    private List<Student> studentList;

    public StudentAdapter(Context context, List<Student> students) {
        super(context, R.layout.student_item, students);
        this.context = context;
        this.studentList = students;
    }

    @Override
    public View getView(int position, View convertView, ViewGroup parent) {
        if (convertView == null) {
            LayoutInflater inflater = LayoutInflater.from(context);
            convertView = inflater.inflate(R.layout.student_item, parent, false);
        }

        TextView tvName = convertView.findViewById(R.id.tvName);
        TextView tvDate = convertView.findViewById(R.id.tvDate);
        TextView tvGender = convertView.findViewById(R.id.tvGender);
        TextView tvAddress = convertView.findViewById(R.id.tvAddress);
        TextView tvPhone = convertView.findViewById(R.id.tvPhone);
        TextView tvEmail = convertView.findViewById(R.id.tvEmail);
        TextView tvMajor = convertView.findViewById(R.id.tvMajor);
        Button btnEdit = convertView.findViewById(R.id.btnEdit);
        Button btnDelete = convertView.findViewById(R.id.btnDelete);
        Button btnShowAddress = convertView.findViewById(R.id.btnShowAddress);

        Student student = studentList.get(position);
        tvName.setText(student.getName());
        tvEmail.setText("Email: " + student.getEmail());
        tvDate.setText("Date: " + student.getDate().toString());
        tvPhone.setText("Phone: " + student.getPhone().toString());
        tvAddress.setText("Address: " + student.getAddress().toString());
        tvGender.setText("Gender: " + student.getGender().toString());
        tvMajor.setText("Major ID: " + student.getMajorId());

        btnEdit.setOnClickListener(v -> ((StudentManagerActivity) context).showEditStudentDialog(student));
        btnDelete.setOnClickListener(v -> ((StudentManagerActivity) context).deleteStudent(student.getId()));
        btnShowAddress.setOnClickListener(v -> ((StudentManagerActivity) context).showMap(student));

        return convertView;
    }
}
