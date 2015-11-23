using UnityEngine;
using System.Collections;
/*
TODO:   Collision detection between player and bars
		Public variables of this script used in other scripts (no magic numbers)
		Obstacles set up, collision
		Color
		Delay for player to move
		Camera control zoom in 
		Automatically regenerate different bars
		UI (how many loops)
*/
public class Rings : MonoBehaviour {
	public GameObject prefab;
	public GameObject player;	
	public GameObject bar;
	//scale for the obstacles to fit in
	private const float scale = 0.23743f;//0.25f*prefab.GetComponent<CircleCollider2D>().radius/bar.GetComponent<BoxCollider2D>().size.x; 
	//half a gap between rings
	private const float space = 1.275f/2.0f;
	public int numRing=4;
	public int numBar=4;
	private int separation = 40;
	// Use this for initialization
	bool duplicates(int[] arr){
		for (int y = 0; y<numBar; y++) {
			for (int x = y+1; x<numBar; x++) {
				if(arr[y]==arr[x]){
					return true;
				}
			}
		}
		return false;
	}
	void replace(int[] angles){
		for (int y = 0; y<numBar; y++) {
			for (int x = y+1; x<numBar; x++) {
				while (angles[x] == angles[y]) {
					angles [x] = Random.Range (1, 360 / separation);
				}
			}
		}
	}
	void Start () {
		Instantiate (player);
		for (int i = 0; i<numRing; i++) {
			GameObject a = Instantiate (prefab);
			int k = i+1;
			a.name = "Ring" + k.ToString();
			a.transform.localScale += new Vector3(0.25f*i, 0.25f*i, 0.25f*i);
			a.GetComponent<SpriteRenderer>().material.SetColor("_Color", new Color((50+i*50f)/255.0f, (175f+i*20f)/255.0f, 1f));
		}
		int[] angles = new int[numBar];
		for (int i = 0; i<numBar; i++) {
			int k  = Random.Range (1, 360/separation);
			angles[i] = k;
		}
		while (duplicates (angles)) {
			replace (angles);
		}
		
		for (int i = 0; i<numBar; i++) {
			angles [i] = angles [i] * separation;
		}
		for (int i = 0; i<numBar; i++) {
			float k = angles[i];
			int gap = Random.Range (1, numRing-1);
			for (int x = 1; x<=numRing-1; x++) {
				if(x!=gap){
					GameObject ring =  GameObject.Find ("Ring" + x.ToString());
					float r = ring.GetComponent<CircleCollider2D>().radius*ring.transform.localScale.x;
					Vector3 bar_pos = new Vector3(Mathf.Cos(k*Mathf.PI/180.0f)*(r+space), Mathf.Sin (k*Mathf.PI/180.0f)*(r+space), 0);
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
