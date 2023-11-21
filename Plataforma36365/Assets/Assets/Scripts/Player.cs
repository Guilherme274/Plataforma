using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor.Timeline;
using Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    float horizontal = 0;
    [SerializeField] float velocidade = 9f;
    [SerializeField] float forcaPulo = 3f;
    float vertical = 0;
    Animator anim;
    bool noChao;
    bool pulou;
    [SerializeField] bool entrou = false;
    int direcaoLado = 0;
    bool pertoPorta =  false;
    bool abriu =false;
    bool apertou = false;
    bool morreu = false;
    [SerializeField] Transform detectaSerra;
    [SerializeField] GameObject player;
    [SerializeField] Transform spawn;
    Porta porta;
    Interruptor interruptor;
    CinemachineVirtualCamera cam;
    [SerializeField] GameObject[] portas;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        porta = FindObjectOfType<Porta>();
        interruptor = FindObjectOfType<Interruptor>();
        cam = FindObjectOfType<CinemachineVirtualCamera>();
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * velocidade, rb.velocity.y);
    }

    private void Update()
    {
        anim.SetFloat("posicaoY", rb.velocity.y);
        vertical = transform.position.y;

        horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump") && noChao)
        {
            rb.AddForce(Vector2.up * forcaPulo);
            anim.SetBool("pulou", true);
            noChao = false;

        }
        else
        {
            if(Input.GetButtonDown("Jump") && noChao == false && pulou == false)
            {
                rb.AddForce(Vector2.up * forcaPulo);
                anim.SetBool("pulou", true);
                pulou = true;
            }
        }
        

        if(horizontal > 0)
        {
            direcaoLado = 1;
        }

        if(horizontal < 0)
        {
            direcaoLado = -1;
        }

        if(direcaoLado != 0)
        {
            transform.localScale = new Vector2(direcaoLado, transform.localScale.y);
        }

        if (Input.GetKeyDown(KeyCode.E) && entrou && !apertou)
        {
            abriu = true;
            apertou = true;
            Invoke("fecharPorta", 3f);
            interruptor.mudarVerde();
        }

        porta.anim.SetBool("destrancou", abriu);
        porta.anim.SetBool("abriu", pertoPorta);
       
        anim.SetFloat("posicaoX", Mathf.Abs(rb.velocity.x));

        if (morreu)
        {
            GameObject roboInstaciado = Instantiate(player, spawn.position, Quaternion.identity);
            Destroy(gameObject);
            morreu = false;
            cam.Follow = roboInstaciado.transform;
        }

        if(pertoPorta && abriu)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                this.transform.position = porta.par.transform.position;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
         if(collision.gameObject.tag == "chao")
         {
            anim.SetBool("pulou", false);

            noChao = true;
            pulou = false;
         }

         if(collision.collider.CompareTag("serra"))
         {
            morreu = true;
         }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("acido"))
        {
            morreu = true;
        }

        if(collision.CompareTag("porta"))
        {
            pertoPorta = true;
        }

        if(collision.CompareTag("interruptor"))
        {
            entrou = true;
            
        }

        if (collision.CompareTag("interruptor2"))
        {
            entrou = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("interruptor"))
        {
            entrou = false;
        }

        if (collision.CompareTag("interruptor2"))
        {
            entrou = false;
        }

        if (collision.CompareTag("porta"))
        {
            pertoPorta = false;
        }
    }

    void fecharPorta()
    {
        abriu = false;
        pertoPorta = false;
        apertou = false;
        interruptor.mudarVermelho();
    }
}
