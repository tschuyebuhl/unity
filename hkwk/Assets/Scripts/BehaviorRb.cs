using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviorRb : MonoBehaviour
{
  public float moveSpeed = 25f;
  public float rotateSpeed = 75f;
  public float jumpVelocity = 5f;

  // Start is called before the first frame update
  void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  public virtual void Pickup()
  {
    moveSpeed *= 1.0f;
  }
  public virtual void JumpPickup()
	{
    jumpVelocity *= 1.0f;
	}
}
