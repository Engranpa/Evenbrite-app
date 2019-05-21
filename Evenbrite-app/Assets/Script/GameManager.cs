using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int[] numRandom;
    public int[] persona;
    public int i = 0;
    public int correct = 0;
    public int casicorrect = 0;
    void Start()
    {
          for (int i = 0; i < 4; i++)
          {
              if (numRandom[i] == persona[i])
              {
                  correct++;
              }
            else if (persona[i] == numRandom[0] || persona[i] == numRandom[1] || persona[i] == numRandom[2] || persona[i] == numRandom[3])
            {
                casicorrect++;
            }

        }


    }

    // Update is called once per frame
    void Update()
    {
      

    }

    }

