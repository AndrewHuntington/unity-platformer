using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
  [SerializeField] AudioClip pickupSoundFX;
  [Range(0.0f, 1.0f)]
  [SerializeField] float pickupSoundVolume = 1f;

  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.tag == "Player")
    {
      AudioSource.PlayClipAtPoint(pickupSoundFX, Camera.main.transform.position, pickupSoundVolume);
      Destroy(gameObject);
    }
  }
}
