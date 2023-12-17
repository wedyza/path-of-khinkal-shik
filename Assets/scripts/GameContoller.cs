using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class GameContoller : MonoBehaviour
{
    [SerializeField] private Transform pos;
    [SerializeField] private Player player;
    private float orderPositionX;
    private int timeFromLastVisitor = 0;

    public Order order;

    private List<Order> _orders;
    // Update is called once per frame
    void Start()                        
    {
        StartCoroutine(CallMethodAfterDelay());
    }
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("order").Length < 3 && timeFromLastVisitor >= 2)
        {
            var ordersCount = GameObject.FindGameObjectsWithTag("order").Length;
            orderPositionX = (200 - ordersCount * 245) / 100f;
            var newOrder = Instantiate(order, new Vector3(orderPositionX, 1.27f, 280), quaternion.identity);
            newOrder.tag = "order";
            newOrder.transform.SetParent(order.transform.parent);
            newOrder.transform.localScale = order.transform.localScale;
            newOrder.transform.SetSiblingIndex(1);
            timeFromLastVisitor = 0;
        }
    }

    IEnumerator CallMethodAfterDelay()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            timeFromLastVisitor++;
        }
    }
}
