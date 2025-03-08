package com.example.roomdatabase.dao;

import androidx.room.Dao;
import androidx.room.Delete;
import androidx.room.Insert;
import androidx.room.Query;
import androidx.room.Update;

import com.example.roomdatabase.model.Person;

import java.util.List;

@Dao
public interface PersonDao {
    @Query("SELECT * FROM person")
    List<Person> getAll();

    @Query("SELECT * FROM person WHERE id IN (:personIds)")
    List<Person> loadAllByIds(int[] personIds);

    @Query("SELECT * FROM person WHERE firstName LIKE :first AND " +
            "lastName LIKE :last LIMIT 1")
    Person findByName(String first, String last);

    @Insert
    void insert(Person person);

    @Update
    void update(Person person);

    @Delete
    void delete(Person person);
}
