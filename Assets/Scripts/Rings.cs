using UnityEngine;
using System.Collections;

public class Rings : MonoBehaviour {
	public GameObject prefab;
	public GameObject player;	
	public GameObject bar;
	//distance between rings
	private const float scale = 0.23743f;//0.25f*prefab.GetComponent<CircleCollider2D>().radius/bar.GetComponent<BoxCollider2D>().size.x; 
	public int numRing=4;
	public int numBar=4;
	// Use this for initialization
	void Start () {
		Instantiate (player);
		for (int i = 0; i<numRing; i++) {
			GameObject a = Instantiate (prefab);
			int k = i+1;
			a.name = "Ring" + k.ToString();
			a.transform.localScale += new Vector3(0.25f*i, 0.25f*i, 0.25f*i);
			a.GetComponent<SpriteRenderer>().material.SetColor("_Color", new Color((50+i*50f)/255.0f, (175f+i*20f)/255.0f, 1f));
		}

		for (int i = 0; i<numBar; i++) {
			float k = Random.Range (0.0f, 180.0f);
			int gap = Random.Range (1, 4);
			for (int x = 1; x<=4; x++) {
				if(x!=gap){
					GameObject ring =  GameObject.Find ("Ring" + x.ToString());
					float r = ring.GetComponent<CircleCollider2D>().radius*ring.transform.localScale.x;
					Vector3 bar_pos = new Vector3(Mathf.Cos(k*Mathf.PI/180.0f)*r+(bar.GetComponent<BoxCollider2D>().size.x * scale)/2.0f, Mathf.Sin (k*Mathf.PI/180.0f)*r+(bar.GetComponent<BoxCollider2D>().size.y * scale)/2.0f, 0);
					Quaternion q = Quaternion.identity;
					q.eulerAngles = new Vector3(0.0f,0.0f,k-90.0f);
					Instantiate (bar, bar_pos, q);
					bar.transform.localScale = new Vector3(scale,scale,0);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
