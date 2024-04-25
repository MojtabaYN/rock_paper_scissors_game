using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bot_And_Check : MonoBehaviour
{
    public enum All_Choices { Rock, Paper , Scissors }
    public enum Possible_Winners { Player, Bot, Draw }


    public All_Choices Player_pick;
    public All_Choices Bot_Pick;
    public Possible_Winners Winner;
    public Animator Player_Animator;
    public Animator Bot_Animator;
    public Image[] Bot_UI_Score;
    public Image[] Player_UI_Score;
    private int Player_Score_counter;
    private int Bot_Score_counter;
    public Animator Win_and_lose_Animator;
    private bool Game_Ended = false;
    public void Start_New_Round()
    {
        if (!Game_Ended)
        {
            Bot_Pick = Random_Bot_Func();
            Run_hands_animation(Player_pick, Bot_Pick);
            Winner = Winner_func(Player_pick, Bot_Pick);
            Score_update(Winner);
            Win_or_lose();
        }
    }

    public All_Choices Random_Bot_Func() //Random Bot Generator
    {
        int enumCount = System.Enum.GetValues(typeof(All_Choices)).Length;
        int randomIndex = Random.Range(0, enumCount);
        All_Choices randomEnum = (All_Choices)randomIndex;
        return (All_Choices)randomEnum;
    }

    public Possible_Winners Winner_func(All_Choices playerChoice , All_Choices botChoice)
    {
        if (playerChoice == botChoice)
        {
            // It's a tie
            return Possible_Winners.Draw;
        }
        else if ((playerChoice == All_Choices.Rock && botChoice == All_Choices.Scissors) ||
                 (playerChoice == All_Choices.Paper && botChoice == All_Choices.Rock) ||
                 (playerChoice == All_Choices.Scissors && botChoice == All_Choices.Paper))
        {
            // Player wins
            return  Possible_Winners.Player;
        }
        else
        {
            // Bot wins
            return Possible_Winners.Bot;
        }
    }

    public void Run_hands_animation(All_Choices playerChoice, All_Choices botChoice)
    {
        Bot_Animator.SetTrigger(botChoice.ToString());
        Player_Animator.SetTrigger(playerChoice.ToString());
    }

    public void Score_update(Possible_Winners The_Winner)
    {
        if(Possible_Winners.Player == The_Winner)
        {
            Player_Score_counter++;
            for (int i = 0; i < Player_Score_counter; i++)
            {
                // Example: Change the color of each image in the array
                Player_UI_Score[i].color = Color.white;
            }
        }
        else if (Possible_Winners.Bot == The_Winner)
        {
            Bot_Score_counter++;
            for (int i = 0; i < Bot_Score_counter; i++)
            {
                // Example: Change the color of each image in the array
                Bot_UI_Score[i].color = Color.white;
            }
        }
        else
        {
            //draw!
        }
        
    }

    public void Win_or_lose()
    {
        if(Bot_Score_counter==10)
        {
            Game_Ended = true;
            Win_and_lose_Animator.SetTrigger("Player_lose");
        }
        else if(Player_Score_counter == 10)
        {
            Game_Ended = true;
            Win_and_lose_Animator.SetTrigger("Player_Wins");
        }
    }


}
