using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    private int _spriteVersion = 0;
    private string _spriteNames = "kleinFynn";
    private SpriteRenderer _spriteRenderer;
    private Sprite[] sprites;
    
    private void Start() {
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>(_spriteNames);
    }

    public void SpriteChange() {
        _spriteVersion += 1;
        if(_spriteVersion > 2) {
            _spriteVersion = 0;
        }
        _spriteRenderer.sprite = sprites[_spriteVersion];    
    }
}
