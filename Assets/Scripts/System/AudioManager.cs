using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public static AudioManager current = null;
    private AudioSource activeMusic = null;

    void Awake()
    {
        current = this;
    }

    public void PlayMusic(string fileName, float vol, float pitch, bool loop)
    {
        Debug.Log("Playing music " + fileName);
        AudioClip clip = Resources.Load(fileName) as AudioClip;

        if (clip == null)
        {
            Debug.LogWarning("Couldn't find " + fileName);
            return;
        }

        if (activeMusic != null)
        {
            activeMusic.Stop();
            activeMusic = null;
        }

        activeMusic = gameObject.AddComponent("AudioSource") as AudioSource;
        audio.volume = vol;
        audio.pitch = pitch;
        audio.loop = true;
        audio.PlayOneShot(clip);
    }

    public void Play(string fileName, float vol, float pitch)
    {
        AudioClip clip = Resources.Load(fileName) as AudioClip;

        if (clip == null)
        {
            Debug.LogWarning("Couldn't find " + fileName);
            return;
        }

        GameObject sound = new GameObject("sfx");
        sound.AddComponent("AudioSource");
        sound.audio.volume = vol;
        sound.audio.pitch = pitch;
        sound.audio.PlayOneShot(clip);
        sound.transform.parent = current.transform;

        //StartCoroutine(GarbageCollection(sound));
    }

    /*IEnumerator GarbageCollection(GameObject sound)
    {
        if(sound.audio != null)
            yield return new WaitForSeconds (sound.audio.clip.length);

        Destroy(sound);
    }*/
}