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

	void OnCollisionEnter2D(Collision2D obs){
		Debug.Log ("collision");

		if (obs.gameObject.name.Contains("Gap")) {
			Debug.Log ("gap");
			currentRing.gameObject.GetComponent<Collider2D>().enabled=false;
			currentRing=ring2;
		}
	}
	
}