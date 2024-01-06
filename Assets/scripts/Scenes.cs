using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenes : MonoBehaviour
{
    [SerializeField] private Image _imageObj;
    public void ChangeScene(int sceneNumber)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneNumber);
        if (sceneNumber == 1)
        {
            var player = FindObjectOfType<Player>();
            Debug.Log(player.currentBackgroundIndex);
            _imageObj.sprite = player.backgrounds[player.currentBackgroundIndex];
        }
    }
}
