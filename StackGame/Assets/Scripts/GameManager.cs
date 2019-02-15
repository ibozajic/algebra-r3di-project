using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnCubeSpawned = delegate { };

    private CubeSpawner[] spawners;

    public AudioSource gameMusic;

    private int spawnerIndex;
    private CubeSpawner currentSpawner;

    private void Awake()
    {
        spawners = FindObjectsOfType<CubeSpawner>();
        gameMusic = GameObject.Find("GameMusic").GetComponent<AudioSource>();

        string path = Application.persistentDataPath + "/game.dat";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            gameMusic.volume = data.musicVolumen;
            Debug.Log("Retrive saved volumen: " + data.musicVolumen);
        }
        else
        {
            gameMusic.volume = 0.01f;
            Debug.Log("Save file not find in " + path);
        }
    }

    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            if(MovingCube.CurrentCube != null)
                MovingCube.CurrentCube.Stop();

            spawnerIndex = spawnerIndex == 0 ? 1 : 0;
            currentSpawner = spawners[spawnerIndex];

            currentSpawner.SpawnCube();

            OnCubeSpawned();
        }
    }
}
