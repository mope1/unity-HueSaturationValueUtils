using UnityEngine;
using System.Collections;
using HueSaturationValueUtils;
public class Value : MonoBehaviour {


	private ColorHSV colorHSV = Color.red.toHSV();
	private float v = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		v += 0.001f;
		if (v > 1f) {
			v = 0;
		}
		colorHSV = new ColorHSV(colorHSV.h, colorHSV.s, v);
		gameObject.GetComponent<Renderer> ().material.color = colorHSV;

	}
}
