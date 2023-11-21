using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameContoller : MonoBehaviour
{
    [SerializeField] private Transform pos;
    [SerializeField] private Player player;
    public Order order;

    private List<Order> _orders;
    // Update is called once per frame
    void Start()                        
    {
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        { 
            Instantiate(order);
        }
    }
}
