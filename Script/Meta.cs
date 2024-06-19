using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{
    
    public List<Vector3> posiciones; // Lista de posiciones posibles
    public float intervaloMinimo = 2.0f; // Intervalo mínimo entre apariciones
    public float intervaloMaximo = 5.0f; // Intervalo máximo entre apariciones
    public float tiempoVisible = 2.0f; // Tiempo que el objeto permanece visible

    private Renderer rend;
    private Collider col;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        col = GetComponent<Collider>();
        StartCoroutine(ControlarAparicion());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ControlarAparicion()
    {
        while (true)
        {
            // Esperar un tiempo aleatorio antes de aparecer
            float tiempoEspera = Random.Range(intervaloMinimo, intervaloMaximo);
            yield return new WaitForSeconds(tiempoEspera);

            // Elegir una posición aleatoria de la lista
            int indicePosicion = Random.Range(0, posiciones.Count);
            transform.position = posiciones[indicePosicion];

            // Hacer que el objeto sea visible y activar su colisionador
            rend.enabled = true;
            col.enabled = true;

            // Esperar el tiempo visible
            yield return new WaitForSeconds(tiempoVisible);

            // Hacer que el objeto sea invisible y desactivar su colisionador
            rend.enabled = false;
            col.enabled = false;
        }
    }

}
