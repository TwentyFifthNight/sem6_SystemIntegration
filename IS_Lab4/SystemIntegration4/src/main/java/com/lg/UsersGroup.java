package com.lg;

import javax.persistence.*;
import java.util.HashSet;
import java.util.Set;

@Entity
@Table(name = "usersGroups")
public class UsersGroup {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;
    @ManyToMany(mappedBy = "userGroups")
    private final Set<User> users = new HashSet<>();

    public UsersGroup(Long id) {
        this.id = id;
    }

    public UsersGroup(){}

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public Set<User> getUsers() {
        return users;
    }

    public void addUser(User user) {
        this.users.add(user);
    }
}
