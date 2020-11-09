using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Tower : MonoBehaviour
{
    public List<Enemy> currentEnemies;
    public Enemy currentTarget;

    public GameObject turret;
    private LineRenderer lineRenderer;// = new LineRenderer();

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, GetComponent<SphereCollider>().radius);
    }

    void Update()
    {
        if(currentTarget)
        {
            lineRenderer.SetPosition(0, turret.transform.position);
            lineRenderer.SetPosition(1, currentTarget.transform.position);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Enemy newEnemy = collider.GetComponent<Enemy>();
        currentEnemies.Add(newEnemy);

        newEnemy.DeathEvent.AddListener(delegate { BookKeeping(newEnemy);  });

        evaluateTarget(newEnemy);
    }

    void OnTriggerExit(Collider collider)
    {
        Enemy enemyLeaving = collider.GetComponent<Enemy>();
        //enemyLeaving.DeathEvent.RemoveListener(delegate { BookKeeping(enemyLeaving); });  //unsubscribing to the DeathEvent for this enemy

        currentEnemies.Remove(enemyLeaving); //clean up
        evaluateTarget(enemyLeaving);

    }

    private void BookKeeping(Enemy enemy)
    {
        currentEnemies.Remove(enemy);
        evaluateTarget(enemy);
    }

    private void evaluateTarget(Enemy enemy)
    {
        if (currentTarget == enemy)
        {
            currentTarget = null;
            lineRenderer.enabled = false;
        }

        if (currentTarget == null)
        {
            currentTarget = currentEnemies[0];
            lineRenderer.enabled = true;
        }
    }
}
