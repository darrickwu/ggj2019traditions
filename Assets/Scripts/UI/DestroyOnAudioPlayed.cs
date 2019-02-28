using UnityEngine;

public class DestroyOnAudioPlayed : MonoBehaviour
{
  private AudioSource audioSource;

  void Awake()
  {
    audioSource = GetComponent<AudioSource>();
  }
  void Update()
  {
    if (!audioSource.isPlaying)
    {
      Destroy(gameObject);
    }
  }
}