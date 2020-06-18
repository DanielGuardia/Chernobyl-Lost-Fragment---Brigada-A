using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Jugador_Interfaz : MonoBehaviour
{
    private Jugador jugador;
    private Jugador_Ataque jugadorAtaque;
    private GameObject interfaz;
    private Image iVida;
    private TextMeshProUGUI iTextos;
    private string mensajeiTextosAntes;
    private BaulMateriales iBaul;
    private bool mostrarBaul = false; 
    public float timerMostarBaulComienzo = 5f;
    public KeyCode keyBaul;
    private float timerMostarBaul = 0f;
    private Image iCara;
    private TextMeshProUGUI iRadiacionTexto;
    private TextMeshProUGUI iBalasTexto;
    private TextMeshProUGUI iExplosivosTexto;

    private void Awake() 
    {
        GameObject jug = GameObject.Find("Player");
        jugador = jug.GetComponent<Jugador>();
        jugadorAtaque = jug.GetComponent<Jugador_Ataque>();
        interfaz = GameObject.Find("Interfaz_De_Partida");
        iVida = interfaz.transform.Find("Nivel_Vida").gameObject.transform.Find("Imagen").gameObject.GetComponent<Image>();
        iTextos = interfaz.transform.Find("Textos").GetComponentInChildren<TextMeshProUGUI>();
        iBaul = jugador.baulMateriales;
        iCara = interfaz.transform.Find("Cara_Personaje").GetComponent<Image>();
        iCara.sprite = jugador.caraActual;
        iRadiacionTexto = interfaz.transform.Find("Nivel_Radiacion").GetComponentInChildren<TextMeshProUGUI>();
        iBalasTexto = interfaz.transform.Find("N_Balas").GetComponentInChildren<TextMeshProUGUI>();
        iExplosivosTexto = interfaz.transform.Find("N_Explosivos").GetComponentInChildren<TextMeshProUGUI>();
        /*Mostar:
        vida
        hablar
        baul
        cara
        radiacion
        */
    }
    private void Update() 
    {
        //Vida
        iVida.fillAmount = (float)jugador.vida/100;
        //Hablar
        iTextos.text = jugador.hablar;
        //Baul
        if(Input.GetKeyDown(keyBaul))
        {
            if(mostrarBaul) mostrarBaul = false;
            else
            {
                mensajeiTextosAntes = iTextos.text;        
                timerMostarBaul = timerMostarBaulComienzo;
                mostrarBaul = true;
            }
        }
        if(mostrarBaul) 
        {
            //iTextos.text = "jfkdl";
            iTextos.text = jugador.baulMateriales.DevolverTodosLosObjetos();
            timerMostarBaul -= Time.deltaTime;
            if(timerMostarBaul <= 0)
            {
                iTextos.text = mensajeiTextosAntes;
                mostrarBaul = false;
            }            
        }
        //Cara
        iCara.sprite = jugador.caraActual;
        //Radiacion
        iRadiacionTexto.text = "" + jugador.NivelRadiacion;
        //N Balas
        iBalasTexto.text = "" + jugadorAtaque.balas;
        //N Explosivos
        iExplosivosTexto.text = "" + jugadorAtaque.explosivos;
    }
    public void OnClick_Baul()
    {
        mensajeiTextosAntes = iTextos.text;        
        timerMostarBaul = timerMostarBaulComienzo;
        mostrarBaul = true;
    }

}
