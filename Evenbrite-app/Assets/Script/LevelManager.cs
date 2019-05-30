using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public void HumanVSMachine()
    {
        SceneManager.LoadScene(1);
    }
    public void MachineVsHuman()
    {
        SceneManager.LoadScene(2);
    }

    public void ToMenu() {
        SceneManager.LoadScene(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
