using UnityEngine;
using System.Collections;

public class PlayerBehaviorRings : MonoBehaviour {
	public static GameObject currentRing;
	public GameObject ring1;
	public GameObject ring2;
	public GameObject ring3;
	public GameObject ring4;

	void Start () {
		currentRing = ring1;
	}

	void Update () {
	}

	void OnTriggerEnter2D(Collider2D obs){
		if (obs.gameObject.name.Contains(ringNow())&&obs.gameObject.name.Contains("Gap")){
			Debug.Log ("gap");
			currentRing.gameObject.GetComponent<Collider2D>().enabled=false;
			currentRing.gameObject.GetComponent<SpriteRenderer>().enabled = false;
			if(currentRing.name.Substring(4)!="1"){
				GameObject pad = GameObject.Find("RaisePad"+currentRing.name.Substring (4));
				pad.GetComponent<SpriteRenderer>().enabled = false;
			}
			//Debug.Log (pad.name);
			//currentRing.gameObject.GetComponentsInChildren<SpriteRenderer>()[2].enabled = false;
			currentRing=nextRing();
		}
		if (obs.gameObject.name.Contains(ringNow())&&obs.gameObject.name.Contains("RaisePad")){
			Debug.Log ("raise");
			currentRing=prevRing();
			currentRing.gameObject.GetComponent<Collider2D>().enabled=true;
			currentRing.gameObject.GetComponent<SpriteRenderer>().enabled = true;
			if(currentRing.name.Substring(4)!="1"){
				GameObject pad = GameObject.Find("RaisePad"+currentRing.name.Substring (4));
				pad.GetComponent<SpriteRenderer>().enabled = true;
			}
		}
	}

	string ringNow(){
		return currentRing.gameObject.name.Substring (4);
	}

	GameObject nextRing(){
		if (currentRing == ring1)
			return ring2;
		else if (currentRing == ring2)
			return ring3;
		else if (currentRing == ring3)
			return ring4;
		return currentRing;
	}

	GameObject prevRing(){
		if (currentRing == ring2)
			return ring1;
		else if (currentRing == ring3)
			return ring2;
		else if (currentRing == ring4)
			return ring3;
		return currentRing;
	}
}