using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serra : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float velocidade = 12f;
    [SerializeField] float velocidadeRotacao = 0.5f;
    [SerializeField] Transform limiteEsq;
    [SerializeField] Transform limiteDir;    
    int aleatorio;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        aleatorio = Random.Range(1, 2);
        if(aleatorio == 1)
        {
            rb.velocity = Vector2.right * velocidade;
            
        }
        else
        {
            rb.velocity = Vector2.left * velocidade;
            velocidadeRotacao = velocidadeRotacao * (-1);
        }
    }
    void Update()
    {
        Vector3 rotacaoAtual = transform.rotation.eulerAngles;

        if(transform.position.x >= limiteDir.position.x)
        {
            rb.velocity = Vector2.left * velocidade;
            velocidadeRotacao = velocidadeRotacao * (-1);
        }


        if (transform.position.x <= limiteEsq.position.x)
        {
            rb.velocity = Vector2.right * velocidade;
            velocidadeRotacao = velocidadeRotacao * (-1);
        }

        rotacaoAtual.z += velocidadeRotacao;

        transform.rotation = Quaternion.Euler(rotacaoAtual);
    }
}
