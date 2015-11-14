using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {
	public Rigidbody2D rb;
	public GameObject planet;
	public float height = 0.3f;

	private Vector3 d;
	private float acceleration = 10f;
	private bool jump = true;
	private Vector3 desired;
	private bool reach = true;
	private float radius;
	private float theta = 0;
	private Vector3 newpos = Vector3.zero;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

	//	desired = transform.position;
	}
/*	void OnCollisionStay2D(Collision2D obs){
		jump = true;
		
	}
	void OnCollisionExit2D(Collision2D obs){
		jump = false;


	}*/

	private float nextJump; 
	private int i;
	void Update(){
		/*float magnitude = transform.localScale.x * GetComponent<CircleCollider2D> ().radius + 
			planet.transform.localScale.x * planet.GetComponent<CircleCollider2D> ().radius;
		Vector3 posDiff = planet.transform.position - transform.position;
		bool touching = Mathf.Abs (posDiff.magnitude - magnitude) < 0.1;
		if (touching) {
			jump = true;
			reach = false;
			//desired = transform.position;
		} else {
			jump = false;
		}*/
	//	move ();
	/*	if (Input.GetAxis ("Jump")==1){
			if(jump == true){
				//desired = (transform.position - posDiff)*2f;
				Debug.Log (desired);
				move ();
			}
			
		}
		//	Vector3 desired = transform.position;

		if ((transform.position - desired).magnitude < 0.1f) {
			reach = true;
		}
		if(reach == false){
		//	move ();
		}*/
	}
		// Update is called once per frame
	void FixedUpdate () {
		move ();
	/*	if (theta > 180f) {
			theta = -180f;
		}
		theta += 0.02f;
		//planet = PlayerBehaviorRings.currentRing;
		radius = transform.localScale.x * GetComponent<CircleCollider2D> ().radius + 
			planet.transform.localScale.x * planet.GetComponent<CircleCollider2D> ().radius;
		float x = radius*Mathf.Cos(theta);
		float y = radius*Mathf.Sin(theta);
		//float ang = radius*Mathf.Tan(toRad(theta));
		//where your instantiated object spawns from
		transform.position = new Vector3 (x, y, 0);
		//myObj.transform.rotation = Quaternion.AngleAxis(toDeg (ang), Vector3.forward);

*/
		Vector3 posDiff = planet.transform.position - transform.position;
/*
		float magnitude = transform.localScale.x * GetComponent<CircleCollider2D> ().radius + 
			planet.transform.localScale.x * planet.GetComponent<CircleCollider2D> ().radius;
		bool touching = Mathf.Abs (posDiff.magnitude - magnitude) < 0.1;
		if (touching) {
			jump = true;
		} else {
			jump = false;
		}
		Vector3 perpendicular = Quaternion.Euler(0,0,0)* new Vector3 (-posDiff.y, posDiff.x, posDiff.z);
		rb.velocity = new Vector2(perpendicular.x, perpendicular.y).normalized * 5;
		//if (jump == false) {rb.AddForce (posDiff.normalized * acceleration);}*/
	//	rb.AddForce(posDiff.normalized * acceleration);
		//desired = transform.position;
	/*
		Vector3 n = Quaternion.Euler (0, 0, -30) * -posDiff;
		if (Input.GetAxis ("Jump")==1){
			if(jump == true){
				//desired = (transform.position - posDiff)*0.7f;
				rb.velocity = new Vector2(n.x, n.y) * 10;

				//move ();
			}

			
		}
		//if (jump == true) {
		//	transform.position = Vector3.Lerp (transform.position, desired, 5);
		//}

		//rb.AddForce (perpendicular.normalized * 5);*/
	}

	void move(){
		Debug.Log (jump);
		Vector3 posDiff = planet.transform.position - transform.position;
		Vector3 newpos = new Vector3(0,0,0);
		if (Input.GetAxis ("Jump") == 1) {
			if (jump == true) {
				//Vector3 n = Quaternion.Euler (0, 0, 0) * -posDiff;
				//rb.velocity += new Vector2(n.x, n.y) * 0.1f;
				newpos = -posDiff.normalized*height;// (transform.position - posDiff)*2f;
				jump = false;
				}
			}
		if ((transform.localPosition - newpos).magnitude < 1f) {
			newpos = Vector3.zero;
		}
		if(transform.localPosition.magnitude <1f){
				jump = true;

			}
			
		//transform.localPosition += newpos*0.1f;
		transform.localPosition = Vector3.Lerp (transform.localPosition, newpos, Time.deltaTime*3f);
//		Vector3 posDiff = planet.transform.position - transform.position;
//
//
//		transform.position = Vector3.Lerp (transform.position, desired, Time.deltaTime*5);
//

//		//rb.AddForce(new Vector2(n.x,n.y)*100);
//
//	}
//
////	void OnCollisionEnter2D(Collision obs){
////		if (obs.gameObject.name.Contains ("Obstacle")) {
////			if (this.GetComponent<Renderer> ().material.color == obs.gameObject.GetComponent<Renderer> ().material.color) {
////				obs.gameObject.GetComponent<Collider2D>().enabled=false;
////				obs.gameObject.GetComponent<Renderer>().material.color = Color.black;
////			} 
////			else {
////				Destroy (this.gameObject);
////			}
////		}
	}
}