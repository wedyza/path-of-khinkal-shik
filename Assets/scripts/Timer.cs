using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    int sec = 0;
    int min = 3;
    int delta = 1;
    [SerializeField] TMP_Text _timerText;
    public GameObject panel;
    void Start()
    {
        StartCoroutine(ITimer());
        //Debug.Log("timer");
    }

    IEnumerator ITimer()
    { 
        while (true) 
        {
            if (min == 0 && sec == 0)
            {
                panel.SetActive(true);
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
