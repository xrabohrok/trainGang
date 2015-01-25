using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
public class ScrollingTexture : MonoBehaviour {

    public Vector2 speed;

	// Use this for initialization
    MeshRenderer renderer;
	void Start () {
        renderer = this.GetComponent<MeshRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
        renderer.material.SetTextureOffset("_MainTex", renderer.material.GetTextureOffset("_MainTex") + Time.deltaTime * speed);
	}
}
