using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Audio 
{
    #region SoundField
    [HideInInspector]
    public AudioSource source;

    public AudioClip clip;
    public string soundName;
    public bool loop;
    public float volume;
    #endregion
}
