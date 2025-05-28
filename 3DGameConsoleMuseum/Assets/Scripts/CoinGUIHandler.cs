using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinGUIHandler : MonoBehaviour
{


    public static CoinGUIHandler main;

    public GameObject coinsGUI;
    public Text coinsText;
    private int coinsCollected = 0;

    private Coroutine coinsCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        main = this;
    }


    IEnumerator showGuiForSeconds(float delay)
    {
        coinsGUI.SetActive(true);
        yield return new WaitForSeconds(delay);
        coinsGUI.SetActive(false);
    }

    public void addCoin()
    {
        coinsCollected++;
        coinsText.text = "Total Coins: " + coinsCollected;
        if (coinsCoroutine != null)
            StopCoroutine(coinsCoroutine);
        coinsCoroutine = StartCoroutine(showGuiForSeconds(3));
    }

}
