using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plate : MonoBehaviour
{
    public void PlaceOnPlate(Khinkali khinkalina)
    {
        khinkalina.transform.SetParent(transform);
        khinkalina.transform.localPosition = Vector3.zero;
        khinkalina.gameObject.SetActive(true);
    }
}
