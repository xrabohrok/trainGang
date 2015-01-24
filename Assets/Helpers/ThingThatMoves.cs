using UnityEngine;
using System.Collections;

public class ThingThatMoves : MonoBehaviour {

    public Vector3 directionToMove;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        this.transform.position = this.transform.position + directionToMove * Time.deltaTime;
	}
}
