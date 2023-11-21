using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
    public Animator anim;
    [SerializeField] public GameObject par;
    
    void Start()
    {
        anim = FindObjectOfType<Animator>();
    }
    void Update()
    {
        
    }
}
