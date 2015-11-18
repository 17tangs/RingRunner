using UnityEngine;
using System.Collections;

public class playerbehavior2 : MonoBehaviour {
	public GameObject planet;
	private float radius;
	public float theta = 0;
	private int current = 4;
	[Range(0.00f, 0.05f)]
	public float AngleIncrement = 0.02f ;
	void Start () {
		planet = GameObject.Find ("Ring4");
		Debug.Log (planet);
	}
	
	void Update () {
		planet = GameObject.Find ("Ring"+ current.ToString());
		if (Input.GetKeyDown (KeyCode.UpArrow)) 
		{
			if (current < 4) 
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

	void FixedUpdate () {
		Debug.Log (theta);
		Vector3 posDiff = planet.transform.position - transform.position;
		if (theta > 180f) {
			theta = -180f;
		}
		theta += AngleIncrement;
		radius = GameObject.Find("Player").transform.localScale.x * GameObject.Find ("Player").GetComponent<CircleCollider2D> ().radius + 
			planet.transform.localScale.x * planet.GetComponent<CircleCollider2D> ().radius;
		float x = radius * Mathf.Cos (theta);
		float y = radius * Mathf.Sin (theta);
		transform.position = new Vector3 (x, y, 0);
	}

}
