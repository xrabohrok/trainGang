using UnityEngine;
using System.Collections;

[RequireComponent(typeof(MeshRenderer))]
public class ScrollingTexture : MonoBehaviour {

    public Vector2 speed;

	// Use this for initialization
    MeshRenderer rendererthing;
	void Start () {
        rendererthing = this.GetComponent<MeshRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
        rendererthing.material.SetTextureOffset("_MainTex", renderer.material.GetTextureOffset("_MainTex") + Time.deltaTime * speed);
	}
}
