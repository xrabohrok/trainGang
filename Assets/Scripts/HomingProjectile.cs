using UnityEngine;
using System.Collections;

public class HomingProjectile : MonoBehaviour {

	// Time to live in seconds
	public float ttl = 1.0F;
	public float speed = 1.0F;
	public GameObject target;
	public int damage = 1;
	
	//This is the distance that's allowed for a collision.
	public float distanceThreshold = 0.5F;
	
	private float startTime = Time.time;
	private Vector3 startMarker;
	private float journeyLength;
	
	
	// Use this for initialization
	void Start () {
		if (this.target != null) {
			startTime = Time.time;
			startMarker = this.transform.position;
			journeyLength = Vector3.Distance (startMarker, this.target.transform.position);
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
		
		//move to the target.
		if(this.target != null && this.transform.position != this.target.transform.position){
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			this.transform.position = Vector3.Lerp (startMarker, target.transform.position, fracJourney);
		}
		else {
			// we reached the end.
			Destroy (this.gameObject);
		}
	}
}
