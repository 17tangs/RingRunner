using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Scores : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		GameObject p = GameObject.Find ("P(Clone)");
		GetComponent<Text> ().text = p.GetComponent<PlayerRotation> ().GetRevolution().ToString();
		
	}
}
