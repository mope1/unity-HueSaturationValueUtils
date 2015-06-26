using UnityEngine;
using System.Collections;
using HueSaturationValueUtils;
public class Saturation : MonoBehaviour {


	private ColorHSV colorHSV = Color.red.toHSV();
	private float s = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		s += 0.001f;
		if (s > 1f) {
			s = 0;
		}
		colorHSV = new ColorHSV(colorHSV.h, s, colorHSV.v);
		gameObject.GetComponent<Renderer> ().material.color = colorHSV;

	}
}
