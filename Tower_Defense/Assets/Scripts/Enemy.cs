using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
  public Waypoints[] navPoints;
  private Transform target;
  private Vector3 direction;
  public float amplify = 1;
  private int index = 0;
  private bool move = true;
  private Purse purse;
  public int currentHealth = 100;
  private int startingHealth;
  public int cashPoints = 100;
  private HealthBar healthBar;

  // Start is called before the first frame update
  void Start()
  {
    purse = GameObject.FindGameObjectWithTag("Purse").GetComponent<Purse>();
    healthBar = GetComponentInChildren<HealthBar>();
    startingHealth = currentHealth;
    //Place our enemy at the start point
    transform.position = navPoints[index].transform.position;
    NextWaypoint();
    
    //Move towards the next waypoint
    //Retarget to the following waypoint when we reach our current waypoint
    //Repeat through all of the waypoints until you reach the end
  }

  // Update is called once per frame
  void Update()
  {
    if (move)
    {
      transform.Translate(direction.normalized * Time.deltaTime * amplify);

      if ((transform.position - target.position).magnitude < .1f)
      {
        NextWaypoint();
      }
    }

  }

  private void NextWaypoint()
  {
    if (index < navPoints.Length - 1)
    {
      index += 1;
      target = navPoints[index].transform;
      direction = target.position - transform.position;
    }
    else
    {
      move = false;
    }
  }

  public void TakeDamage(int amountDamage)
  {
    currentHealth -= amountDamage;
    if (currentHealth < 0)
    {
      purse.AddCash(cashPoints);
      Destroy(this.gameObject);
    }
    else
    {
      healthBar.Damage(currentHealth, startingHealth);
    }
  }

}
