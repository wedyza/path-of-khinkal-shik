using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    [SerializeField] List<Sprite> sprites;
    int currentSpriteIndex;
    [SerializeField] Image _imageObj;
    [SerializeField] Button _buttonRight;
    [SerializeField] Button _buttonLeft;
    private Sounds sounds;
    
    public AudioClip clip;

    void Start()
    {
        sounds = GameObject.FindWithTag("sounds").GetComponent<Sounds>();
    }
    
    public void ChangeSprite(int step)
    {
        sounds.Play(clip);
        if (currentSpriteIndex < sprites.Count - 1 && step > 0 || currentSpriteIndex > 0 && step < 0) 
            currentSpriteIndex += step;
        if (currentSpriteIndex == 0) _buttonLeft.gameObject.SetActive(false);
        else if (currentSpriteIndex == sprites.Count - 1) _buttonRight.gameObject.SetActive(false);
        else 
        { 
            _buttonLeft.gameObject.SetActive(true);
            _buttonRight.gameObject.SetActive(true);
        }
    }

    public void ResetTutorial()
    {
        currentSpriteIndex = 0;
            _buttonLeft.gameObject.SetActive(false);
    }

    private void Update()
    {
        _imageObj.sprite = sprites[currentSpriteIndex];
    }
}
