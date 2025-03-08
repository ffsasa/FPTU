package com.example.roomdatabase;

import android.content.Intent;
import android.os.Bundle;
import android.view.MenuItem;
import android.widget.Button;
import android.widget.EditText;

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

        intent = getIntent();
        if (intent != null && intent.hasExtra(Constants.UPDATE_PERSON_ID)) {
            btnSave.setText("UPDATE");
            populateUI((Person) intent.getSerializableExtra(Constants.UPDATE_PERSON_ID));
        }

        btnSave.setOnClickListener(v -> saveButtonClicked());
    }

    private void saveButtonClicked() {
        final Person person = new Person(
                etFirstName.getText().toString(),
                etLastName.getText().toString()
        );

        AppExecutors.getInstance().diskIO().execute(new Runnable() {
            @Override
            public void run() {
                if (intent.hasExtra(Constants.UPDATE_PERSON_ID)) {
                    mDb.personDao().update(person);
                } else {
                    mDb.personDao().insert(person);
                }
                runOnUiThread(() -> {
                    setResult(RESULT_OK);
                    finish();
                });
            }
        });
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
