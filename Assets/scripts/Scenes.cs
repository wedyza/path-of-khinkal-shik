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
        var player = FindObjectOfType<Player>();
        player.moneyFromCurrentShift = 0;
        //player.placesForOrders = new List<bool>() { true, true, true };
    }
}
