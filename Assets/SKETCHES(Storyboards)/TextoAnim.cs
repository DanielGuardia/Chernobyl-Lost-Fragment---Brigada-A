using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoAnim : MonoBehaviour
{
    string frase = "El ser Humano es impredesible en sus acciones1111111111111111111111111111111111111111111111111111111111111111111111111111";
    //string frase2 = "muchas de estas historias";
    public Text texto;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Reloj());
    }

    IEnumerator Reloj()
    {
        foreach (char caracter in frase)
        {
            texto.text = texto.text + caracter;
            yield return new WaitForSeconds(0.1f);
        }

        //foreach (char caracter in frase2)
        //{
        //    texto.text = texto.text + caracter;
        //    yield return new WaitForSeconds(0.1f);
        //}
    }
}