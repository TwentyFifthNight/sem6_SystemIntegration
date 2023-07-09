package com.soap;

import com.soap.User.User;
import com.soap.User.Voivodeship;
import de.mkammerer.argon2.Argon2;
import de.mkammerer.argon2.Argon2Factory;

import javax.jws.WebService;
import javax.management.relation.Role;
import javax.persistence.*;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@WebService(endpointInterface = "com.soap.SOAPInterface")
public class WS implements SOAPInterface {
    private final String user;
    private final String password;

    private EntityManagerFactory getEntityManagerFactory() {
        return Persistence.createEntityManagerFactory( "Users_JPA",
                getProperties() );
    }

    private Map getProperties(){
        Map result = new HashMap();
        if(user != null)
            result.put("javax.persistence.jdbc.user", user);
        if(password != null)
            result.put( "javax.persistence.jdbc.password", password );
        return result;
    }

    public WS(String ...user){
        this.user = user.length > 0 ? user[0] : null;
        this.password = user.length > 1 ? user[1] : null;
    }

    @Override
    public String login(String username, String password) {
        EntityManagerFactory factory = getEntityManagerFactory();
        EntityManager em = factory.createEntityManager();

        em.getTransaction().begin();
        try {
            Query query = em.createQuery("Select u FROM User u WHERE u.username = '" + username + "'");
            List<User> users = query.getResultList();

            if (users.size() != 1)
                return "";

            Argon2 argon2 = Argon2Factory.create(64, 64);
            if (!argon2.verify(users.get(0).getPassword(), password.toCharArray()))
                return "";

            return users.get(0).toString();
        }catch (Exception e){
            e.printStackTrace();
        }finally {
            em.getTransaction().commit();
            em.close();
            factory.close();
        }
        return "";
    }

    @Override
    public Boolean registerUser(String username, String password, String voivodeshipName) {
        EntityManagerFactory factory = getEntityManagerFactory();
        EntityManager em = factory.createEntityManager();

        em.getTransaction().begin();
        try {
            Query query = em.createQuery("Select u FROM User u WHERE u.username = '" + username + "'");

            int userCount = query.getResultList().size();
            if (userCount > 0)
                return false;

            Argon2 argon2 = Argon2Factory.create(64, 64);
            String hash;
            try {
                hash = argon2.hash(40, 65536, 4, password.toCharArray());
            } finally {
                argon2.wipeArray(password.toCharArray());
            }

            User user = new User(null, username, hash);

            query = em.createQuery("Select v FROM Voivodeship v WHERE v.name = '" + voivodeshipName + "'");
            Voivodeship voivoivodeship = (Voivodeship) query.getResultList().get(0);

            user.setVoivodeship(voivoivodeship);

            em.persist(user);

            return true;
        }catch (Exception e){
            e.printStackTrace();
        }finally {
            em.getTransaction().commit();
            em.close();
            factory.close();
        }
        return false;
    }
}