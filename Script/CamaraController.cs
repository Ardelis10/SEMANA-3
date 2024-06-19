using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraController : MonoBehaviour
{
    
    //Referencia a nuestro jugador 
    public GameObject jugador; 

    //Para registrar la diferencia entre la posición de la cámara y la del jugador  
    private Vector3 offset;  

    // Start is called before the first frame update
    void Start()
    {
        //diferencia entre la posición de la cámara y la del jugador   
        offset = transform.position - jugador.transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        //Actualizo la posición de la cámara   
        transform.position = jugador.transform.position + offset; 
    }
}
