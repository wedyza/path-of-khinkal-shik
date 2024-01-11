using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using System.Linq;
using System;
using InstantGamesBridge;
using InstantGamesBridge.Modules.Platform;
using UnityEngine.SceneManagement;

public class GameContoller : MonoBehaviour
{
    [SerializeField] private Transform pos;
    [SerializeField] private Player player;
    private float orderPositionX;
    static public int timeFromLastVisitor;
    //bool flag;

    public Order order;

    //private List<Order> _orders;
    // Update is called once per frame
    void Start()
    {
        player = FindObjectOfType<Player>();
        StartCoroutine(CallMethodAfterDelay());
        orderPositionX = 2;
        timeFromLastVisitor = 0;
        Bridge.platform.SendMessage(PlatformMessage.GameReady);
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("order").Length < player.characteristics["maxNumberOfClients"].current && timeFromLastVisitor >= player.characteristics["intervalBetweenClients"].current)
        {
            var orders = GameObject.FindGameObjectsWithTag("order");
            for (var i = 0; i < 3; i++)
                if (Array.TrueForAll(orders, x => x.transform.localPosition.x != (200 - i * 245) * (Screen.width / 736f)))
                {
                    orderPositionX = ((200 - i * 245) * (Screen.width / 736f)) / 100f;
                    break;
                }
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
