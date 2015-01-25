using UnityEngine;
using System.Collections;


public class SoldierAI : MonoBehaviour, Ishootable {


    private bool selected = false;
    private bool onTheMove = false;
    public float speed = 1.0f;
    public float stopDist = .1f;
    Vector3 targetLocation;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if(onTheMove)
        {
            //rotate
            var newRotation = Vector3.RotateTowards(this.transform.forward, targetLocation, Mathf.PI, Mathf.PI);
            this.transform.rotation = Quaternion.LookRotation(newRotation);

            //move
            var step = speed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetLocation, step);

            //Don't get too close
            if(Vector3.Distance(this.transform.position, targetLocation) <= stopDist)
            {
                onTheMove = false;
            }
        }
	}

    public void wasSelected()
    {
        selected = true;
    }

    public void wasDeSelected()
    {
        selected = false;
    }

    public void recieveOrderTo(Vector3 location)
    {
        if (selected)
        {
            targetLocation = new Vector3(location.x, this.transform.position.y, location.z);
            onTheMove = true;
        }
    }

    void takeDamage(int damage)
    { }
}
