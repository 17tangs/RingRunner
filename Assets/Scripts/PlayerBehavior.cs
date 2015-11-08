using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {
	public Rigidbody2D rb;
	public GameObject planet;
	private float acceleration = 150f;
	private bool jump = false;
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		
	}
	void OnCollisionStay2D(Collision2D obs){
		jump = true;
		
	}
	void OnCollisionExit2D(Collision2D obs){
		if(jump == true){
			jump = false;
		}

	}
	void Update(){
	}
	private float nextJump; 
	private int i;
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 posDiff = planet.transform.position - transform.position;
		Vector3 perpendicular = new Vector3 (-posDiff.y, posDiff.x, posDiff.z);
		rb.velocity = new Vector2(perpendicular.x, perpendicular.y).normalized * 5;
		rb.AddForce(posDiff.normalized * acceleration);
		Vector3 n = Quaternion.Euler (0, 0, -30) * -posDiff;
		Debug.Log (Input.GetKey (KeyCode.Space));
		if (Input.GetKeyDown (KeyCode.Space)){
			if(jump == true){
				move ();
			}

			
		}
		//rb.AddForce (perpendicular.normalized * 5);
	}
	void move(){
		Vector3 posDiff = planet.transform.position - transform.position;
		Vector3 n = -posDiff;//Quaternion.Euler (0, 0, -30) * -posDiff;
//		rb.AddForce (n*10);
		rb.velocity += new Vector2(n.x, n.y) * 10;


	}
}