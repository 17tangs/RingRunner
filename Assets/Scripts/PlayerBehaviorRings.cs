using UnityEngine;
using System.Collections;

public class PlayerBehaviorRings : MonoBehaviour {
	public Rigidbody2D rb;
	public GameObject planet;
	public static GameObject currentRing;
	public GameObject ring1;
	public GameObject ring2;
	public GameObject ring3;

	void Start () {
		currentRing = ring1;
	}

	void Update () {
		Debug.Log (currentRing.gameObject.name);
	}

	void OnTriggerEnter2D(Collider2D obs){
		if (obs.gameObject.name.Contains(ringNow())&&obs.gameObject.name.Contains("Gap")){
			Debug.Log ("gap");
			currentRing.gameObject.GetComponent<Collider2D>().enabled=false;
			currentRing=nextRing();
		}
		if (obs.gameObject.name.Contains(ringNow())&&obs.gameObject.name.Contains("RaisePad")){
			Debug.Log ("raise");
			currentRing=prevRing();
			currentRing.gameObject.GetComponent<Collider2D>().enabled=true;
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
		return currentRing;
	}

	GameObject prevRing(){
		if (currentRing == ring2)
			return ring1;
		else if (currentRing == ring3)
			return ring2;
		return currentRing;
	}
}