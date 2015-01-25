using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour, Ishootable {

	public float attackSpeed = 1.0F;
	public float projectileSpeed = 1.0F;
    public GameObject projectile;

	private bool attacking;
	private GameObject target;
	


	private float timeSinceLastShot;

	// Use this for initialization
	void Start () {
        timeSinceLastShot = attackSpeed;
	}
	
	// Update is called once per frame
	void Update () 
    {
        timeSinceLastShot += Time.deltaTime;

		if (attacking) 
        {
            if (timeSinceLastShot >= attackSpeed) 
            {
                var shot = (GameObject)Instantiate(this.projectile, this.transform.position, this.transform.rotation);
                var projectile = shot.GetComponent<projectile>();
                projectile.ttl = 5.0F;
                projectile.target = this.target;
                projectile.speed = this.projectileSpeed;
                projectile.damage = this.GetComponent<Stats>().damage;
                projectile.shooter = this.gameObject;
                projectile.shooterTag = this.tag;
                timeSinceLastShot = 0.0F;
			}
		}
	}


    public void takeDamage(int damage)
    { }

}
