using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //реклама: 
    //    максимальное количество клиентов
    //    интервал между клиентами
    [SerializeField] int maxNumberOfClients = 1;
    [SerializeField] int intervalBetweenClients = 5;

    //готовка:
    //    время варки
    [SerializeField] int cookingTime = 5;

    //чаевые
    [SerializeField] int tips = 0;

    //ингридиенты
     

    //что-то с дизайном будет, но надо дизайнера дождаться
}
