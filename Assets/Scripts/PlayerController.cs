using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public GameObject planet;
	public float height = 3f;
	public float gravity = 5f;
	private bool is_jumping = false;
	private bool allow = true;
	private Vector3 newpos = Vector3.zero;
	// Use this for initialization
	void Start () {

	}

	private float nextJump; 
	private int i;
	void Update(){
		planet = GameObject.Find ("Ring3");
	}

	void FixedUpdate () {
		move ();

	}
	void OnCollisionEnter2D(Collision2D collider){
		Destroy (this);
	}

	void move(){
		Vector3 posDiff = planet.transform.position - transform.position;
		if (Input.GetAxis ("Jump") == 1) {
			if (allow == true) {
				newpos = -posDiff.normalized*height;
				is_jumping = true;
				allow = false;
			}
		}
		if ((transform.localPosition - newpos).magnitude < 1f) {
			newpos = Vector3.zero;

		}
		if(transform.localPosition.magnitude <0.1f){
			allow = true;
			is_jumping = false;

		}

		transform.localPosition = Vector3.Lerp (transform.localPosition, newpos, Time.deltaTime*gravity);

	}
}