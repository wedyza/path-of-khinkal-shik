using System;
using System.Collections;
using System.Collections.Generic;
using InstantGamesBridge;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Dictionary<string, (float current, float maximum, float step, int price)> characteristics;
    public Dictionary<int, (bool isAvailable, int price)> backgrounds;

    public int money;
    public int moneyFromCurrentShift;

    public List<Sprite> backgroundsSprites;
    //public List<bool> placesForOrders;

    public int currentBackgroundIndex;

    void Start()
    {
        Bridge.storage.Get("player", OnStorageGetCompleted);
    }
    
    void Update()
    {        
        if (GameObject.FindGameObjectsWithTag("player").Length == 1) DontDestroyOnLoad(gameObject);
    }

    public void Parse(string d)
    {
        characteristics = new Dictionary<string, (float current, float maximum, float step, int price)>();
        backgrounds = new Dictionary<int, (bool isAvailable, int price)>();

        foreach (var k in characteristics.Keys)
        {
            Debug.Log(k);
            Debug.Log(characteristics[k]);
        }
        
        var dSplit = d.Split("|");
        var chars = dSplit[0].Split("~");
        var backs = dSplit[1].Split("~");
        money = int.Parse(dSplit[2].Split(":")[1]);
        currentBackgroundIndex = int.Parse(dSplit[3].Split(":")[1]);

        foreach (var c in chars)
        {
            if (c == "")
                continue;
            var firstSplit = c.Split("?");
            var key = firstSplit[0];
            var values = firstSplit[1].Split("/");

            float current = 0, maximum = 0, step = 0;
            int price = 0;
            foreach (var v in values)
            {
                var vSplit = v.Split(":");
                var parameter = vSplit[0];
                var value = vSplit[1];
                switch (parameter)
                {
                    case "current":
                        current = float.Parse(value);
                        break;
                    case "maximum":
                        maximum = float.Parse(value);
                        break;
                    case "step":
                        step = float.Parse(value);
                        break;
                    case "price":
                        price = int.Parse(value);
                        break;
                }
            }
            characteristics.Add(key, (current: current, maximum:maximum, step:step, price:price));
        }

        foreach (var b in backs)
        {
            if (b == "")
                continue;
            
            var firstSplit = b.Split("?");
            var key = int.Parse(firstSplit[0]);

            var values = firstSplit[1].Split("/");

            bool isAviable = false;
            int price = 0;
            
            foreach (var v in values)
            {
                var vSplit = v.Split(":");
                var parameter = vSplit[0];
                var value = vSplit[1];

                switch (parameter)
                {
                    case "isAviable":
                        isAviable = Boolean.Parse(value);
                        break;
                    case "price":
                        price = int.Parse(value);
                        break;
                }
            }
            backgrounds.Add(key, (isAvailable:isAviable, price:price));
        }
    }

    public void Save()
    {
        string d = "";
        foreach (var k in characteristics.Keys)
        {
            d += k + "?" + "current:" + characteristics[k].current + "/maximum:" + characteristics[k].maximum +
                 "/step:" + characteristics[k].step + "/price:" + characteristics[k].price + "~";
        }

        d += "|";

        foreach (var k in backgrounds.Keys)
        {
            d += k + "?" + "isAviable:" + backgrounds[k].isAvailable + "/price:" + backgrounds[k].price + "~";
        }

        d += "|";

        d += "money:" + money;

        d += "|";

        d += "currentBackgroundIndex:" + currentBackgroundIndex;
        
        Bridge.storage.Set("player", d, OnStorageGetSaved);
    }

    public void SetupDefault()
    {
        characteristics = new Dictionary<string, (float current, float maximum, float step, int price)>()
        {
            { "maxNumberOfClients", (current: 1, maximum: 3, step: 1, price: 100) },
            { "intervalBetweenClients", (current: 5, maximum: 1.5f, step: -0.5f, price: 100) },
            { "cookingTime", (current: 7, maximum: 1.5f, step: -0.5f, price: 100) },
            { "tips", (current: 0, maximum: 10, step: 1, price: 100) },
        };
        backgrounds = new Dictionary<int, (bool isAvailable, int price)>()
        {
            { 0, (isAvailable: true, price: 0) },
            { 1, (isAvailable: false, price: 250) },
            { 2, (isAvailable: false, price: 250) },
            { 3, (isAvailable: false, price: 500) },
        };
                
        money = 0;
        currentBackgroundIndex = 0;
        //placesForOrders = new List<bool>() { true, true, true };
    }
    
    private void OnStorageGetSaved(bool success)
    {
        Debug.Log($"OnStorageGetSaved, success: {success}");
    }
    
    private void OnStorageGetCompleted(bool success, string data)
    {
        if (success)
            if (data != null)
            {
                Parse(data);
                Debug.Log("succesfully loaded");
            }
            else
            {
                SetupDefault();
                Debug.Log("No data defined");
            }
        else
        {
            SetupDefault();
            Debug.Log("Error on loading");
        }
    }
}
