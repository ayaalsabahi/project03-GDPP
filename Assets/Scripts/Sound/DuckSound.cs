using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckSound : MonoBehaviour
{
    public AudioClip quackingDuck;
    public AudioClip fleeDuck;


    private AudioSource quackSource;
    private AudioSource fleeSource;


    public Transform player;
    public float minVolumeDistance;
    public float maxVolumeDistance;
    public float maxVolume = 1.0f;


    private void Awake()
    {
        quackSource = gameObject.AddComponent<AudioSource>();
        fleeSource = gameObject.AddComponent<AudioSource>();
        

        quackSource.clip = quackingDuck;
        fleeSource.clip = fleeDuck;


        quackSource.minDistance = minVolumeDistance;
        quackSource.maxDistance = maxVolumeDistance;
        fleeSource.minDistance = minVolumeDistance;
        fleeSource.maxDistance = maxVolumeDistance;


        quackSource.loop = true;
        fleeSource.loop = true;



    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(gameObject.transform.position, player.position);
        //Debug.Log("dist to player" + distanceToPlayer);
        float normalizedDistance = Mathf.Clamp01((distanceToPlayer - minVolumeDistance) / (maxVolumeDistance - minVolumeDistance));
        float volume = Mathf.Clamp01(1.0f - Mathf.Log(normalizedDistance + 1.0f) / Mathf.Log(2.0f));
        quackSource.volume = volume * maxVolume/2;
        fleeSource.volume = volume * maxVolume;
        //policeSource.volume = volume * maxVolume;

    }

    public void SusSound()
    {
        quackSource.Play();
    }

    public void FleeSound()
    {
        quackSource.Stop();
        fleeSource.Play();
    }

    public void stopSound()
    {
        quackSource.Stop();
        fleeSource.Stop();
    }



    
}
