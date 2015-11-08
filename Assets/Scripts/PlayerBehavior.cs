using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {
	public Rigidbody2D rb;
	public GameObject planet;
	private Vector3 d;
	private float acceleration = 150f;
	private bool jump = true;
	private Vector3 desired;
	private bool reach = true;
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
	/*void Update(){
		float magnitude = transform.localScale.x * GetComponent<CircleCollider2D> ().radius + 
			planet.transform.localScale.x * planet.GetComponent<CircleCollider2D> ().radius;
		Vector3 posDiff = planet.transform.position - transform.position;
		bool touching = Mathf.Abs (posDiff.magnitude - magnitude) < 0.1;
		if (touching) {
			jump = true;
			reach = false;
			//desired = transform.position;
		} else {
			jump = false;
		}

		if (Input.GetAxis ("Jump")==1){
			if(jump == true){
				desired = (transform.position - posDiff)*2f;
				Debug.Log (desired);
				//move ();
			}
			
		}
		//	Vector3 desired = transform.position;

		if ((transform.position - desired).magnitude < 0.1f) {
			reach = true;
		}
		if(reach == false){
			move ();
		}
	}*/
		// Update is called once per frame
	void FixedUpdate () {
		planet = PlayerBehaviorRings.currentRing;

		Vector3 posDiff = planet.transform.position - transform.position;

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
		//if (jump == false) {rb.AddForce (posDiff.normalized * acceleration);}
		rb.AddForce(posDiff.normalized * acceleration);
		//desired = transform.position;
	
		Vector3 n = Quaternion.Euler (0, 0, -30) * -posDiff;
		if (Input.GetAxis ("Jump")==1){
			if(jump == true){
				//desired = (transform.position - posDiff)*0.7f;
				Debug.Log ("new: " + new Vector2(n.x,n.y));
				rb.velocity = new Vector2(n.x, n.y) * 10;

				//move ();
			}

			
		}
		Debug.Log (rb.velocity);
		//if (jump == true) {
		//	transform.position = Vector3.Lerp (transform.position, desired, 5);
		//}

		//rb.AddForce (perpendicular.normalized * 5);*/
	}
	void move(){
		Vector3 posDiff = planet.transform.position - transform.position;


		//transform.position = Vector3.Lerp (transform.position, desired, Time.deltaTime*5);

		//Vector3 posDiff = planet.transform.position - transform.position;
		Vector3 n = Quaternion.Euler (0, 0, 0) * -posDiff;
		//transform.position = Vector3.Lerp(transform.position, (transform.position - posDiff)*0.6f, 30);
		rb.velocity += new Vector2(n.x, n.y) * 10;
		//rb.AddForce(new Vector2(n.x,n.y)*100);

	}

	void OnCollisionEnter2D(Collision2D obs){
		if (obs.gameObject.name.Contains ("Obstacle")) {
			if (this.GetComponent<Renderer> ().material.color == obs.gameObject.GetComponent<Renderer> ().material.color) {
				rb.velocity = -1*rb.velocity;
//				obs.gameObject.GetComponent<Renderer>().material.color = new Color(255, 215, 0);
			} 
//			else {
//				Destroy (this.gameObject);
//			}
		}
	}
}