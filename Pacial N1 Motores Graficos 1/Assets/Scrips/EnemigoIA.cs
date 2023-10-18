using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemigoIA : MonoBehaviour
{
    public float velocidad = 2.0f;
    public float cambiarDireccionIntervalo = 2.0f;
    public float distanciaReaccion = 5.0f; // Distancia a la que el enemigo reacciona al personaje
    public Transform personaje; // Referencia al objeto del personaje

    private Vector3 direccionActual;
    private float tiempoParaCambio;

    void Start()
    {
        tiempoParaCambio = cambiarDireccionIntervalo;
        CambiarDireccionAleatoria();
    }

    void Update()
    {
        tiempoParaCambio -= Time.deltaTime;

        if (tiempoParaCambio <= 0)
        {
            CambiarDireccionAleatoria();
            tiempoParaCambio = cambiarDireccionIntervalo;
        }

        // Calcula la distancia entre el enemigo y el personaje
        float distanciaAlPersonaje = Vector3.Distance(transform.position, personaje.position);

        // Si el personaje está lo suficientemente cerca, aleja al enemigo
        if (distanciaAlPersonaje < distanciaReaccion)
        {
            Vector3 direccionHaciaPersonaje = (transform.position - personaje.position).normalized;
            direccionActual = direccionHaciaPersonaje;
        }

        transform.Translate(direccionActual * velocidad * Time.deltaTime);
    }

    void CambiarDireccionAleatoria()
    {
        float randomX = UnityEngine.Random.Range(-1.0f, 1.0f);
        float randomZ = UnityEngine.Random.Range(-1.0f, 1.0f);
        direccionActual = new Vector3(randomX, 0, randomZ).normalized;
    }
}