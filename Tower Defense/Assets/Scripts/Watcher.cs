using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class Watcher : MonoBehaviour
{
    public TextMeshProUGUI purse;
    public int coins = 0; //keeping track of score

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Greetings");
    }

    // Update is called once per frame
    void Update()
    {
        //Updating Score
        purse.text = "Coins: "+coins;

        // Test for mouse click(Raycast Stuff)
        if (Input.GetMouseButtonUp(0))
        {
            //Get mouse position in world space
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, 100f));

            //Get direction vector from camera position to m ouse position in world space
            Vector3 direction = worldMousePosition - Camera.main.transform.position;

            RaycastHit hit;

            // Cast a ray from the camera to the given direction
            if (Physics.Raycast(Camera.main.transform.position, direction, out hit, 100f))
            {
                //Debug.Log(hit.collider.gameObject.name);
                //Debug.Log("Hellow");
                //If it hits a Enemy
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    //Destroy(hit.collider.gameObject);
                    GameObject findEnemy = GameObject.FindGameObjectsWithTag("Enemy")[0];
                    Enemy enemyScript = findEnemy.GetComponent<Enemy>();
                    enemyScript.HP -= 1;
                    Debug.Log("Enemy has Taken 1 Damage");
                }


            }

        }
    }

}
