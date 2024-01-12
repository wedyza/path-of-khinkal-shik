using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using System.Linq;
using System;
using InstantGamesBridge;
using InstantGamesBridge.Modules.Platform;
using UnityEngine.SceneManagement;
using UnityEngine.Profiling;

public class GameContoller : MonoBehaviour
{
    [SerializeField] private Transform pos;
    [SerializeField] private Player player;
    private float orderPositionX;
    static public int timeFromLastVisitor;

    public Order order;
    private List<Order> orders;

    void Start()
    {
        player = FindObjectOfType<Player>();
        StartCoroutine(CallMethodAfterDelay());
        orderPositionX = 2;
        timeFromLastVisitor = 0;
        Bridge.platform.SendMessage(PlatformMessage.GameReady);
        orders = new List<Order>() { null, null, null };
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("order").Length < player.characteristics["maxNumberOfClients"].current && timeFromLastVisitor >= player.characteristics["intervalBetweenClients"].current)
        {
            //var newOrder = gameObject.AddComponent<Order>();
            //var orders = GameObject.FindGameObjectsWithTag("order");
            for (var i = 0; i < 3; i++)
                /*if (Array.TrueForAll(orders, x => x.transform.localPosition.x >= (200 - i * 245 + 100) || x.transform.localPosition.x <= (200 - i * 245-100)))*/
                if (orders[i] == null)
                {
                    orderPositionX = ((200 - i * 245)) / 100f;
                    var newOrder = Instantiate(order, new Vector3(orderPositionX, 1.27f, 280), quaternion.identity);
                    orders[i] = newOrder;
            newOrder.tag = "order";
            newOrder.transform.SetParent(order.transform.parent);
            newOrder.transform.localScale = order.transform.localScale;
            newOrder.transform.SetSiblingIndex(1);
            timeFromLastVisitor = 0;
                    /*Debug.Log(Screen.width);
                    Debug.Log(Screen.height);
                    Debug.Log((200 - i * 245));
                    Debug.Log(orderPositionX);*/
                    break;
                }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.money += 500;
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
