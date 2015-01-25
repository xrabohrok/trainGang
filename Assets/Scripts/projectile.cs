using UnityEngine;
using System.Collections.Generic;

public class projectile : MonoBehaviour {

	// Time to live in seconds
	public float ttl = 1.0F;
	public float speed = 1.0F;
	public GameObject target;
    public GameObject shooter;
	public int damage = 1;
    public string shooterTag;

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

        if(collision.gameObject.tag != shooterTag)
        {
            if(collision.gameObject.layer == LayerMask.NameToLayer("Enemies"))
            {
                collision.gameObject.GetComponent<EnemyController>().takeDamage(damage);
                die();
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

    void die()
    {
        //maybe particles? //score? //money?
        GameObject.Destroy(this);
    }
}
