using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickup : MonoBehaviour
{
  [SerializeField] AudioClip pickupSoundFX;
  [Range(0.0f, 1.0f)]
  [SerializeField] float pickupSoundVolume = 1f;
  [SerializeField] int pointValue = 100;
  bool wasCollected = false;
  void OnTriggerEnter2D(Collider2D other)
  {

    if (other.tag == "Player" && !wasCollected)
    {
      wasCollected = true;
      FindObjectOfType<GameSession>().AddToScore(pointValue);
      AudioSource.PlayClipAtPoint(pickupSoundFX, Camera.main.transform.position, pickupSoundVolume);
      Destroy(gameObject);
    }
  }
}
