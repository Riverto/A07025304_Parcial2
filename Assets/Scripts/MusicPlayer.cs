using UnityEngine;
using UnityEngine.SceneManagement;			//	Required to handle scenes
using System.Collections;

public class MusicPlayer : MonoBehaviour {
	static MusicPlayer instance = null;		//	Singleton used to load the music player

	public AudioClip startClip;				//	Clip to play at the start menu

	private AudioSource music;				//	We use it to play the right music
	
	void Start () {
		//	If the music player already exists, then the new instance is destroyed; otherwise, we
		//	create an instance of the music player and set it to not be destroyed upon a new load.
		if (instance != null && instance != this) {
			Destroy (gameObject);
			print ("Duplicate music player self-destructing!");
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad(gameObject);

			//	We also define our starting audio clip, because the OnLoadCallBack is not run until
			//	another scene is loaded.  We set our clip to play in a loop and then start playing it.
			music = GetComponent<AudioSource> ();
			music.clip = startClip;
			music.loop = true;
			music.Play ();
		}
		
	}
}
