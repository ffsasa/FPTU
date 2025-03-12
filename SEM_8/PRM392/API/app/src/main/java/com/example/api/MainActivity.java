package com.example.api;

import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.activity.EdgeToEdge;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.graphics.Insets;
import androidx.core.view.ViewCompat;
import androidx.core.view.WindowInsetsCompat;

import com.example.api.api.TraineeRepository;
import com.example.api.model.Trainee;

import java.util.ArrayList;
import java.util.List;

import retrofit2.Call;
import retrofit2.Callback;
import retrofit2.Response;

public class MainActivity extends AppCompatActivity {

    private EditText etName, etEmail, etPhone, etGender;
    private ListView listViewTrainees;
    private TraineeRepository traineeRepository;
    private ArrayAdapter<Trainee> adapter;
    private List<Trainee> traineeList = new ArrayList<>();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        etName = findViewById(R.id.et_name);
        etEmail = findViewById(R.id.et_email);
        etPhone = findViewById(R.id.et_phone);
        etGender = findViewById(R.id.et_gender);
        listViewTrainees = findViewById(R.id.list_view_trainees);
        Button btnRefresh = findViewById(R.id.btn_refresh);

        traineeRepository = new TraineeRepository();

        // Gán sự kiện bấm cho btn_refresh
        btnRefresh.setOnClickListener(v -> refreshList());

        // Khởi tạo adapter cho ListView
        adapter = new ArrayAdapter<Trainee>(this, R.layout.trainee_item, R.id.tv_name, traineeList) {
            @Override
            public View getView(int position, View convertView, ViewGroup parent) {
                View view = super.getView(position, convertView, parent);
                TextView tvName = view.findViewById(R.id.tv_name);
                TextView tvEmail = view.findViewById(R.id.tv_email);
                TextView tvPhone = view.findViewById(R.id.tv_phone);
                TextView tvGender = view.findViewById(R.id.tv_gender);
                Button btnEdit = view.findViewById(R.id.btn_edit);
                Button btnDelete = view.findViewById(R.id.btn_delete);

                final Trainee trainee = traineeList.get(position);
                tvName.setText(trainee.getName());
                tvEmail.setText(trainee.getEmail());
                tvPhone.setText(trainee.getPhone());
                tvGender.setText(trainee.getGender());

                btnEdit.setOnClickListener(v -> editTrainee(trainee));
                btnDelete.setOnClickListener(v -> deleteTrainee(trainee.getId()));

                return view;
            }
        };
        listViewTrainees.setAdapter(adapter);
    }

    public void saveTrainee(View view) {
        String name = etName.getText().toString();
        String email = etEmail.getText().toString();
        String phone = etPhone.getText().toString();
        String gender = etGender.getText().toString();

        Trainee trainee = new Trainee(name, email, phone, gender);
        Call<Trainee> call = traineeRepository.getTraineeService().createTrainee(trainee);
        call.enqueue(new Callback<Trainee>() {
            @Override
            public void onResponse(Call<Trainee> call, Response<Trainee> response) {
                if (response.body() != null) {
                    Toast.makeText(MainActivity.this, "Save successfully", Toast.LENGTH_LONG).show();
                    clearFields();
                    addTraineeToList(response.body()); // Cập nhật danh sách thay vì gọi API
                }
            }

            @Override
            public void onFailure(Call<Trainee> call, Throwable t) {
                Toast.makeText(MainActivity.this, "Save Fail", Toast.LENGTH_LONG).show();
                t.printStackTrace();
            }
        });
    }

    private void addTraineeToList(Trainee trainee) {
        traineeList.add(trainee);
        adapter.notifyDataSetChanged();
        Log.d("DEBUG", "Trainee mới được thêm, tổng số: " + traineeList.size());
    }

    public void refreshList() {
        Call<List<Trainee>> call = traineeRepository.getTraineeService().getAllTrainees();

        call.enqueue(new Callback<List<Trainee>>() {
            @Override
            public void onResponse(Call<List<Trainee>> call, Response<List<Trainee>> response) {

                if (response.isSuccessful() && response.body() != null) {

                    traineeList.clear();
                    traineeList.addAll(response.body());

                    runOnUiThread(() -> adapter.notifyDataSetChanged());
                } else {
                    try {
                        Log.e("API", "Lỗi chi tiết: " + response.errorBody().string());
                    } catch (Exception e) {
                        e.printStackTrace();
                    }
                }
            }

            @Override
            public void onFailure(Call<List<Trainee>> call, Throwable t) {
                Toast.makeText(MainActivity.this, "Load Fail", Toast.LENGTH_LONG).show();
            }
        });
    }


    public void editTrainee(Trainee trainee) {
        etName.setText(trainee.getName());
        etEmail.setText(trainee.getEmail());
        etPhone.setText(trainee.getPhone());
        etGender.setText(trainee.getGender());

        findViewById(R.id.btn_submit).setOnClickListener(v -> updateTrainee(trainee.getId()));
    }

    public void updateTrainee(String traineeId) {
        String name = etName.getText().toString();
        String email = etEmail.getText().toString();
        String phone = etPhone.getText().toString();
        String gender = etGender.getText().toString();

        Trainee updatedTrainee = new Trainee(name, email, phone, gender);
        updatedTrainee.setId(traineeId);
        Call<Trainee> call = traineeRepository.getTraineeService().updateTrainee(traineeId, updatedTrainee);
        call.enqueue(new Callback<Trainee>() {
            @Override
            public void onResponse(Call<Trainee> call, Response<Trainee> response) {
                if (response.body() != null) {
                    Toast.makeText(MainActivity.this, "Update successfully", Toast.LENGTH_LONG).show();
                    clearFields();
                    updateTraineeInList(response.body());
                }
            }

            @Override
            public void onFailure(Call<Trainee> call, Throwable t) {
                Toast.makeText(MainActivity.this, "Update Fail", Toast.LENGTH_LONG).show();
                t.printStackTrace();
            }
        });
    }

    private void updateTraineeInList(Trainee updatedTrainee) {
        for (int i = 0; i < traineeList.size(); i++) {
            if (traineeList.get(i).getId().equals(updatedTrainee.getId())) {
                traineeList.set(i, updatedTrainee);
                adapter.notifyDataSetChanged();
                Log.d("DEBUG", "Cập nhật trainee: " + updatedTrainee.getId());
                return;
            }
        }
    }

    public void deleteTrainee(String traineeId) {
        Call<Void> call = traineeRepository.getTraineeService().deleteTrainee(traineeId);
        call.enqueue(new Callback<Void>() {
            @Override
            public void onResponse(Call<Void> call, Response<Void> response) {
                Toast.makeText(MainActivity.this, "Delete successfully", Toast.LENGTH_LONG).show();
                removeTraineeFromList(traineeId);
            }

            @Override
            public void onFailure(Call<Void> call, Throwable t) {
                Toast.makeText(MainActivity.this, "Delete Fail", Toast.LENGTH_LONG).show();
                t.printStackTrace();
            }
        });
    }

    private void removeTraineeFromList(String traineeId) {
        traineeList.removeIf(trainee -> trainee.getId().equals(traineeId));
        adapter.notifyDataSetChanged();
        Log.d("DEBUG", "Xóa trainee: " + traineeId);
    }

    private void clearFields() {
        etName.setText("");
        etEmail.setText("");
        etPhone.setText("");
        etGender.setText("");
    }
}
