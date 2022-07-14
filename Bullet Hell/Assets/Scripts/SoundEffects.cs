using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
  [Header("Shooting")] 
  [SerializeField] AudioClip shootingClip;
  [SerializeField] [Range(0f,1f)] float shootingVolume = 1f;

  [Header("Hitting")] 
  [SerializeField] AudioClip hittingClip;
  [SerializeField] [Range(0f,1f)] float hittingVolume = 1f;
  public void PlayShootingClip()
  {
     PlayClip(shootingClip,shootingVolume);
  }
  public void PlayHittingClip()
  {
    PlayClip(hittingClip,hittingVolume);
  }
  void PlayClip(AudioClip clip, float volume)
  {
    if(clip!= null)
    {
      Vector3 cameraPos = Camera.main.transform.position;
      AudioSource.PlayClipAtPoint(clip,cameraPos,volume);
    }
  }
}
