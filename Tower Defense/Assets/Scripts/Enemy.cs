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

    public int HP = 10;

  // Start is called before the first frame update
  void Start()
  {
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
    if(HP <= 0)
    {
        GameObject findWatcher = GameObject.FindGameObjectsWithTag("Watcher")[0];
        Watcher watcherScript = findWatcher.GetComponent<Watcher>();
        watcherScript.coins += 1;

        Debug.Log("Yoinks Scoob, I'm dead");
        Destroy(gameObject);
    }

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


}
