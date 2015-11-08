using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerColor : MonoBehaviour {

	public List<Color> colors;
	public float numToSpawn = 8;

	IEnumerator Start(){
		colors = GenerateObstacles.colors;
		yield return new WaitForEndOfFrame();
	}

	// Update is called once per frame
	void Update () {
		this.GetComponent<Renderer>().material.color = colors[1];
	}
}
