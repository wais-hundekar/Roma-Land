using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public Sounds[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sounds s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;

        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Play(string name)
    {
        Sounds s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }

    void Start()
    {
        Play("Theme");
    }

}
