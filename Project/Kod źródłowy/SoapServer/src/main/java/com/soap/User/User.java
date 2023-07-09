package com.soap.User;

import javax.persistence.*;

@Entity
@Table(name = "users", indexes = @Index(columnList = "username"))
public class User{

    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    private Long id;

    @Column(nullable = false, unique = true)
    private String username;

    @Column(nullable = false)
    private String password;

    @ManyToOne
    @JoinColumn(name="voivodeships_id", nullable=false)
    private Voivodeship voivodeship;

    public User(Long id, String username, String password) {
        this.id = id;
        this.username = username;
        this.password = password;
        voivodeship = new Voivodeship();
    }

    public User() {
        voivodeship = new Voivodeship();
    }

    public Voivodeship getVoivodeship(){
        return this.voivodeship;
    }
    public void setVoivodeship(Voivodeship voivodeship){
        this.voivodeship = voivodeship;
    }

    public Long getId() {
        return id;
    }

    public void setId(Long id) {
        this.id = id;
    }

    public String getUsername() {
        return username;
    }

    public void setUsername(String username) {
        this.username = username;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    @Override
    public String toString() {
        return '{' +
                "\"id\":" + id +
                ",\"username\":\"" + username +
                "\",\"voivodeship\":\"" + voivodeship.getName() + "\"}";
    }
}
