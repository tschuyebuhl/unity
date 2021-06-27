using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPickup : MonoBehaviour
{
	void OnTriggerEnter(Collider other)
	{

		if (other.tag == "CanPickup")
		{
			Destroy(this.transform.parent.gameObject);
			other.GetComponent<BehaviorRb>().JumpPickup();
			//Debug.Log(collision.gameObject);
			Debug.Log("Item collected!");
		}
	}
}
