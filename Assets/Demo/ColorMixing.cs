using UnityEngine;
using System.Collections;
using HueSaturationValueUtils;
public class ColorMixing : MonoBehaviour {

	private float v = 0;
	public Color color1;
	public Color color2;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		ColorHSV colorHSV1 = color1.toHSV ();
		ColorHSV colorHSV2 =  color2.toHSV ();

		gameObject.GetComponent<Renderer> ().material.color = new ColorHSV ((colorHSV1.h + colorHSV2.h) * 0.5f, 
		                                                                    (colorHSV1.s + colorHSV2.s) * 0.5f, 
		                                                                    (colorHSV1.v + colorHSV2.v) * 0.5f); 

	}
}
