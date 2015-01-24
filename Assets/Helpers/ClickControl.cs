using UnityEngine;
using System.Collections;

public class ClickControl : MonoBehaviour
{

    public Vector3 LastGoodPoint { get; set; }

    bool valid = false;
    public bool validPoint { get { return valid; } private set{ valid = value;} }
    public GameObject thingClicked { get; set; }
    public string limitToLayerNamed;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit infoOut;

        //limit to one layer
        int layermaskNum = 0;
        if(!string.IsNullOrEmpty(limitToLayerNamed))
        {
            layermaskNum = LayerMask.NameToLayer(limitToLayerNamed);
        }
        int layerMask = 1 << layermaskNum;

        if (Physics.Raycast(ray, out infoOut, 500, layerMask))
        {
            LastGoodPoint = infoOut.point;
            thingClicked = infoOut.collider.gameObject;
            valid = true;
        }
        else
        {
            valid = false;
        }
    }
}
