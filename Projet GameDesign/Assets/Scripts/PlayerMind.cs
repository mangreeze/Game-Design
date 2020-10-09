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

    public MindBar mindBar;

    // Start is called before the first frame update
    void Start()
    {
        currentMind = maxMind;
        mindBar.SetMaxMind(maxMind);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > waitTime)
        {
            if (dark && currentMind > 0)
            {
                currentMind = currentMind - 1;
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
