using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GMMachineGuess : MonoBehaviour
{
    public int[] digits = new int[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };


    public string lastMove;
    public string answer;
    public string SecNumString;
    public InputField secNum;
    public InputField ps;
    public InputField ms;
    public List<string> possiblenumbers;
    public Text bigtext;
    public Text ShowSN;
    void Start()
    {
        DisplayBigText("Ingresa un numero de 4 digitos");
        StartGame();
        MakeMove();

    }

    public void GiveAnswer()         // llamado con el boton, crea el string de answer, arranca el sistema e imprime.
    {
        answer = "+" + ps.text + "-" + ms.text;
        TakeAnswer(answer);
        MakeMove();
        DisplayBigText("Ingrese Buenos y Regulares para: " + lastMove);

        if (SecNumString == lastMove)
        {

            bigtext.text = "TU NUMERO ES:  " + lastMove;

        }
        if (lastMove == "Error")
        {
            DisplayBigText("los numeros ingresados estaban equivocados");
        }
    }




    public List<string> PosiblesNumeros()
    {      // seleciona los digitos.

        List<string> numbers = new List<string>();
        for (int d1 = 0; d1 < digits.Length; d1++)
            for (int d2 = 0; d2 < digits.Length; d2++)
                for (int d3 = 0; d3 < digits.Length; d3++)
                    for (int d4 = 0; d4 < digits.Length; d4++)
                    {
                        if (d1 != d2 && d1 != d3 && d1 != d4
                               && d2 != d3 && d2 != d4
                                && d3 != d4)
                        {
                            numbers.Add((digits[d1].ToString() + digits[d2].ToString() + digits[d3].ToString() + digits[d4].ToString()));
                        }
                    }

        return numbers;
    }


    public string MakeMove()
    {
        if (possiblenumbers.Count > 0)
        {
            lastMove = possiblenumbers[Random.Range(0, possiblenumbers.Count)]; // mueve el numero del arrray usado a uno nuevo para mantenerlo y comprar en otros metodos
            return lastMove;
        }

        else
        {
            return lastMove = "Error";
        }
    }

    public void PrunePossibleMovesForTheAnswer(string guess, string answer)  // descarta los numeros que no coinciden con la respuesta del jugador
    {
        for (int i = 0; i < possiblenumbers.Count; i++)
        {
            string token = possiblenumbers[i];
            if (AnswerToGuess(token, guess) != answer)
                possiblenumbers.RemoveAt(i--);
        }
    }
    public string AnswerToGuess(string token, string guess)     // busca todos los resultados que tienen la misma cantidad de p y m que el usuario ingreso
    {
        int p = 0, m = 0;

        for (int i = 0; i < guess.Length; i++)
        {
            int pos = token.IndexOf(guess[i]);
            if (pos >= 0)
            {
                if (pos == i) p++;
                else m++;
            }
        }
        return "+" + p + "-" + m;
    }

    public string StartGame()            // inicia el primer list, vacia el lastmove, y regresa un numero de 4 digitos
    {
        possiblenumbers = PosiblesNumeros();
        //Debug.Log(possiblenumbers.Count);
        lastMove = string.Empty;
        return possiblenumbers[Random.Range(0, possiblenumbers.Count)];

    }

    public void TakeAnswer(string answer)     // pasa la variable de answer y last move al metodo para hacer las pruebas 
    {
        //   Debug.Log("entre a take awnser");
        PrunePossibleMovesForTheAnswer(lastMove, answer);

    }

    public void SelecNumSec()
    {          // metodo para mostrar la selección de numero secreto

        SecNumString = secNum.text;
        ShowSN.text = SecNumString;

        DisplayBigText("Ingrese Buenos y Regulares para: " + lastMove);
    }

    public void DisplayBigText(string BT)
    {

        bigtext.text = BT;
    }

    public void RestartGame()
    {

        DisplayBigText("Ingresa un numero de 4 digitos");
        StartGame();
        MakeMove();
    }

   

}

