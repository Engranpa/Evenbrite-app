using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int[] numRandom = new int[4];
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
            else if (numRandom[i] == persona[0] || numRandom[i] == persona[1] || numRandom[i] == persona[2] || numRandom[i] == persona[3])
            {
                casicorrect++;
            }

        }




    }

    // Update is called once per frame
    void Update()
    {
      

    }

    /* void NumberGenerator()
    {
        Random rand = new Random();
        int[] randArray = { 10, 10, 10, 10 };

        for (int i = 0; i < randArray.Length; i++)
        {
            int temp
            while (temp == randArray[0] || temp == randArray[1] || temp == randArray[2] || temp == randArray[3])
            {
                temp = rand(9);
            }
            randArray[i] = temp;
        }**/
       
    }
}



