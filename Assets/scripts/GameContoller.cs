using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
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
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            var newOrder = Instantiate(order, order.transform.position, quaternion.identity);
            newOrder.transform.SetParent(order.transform.parent);
            newOrder.transform.localScale = order.transform.localScale;
            newOrder.transform.SetAsFirstSibling();
        }
    }
}
