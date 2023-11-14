using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacao : MonoBehaviour
{
    float velocidadeRotacao = 0.5f;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        Vector3 rotacaoAtual = transform.rotation.eulerAngles;
        rotacaoAtual.z += velocidadeRotacao;
        transform.rotation = Quaternion.Euler(rotacaoAtual);
    }
}
