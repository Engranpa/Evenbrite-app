using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private readonly int[] numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public int[] numRandom = new int[4];
    public int[] guesspersona = new int[4];


    public int correct = 0;
    public int casicorrect = 0;
    public int randomIndex;

    public InputField input;

    public Text G1;
    public Text G2;
    public Text G3;
    public Text G4;


    void Start()
    {
    }

    void Update()
    {


    }

    public void StartGame() {
        Reshuffle(numbers); //mezcla los numeros del array
        System.Array.Copy(numbers, numRandom, 4); // copia los primeros 4 numeros
    }
    public void Compare() {
        for (int i = 0; i < 4; i++)
        {
            if (numRandom[i] == guesspersona[i])  // compara cada casilla del array con la del otro
            {correct++;
            }
            else if (numRandom[i] == guesspersona[0] || numRandom[i] == guesspersona[1] || numRandom[i] == guesspersona[2] || numRandom[i] == guesspersona[3])
            { // si no es igual la compara con el resto 
                casicorrect++;
            }
        }

    }


    void Reshuffle(int[] numbers)
    {
        // Mezcla los numeros del array en diferente orden
        for (int t = 0; t < numbers.Length; t++)
        {
            int tmp = numbers[t];
            int r = Random.Range(t, numbers.Length);
            numbers[t] = numbers[r];
            numbers[r] = tmp;
        }
    }

    void GetInput()
    {

       

    }
  
}





