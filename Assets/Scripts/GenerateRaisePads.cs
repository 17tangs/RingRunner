using UnityEngine;
using System.Collections;

public class GenerateRaisePads : MonoBehaviour {

	public static GameObject[] pads;
	public GameObject ring;
	public int numSpawned = 0;
	public int numToSpawn = 8;
	float radius;
	
	// Use this for initialization
	void Start () {
		numSpawned = 0;
		radius = (ring.GetComponent<CircleCollider2D> ().radius) * (ring.GetComponent<Transform>().localScale.x);
		pads=Resources.LoadAll<GameObject>("Prefabs");
	}
	
	void SpawnRandomObject() 
	{    
		//position of target prefab
		int whichItem = 1;
		GameObject myObj = Instantiate (pads [whichItem]) as GameObject;		
		myObj.gameObject.name = "RaisePad"+ring.name.Substring(4);
		numSpawned++;
		float theta = Random.Range(-180, 180);
		float x = radius*Mathf.Cos(toRad(theta));
		float y = radius*Mathf.Sin(toRad(theta));
		float ang = radius*Mathf.Tan(toRad(theta));
		//where your instantiated object spawns from
		myObj.transform.position = new Vector3(x, y, 0);
		myObj.transform.rotation = Quaternion.AngleAxis(toDeg (ang)+90, Vector3.forward);
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
