using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoPersonaje : MonoBehaviour
{
    public float velocidad = 5.0f;
    public float fuerzaSalto = 8.0f;
    public int saltosDoblesPermitidos = 2;
    private int saltosRealizados = 0;

    void Update()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 movimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical) * velocidad * Time.deltaTime;

        transform.Translate(movimiento);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (saltosRealizados < saltosDoblesPermitidos)
            {
                Saltar();
                saltosRealizados++;
            }
        }

        // Reiniciar el juego cuando se presiona la tecla "R"
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        // Reiniciar el juego cuando el jugador se cae del escenario
        if (transform.position.y < -10) // Ajusta el valor -10 a la altura a la que consideras que el jugador se ha caído
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    void Saltar()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0, fuerzaSalto, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Suelo"))
        {
            saltosRealizados = 0;
        }
    }
}