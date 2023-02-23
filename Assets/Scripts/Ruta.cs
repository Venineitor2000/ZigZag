using System.Collections;
using UnityEngine;


    public class Ruta : MonoBehaviour
    {
        public GameObject prefabRuta;
        //Para los bloques q ya pusiste a manos, poe su valor aca a mano tmb
        public Transform penultimoBloque;
        public Transform ultimoBloque;
        Vector3 diferencia;
        //Esto es para cuandohayq poner el bloque a la izquierda, lo calcule poniendo un bloque delante del ultimo y otro a su costado y sacando la difrencia en sus x
        float diferenciaXIzquierdaDerecha = -1.4142138f;
        int cantidadRuta;
        // Use this for initialization

        public void IniciarContruccion()
        {
            diferencia = ultimoBloque.position - penultimoBloque.position;
            InvokeRepeating("CrearnuevaParteRuta",0,0.3f);
        }

        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            
        }
    
        void CrearnuevaParteRuta()
        {
            Vector3 nuevaPosicion;
            float opcion = Random.Range(0, 100);
            if (opcion < 50)
                nuevaPosicion = ultimoBloque.position + diferencia;
            else
                nuevaPosicion = ultimoBloque.position + diferencia + new Vector3(diferenciaXIzquierdaDerecha, 0);

            ultimoBloque = Instantiate(prefabRuta,nuevaPosicion,prefabRuta.transform.rotation).transform;
            ultimoBloque.parent = gameObject.transform;
            cantidadRuta++;
            if(cantidadRuta % 5 == 0)
                ultimoBloque.GetChild(0).gameObject.SetActive(true);
        }
    }
