package com.example.testpe;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;

import androidx.appcompat.app.AlertDialog;
import androidx.appcompat.app.AppCompatActivity;

import com.example.testpe.Adapter.MajorAdapter;
import com.example.testpe.api.MajorRepository;
import com.example.testpe.api.MajorService;
import com.example.testpe.model.Major;
import com.google.android.material.floatingactionbutton.FloatingActionButton;

import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MajorManagerActivity extends AppCompatActivity {
    private ListView listViewMajors;
    private FloatingActionButton btnAddMajor;
    private MajorAdapter majorAdapter;
    private List<Major> majorList;
    private MajorService majorService;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_major_manager);

        listViewMajors = findViewById(R.id.listViewMajors);
        btnAddMajor = findViewById(R.id.btnAddMajor);

        majorList = new ArrayList<>();
        majorAdapter = new MajorAdapter(this, majorList);
        listViewMajors.setAdapter(majorAdapter);

        MajorRepository majorRepository = new MajorRepository();
        majorService = majorRepository.getMajorService();

        loadMajors();

        btnAddMajor.setOnClickListener(v -> showAddMajorDialog());
    }

    private void loadMajors() {
        majorService.getAllMajors().enqueue(new Callback<List<Major>>() {
            @Override
            public void onResponse(Call<List<Major>> call, Response<List<Major>> response) {
                if (response.isSuccessful() && response.body() != null) {
                    majorList.clear();
                    majorList.addAll(response.body());
                    majorAdapter.notifyDataSetChanged();
                }
            }

            @Override
            public void onFailure(Call<List<Major>> call, Throwable t) {
                Toast.makeText(MajorManagerActivity.this, "Lỗi tải dữ liệu", Toast.LENGTH_SHORT).show();
            }
        });
    }

    private void showAddMajorDialog() {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Thêm Ngành");

        View view = LayoutInflater.from(this).inflate(R.layout.dialog_add_major, null);
        builder.setView(view);

        EditText edtMajorName = view.findViewById(R.id.edtMajorName);

        builder.setPositiveButton("Thêm", (dialog, which) -> {
            String majorId =  UUID.randomUUID().toString();
            String majorName = edtMajorName.getText().toString().trim();

            if (majorId.isEmpty() || majorName.isEmpty()) {
                Toast.makeText(MajorManagerActivity.this, "Vui lòng nhập đầy đủ thông tin", Toast.LENGTH_SHORT).show();
                return;
            }

            Major newMajor = new Major(majorId, majorName);

            majorService.createMajor(newMajor).enqueue(new Callback<Major>() {
                @Override
                public void onResponse(Call<Major> call, Response<Major> response) {
                    if (response.isSuccessful()) {
                        loadMajors();
                        Toast.makeText(MajorManagerActivity.this, "Thêm thành công", Toast.LENGTH_SHORT).show();
                    }
                }

                @Override
                public void onFailure(Call<Major> call, Throwable t) {
                    Toast.makeText(MajorManagerActivity.this, "Lỗi khi thêm", Toast.LENGTH_SHORT).show();
                }
            });
        });

        builder.setNegativeButton("Hủy", null);
        builder.show();
    }

    public void deleteMajor(Major major) {
        new AlertDialog.Builder(this)
                .setTitle("Xác nhận xóa")
                .setMessage("Bạn có chắc muốn xóa " + major.getNameMajor() + "?")
                .setPositiveButton("Xóa", (dialog, which) -> {
                    majorService.deleteMajor(major.getId()).enqueue(new Callback<Void>() {
                        @Override
                        public void onResponse(Call<Void> call, Response<Void> response) {
                            if (response.isSuccessful()) {
                                majorList.remove(major);
                                majorAdapter.notifyDataSetChanged();
                                Toast.makeText(MajorManagerActivity.this, "Đã xóa", Toast.LENGTH_SHORT).show();
                            }
                        }

                        @Override
                        public void onFailure(Call<Void> call, Throwable t) {
                            Toast.makeText(MajorManagerActivity.this, "Lỗi khi xóa", Toast.LENGTH_SHORT).show();
                        }
                    });
                })
                .setNegativeButton("Hủy", null)
                .show();
    }

    public void showEditMajorDialog(Major major) {
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setTitle("Chỉnh sửa sinh viên");

        View view = LayoutInflater.from(this).inflate(R.layout.dialog_add_major, null);
        builder.setView(view);

        EditText edtMajorName = view.findViewById(R.id.edtMajorName);

        edtMajorName.setText(major.getNameMajor());

        builder.setPositiveButton("Lưu", (dialog, which) -> {
            major.setNameMajor(edtMajorName.getText().toString());

            majorService.updateMajor(major.getId(), major).enqueue(new Callback<Major>() {
                @Override
                public void onResponse(Call<Major> call, Response<Major> response) {
                    if (response.isSuccessful()) {
                        loadMajors();
                        Toast.makeText(MajorManagerActivity.this, "Cập nhật thành công", Toast.LENGTH_SHORT).show();
                    }
                }

                @Override
                public void onFailure(Call<Major> call, Throwable t) {
                    Toast.makeText(MajorManagerActivity.this, "Lỗi khi cập nhật", Toast.LENGTH_SHORT).show();
                }
            });
        });

        builder.setNegativeButton("Hủy", null);
        builder.show();
    }
}

