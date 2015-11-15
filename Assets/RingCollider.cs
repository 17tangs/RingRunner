using UnityEngine;
using System.Collections;

public class RingCollider : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<CircleCollider2D> ().radius = 5.1f * transform.localScale.x;
	}
}
