using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    private readonly int[] numbers = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
    public int[] numRandom = new int[4];
    public int[] guesspersona = new int[4] { 0, 0, 0, 0 };


    public int correct = 0;
    public int casicorrect = 0;
    public bool error = false;
   
    public InputField input0;
    public InputField input1;
    public InputField input2;
    public InputField input3;
    public Text history;
  
    public Text g0;     
    public Text g1;
    public Text g2;
    public Text g3;
   


    void Start()
    {
        DisplayNumbers();
        Reshuffle(numbers); //mezcla los numeros del array
        System.Array.Copy(numbers, numRandom, 4); // copia los primeros 4 numeros
        history.text = "hay un numero secreto de 4 digitos, ingresa 4 numeros del 0 al 9! \n";
    }

    void Update()
    {


    }

    
    public void Compare()
    {
        correct = 0;
        casicorrect = 0;
        for (int i = 0; i < 4; i++)
        {
            if (guesspersona[0] == guesspersona[1] || guesspersona[0] == guesspersona[2] || numRandom[0] == guesspersona[2] || guesspersona[0] == guesspersona[3] || guesspersona[1] == guesspersona[2]
                || guesspersona[1] == guesspersona[3] || guesspersona[2] == guesspersona[3])
            {
                error = true;
            }
            else if (numRandom[i] == guesspersona[i])  // compara cada casilla del array con la del otro
            {
                correct++;
            }
            else if (numRandom[i] == guesspersona[0] || numRandom[i] == guesspersona[1] || numRandom[i] == guesspersona[2] || numRandom[i] == guesspersona[3])
            { // si no es igual la compara con el resto 
                casicorrect++;
            }
            
        }

        ConsoleHistory();
    }


    public void Reshuffle(int[] numbers)
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

    public void SelectNumbers(InputField x )         // toma el input y lo convierte a int, los asigna al array de numeros.
    {
        if (int.Parse(x.text) < 10)
        {
            if (x.text == input0.text)
            {
                guesspersona[0] = int.Parse(x.text);
            }
            if (x.text == input1.text)
            {
                guesspersona[1] = int.Parse(x.text);
            }
            if (x.text == input2.text)
            {
                guesspersona[2] = int.Parse(x.text);
            }
            if (x.text == input3.text)
            {
                guesspersona[3] = int.Parse(x.text);
            }
            
           
        }
        else
        {
            history.text = history.text + "Digito no correcto \n";
        }
        DisplayNumbers();


    }
    private void DisplayNumbers()
    {         //actualiza los numeros sobre el input
        g0.text = "" + guesspersona[0];
        g1.text = "" + guesspersona[1];
        g2.text = "" + guesspersona[2];
        g3.text = "" + guesspersona[3];
    }

    private void ConsoleHistory() {

        if (correct == 4)
        {
            history.text = "GANASTE!";
        }
        else if(error == true){
            history.text = "No se aceptan numeros duplicados \n";
            error = false;
        }

        else
        {

            history.text = history.text + "El numero " + guesspersona[0] + guesspersona[1] + guesspersona[2] + guesspersona[3] + " tiene: " + correct + "correctos y " + casicorrect + " numeros en diferentes casillas. \n";

        }
        
    }
}





