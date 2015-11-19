using UnityEngine;
using System.Collections;

public class playerbehavior2 : MonoBehaviour {
	public GameObject planet;
	private float radius;
	public float theta = 0;
	private int current = 4;
	[Range(0.00f, 5.00f)]
	public float AngleIncrement = 1.3f ;
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
		Vector3 posDiff = planet.transform.position - transform.position;
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
