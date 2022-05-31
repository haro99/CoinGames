using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Coin, SetPos, LockObj;
    public Text CoinText, WinText, BonusText;
    public Button DropBton, PayBtn;
    public int[] slots, dividend, bonus;
    public int havecoin, line;

    // Start is called before the first frame update
    void Start()
    {
        CoinText.text = havecoin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
        }
    }

    public void SlotIn(int slotnumber)
    {
        slots[slotnumber]++;

        if (SlotCheck())
            StartCoroutine(Reset());
        else
        {
            DiviCheck();
            WinText.text = dividend[line].ToString();
            if (line > 0)
                PayBtn.interactable = true;
        }
    }

    /// <summary>
    /// コインが二つ以上入っていないかチェック
    /// </summary>
    /// <returns></returns>
    public bool SlotCheck()
    {
        for(int i = 0; i< slots.Length;i++)
        {
            if(slots[i]>1)
            {
                return true; 
            }
        }

        return false;
    }

    public void DiviCheck()
    {
        line = 0;
        for (int i = 0; i < slots.Length - 1; i++)
        {
            if (slots[i] > 0 && slots[i + 1] > 0)
            {
                line++;
            }
        }
    }

    IEnumerator Reset()
    {
        yield return new WaitForSeconds(3);

        LockObj.SetActive(false);

        yield return new WaitForSeconds(5);

        for(int i = 0; i < slots.Length;i++)
        {
            slots[i] = 0;
        }
        line = 0;
        WinText.text = "0";
        LockObj.SetActive(true);
    }

    IEnumerator Roll()
    {
        int number = 0;
        for (int i = 0; i < 10; i++)
        {
            number = Random.Range(0, bonus.Length - 1);
            BonusText.text = bonus[number].ToString();
            yield return new WaitForSeconds(0.3f);
        }

        havecoin += bonus[number];
        CoinText.text = havecoin.ToString();

    }

    public void CoinDrop()
    {
        if (havecoin > 0)
        {
            havecoin--;
            CoinText.text = havecoin.ToString();

            Instantiate(Coin, SetPos.transform.position, Coin.transform.rotation);
        }
        else
        {
            Debug.Log("メダルが足りません");
        }
    }

    public void GetCoin()
    {
        havecoin += dividend[line];
        CoinText.text = havecoin.ToString();

        StartCoroutine(Reset());
        PayBtn.interactable = false;
    }

    public void SlotStart()
    {
        StartCoroutine(Roll());
    }

    public void SceneChange(int number)
    {
        SceneManager.LoadScene(number);
    }
}
