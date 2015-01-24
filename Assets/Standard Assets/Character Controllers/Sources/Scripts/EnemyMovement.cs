using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyMovement : MonoBehaviour {

	//public ArrayList points = new ArrayList();
	public float speed = 1.0F;
	public List<Vector3> positions = new List<Vector3>();
	
	private Vector3 pos;
	private Queue<Vector3> positionIT;
	
	private float startTime;
	private float journeyLength;
	private Vector3 startMarker;
	private Vector3 endMarker;
	private bool getNextPosition;

	// Use this for initialization
	void Start () {
		positionIT = new Queue<Vector3>(positions);
		getNextPosition = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (getNextPosition && positionIT.Count>0) {
			Debug.Log ("getting next position");
			// get the next position from the position iterator.
			endMarker = positionIT.Dequeue();
			startMarker = this.transform.position;
			startTime = Time.time;
			journeyLength = Vector3.Distance(startMarker, endMarker);
			getNextPosition = false;
		}
		else if (!getNextPosition){
			Debug.Log ("moving to next position");
			// lerp to the current if there's still positions to lerp to.
			
			float distCovered = (Time.time - startTime) * speed;
			float fracJourney = distCovered / journeyLength;
			this.transform.position = Vector3.Lerp (startMarker, endMarker, fracJourney);
			if (this.transform.position == endMarker)
				getNextPosition = true;
			Debug.Log ("distCovered: " + distCovered);
			Debug.Log ("fracJourney: " + fracJourney);
		}
	}
}
