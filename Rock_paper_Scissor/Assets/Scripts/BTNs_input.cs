using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Bot_And_Check;
using UnityEngine.SceneManagement;

public class BTNs_input : MonoBehaviour
{
    public All_Choices What_is_Button;
    
    public void Hit_Button()
    {
        GameObject.Find("Game_Manager").GetComponent<Bot_And_Check>().Player_pick = What_is_Button;
        GameObject.Find("Game_Manager").GetComponent<Bot_And_Check>().Start_New_Round();
    }

    public void Reset_Game_Scene()
    {
        SceneManager.LoadScene("Play");
    }

}
