using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScript : MonoBehaviour {

	public bool can_jump = true;
	public float jump_force = 100f;
	public Rigidbody warrior_rigid_body;

	void Start()
	{
		warrior_rigid_body = GetComponent<Rigidbody> ();
	}
	public void Jump()
	{
		if (can_jump) 
		{
			warrior_rigid_body.AddForce (Vector3.up * jump_force, ForceMode.Impulse);
			can_jump = false;
			StartCoroutine (JumpTimer ());
		}
	}

	IEnumerator JumpTimer()
	{
		yield return new WaitForSeconds (0.8f);
		can_jump = true;
	}
}
