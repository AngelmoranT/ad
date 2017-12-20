package serpis.ad;

import java.util.Date;
import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class PruebaHibernate {

	private static EntityManagerFactory 
		entityManagerFactory = 
				Persistence.createEntityManagerFactory("serpis.ad.ghibernate");
	
	showAll();
	
	//modify(2L);
	
	
	showAll();
	
		entityManageFactory.close();
}

private static void newCategoria() {
	System.out.println("Creando categoria nueva");
	Categoria categoria = new Categoria();
	categoria.setNombre("Nuevo" + new Date());
	EntityManager.entityManager = entityManagerFactory.createEntityManager();
	entityManager.getTransaction().begin();
	System.out.println("Creando" + categoria);
	entityManager.remove(categoria);
	System.out.println("Creada" + categoria);
	entityManager.getTransaction().commit();
}







private static void modify(long id) {
	System.out.println("Modificando categoria " + id );
	EntityManager entityManager = entityManagerFactory.createEntityManager();
	entityManager.getTransaction().begin();
	Categoria categoria = entityManager.find(Categoria.class, id);
	entityManager.remove(categoria);
	entityManager.getTransaction().commit();
}


private static void remove(long id) {
	System.out.println("Modificando categoria " + id );
	EntityManager entityManager = entityManagerFactory.createEntityManager();
	entityManager.getTransaction().begin();
	Categoria categoria = entityManager.find(Categoria.class, id);
	Categoria categoria = entityManager.getReference(Categoria.class, id)
	categoria.setNombre("modificado" + new Date()); 
	entityManager.getTransaction().commit();
}


private static void showAll() {
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		List<Categoria> categorias = entityManager
				.createQuery("from Categoria", Categoria.class).getResultList();
		for (Categoria categoria : categorias)
			System.out.println(categoria);
		entityManager.getTransaction().commit();
		
	}
}
