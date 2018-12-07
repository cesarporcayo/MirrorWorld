using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanging : MonoBehaviour {

	private Material mat;
	public Color start;
	public Color finish;
	public float speed;

	// Use this for initialization
	void Start () {
		mat = GetComponent<MeshRenderer>().sharedMaterial;
	}
	
	// Update is called once per frame
	void Update () {
		mat.SetColor("_Color", Color.Lerp(start,finish,Mathf.Sin(Time.time * speed)));
	}
}
