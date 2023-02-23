using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguimientoCamara : MonoBehaviour
{
    public Transform objetivo;
    Vector3 diferencia;
    // Start is called before the first frame update
    private void Awake()
    {
        diferencia = transform.position - objetivo.position;
    }

    //Se aciva en cadda cuadro pero solo si hay un cambio en pantalla, sino no hace nada, para ahorrar recursos
    private void LateUpdate()
    {
        transform.position = objetivo.position + diferencia;
    }
}
