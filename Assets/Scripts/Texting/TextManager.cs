using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextManager : MonoBehaviour
{
    [SerializeField] Text sendText;
    [SerializeField] Text receiveText;

    [SerializeField] AudioSource textTone;

    [SerializeField] string[] messages;
    [SerializeField] string[] responses;

    WaitForSeconds TYPE_DELAY;
    WaitForSeconds RESPONSE_DELAY;

    // Start is called before the first frame update
    void Start()
    {
        TYPE_DELAY = new WaitForSeconds(0.05f);
        RESPONSE_DELAY = new WaitForSeconds(3.0f);

        sendText.text = "";
        receiveText.text = "";

        StartCoroutine(Texting());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Texting()
    {
        string currentMessage;
        string currentResponse;

        for (int i = 0; i < messages.Length && i < responses.Length; i++)
        {
            currentMessage = messages[i];
            currentResponse = responses[i];

            if (currentMessage.Length > 0)
            {
                yield return TypeText(sendText, currentMessage);
                yield return RESPONSE_DELAY;
                sendText.text = "";
                yield return RESPONSE_DELAY;
            }
            
            if (currentResponse.Length > 0)
            {
                receiveText.text = currentResponse;

                // Play audio
                textTone.Play();

                yield return RESPONSE_DELAY;
                receiveText.text = "";

                yield return RESPONSE_DELAY;
            }
        }

        SceneManager.LoadScene("cave");
    }

    IEnumerator TypeText(Text displayText, string message)
    {
        displayText.text = "";

        // Type message
        for (int x = 0; x < message.Length; x++)
        {
            yield return new WaitForSeconds(Random.value * 0.1f);
            displayText.text += message[x];
        }
    }
}
