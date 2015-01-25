using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour {

	// Time to live in seconds
	public float ttl = 1.0F;
	public float speed = 1.0F;
	public GameObject target;
	public int damage = 1;

	//This is the distance that's allowed for a collision.
	public float distanceThreshold = 0.5F;

	private float startTime = Time.time;
	private Vector3 startMarker;
	private Vector3 endMarker;
	private float journeyLength;


	// Use this for initialization
	void Start () {
		if (this.target != null) {
			startTime = Time.time;
			startMarker = this.transform.position;
			endMarker = target.transform.position;
			journeyLength = Vector3.Distance (startMarker, endMarker);
		}
	}

	void OnCollisionEnter(Collision collision) {
		foreach (ContactPoint contact in collision.contacts) {
			if(this.target != null && contact.otherCollider.CompareTag(this.target.tag)){
				contact.otherCollider.gameObject.GetComponent<Stats>().hit (this.damage);
				Destroy (this.gameObject);
			}
		}
	}
			
			// Update is called once per frame
	void Update () {
		//Calculate TTL
		if (Time.time - startTime >= ttl) {
			Destroy (this.gameObject);
		}

		// 
		//if (Vector3.Distance (this.transform.position, target.transform.position) <= distanceThreshold) {
			//this.target.hit(damage);
			// TODO: Special Effects
		//	Destroy (this.gameObject);
		//}

		//move to the target.
		if(this.transform.position != endMarker){
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			this.transform.position = Vector3.Lerp (startMarker, endMarker, fracJourney);
		}
		else {
			// we reached the end.
			Destroy (this.gameObject);
		}
	}
}
