using UnityEngine;
using System.Collections;

public class Obstacles : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	}

	void OnCollisionEnter2D(Collision2D obs){
		if (obs.gameObject.name.Contains ("Obstacle")) {
			if (this.GetComponent<Renderer> ().material.color == obs.gameObject.GetComponent<Renderer> ().material.color) {
				obs.gameObject.GetComponent<Renderer>().material.color = new Color(255, 215, 0);

	
			}
		}
	}



}

