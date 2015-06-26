using UnityEngine;
using System.Collections;
using HueSaturationValueUtils;
public class Hue : MonoBehaviour {


	private ColorHSV colorHSV = Color.red.toHSV();
	private float h = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		h += 0.001f;
		if (h > 1f) {
			h = 0;
		}
		colorHSV = new ColorHSV(h, colorHSV.s, colorHSV.v);
		gameObject.GetComponent<Renderer> ().material.color = colorHSV;

	}
}
