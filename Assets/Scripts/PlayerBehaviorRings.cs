using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {
	public Rigidbody2D rb;
	public GameObject planet;
	public GameObject currentRing;
	public GameObject ring1;
	public GameObject ring2;
	
	
	private float acceleration = 9.8f;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		currentRing = ring1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.Space)) {
			Debug.Log (5);
			//Vector3 op = transform.position;
			//transform.position = new Vector3(op.x, op.y+0.5f, op.z);
		}
		//transform.Translate (-Vector3.right * 5 * Time.deltaTime);
		
		Vector3 posDiff = planet.transform.position - transform.position;
		Vector3 perpendicular = new Vector3 (-posDiff.y, posDiff.x, posDiff.z);
		
		rb.velocity = perpendicular.normalized * 5;
		
		rb.AddForce(posDiff.normalized * acceleration);
		//rb.AddForce (perpendicular.normalized * 5);
	}
	
	void OnCollisionEnter2D(Collision2D obs){
		if (obs.gameObject.name.Contains("Gap")) {
			Debug.Log ("gap");
			currentRing.gameObject.GetComponent<Collider2D>().enabled=false;
			currentRing=ring2;
		}
	}
	
}