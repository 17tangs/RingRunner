using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateObstacles : MonoBehaviour {

	public static Color[] colors = new Color[9];
	public Color c;
	public GameObject ring;
	public static int numSpawned = 0;
	public static int numToSpawn = 3;
	float radius;

	// Use this for initialization
	void Start () {
		radius = (ring.GetComponent<CircleCollider2D> ().radius) * (ring.GetComponent<Transform>().localScale.x);
		colors[0] = Color.blue;
		colors[1] = Color.red;
		colors[2] = Color.green;
		colors[3] = Color.black;
		colors[4] = Color.yellow;
		colors[5] = Color.cyan;
		colors[6] = Color.grey;
		colors[7] = Color.white;
		colors[8] = Color.magenta;
	}

	void SpawnRandomObject() 
	{    
		GameObject myObj = Resources.Load<GameObject>("Obstacle") as GameObject;
		numSpawned++;
		float theta = Random.Range(-180, 180);
		float x = radius*Mathf.Cos(theta);
		float y = radius*Mathf.Sin(theta);
		//where your instantiated object spawns from
		myObj.transform.position = new Vector3(x, y, 0);
		c = colors[Random.Range(0, 8)];
		myObj.GetComponent<Renderer>().material.color = c;
	}
	
	// Update is called once per frame
	void Update () {
		if (numToSpawn > numSpawned) 
		{
			SpawnRandomObject ();
		}
	}
}
