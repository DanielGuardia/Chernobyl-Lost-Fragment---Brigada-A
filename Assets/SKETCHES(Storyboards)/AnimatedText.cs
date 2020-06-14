using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class AnimatedText : MonoBehaviour
{
    public string nombreNivel1;
	public float letterPaused = 0.025f;
	public string[] message;
	public Text textComp;
    public GameObject enter;

    private bool checkNext = false;
    private int lineaActual = 0;

	void Start()
    {
        textComp.text = "";
		StartCoroutine(TypeText(lineaActual));
	}

    private void Update()
    {
        if(checkNext)
        {
            enter.SetActive(true);
        }
        else
        {
            enter.SetActive(false);
        }

        if(lineaActual < message.Length - 1 && checkNext && Input.GetKeyDown(KeyCode.Return))
        {
            lineaActual++;

            checkNext = false;
            textComp.text = "";

            StartCoroutine(TypeText(lineaActual));
        }
        if(lineaActual == message.Length-1 && checkNext && Input.GetKeyDown(KeyCode.Return))
        {
            //SceneManager.LoadScene(nombreNivel1);
            SceneManager.LoadScene(1);
        }
        //Saltar **No incluir esto en version final
        if(Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene(1);
        }
    }

    IEnumerator TypeText(int line)
    {
        foreach(char letter in message[line].ToCharArray())
        {
            textComp.text += letter;

            yield return 0;
            yield return new WaitForSeconds(letterPaused);
        }

        checkNext = true;
    }

    public int getLineaActual()
    {
        return lineaActual;
    }

    public int getLastLine()
    {
        return message.Length - 1;
    }

    public bool getCheckNext()
    {
        return checkNext;
    }
}
