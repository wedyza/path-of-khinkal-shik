using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueGame : MonoBehaviour
{
    public GameObject panel;
    public void Continue()
    {
        panel.SetActive(false);
        Time.timeScale = 1f;
    }
}
