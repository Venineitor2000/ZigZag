using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text textoPuntaje;
    public Text textoPuntajeMaximo;
    int puntaje;
    public bool juegoIniciado;
    int puntajeMaximo;
    [SerializeField] GameObject tutorial;

    private void Awake()
    {
        cargarPuntaje();
        textoPuntajeMaximo.text = "Mejor: " + puntajeMaximo.ToString();
    }
    public void IniciarJuego()
    {
        tutorial.SetActive(false);
        juegoIniciado = true;
        FindObjectOfType<Ruta>().IniciarContruccion();
    }
    private void LateUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Space) && !juegoIniciado)
            IniciarJuego();
    }

    public void FinalizarJuego()
    {
        ActualizarPuntajeMaximo();
        SceneManager.LoadScene(0);
    }

    public void AumentarPuntaje()
    {
        puntaje++;
        textoPuntaje.text = puntaje.ToString();        
    }

    void ActualizarPuntajeMaximo()
    {
        if (puntaje > puntajeMaximo)
        {
            puntajeMaximo = puntaje;
            GuardarPuntaje();
        }            
    }
    void cargarPuntaje()
    {
        puntajeMaximo = PlayerPrefs.GetInt("PuntajeMaximo");
        
    }

    void GuardarPuntaje ()
    {     
            PlayerPrefs.SetInt("PuntajeMaximo", puntajeMaximo);
    }
}
