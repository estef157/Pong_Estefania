using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Bola : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float fuerza;
    private int puntuacionPlayer1 = 0;
    private int puntuacionPlayer2 = 0;


    [SerializeField] private TMP_Text textoScore1;
    [SerializeField] private TMP_Text textoScore2;
    private Vector3 posicionInicial;
    



    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector3(1, 1, 0).normalized * fuerza, ForceMode2D.Impulse);

        posicionInicial = transform.position;
    }

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Porteria1"))
        {
            puntuacionPlayer2++;
            textoScore2.SetText("Score: " + textoScore2);
            transform.position = posicionInicial;
            ReiniciarBola();
        }
        else if (other.gameObject.CompareTag("Porteria2"))
        {
            puntuacionPlayer1++;
            textoScore1.SetText("Score: " + textoScore1);
            transform.position = posicionInicial;
            ReiniciarBola();
        }

        
    }

    void ReiniciarBola()
    {
        rb.velocity = new Vector3(0, 0, 0);
        int numeroRandom = Random.Range(-1, 2);
        int numeroRandom2 = Random.Range(-1, 2);
        rb.AddForce(new Vector3(numeroRandom, numeroRandom2, 0).normalized * fuerza, ForceMode.Impulse);

        
        while (numeroRandom == 0 && numeroRandom2 == 0)
        {
            numeroRandom = Random.Range(-1, 2);
            numeroRandom2 = Random.Range(-1, 2);
        }


    }

    
}
