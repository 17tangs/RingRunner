using UnityEngine;
using System.Collections;

public class PlayerBehaviorRings : MonoBehaviour {
	public Rigidbody2D rb;
	public GameObject planet;
	public GameObject currentRing;
	public GameObject ring1;
	public GameObject ring2;

	void Start () {
		currentRing = ring1;
	}

	void Update () {
		Debug.Log (currentRing.gameObject.name);
	}

	void OnTriggerEnter2D(Collider2D obs){
		if (obs.gameObject.name.Contains(ringNow())){
			Debug.Log ("gap");
			currentRing.gameObject.GetComponent<Collider2D>().enabled=false;
			currentRing=ring2;
		}
	}

	string ringNow(){
		return "Gap"+currentRing.gameObject.name.Substring (4);
	}
}