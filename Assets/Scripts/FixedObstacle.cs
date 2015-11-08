using UnityEngine;
using System.Collections;

public class FixedObstacle : MonoBehaviour {

	public GameObject planet;
	float acceleration = 100.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 posDiff = planet.transform.position - this.transform.position;
		this.GetComponent<Rigidbody2D>().AddForce(posDiff.normalized * acceleration);
	}
}
