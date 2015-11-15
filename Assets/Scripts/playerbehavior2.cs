using UnityEngine;
using System.Collections;

public class playerbehavior2 : MonoBehaviour {
	public Rigidbody2D rb;
	public GameObject planet;
	private Vector3 d;
	private float acceleration = 150f;
	private bool jump = true;
	private Vector3 desired;
	private bool reach = true;
	private float radius;
	private float theta = 0;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		planet = GameObject.Find ("Ring4");
		Debug.Log (planet);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey ("1")) {
			planet = GameObject.Find ("Ring1");
		}
		else if(Input.GetKey ("2")) {
			planet = GameObject.Find ("Ring2");
		}
		else if(Input.GetKey ("3")) {
			planet = GameObject.Find ("Ring3");
		}
		else if(Input.GetKey ("4")) {
			planet = GameObject.Find ("Ring4");
		}
	}

	void FixedUpdate () {
		//move ();
		Vector3 posDiff = planet.transform.position - transform.position;
		//rb.AddForce(posDiff.normalized * acceleration);
		if (theta > 180f) {
			theta = -180f;
		}
		theta += 0.02f;
		//planet = PlayerBehaviorRings.currentRing;
		radius = GameObject.Find("Player").transform.localScale.x * GameObject.Find ("Player").GetComponent<CircleCollider2D> ().radius + 
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
			//if (jump == true) {
				Vector3 n = Quaternion.Euler (0, 0, 0) * -posDiff;
				rb.velocity += new Vector2(n.x, n.y) * 2f;
				//newpos = -posDiff.normalized*height;// (transform.position - posDiff)*2f;
			//	jump = false;
			//}
		}
	}
}
