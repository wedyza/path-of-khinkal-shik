using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Scenes : MonoBehaviour
{
    [SerializeField] private Image _imageObj;
    private Sounds sounds;

    public AudioClip clip;

    void Start()
    {
        sounds = GameObject.FindWithTag("sounds").GetComponent<Sounds>();
    }
    
    public void ChangeScene(int sceneNumber)
    {
        sounds.Play(clip);
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneNumber);
        var player = FindObjectOfType<Player>();
        player.moneyFromCurrentShift = 0;
        //player.placesForOrders = new List<bool>() { true, true, true };
    }
}
