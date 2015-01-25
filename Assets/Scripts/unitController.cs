using UnityEngine;
using System.Collections;

public class unitController : MonoBehaviour {

	public float attackSpeed = 1.0F;
	public float projectileSpeed = 1.0F;
	public GameObject projectile;
	public float range = 7.0f;

	private bool attacking;
	private GameObject target;
	private float x;


	// Use this for initialization
	void Start () {
		x = attackSpeed;
	}
	
	// Update is called once per frame
	void Update () {

		//Check for enemies to attack.
		GameObject obj = FindClosestEnemy ();
		Debug.Log (obj.name.ToString ());


		if (!obj) {
			this.attacking = true;
			this.target = obj;
		}
		else{
			this.attacking = false;
			this.target = null;
		}

		x += Time.deltaTime;
		
		if (attacking) {
			if (x >= attackSpeed) {
				var shot = (GameObject) Instantiate (projectile, this.transform.position, this.transform.rotation);
				shot.GetComponent<HomingProjectile> ().ttl = 5.0F; 
				shot.GetComponent<HomingProjectile>().target = this.target;
				shot.GetComponent<HomingProjectile>().speed = this.projectileSpeed;
				shot.GetComponent<HomingProjectile>().damage = this.GetComponent<Stats>().damage;
				x = 0.0F;
			}
		}
	}

	//returns the closest obj with given tag.
	GameObject FindClosestEnemy() {
		GameObject[] gos;
		gos = GameObject.FindGameObjectsWithTag("Enemy");
		GameObject closest = null;
		float distance = Mathf.Infinity;
		Vector3 position = transform.position;
		foreach (GameObject go in gos) {
			Vector3 diff = go.transform.position - position;
			float curDistance = diff.sqrMagnitude;
			if (curDistance < distance) {
				closest = go;
				distance = curDistance;
			}
		}
		return closest;
	}

	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Enemy")){
			//Debug.Log ("start fire");
			this.attacking = true;
			this.target = other.gameObject;
		}
	}
	
	void OnTriggerExit(Collider other) {
		if (other.CompareTag ("Enemy")) {
			//Debug.Log ("stop fire");
			this.attacking = false;
			this.target = null;
		}
	}
}
