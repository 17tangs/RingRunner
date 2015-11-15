using UnityEngine;
using System.Collections;

public class Rings : MonoBehaviour {
	public GameObject prefab;
	public GameObject player;	
	// Use this for initialization
	void Start () {
		Instantiate (player);
		for (int i = 0; i<4; i++) {
			GameObject a = Instantiate (prefab);
			int k = i+1;
			a.name = "Ring" + k.ToString();
			a.transform.localScale += new Vector3(0.25f*i, 0.25f*i, 0.25f*i);
			a.GetComponent<SpriteRenderer>().material.SetColor("_Color", new Color((50+i*50f)/255.0f, (175f+i*20f)/255.0f, 1f));
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
