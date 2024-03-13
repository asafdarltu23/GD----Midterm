using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionsScript : MonoBehaviour
{
    public GameObject instruction;
    public GameObject[] thingsToHide;

    public void ShowInstructions()
    {
        instruction.SetActive(true);
        for (int i = 0; i < thingsToHide.Length; i++)
        {
            thingsToHide[i].SetActive(false);
        }
    }

    public void HideInstructions()
    {
        instruction?.SetActive(false);
        for (int i = 0; i < thingsToHide.Length; i++)
        {
            thingsToHide[i].SetActive(true);
        }
    }
}
