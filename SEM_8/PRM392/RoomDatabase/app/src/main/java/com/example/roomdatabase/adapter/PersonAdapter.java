package com.example.roomdatabase.adapter;

import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.recyclerview.widget.RecyclerView;

import com.example.roomdatabase.AppExecutors;
import com.example.roomdatabase.EditPersonActivity;
import com.example.roomdatabase.R;
import com.example.roomdatabase.constants.Constants;
import com.example.roomdatabase.db.AppDatabase;
import com.example.roomdatabase.model.Person;

import java.util.List;

public class PersonAdapter extends RecyclerView.Adapter<PersonAdapter.MyViewHolder> {
    private Context context;
    private List<Person> personList;
    private AppDatabase mDb; // Thêm biến để tham chiếu database

    public PersonAdapter(Context context) {
        this.context = context;
        this.mDb = AppDatabase.getDatabase(context); // Khởi tạo database khi tạo adapter
    }

    @Override
    public MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {
        View view = LayoutInflater.from(context).inflate(R.layout.item_person, parent, false);
        return new MyViewHolder(view);
    }

    @Override
    public void onBindViewHolder(MyViewHolder holder, int position) {
        if (personList != null && !personList.isEmpty()) {
            Person person = personList.get(position);
            holder.name.setText(person.getFirstName());
            holder.email.setText(person.getLastName());
        }
    }

    @Override
    public int getItemCount() {
        return personList != null ? personList.size() : 0;
    }

    public void setTasks(List<Person> persons) {
        this.personList = persons;
        notifyDataSetChanged();
    }

    public Person getPersonAt(int position) {
        return personList.get(position);
    }

    public void removePerson(int position) {
        personList.remove(position);
        notifyItemRemoved(position);
    }

    public void retrieveTasks() {
        AppExecutors.getInstance().diskIO().execute(new Runnable() {
            @Override
            public void run() {
                final List<Person> persons = mDb.personDao().getAll(); // Sử dụng personDao từ AppDatabase mới
                AppExecutors.getInstance().mainThread().execute(new Runnable() {
                    @Override
                    public void run() {
                        setTasks(persons);
                    }
                });
            }
        });
    }

    class MyViewHolder extends RecyclerView.ViewHolder {
        TextView name, email;

        MyViewHolder(View itemView) {
            super(itemView);
            name = itemView.findViewById(R.id.tv_firstName);
            email = itemView.findViewById(R.id.tv_lastName);

            itemView.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    int position = getAdapterPosition();
                    if (position != RecyclerView.NO_POSITION && personList != null && !personList.isEmpty()) {
                        Intent intent = new Intent(context, EditPersonActivity.class);
                        intent.putExtra(Constants.UPDATE_PERSON_ID, personList.get(position));
                        context.startActivity(intent);
                    }
                }
            });
        }
    }
}
