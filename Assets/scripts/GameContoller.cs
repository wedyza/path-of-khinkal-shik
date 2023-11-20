using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoller : MonoBehaviour
{
    [SerializeField] Order order;

    [SerializeField] private Transform pos;
    // Update is called once per frame
    void Start()
    {
        Screen.SetResolution(736, 414, true);
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Instantiate(order);
        }
    }
}
