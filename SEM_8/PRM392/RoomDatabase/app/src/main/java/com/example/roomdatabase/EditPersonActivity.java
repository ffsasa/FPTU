package com.example.roomdatabase;

import android.util.Log;
import android.content.Intent;
import android.os.Bundle;
import android.view.MenuItem;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.appcompat.app.AppCompatActivity;
import androidx.room.Room;

import com.example.roomdatabase.constants.Constants;
import com.example.roomdatabase.db.AppDatabase;
import com.example.roomdatabase.model.Person;

public class EditPersonActivity extends AppCompatActivity {
    private EditText etFirstName, etLastName;
    private Button btnSave;
    private Intent intent;
    private AppDatabase mDb;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_person_edit);

        // Initialize views
        etFirstName = findViewById(R.id.et_firstName);
        etLastName = findViewById(R.id.et_lastName);
        btnSave = findViewById(R.id.btnSave);

        // Initialize database
        mDb = Room.databaseBuilder(getApplicationContext(), AppDatabase.class, "app-database").build();

        // Khởi tạo intent trước khi dùng
        intent = getIntent();

        // Kiểm tra nếu là chế độ chỉnh sửa
        if (intent != null && intent.hasExtra(Constants.UPDATE_PERSON_ID)) {
            btnSave.setText("UPDATE");
            // Đoạn code được thêm: Query Person từ database thay vì lấy từ Intent
            int personId = intent.getIntExtra(Constants.UPDATE_PERSON_ID, -1);
            if (personId != -1) {
                AppExecutors.getInstance().diskIO().execute(() -> {
                    Person person = mDb.personDao().getById(personId);
                    runOnUiThread(() -> populateUI(person));
                });
            } else {
                Toast.makeText(this, "ID không hợp lệ", Toast.LENGTH_SHORT).show();
                finish();
            }
        }

        btnSave.setOnClickListener(v -> saveButtonClicked());
    }

    private void saveButtonClicked() {
        final Person person = new Person(
                etFirstName.getText().toString(),
                etLastName.getText().toString()
        );

        if (intent.hasExtra(Constants.UPDATE_PERSON_ID)) {
            int personId = intent.getIntExtra(Constants.UPDATE_PERSON_ID, -1);
            Log.d("EditPerson", "Received personId: " + personId);
            if (personId == -1) {
                Toast.makeText(this, "ID không hợp lệ", Toast.LENGTH_SHORT).show();
                finish();
                return;
            }
            person.setId(personId);
            AppExecutors.getInstance().diskIO().execute(() -> {
                mDb.personDao().update(person);
                Log.d("EditPerson", "Updated person with ID: " + personId);
                runOnUiThread(() -> {
                    setResult(RESULT_OK);
                    finish();
                });
            });
        } else {
            AppExecutors.getInstance().diskIO().execute(() -> {
                mDb.personDao().insert(person);
                runOnUiThread(() -> {
                    setResult(RESULT_OK);
                    finish();
                });
            });
        }
    }

    private void populateUI(Person person) {
        if (person == null) return;
        etFirstName.setText(person.getFirstName());
        etLastName.setText(person.getLastName());
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        switch (item.getItemId()) {
            case android.R.id.home:
                onBackPressed();
                return true;
        }
        return super.onOptionsItemSelected(item);
    }
}
