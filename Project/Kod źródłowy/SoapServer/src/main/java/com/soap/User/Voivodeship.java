package com.soap.User;

import javax.persistence.*;
import java.util.HashSet;
import java.util.Set;

@Entity
@Table(name = "voivodeships")
public class Voivodeship {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable = false, unique = true, name = "name")
    private String name;

    @OneToMany(mappedBy = "voivodeship")
    private final Set<User> users;

    public Voivodeship(Long id, String name) {
        this.id = id;
        this.name = name;
        users = new HashSet<>();
    }

    public Voivodeship() {
        users = new HashSet<>();
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    public Set<User> getUsers() {
        return users;
    }

    public void addUser(User user){
        this.users.add(user);
    }
}
