using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	public float attackSpeed = 1.0F;
	private bool attacking;

	private float x;
	/// <summary>
	/// Starts the firing at the given GameObject using the given skill.
	/// </summary>
	/// <param name="obj">GameObject this is shooting at.</param>
	/// <param name="ability">Ability that we want to shoot at the GameObject.</param>
	void StartFire(GameObject obj, string ability){

	}

	// Use this for initialization
	void Start () {
		x = attackSpeed;
	}
	
	// Update is called once per frame
	void Update () {

		if (attacking) {
			x += Time.deltaTime;
			if (x >= attackSpeed) {
				Debug.Log("Fired Projectile");
				x = 0.0F;
			}
		}
	}


	void OnTriggerEnter(Collider other) {
		if(other.CompareTag("Soldier")){
			//Debug.Log ("start fire");
			this.attacking = true;
		}
	}

	void OnTriggerExit(Collider other) {
		if (other.CompareTag ("Soldier")) {
			//Debug.Log ("stop fire");
			this.attacking = false;
		}
	}

	/*
	void OnCollisionEnter(Collision collision){
		foreach (ContactPoint contact in collision.contacts) {
			//Debug.DrawRay(contact.point, contact.normal, Color.white);
			//Debug.Log ("We made CONTACT!!!  FIRE AT WILL!!");
			Debug.Log (contact.otherCollider.ToString());
		}
	}*/

}
