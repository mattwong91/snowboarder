using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashDetector : MonoBehaviour
{
  CircleCollider2D headCollider;

  void Start()
  {
    headCollider = GetComponent<CircleCollider2D>();
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.otherCollider == headCollider)
    {
      Debug.Log("Bonked your head");
      other.gameObject.GetComponent<SurfaceEffector2D>().enabled = false;
      GetComponent<PlayerController>().enabled = false;
    }
  }
}
