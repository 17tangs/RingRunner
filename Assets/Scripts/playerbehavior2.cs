using UnityEngine;
using System.Collections;

public class playerbehavior2 : MonoBehaviour {
	public GameObject planet;
	private float radius;
	public float theta = 0f;
	public int revolution = -1;
	private int current = 3;
	[Range(0.00f, 5.00f)]
	public float AngleIncrement = 1f ;
	void Start () {
		planet = GameObject.Find ("Ring3");
	}
	
	void Update () {
		planet = GameObject.Find ("Ring"+ current.ToString());
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			if (current < 3) 
			{
				current++;
			}
		} 
		else if (Input.GetKeyDown (KeyCode.DownArrow)) 
		{
			if (current > 1) 
			{
				current--;
			}
		}

	}
	void OnTriggerStay2D(Collider2D collider){
		Destroy (GameObject.Find ("Player"));
		//Destroy (this);
	}
	void FixedUpdate () {
		AngleIncrement += 0.0005f;
		Vector3 posDiff = planet.transform.position - transform.position;
		if (Mathf.Abs (theta) < 0.5f) {
			revolution++;
		}
		if (theta > 180f) {
			theta = -180f;
		}
		theta += AngleIncrement;
		radius = GameObject.Find("Player").transform.localScale.x * GameObject.Find ("Player").GetComponent<CircleCollider2D> ().radius + 
			planet.transform.localScale.x * planet.GetComponent<CircleCollider2D> ().radius;
		float x = radius * Mathf.Cos ((theta*Mathf.PI)/180.0f);
		float y = radius * Mathf.Sin ((theta*Mathf.PI)/180.0f);
		transform.position = new Vector3 (x, y, 0);
	}

}
