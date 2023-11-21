using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    [SerializeField] GameObject porta;
    SpriteRenderer render;
    [SerializeField] Sprite[] sprites;
    public Animator anim;
    void Start()
    {
        render = GetComponent<SpriteRenderer>();
        
    }

    
    void Update()
    {
        anim = porta.GetComponent<Animator>();
    }

    public void mudarVerde()
    {
        render.sprite = sprites[1];
    }

    public void mudarVermelho()
    {
        render.sprite = sprites[0];
    }

}
