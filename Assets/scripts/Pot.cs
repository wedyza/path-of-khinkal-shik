using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pot : MonoBehaviour, IDropHandler
{
    private List<Khinkali> _khinkalis;
    public Plate LinkedPlate;
    private Image imgObj;

    public Sprite FullIdle;
    public Sprite[] khinkalisIdle;
    public Sprite[] khinkalisOnFire;
    
    public void Awake()
    {
        _khinkalis = new List<Khinkali>();
        imgObj = GetComponent<Image>();
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

        if (khinkalina != null && khinkalina.IsCooked && _khinkalis.Count < 4)
        {
            khinkalina.gameObject.SetActive(false);
            _khinkalis.Add(khinkalina);
            SpriteUpdater(false);
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
            SpriteUpdater(false);
            Debug.Log("хинкали готовы!");
        }
    }

    void SpriteUpdater(bool isBoiling)
    {
        if (isBoiling)
            imgObj.sprite = khinkalisOnFire[_khinkalis.Count - 1];
        else
        {
            if (_khinkalis.Count == 0)
                imgObj.sprite = FullIdle;
            else
                imgObj.sprite = khinkalisIdle[_khinkalis.Count - 1];
        }
    }
}
