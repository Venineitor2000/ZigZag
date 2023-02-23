using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{
    Rigidbody rb;
    
    bool caminarDerecha = true;
    public Transform inicioRayo1, inicioRayo2;
    Animator animator;
    GameManager gameManager;
    public GameObject particulasCristalPrefab;
    public AudioSource audioPickUP;
    // Start is called before the first frame update
    private void Awake()
    {
        
        gameManager = GameObject.FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameManager.juegoIniciado)
        {
            return;
        }
        else
            animator.SetTrigger("JuegoIniciado");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CambiarDireccion();
        }
        DetectarVacioYCaer();

        if (transform.position.y < -2)
            gameManager.FinalizarJuego();

    }

    private void FixedUpdate()
    {
        //El return; lo que hace es terminar la ejecucion del FixedUpdate cada vez q se llama,
        //osea impide q se ejecute el movimiento del player en cada llamado de fixedupdate 
        if (!gameManager.juegoIniciado)
        {
            return;
        }
        else
            animator.SetTrigger("JuegoIniciado");
        transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag.Equals("Cristal"))
        {
            audioPickUP.Play();
            GameObject instancia = Instantiate(particulasCristalPrefab, other.transform.position + new Vector3(0, 0.23f), Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(instancia,2);
            gameManager.AumentarPuntaje();
        }
            
    }

    void CambiarDireccion()
    {
        
        caminarDerecha = !caminarDerecha;
        if(caminarDerecha)
        {
            
            
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else
        {
            
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
    }

    void DetectarVacioYCaer()
    {

        bool noContacto1 = (!Physics.Raycast(inicioRayo1.position, -transform.up, Mathf.Infinity));
        bool noContacto2 = (!Physics.Raycast(inicioRayo2.position, -transform.up, Mathf.Infinity));
        if(noContacto1 && noContacto2)
        {
            
            animator.SetTrigger("Cayendo");
            GetComponent<CapsuleCollider>().isTrigger = true;
        }
            
    }
}
