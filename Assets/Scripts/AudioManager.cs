using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    #region Singleton
    private static AudioManager _instance;

    public static AudioManager Instance
    {
        get 
        {
            if (_instance==null)
            {
                _instance = FindObjectOfType<AudioManager>();
            }

            return _instance;
        }
       
    }
    #endregion
    public List<Audio> audios = new List<Audio>();
    public AudioSource audioSource;

    bool isplaying = true;

    private void Awake()
    {
        //DontDestroyOnLoad(gameObject);
    }
    #region MUSÝC
    public void PlayMusic(string name)
    {
        foreach (Audio audio in audios)
        {
            if (audio.soundName == name)
            {
                if (audio.source == null)
                {
                    audio.source = gameObject.AddComponent<AudioSource>();
                }
                audio.source.clip = audio.clip;
                audio.source.volume = audio.volume;
                audio.source.loop = audio.loop;
                audio.source.Play();
                break;
            }
        }
    } // MÜZÝKLERÝ BAÞLATAN METOD
    public void SwitchSoundState(bool isOn)
    {
        if (isOn) 
        {
            audioSource.Play();
        }
        else
        {
            audioSource.Pause();
        }


    }
    #endregion
   

}
