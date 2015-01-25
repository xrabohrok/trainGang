using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour, Ishootable {

	public float attackSpeed = 1.0F;
	public float projectileSpeed = 1.0F;

	private bool attacking;
	private GameObject target;
	public GameObject projectile;


	private float x;

	// Use this for initialization
	void Start () {
		x = attackSpeed;
	}
	
	// Update is called once per frame
	void Update () {
		x += Time.deltaTime;

		if (attacking) {
			if (x >= attackSpeed) {
                var shot = (GameObject)Instantiate(projectile, this.transform.position, this.transform.rotation);
                var projectile = shot.GetComponent<projectile>();
                projectile.ttl = 5.0F;
                projectile.target = this.target;
                projectile.speed = this.projectileSpeed;
                projectile.damage = this.GetComponent<Stats>().damage;
                projectile.shooter = this.gameObject;
                projectile.shooterTag = this.tag;
				x = 0.0F;
			}
		}
	}


	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Soldier")){
			//Debug.Log ("start fire");
			this.attacking = true;
			this.target = other.gameObject;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag ("Soldier")) {
			//Debug.Log ("stop fire");
			this.attacking = false;
			this.target = null;
		}
	}

    void takeDamage();

}
