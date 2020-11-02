using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
  public Transform anchor;

  void Awake()
  {
    anchor = GetComponentsInChildren<Transform>()[1];
  }

  public void Damage(int amountOfHealth, int startingHealth)
  {
    float healthPercentage = Mathf.Clamp01(amountOfHealth / (float)startingHealth); // check value is between 0 and 1

    anchor.localScale = new Vector3(healthPercentage, anchor.localScale.y, anchor.localScale.z);
  }

}
