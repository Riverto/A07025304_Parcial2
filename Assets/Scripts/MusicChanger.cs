using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicChanger : MonoBehaviour {
    public AudioClip LevelMusic;


	// Use this for initialization
	void Start () {
        //Buscamos el objeto MusicPlayer y su audioSource
        MusicPlayer MPObject = GameObject.FindObjectOfType<MusicPlayer>();
        AudioSource musicPlayer = MPObject.GetComponent<AudioSource>();

        //Si el clip es diferente al deseado
        if (musicPlayer.clip != LevelMusic)
        {
            //paramos la musica
            musicPlayer.Stop();
            //cambiamos el clip
            musicPlayer.clip = LevelMusic;
            //activamos loop
            musicPlayer.loop = true;
            //y empezamos la musica
            musicPlayer.Play();
        }
	}
}
