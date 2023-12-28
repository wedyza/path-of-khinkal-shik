using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Pot : MonoBehaviour, IDropHandler
{
    private List<Khinkali> _khinkalis;
    public Plate LinkedPlate;
    
    public void Awake()
    {
        _khinkalis = new List<Khinkali>();
    }
    
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Boil());
        }
    }
    
    public void OnDrop(PointerEventData eventData)
    {
        var khinkalina = eventData.pointerDrag.gameObject.GetComponent<Khinkali>();

        if (khinkalina != null && khinkalina.IsCooked && _khinkalis.Count < 3)
        {
            khinkalina.gameObject.SetActive(false);
            _khinkalis.Add(khinkalina);
            SpriteUpdater(false);
            
            Debug.Log(khinkalina);
            Debug.Log(_khinkalis);
        }
    }

    IEnumerator Boil()
    {
        if (_khinkalis.Count > 0)
        {
            SpriteUpdater(true);
            yield return new WaitForSeconds(5);
            while (_khinkalis.Count > 0)
            {
                _khinkalis[0].IsBoiled = true;
                LinkedPlate.PlaceOnPlate(_khinkalis[0]);
                _khinkalis.RemoveAt(0);
            }
            Debug.Log("хинкали готовы!");
        }
    }

    void SpriteUpdater(bool isBoiling)
    {
        return;
    }
}
