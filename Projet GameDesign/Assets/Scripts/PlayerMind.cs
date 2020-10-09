using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMind : MonoBehaviour
{
    public bool dark = true;
    public float waitTime = 1.0f;
    private float timer = 0.0f;
    public int maxMind = 100;
    public int currentMind;
    public int addMind = 5;
    public GameObject tm1;
    public GameObject tm2;

    public MindBar mindBar;

    // Start is called before the first frame update
    void Start()
    {
        currentMind = maxMind;
        mindBar.SetMaxMind(maxMind);
    }

    private void WooshTilemaps()
    {
        if ( currentMind <= 66 && tm1.activeSelf)
        {
            tm1.SetActive(false);
        } else if (currentMind > 66 && !tm1.activeSelf)
        {
            tm1.SetActive(true);
        }
        if (currentMind <= 33 && tm2.activeSelf)
        {
            tm2.SetActive(false);
        } else if (currentMind > 33 && !tm2.activeSelf)
        {
            tm2.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            if (dark && currentMind > 0)
            {
                currentMind -= 1;
                mindBar.LoseOneMind();
            } else
            {
                currentMind += 5;
                if (currentMind > 100)
                {
                    currentMind = 100;
                }
            }
            timer -= waitTime;
        }
        mindBar.SetMind(currentMind);
        WooshTilemaps();
    }

    void RecoverMind(int mindRecover)
    {
        if (currentMind + mindRecover > 100)
        {
            currentMind = 100;
            mindBar.SetMind(currentMind);
        } else {
            currentMind += mindRecover;
            mindBar.SetMind(currentMind);
        }
    }

    public void SetDarkVariable(bool newDark)
    {
        dark = newDark;
    }
}
