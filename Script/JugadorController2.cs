using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class JugadorController2 : MonoBehaviour
{
    private Rigidbody rb;  // Declaro la variable de tipo RigidBody que luego asociaremos a nuestro Jugador 
    public float velocidad;  // Declaro la variable pública velocidad para poder modificarla desde la Inspector window    
    // Inicializo el contador de coleccionables recogidos  
    private int contador; 
    // Inicializo variables para los textos  
    public TMP_Text textoContador, textoGanar, Timer;
    private float tiempoRestante = 60.0f; // Variable para el tiempo restante
    private bool juegoTerminado = false;  // Variable para controlar si el juego ha terminado
    
    public Button boton; // Referencia al botón

    // Start is called before the first frame update
    void Start()
    {
        // Capturo esa variable al iniciar el juego   
        rb = GetComponent<Rigidbody>();  

        // Inicio el contador a 0   
        contador = 0; 
        
        setTextoContador();   // Inicio el texto de ganar a vacío   
        textoGanar.text = "";  
        boton.gameObject.SetActive(false); // Asegúrate de que el botón esté desactivado al inicio
    }

    // Update is called once per frame
    void Update()
    {
        if (juegoTerminado)
        {
            return;  // Si el juego ha terminado, no permitimos más movimientos
        }
           
        // Estas variables nos capturan el movimiento en horizontal y vertical de nuestro teclado   
        float movimientoH = Input.GetAxis("Horizontal");   
        float movimientoV = Input.GetAxis("Vertical");    
            
        // Un vector 3 es un trío de posiciones en el espacio XYZ, en este caso el que corresponde al movimiento   
        Vector3 movimiento = new Vector3(movimientoH, 0.0f, movimientoV);    
            
        // Asigno ese movimiento o desplazamiento a mi RigidBody   
        rb.AddForce(movimiento * velocidad);      
              
        // Decremento el tiempo restante
        tiempoRestante -= Time.deltaTime;

        // Actualizo el texto del temporizador
        Timer.text = "Tiempo: " + Mathf.Clamp(tiempoRestante, 0, 60).ToString("F2");

        // Si el tiempo llega a cero, muestro el mensaje de "Perdiste"
        if (tiempoRestante <= 0)
        {
            textoGanar.text = "¡Perdiste!";
            juegoTerminado = true;
            boton.gameObject.SetActive(true); // Muestra el botón al perder
        }
    }

    // Se ejecuta al entrar a un objeto con la opción isTrigger seleccionada  
    void OnTriggerEnter(Collider other)      
    {         
        if (other.gameObject.CompareTag("Coleccionable")) 
        {
            other.gameObject.SetActive(false); 

            // Incremento el contador en uno (también se puede hacer como contador++)
            contador = contador + 1; 

            // Actualizo el texto del contador    
            setTextoContador(); 
        } 
    } 

    // Actualizo el texto del contador (O muestro el de ganar si las ha cogido todas)  
    void setTextoContador()
    {   
        textoContador.text = "Contador: " + contador.ToString();   
        
        if (contador >= 1)
        {   
            textoGanar.text = "¡Ganaste!"; 
            juegoTerminado = true;  // El jugador ha ganado, detener el juego
            boton.gameObject.SetActive(true); // Muestra el botón al ganar
        } 
    }      
}
