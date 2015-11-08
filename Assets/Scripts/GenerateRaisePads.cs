using UnityEngine;
using System.Collections;

public class GenerateRaisePads : MonoBehaviour {

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
		GameObject myObj = Resources.Load<GameObject>("Prefabs/RaisePad") as GameObject;
		myObj.gameObject.name = "RaisePad"+ring.name.Substring(4);
		numSpawned++;
		float theta = Random.Range(-180, 180);
		float x = radius*Mathf.Cos(toRad(theta));
		float y = radius*Mathf.Sin(toRad(theta));
		float ang = radius*Mathf.Tan(toRad(theta));
		//where your instantiated object spawns from
		myObj.transform.position = new Vector3(x, y, 0);
		myObj.transform.rotation = Quaternion.AngleAxis(toDeg (ang), Vector3.forward);
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
