using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kiwi : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 p = this.transform.localPosition;
		p.z += Time.deltaTime * 30f;
		this.transform.localPosition = p;
	}
}
