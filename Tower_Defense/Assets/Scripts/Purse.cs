using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Purse : MonoBehaviour
{
  public int currentCash = 1000;

  public TextMeshProUGUI purseText;

    // Start is called before the first frame update
    void Start()
    {
        SetCash();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetCash()
    {
      purseText.text = $"${currentCash}";
    }

    public void AddCash(int amountOfCash)
    {
      currentCash += amountOfCash;
      SetCash();
    }

    public bool PlaceTower(int amountOfCashRequired)
    {
      if (currentCash - amountOfCashRequired >= 0)  // Do I have enough cash?
      {
        currentCash -= amountOfCashRequired; //Update Purse Amount
        SetCash();  // Update GUI
        return true;  // Yea!! Tower can be added
      }

      return false;  //Not enough ... we broke
    }
}
