package com.example.roomdatabase;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.ItemTouchHelper;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;
import androidx.room.Room;

import com.example.roomdatabase.adapter.PersonAdapter;
import com.example.roomdatabase.constants.Constants;
import com.example.roomdatabase.db.AppDatabase;
import com.example.roomdatabase.model.Person;

import java.util.List;

public class PersonActivity extends AppCompatActivity {
    private RecyclerView recyclerView;
    private PersonAdapter adapter;
    private AppDatabase mDb;
    private static final int REQUEST_CODE_ADD = 1;
    private static final int REQUEST_CODE_EDIT = 2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_person);

        recyclerView = findViewById(R.id.recyclerView);
        recyclerView.setLayoutManager(new LinearLayoutManager(this));

        adapter = new PersonAdapter(this);
        recyclerView.setAdapter(adapter);

        new ItemTouchHelper(new ItemTouchHelper.SimpleCallback(0, ItemTouchHelper.LEFT | ItemTouchHelper.RIGHT) {
            @Override
            public boolean onMove(RecyclerView recyclerView, RecyclerView.ViewHolder viewHolder, RecyclerView.ViewHolder target) {
                return false;
            }

            @Override
            public void onSwiped(RecyclerView.ViewHolder viewHolder, int direction) {
                int position = viewHolder.getAdapterPosition();
                deletePerson(position);
            }
        }).attachToRecyclerView(recyclerView);

        mDb = Room.databaseBuilder(getApplicationContext(), AppDatabase.class, "app-database").build();
        loadData();

        // Nút thêm mới
        findViewById(R.id.fabAdd).setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(PersonActivity.this, EditPersonActivity.class);
                startActivityForResult(intent, REQUEST_CODE_ADD); // Dùng startActivityForResult để thêm
            }
        });
    }

    @Override
    protected void onResume() {
        super.onResume();
        loadData();
    }

    private void loadData() {
        AppExecutors.getInstance().diskIO().execute(new Runnable() {
            @Override
            public void run() {
                final List<Person> persons = mDb.personDao().getAll();
                AppExecutors.getInstance().mainThread().execute(new Runnable() {
                    @Override
                    public void run() {
                        adapter.setTasks(persons);
                    }
                });
            }
        });
    }

    private void deletePerson(int position) {
        AppExecutors.getInstance().diskIO().execute(new Runnable() {
            @Override
            public void run() {
                Person person = adapter.getPersonAt(position);
                if (person != null) {
                    mDb.personDao().delete(person);
                    AppExecutors.getInstance().mainThread().execute(new Runnable() {
                        @Override
                        public void run() {
                            adapter.removePerson(position);
                        }
                    });
                }
            }
        });
    }

    // Đoạn code được thêm: Xử lý kết quả từ EditPersonActivity
    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
        if (resultCode == RESULT_OK && (requestCode == REQUEST_CODE_ADD || requestCode == REQUEST_CODE_EDIT)) {
            loadData();
        }
    }
}