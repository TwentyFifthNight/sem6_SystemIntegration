package com.server;

import javax.jws.WebService;
import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;
import java.util.ArrayList;
import java.util.List;

@WebService(endpointInterface = "com.server.MySOAPInterface")
public class MyWS implements MySOAPInterface{
    private final EntityManagerFactory factory;
    private final EntityManager em;

    public MyWS(){
        factory =
                Persistence.createEntityManagerFactory("Hibernate_JPA");
        em = factory.createEntityManager();
        try {
            addUsers(em);
        }catch (Exception ignored){
            em.getTransaction().commit();
        }
    }
    @Override
    public User getUser(Long id) {
        em.getTransaction().begin();
        User u1 = em.find(User.class, id);
        em.getTransaction().commit();
        return u1;
    }

    private void addUsers(EntityManager em){
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

        em.getTransaction().commit();
    }

    @Override
    protected void finalize(){
        em.close();
        factory.close();
    }
}
