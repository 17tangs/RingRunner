using UnityEngine;
using System.Collections;

public class PlayerColor : MonoBehaviour {

	GenerateObstacles.c;
	
	IEnumerator Start(){
		c = GetComponent<GenerateObstacles>();
	}

	// Update is called once per frame
	void Update () {
		this.GetComponent<Renderer>().material.color = c [Random.Range (0, c.Count())];
		WaitForSeconds (10);
	}
}
