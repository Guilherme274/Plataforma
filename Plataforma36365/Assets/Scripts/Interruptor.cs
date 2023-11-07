using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interruptor : MonoBehaviour
{
    [SerializeField] Sprite vermelho;
    [SerializeField] Sprite verde;
    SpriteRenderer spriteRenderer;
    float tempo;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {

    }

    public void MudarVermelho()
    {

        spriteRenderer.sprite = vermelho;
        
    }
    public void MudarVerde()
    {

        spriteRenderer.sprite = verde;

    }

}
