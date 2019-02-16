using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MainMenu : MonoBehaviour
{
    public Slider volumSlider;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ChangeMusicVolume()
    {
        volumSlider = FindObjectOfType<Slider>();        

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/game.dat";

        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData();
        data.musicVolumen = volumSlider.value;

        formatter.Serialize(stream, data);
        stream.Close();

        Debug.Log("Volume saved: " + volumSlider.value);
    }

    public void SetVolumenSliderValueFromGameData()
    {
        string path = Application.persistentDataPath + "/game.dat";

        if(File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            Debug.Log("Retrive saved volumen: " + data.musicVolumen);

            volumSlider = FindObjectOfType<Slider>();

            if(volumSlider == null)
            {
                Debug.LogWarning("No Slider found on screen");
            }
            else
            {
                Debug.Log("Slider found on Screen");
                volumSlider.normalizedValue = data.musicVolumen;
            }            
        }
        else
        {
            Debug.Log("Save file not find in " + path);
        }
    }
}
