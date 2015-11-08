using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerColor : MonoBehaviour {

	public static Color[] colors = new Color[9];


	void Start(){
		colors[0] = Color.blue;
		colors[1] = Color.red;
		colors[2] = Color.green;
		colors[3] = Color.black;
		colors[4] = Color.yellow;
		colors[5] = Color.cyan;
		colors[6] = Color.grey;
		colors[7] = Color.white;
		colors[8] = Color.magenta;
	}

	// Update is called once per frame
	void Update () {
		ColorChange();
	}
	

	void ColorChange(){
		if (Time.time%2 <= 0.1) {
			Material m = GetComponent<Renderer>().material;
			int x = Random.Range(0, 8);
			m.color = colors[x];
		}
	}
}
