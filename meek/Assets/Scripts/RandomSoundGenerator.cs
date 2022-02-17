using System.Collections.Generic;
using UnityEngine;

namespace Sounds {
  // TODO: After demo phase deprecate this script in favor of Sounds.AudioEmitter in all prefabs
  // TODO: Sounds to play will also need to become instances of AudioEvent ScriptableObject.
  public class RandomSoundGenerator : MonoBehaviour {
    public List<AudioClip> audioClips;
    public AudioClip currentClip;
    public AudioSource source;
    public float minWaitBetweenPlays = 2f;
    public float maxWaitBetweenPlays = 6f;
    public float waitTimeCountdown = -1f;

    private void Start() {
      source = GetComponent<AudioSource>();
    }

    private void Update() {
      if (!source.isPlaying) {
        if (waitTimeCountdown < 0f) {
          currentClip = audioClips[Random.Range(0, audioClips.Count)];
          source.clip = currentClip;
          source.Play();
          waitTimeCountdown = Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);
        }
        else {
          waitTimeCountdown -= Time.deltaTime;
        }
      }
    }
  }
}