using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
  [SerializeField] float loadDelay = 1f;
  [SerializeField] ParticleSystem crashEffect;
  [SerializeField] AudioClip crashSFX;

  CircleCollider2D headCollider;

  void Start()
  {
    headCollider = GetComponent<CircleCollider2D>();
  }

  void OnCollisionEnter2D(Collision2D other)
  {
    if (other.otherCollider == headCollider)
    {
      crashEffect.Play();
      GetComponent<AudioSource>().PlayOneShot(crashSFX);
      other.gameObject.GetComponent<SurfaceEffector2D>().enabled = false;
      GetComponent<PlayerController>().enabled = false;

      Invoke("ReloadScene", loadDelay);
    }
  }

  void ReloadScene()
  {
    SceneManager.LoadScene(0);
  }
}
