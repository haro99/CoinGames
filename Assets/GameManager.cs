using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject CoinObj, SetPos;
    public Text[] Numbers;
    public int[] numbers;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(Turn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SlotStart()
    {
        for(int i = 0; i < 3; i++)
        {
            numbers[i] = Random.Range(1, 7);
            Numbers[i].text = numbers[i].ToString();
        }

        if (numbers[0] == numbers[1] && numbers[0] == numbers[2])
            StartCoroutine(Fever());

    }
    IEnumerator Fever()
    {
        for(int i = 0; i< 5;i++)
        {
            GameObject Coin = Instantiate(CoinObj, SetPos.transform.position, Quaternion.identity);
            Rigidbody RB = Coin.GetComponent<Rigidbody>();
            RB.AddForce(Vector3.up * 10f);
            Destroy(Coin, 5f);
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator Turn()
    {
        while(true)
        {
            Numbers[0].text = Random.Range(1, 9).ToString();
            Numbers[1].text = Random.Range(1, 9).ToString();
            Numbers[2].text = Random.Range(1, 9).ToString();
            yield return new WaitForSeconds(1);
        }
    }
}
