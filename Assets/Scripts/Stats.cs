using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	public int damage = 1;
	public int health = 1;

	private int curHealth;
	private bool dead = false;

	// Use this for initialization
	void Start () {
		this.curHealth = health;
	}
	
	// Update is called once per frame
	void Update () {
		if(dead){
			//TODO: Play death Effects
			Destroy (this.gameObject);
		}
	}
	
	public void hit(int dmg){
		this.curHealth = this.curHealth - dmg;
		if (this.curHealth <= 0) {
			dead = true;
		}
		Debug.Log ("Damage: " + dmg + " curHealth: " + this.curHealth);
	}
}
