package com.lg;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import javax.persistence.Query;
import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) throws IOException {
        System.out.println("Program testowy");
        EntityManagerFactory factory =
                Persistence.createEntityManagerFactory("Hibernate_JPA");
        EntityManager em = factory.createEntityManager();

        addUsersAndRoles(em);

        changePasswordAndRemoveRole(em);

        getKowalscyAndFemales(em);

        addRoleToUser(em);

        addUsersGroupsAndAssignUsers(em);

        saveImage(em);

        em.close();
        factory.close();
    }

    private static void addUsersAndRoles(EntityManager em){
        em.getTransaction().begin();

        List<User> users = new ArrayList<>();
        users.add(new User(null,"test1","test1",
                "Andrzej", "Kowalski", Sex.MALE));
        users.add(new User(null,"test2","test1",
                "Robert", "Makłowicz", Sex.MALE));
        users.add(new User(null,"test3","test1",
                "Robert", "Kubica", Sex.MALE));
        users.add(new User(null,"test4","test1",
                "Justyna", "Kowalczyk", Sex.FEMALE));
        users.add(new User(null,"test5","test1",
                "Magda", "Gessler", Sex.FEMALE));
        users.forEach(em::persist);

        List<Role> roles = new ArrayList<>();
        roles.add(new Role(null, "Student"));
        roles.add(new Role(null, "Kucharz"));
        roles.add(new Role(null, "Kierowca"));
        roles.add(new Role(null, "Skoczek"));
        roles.add(new Role(null, "Profesor"));
        roles.forEach(em::persist);

        em.getTransaction().commit();
    }

    private static void changePasswordAndRemoveRole(EntityManager em){
        em.getTransaction().begin();
        User u1 = em.find(User.class, 1L);
        if(u1 != null) {
            u1.setPassword("pass1");
            em.merge(u1);
        }

        Role roleToRemove = em.find(Role.class, 5L);
        if(roleToRemove != null)
            em.remove(roleToRemove);
        em.getTransaction().commit();
    }

    public static void getKowalscyAndFemales(EntityManager em){
        em.getTransaction().begin();
        Query query = em.createQuery("Select u FROM User u WHERE u.lastName = 'Kowalski'");
        List<User> kowalscy = query.getResultList();

        query = em.createQuery("Select u FROM User u WHERE u.sex = 'FEMALE'");
        List<User> females = query.getResultList();
        em.getTransaction().commit();

        System.out.println("Kowalscy:");
        kowalscy.forEach(kowalski -> System.out.println("Imię: " + kowalski.getFirstName() + " Nazwisko: " + kowalski.getLastName()));
        System.out.println("Kobiety:");
        females.forEach(female -> System.out.println("Imię: " + female.getFirstName() + " Nazwisko: " + female.getLastName()));
    }

    public static void addRoleToUser(EntityManager em){
        em.getTransaction().begin();
        User u2 = new User(null, "user2", "test1", "Andrzej", "Nowak", Sex.MALE);
        u2.addRole(em.find(Role.class,1L));
        u2.addRole(em.find(Role.class,3L));
        em.persist(u2);
        em.getTransaction().commit();
    }

    public static void addUsersGroupsAndAssignUsers(EntityManager em){
        em.getTransaction().begin();
        List<UsersGroup> usersGroups = new ArrayList<>();
        usersGroups.add(new UsersGroup(1L));
        usersGroups.add(new UsersGroup(2L));
        usersGroups.add(new UsersGroup(3L));
        usersGroups.forEach(em::merge);
        em.getTransaction().commit();

        em.getTransaction().begin();
        User user = em.find(User.class, 1L);
        user.addUsersGroup(usersGroups.get(0));
        user.addUsersGroup(usersGroups.get(1));
        em.merge(user);

        user = em.find(User.class, 2L);
        user.addUsersGroup(usersGroups.get(1));
        user.addUsersGroup(usersGroups.get(2));
        em.merge(user);

        user = em.find(User.class, 3L);
        user.addUsersGroup(usersGroups.get(0));
        user.addUsersGroup(usersGroups.get(2));
        em.merge(user);
        em.getTransaction().commit();
    }

    public static void saveImage(EntityManager em) throws IOException {
        em.getTransaction().begin();
        byte[] image;
        try (InputStream is = Main.class.getResourceAsStream("/Java.png")) {
            assert is != null;
            image = is.readAllBytes();
        }

        User user = new User(null,"jan","jan123","Jan","Kowal",Sex.MALE);
        user.setImage(image);
        em.persist(user);
        em.getTransaction().commit();
    }
}
