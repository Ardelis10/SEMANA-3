using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paredes_Desaparecer : MonoBehaviour
{
    
    public float tiempoDesaparicion = 2.0f; // Duración durante la cual la pared desaparece
    public float intervaloMinimo = 5.0f; // Intervalo mínimo entre desapariciones
    public float intervaloMaximo = 15.0f; // Intervalo máximo entre desapariciones

    private Renderer rend;
    private Collider col;
    
    // Start is called before the first frame update
    void Start()
    {
      
        rend = GetComponent<Renderer>(); 
        col = GetComponent<Collider>();
        StartCoroutine(ControlarDesaparicion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ControlarDesaparicion()
    {
        while (true)
        {
            // Esperar un tiempo aleatorio antes de desaparecer
            float tiempoEspera = Random.Range(intervaloMinimo, intervaloMaximo);
            yield return new WaitForSeconds(tiempoEspera); //Espera un tiempo aleatorio antes de desaparecer la pared

            //Desactivan el renderizado (rend) y el colisionador(col) de la pared, respectivamente, haciéndola "desaparecer"
            rend.enabled = false;
            col.enabled = false;

            // Esperar el tiempo de desaparición
            yield return new WaitForSeconds(tiempoDesaparicion); //Espera el tiempo de desaparición antes de hacer que la pared reaparezca

            // Reaparecer la pared
            rend.enabled = true;
            col.enabled = true;
        }
    }

}
