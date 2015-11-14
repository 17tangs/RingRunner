using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour {
	public Rigidbody2D rb;
	public GameObject planet;
	private Vector3 d;
	private float acceleration = 100f;
	private bool jump = true;
	private Vector3 desired;
	private bool reach = true;
	private float radius;
	private float theta = 0;
	// Use this for initialization
	void Start () {
		radius = transform.localScale.x * GetComponent<CircleCollider2D> ().radius + 
			planet.transform.localScale.x * planet.GetComponent<CircleCollider2D> ().radius;
		rb = GetComponent<Rigidbody2D> ();
		transform.position = new Vector3 (0, radius, 0);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void FixedUpdate () {
		move ();
		Vector3 posDiff = planet.transform.position - transform.position;
		
		rb.AddForce(posDiff.normalized * acceleration);
		if (theta > 180f) {
			theta = -180f;
		}
		theta += 0.02f;
		//planet = PlayerBehaviorRings.currentRing;
		radius = transform.localScale.x * GetComponent<CircleCollider2D> ().radius + 
			planet.transform.localScale.x * planet.GetComponent<CircleCollider2D> ().radius;
		//Debug.Log (radius);
		float x = radius * Mathf.Cos (theta);
		float y = radius * Mathf.Sin (theta);
		//Debug.Log (new Vector2(x,y));
		//float ang = radius*Mathf.Tan(toRad(theta));
		//where your instantiated object spawns from
		transform.position = new Vector3 (x, y, 0);
	}
	void move(){
		Vector3 posDiff = planet.transform.position - transform.position;
		if (Input.GetAxis ("Jump") == 1) {
			if (jump == true) {
				Vector3 n = Quaternion.Euler (0, 0, 0) * -posDiff;
				rb.velocity += new Vector2(n.x, n.y) * 5f;
			//newpos = -posDiff.normalized*height;// (transform.position - posDiff)*2f;
				jump = false;
			}
		}
		if (transform.position.magnitude - radius < 0.1f) {
			jump = true;
		}
	}
}
