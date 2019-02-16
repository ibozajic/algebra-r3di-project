using UnityEngine.Audio;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    private float savedMusicVolumen = 0f;

    void Awake()
    {
        string path = Application.persistentDataPath + "/game.dat";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            savedMusicVolumen = (float)Math.Round(data.musicVolumen, 2);
            Debug.Log("Retrive saved volumen: " + data.musicVolumen);
        }
        else
        {
            Debug.LogWarning("Save file not find in " + path);
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = savedMusicVolumen;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("GameMusic");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);

        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }         

        s.source.Play();
    }

    public float getVolumen()
    {
        return savedMusicVolumen;
    }
}
