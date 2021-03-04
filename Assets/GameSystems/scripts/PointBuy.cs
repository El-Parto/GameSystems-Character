using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PointBuy : MonoBehaviour
{
    public TextMeshProUGUI bankText;
    public TextMeshProUGUI stat1Text;
    public TextMeshProUGUI stat2Text;
    public TextMeshProUGUI stat3Text;
    public TextMeshProUGUI stat4Text;
    public TextMeshProUGUI stat5Text;
    public TextMeshProUGUI stat6Text;

    public int statBank = 10;
    public int stat1, stat2, stat3, stat4, stat5, stat6;

    public Button confirmButton;


    // Start is called before the first frame update
    void Start()
    {
        confirmButton.interactable = false;
    }




    public void RaiseStat(int value)
    {
        if (statBank <= 0)
            return;
        statBank--;
        bankText.text = statBank.ToString();
        switch (value)
        {
            case 1:
                stat1++;
                stat1Text.text = stat1.ToString();
                break;
            case 2:
                stat2++;
                stat2Text.text = stat2.ToString();
                break;
            case 3:
                stat3++;
                stat3Text.text = stat3.ToString();
                break;
            case 4:
                stat4++;
                stat4Text.text = stat4.ToString();
                break;
            case 5:
                stat5++;
                stat5Text.text = stat5.ToString();
                break;
            case 6:
                stat6++;
                stat6Text.text = stat6.ToString();
                break;
        }

        if (statBank != 0)
        {
            confirmButton.interactable = false;
        }
        else
        {
            confirmButton.interactable = true;
        }

        
    }

    public void RemoveStat(int value)
    {
        switch (value)
        {
            case 1:
                if (stat1 <= 0)
                    break;
                else
                {
                    stat1--;
                    stat1Text.text = stat1.ToString();
                    statBank++;
                    bankText.text = statBank.ToString();
                    break;
                }
            case 2:
                if (stat2 <= 0)
                    break;
                else
                {
                    stat2--;
                    stat2Text.text = stat2.ToString();
                    statBank++;
                    bankText.text = statBank.ToString();
                    break;
                }
            case 3:
                if (stat3 <= 0)
                    break;
                else
                {
                    stat3--;
                    stat3Text.text = stat3.ToString();
                    statBank++;
                    bankText.text = statBank.ToString();
                    break;
                }
            case 4:
                if (stat4 <= 0)
                    break;
                else
                {
                    stat4--;
                    stat4Text.text = stat4.ToString();
                    statBank++;
                    bankText.text = statBank.ToString();
                    break;
                }
            case 5:
                if (stat5 <= 0)
                    break;
                else
                {
                    stat5--;
                    stat5Text.text = stat5.ToString();
                    statBank++;
                    bankText.text = statBank.ToString();
                    break;
                }
            case 6:
                if (stat6 <= 0)
                    break;
                else
                {
                    stat6--;
                    stat6Text.text = stat6.ToString();
                    statBank++;
                    bankText.text = statBank.ToString();
                    break;
                }
        }
    }


    public void ConfirmStats(playerControls player)
    {
        player.creatingCharacter = false;

        for (int i = 0; i < stat1; i++) //for all the points we put into this stat, do this and repeat for 2 to 6
        {
            player.RaiseStat(1);
        }
        for (int i = 0; i < stat2; i++) //for all the points we put into this stat, do this and repeat for 2 to 6
        {
            player.RaiseStat(2);
        }
        for (int i = 0; i < stat3; i++) //for all the points we put into this stat, do this and repeat for 2 to 6
        {
            player.RaiseStat(3);
        }

        for (int i = 0; i < stat4; i++) //for all the points we put into this stat, do this and repeat for 2 to 6
        {
            player.RaiseStat(4);
        }
        for (int i = 0; i < stat5; i++) //for all the points we put into this stat, do this and repeat for 2 to 6
        {
            player.RaiseStat(5);
        }
        for (int i = 0; i < stat6; i++) //for all the points we put into this stat, do this and repeat for 2 to 6
        {
            player.RaiseStat(6);
        }


    }



    // Update is called once per frame
    void Update()
    {

    }
}
