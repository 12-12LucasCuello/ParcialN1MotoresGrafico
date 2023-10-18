using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMovimiento : MonoBehaviour
{
    public Transform objetivo; // El objeto al que seguir� la c�mara
    public float velocidadRotacion = 5.0f;

    private Vector3 offset; // La distancia inicial entre la c�mara y el objetivo

    void Start()
    {
        // Calcula la distancia inicial entre la c�mara y el objetivo
        offset = transform.position - objetivo.position;
    }

    void LateUpdate()
    {
        // Calcula la nueva posici�n de la c�mara
        float anguloObjetivo = objetivo.eulerAngles.y;
        Quaternion rotacion = Quaternion.Euler(0, anguloObjetivo, 0);
        Vector3 nuevaPosicion = objetivo.position + (rotacion * offset);

        // Aplica la nueva posici�n a la c�mara de manera suave
        transform.position = Vector3.Slerp(transform.position, nuevaPosicion, velocidadRotacion * Time.deltaTime);

        // Haz que la c�mara siempre mire al objetivo
        transform.LookAt(objetivo);
    }
}