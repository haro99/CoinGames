using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitMissManager : MonoBehaviour
{
    public GameObject Coin, Set;
    public Text BetText;
    public Text[] RatoTexts;
    public FragScript[] Frags;
    public int havecoin, betcoin;

    // Start is called before the first frame update
    void Start()
    {
        BetText.text = betcoin.ToString();
        for(int i = 0; i< Frags.Length;i++)
        {
            Frags[i].SetRato(Random.Range(1, 9));
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Coin, Set.transform.position, Coin.transform.rotation);
        }
    }

    public void Hit(int rato)
    {
        Debug.Log(betcoin * rato + "–‡ƒQƒbƒgI");   
    }
}
