using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	public float m_DampTime = 0.2f;                 // Approximate time for the camera to refocus.                
	public GameObject m_Target;     
	private Vector3 m_MoveVelocity;                 // Reference velocity for the smooth damping of the position.
	private Vector3 m_DesiredPosition; 
	public GameObject planet;
	public float level;
	// Use this for initialization
	void Start () {
	}

	void FixedUpdate ()
	{
		m_Target = GameObject.Find ("Player");
		planet = m_Target.GetComponent<PlayerBehavior> ().planet;
		level = planet.GetComponent<Transform> ().localScale.x*5;
		Move ();
	}
	
	
	private void Move ()
	{
	//	Vector3 perpendicular = Quaternion.Euler(0,0,0)* new Vector3 (-posDiff.y, posDiff.x, posDiff.z);
		
		// Find the average position of the targets.
		FindAveragePosition ();
		// Smoothly transition to that position.
		transform.position = Vector3.SmoothDamp(transform.position, m_DesiredPosition, ref m_MoveVelocity, m_DampTime);
	}
	
	
	private void FindAveragePosition ()
	{
		Vector3 posDiff = planet.transform.position - m_Target.transform.position;
		Vector3 averagePos = -posDiff.normalized * level;
		//Vector3 averagePos = m_Target.transform.position;
		averagePos.z = transform.position.z;
		// The desired position is the average position;
		m_DesiredPosition = averagePos;
	}
}
