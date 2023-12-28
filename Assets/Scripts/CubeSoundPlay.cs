using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSoundPlay : MonoBehaviour
{
    [SerializeField] private AudioClip[] audioClips;
    private AudioSource audioSource; // cache

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySound(int index, bool isSkip)
    {
        if (!isSkip)
        {
            if (audioSource.isPlaying)
                return;
        }

        if (audioClips.Length > index)
        {
            audioSource.clip = audioClips[index];
            audioSource.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
