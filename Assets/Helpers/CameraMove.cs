using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]
public class CameraMove : MonoBehaviour {

    public float scrollRate = -5.0f;
    public float borderEdge = 30;

    //public Transform LeftBound;
    //public Transform RightBound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        //right edge
        if(Input.mousePosition.x > Screen.width - borderEdge )
        {
            var percent = ((Input.mousePosition.x - (Screen.width - borderEdge))/ borderEdge);
            if (Input.mousePosition.x > Screen.width)
                percent = 1;
            var newPos =new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + scrollRate * percent * Time.deltaTime);

            this.transform.position = newPos;
        }

        //left edge
        if (Input.mousePosition.x <  borderEdge )
        {
            var percent = ((Input.mousePosition.x) / borderEdge);
            if (Input.mousePosition.x <= 0)
                percent = 1;
            var newPos = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + -scrollRate * percent * Time.deltaTime);
            
            this.transform.position = newPos;
        }
	}
}
