using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateObstacles : MonoBehaviour {

	public static GameObject[] obstacles;
	public static Color[] colors = new Color[9];
	public Color c;
	public GameObject ring;
	public static int numSpawned = 0;
	public static int numToSpawn = 3;
	float radius;

	// Use this for initialization
	void Start () {
		obstacles = Resources.LoadAll<GameObject>("Prefabs");
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
		//spawns item in array position between 0 and 100
		int whichItem = Random.Range (0, numToSpawn);
		GameObject myObj = Instantiate (obstacles [whichItem]) as GameObject;
		//GameObject myObj = Resources.Load<GameObject>("Prefabs/Obstacle") as GameObject;
		numSpawned++;
		float theta = Random.Range(-180, 180);
		float x = radius*Mathf.Cos(theta);
		float y = radius*Mathf.Sin(theta);
		float ang = radius*Mathf.Tan(toRad(theta));
		//where your instantiated object spawns from
		myObj.transform.position = new Vector3 (x, y, 0);
		myObj.transform.rotation = Quaternion.AngleAxis(toDeg (ang), Vector3.forward);

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

	float toDeg(float rad){
		return rad * 180 / (float)System.Math.PI;
	}
	
	float toRad(float deg){
		return deg * (float)System.Math.PI / 180;
	}
}
