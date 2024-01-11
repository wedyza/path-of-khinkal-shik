using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Pot : MonoBehaviour, IDropHandler
{
    private List<Khinkali> _khinkalis;
    public Transform LinkedSpot;
    private Plate LinkedPlate;
    private Image imgObj;
    [SerializeField] private Player player;

    public Sprite FullIdle;
    public Sprite[] khinkalisIdle;
    public Sprite[] khinkalisOnFire;
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    public void Awake()
    {
        _khinkalis = new List<Khinkali>();
        imgObj = GetComponent<Image>();
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

    public IEnumerator Boil()
    {
        LinkedPlate = LinkedSpot.GetChild(0).GetComponent<Plate>();
        if (_khinkalis.Count > 0)
        {
            SpriteUpdater(true);
            yield return new WaitForSeconds(player.characteristics["cookingTime"].current);
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
