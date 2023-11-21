using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacaoSerra : MonoBehaviour
{
    Vector3 rotacaoAtual;
    float velocidadeRotacao = 10f;
    void Start()
    {
        
    }

    void Update()
    {
        rotacaoAtual = transform.rotation.eulerAngles;
        rotacaoAtual.z += velocidadeRotacao;
        transform.rotation = Quaternion.Euler(rotacaoAtual);
    }
}
