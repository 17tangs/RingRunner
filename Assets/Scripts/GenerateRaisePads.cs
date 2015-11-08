using UnityEngine;
using System.Collections;
using System.Math;

public class GenerateRaisePads : MonoBehaviour {

	public static GameObject[] raisePads;
	public GameObject ring;
	public static int numSpawned = 0;
	public static int numToSpawn = 8;
	float radius;
	
	// Use this for initialization
	void Start () {
		radius = (ring.GetComponent<CircleCollider2D> ().radius) * (ring.GetComponent<Transform>().localScale.x);
	}
	
	void SpawnRandomObject() 
	{    
		//spawns item in array position between 0 and numToSpawn
		int whichItem = Random.Range (0, numToSpawn);
		GameObject myObj = Instantiate (raisePads [whichItem]) as GameObject;
		numSpawned++;
		float theta = Random.Range(-180, 180);
		float x = radius*Mathf.Cos(theta);
		float y = radius*Mathf.Sin(theta);
		float y = radius*Mathf.Tan(theta);
		//where your instantiated object spawns from
		myObj.transform.position = new Vector3(x, y, 0);
	}
	
	// Update is called once per frame
	void Update () {
		if (numToSpawn > numSpawned) 
		{
			SpawnRandomObject ();
		}
	}

	float toDegrees(float rad){
		return rad * 180 / Math.PI;
	}
}
