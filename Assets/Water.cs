using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var p = this.transform.localPosition;

		if (Input.GetMouseButtonDown (0)) {
			p.y = 0;
		} else {
			p.y += Time.deltaTime * .4f;

		}
		this.transform.localPosition = p;
	}
}
