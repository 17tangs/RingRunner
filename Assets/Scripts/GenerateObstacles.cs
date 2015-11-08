using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateObstacles : MonoBehaviour {

	public static GameObject[] obstacles;
	public static List<Color> colors;
	public Color c;
	public GameObject ring;
	public static int numSpawned = 0;
	public static int numToSpawn = 8;
	float radius;

	// Use this for initialization
	void Start () {
		obstacles = Resources.LoadAll<GameObject>("Prefabs");
		radius = (ring.GetComponent<CircleCollider2D> ().radius) * (ring.GetComponent<Transform>().localScale.x);
	}

	void SpawnRandomObject() 
	{    
		//spawns item in array position between 0 and 100
		int whichItem = Random.Range (0, numToSpawn);
		GameObject myObj = Instantiate (obstacles [whichItem]) as GameObject;
		numSpawned++;
		float theta = Random.Range(-180, 180);
		float x = radius*Mathf.Cos(theta);
		float y = radius*Mathf.Sin(theta);
		//where your instantiated object spawns from
		myObj.transform.position = new Vector3(x, y, 0);
		c = new Color((Random.Range (0.0f, 1.0f)), (Random.Range (0.0f, 1.0f)), (Random.Range (0.0f, 1.0f)));
		myObj.GetComponent<Renderer>().material.color = c;
		colors.Add (c);
	}
	
	// Update is called once per frame
	void Update () {
		if (numToSpawn > numSpawned) 
		{
			SpawnRandomObject ();
		}
	}
}
