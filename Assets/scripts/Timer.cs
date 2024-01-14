using System.Collections;
using System.Collections.Generic;
using InstantGamesBridge;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    private Sounds sounds;
    Player player;
    public TextMeshProUGUI textEnd;
    public TextMeshProUGUI textTips;
    int sec = 0;
    int min = 2;
    int delta = 1;
    [SerializeField] TMP_Text _timerText;
    public GameObject panel;

    public AudioClip clip;
    void Start()
    {
        sounds = GameObject.FindWithTag("sounds").GetComponent<Sounds>();
        player = FindObjectOfType<Player>();
        StartCoroutine(ITimer());
        //Debug.Log("timer");
    }

    IEnumerator ITimer()
    { 
        while (true) 
        {
            if (min == 0 && sec == 0)
            {
                sounds.Play(clip);
                panel.SetActive(true);
                textEnd.text = "Заработано: " + player.moneyFromCurrentShift + " хинкалин";
                textTips.text = "Чаевые: " + (int)(player.moneyFromCurrentShift * (player.characteristics["tips"].current/100)) + " хинкалин";
                player.money += (int)(player.moneyFromCurrentShift * (player.characteristics["tips"].current/100));
                Time.timeScale = 0f;
                player.Save();
                Bridge.advertisement.ShowBanner();
                break;
            }
            if (sec == 0)
            {
                min--;
                sec = 60;
            }
            sec -= delta;
            _timerText.text = min.ToString("D2") + " : " + sec.ToString("D2");
            yield return new WaitForSeconds(delta);
        }
    }
}
