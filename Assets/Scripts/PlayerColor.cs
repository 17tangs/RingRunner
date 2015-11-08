using UnityEngine;
using System.Collections;

public class PlayerColor : MonoBehaviour {

	GenerateObstacles colors,numToSpawn;
	
	IEnumerator Start(){
		colors = GetComponent<GenerateObstacles>();
		float numToSpawn = Get<GenerateObstacles>();
		yield return new WaitForEndOfFrame();
	}

	// Update is called once per frame
	void Update () {
		this.GetComponent<Renderer>().material.color = colors[Random.Range (0f, numToSpawn)];
		WaitForSeconds (10);
	}
}
