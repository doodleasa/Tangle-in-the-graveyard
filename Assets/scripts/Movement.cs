using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Vector3[] DeathPoints;
    public Vector3 WinPoint;
    public bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        switch (UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex - 1)
        {
            case 0:
            DeathPoints = new Vector3[] {
                new Vector3(-1, 0, 0), //left side wall
                new Vector3(-1, 0, 1),
                new Vector3(-1, 0, 2),
                new Vector3(0, 0, -1), //bottom wall
                new Vector3(1, 0, -1),
                new Vector3(2, 0, -1),
                new Vector3(3, 0, 0), //right wall
                new Vector3(3, 0, 1),
                new Vector3(3, 0, 2),
                new Vector3(0, 0, 3), //top wall
                new Vector3(1, 0, 3),
                new Vector3(2, 0, 3),
                new Vector3(1, 0, 0), //maze part
                new Vector3(1, 0, 2)
            };
                WinPoint = new Vector3(2, 0, 2);
                break;
            case 1:
            DeathPoints = new Vector3[] {
                new Vector3(-1, 0, 0), //left side wall
                new Vector3(-1, 0, 1),
                new Vector3(-1, 0, 2),
                new Vector3(-1, 0, 3),
                new Vector3(-1, 0, 4),
                new Vector3(0, 0, -1), //bottom wall
                new Vector3(1, 0, -1),
                new Vector3(2, 0, -1),
                new Vector3(3, 0, -1),
                new Vector3(4, 0, -1),
                new Vector3(5, 0, 0), //right wall
                new Vector3(5, 0, 1),
                new Vector3(5, 0, 2),
                new Vector3(5, 0, 3),
                new Vector3(5, 0, 4),
                new Vector3(0, 0, 5), //top wall
                new Vector3(1, 0, 5),
                new Vector3(2, 0, 5),
                new Vector3(3, 0, 5),
                new Vector3(4, 0, 5),
                new Vector3(1, 0, 0), //maze part
                new Vector3(1, 0, 2),
                new Vector3(1, 0, 3),
                new Vector3(2, 0, 4),
                new Vector3(3, 0, 1),
                new Vector3(3, 0, 2),
                new Vector3(4, 0, 3)
            };
            WinPoint = new Vector3(4, 0, 4);
            break;
            case 2:
            DeathPoints = new Vector3[]
                {
                new Vector3(-1, 0, 0), //left side wall
                new Vector3(-1, 0, 1),
                new Vector3(-1, 0, 2),
                new Vector3(-1, 0, 3),
                new Vector3(-1, 0, 4),
                new Vector3(-1, 0, 5),
                new Vector3(-1, 0, 6),
                new Vector3(-1, 0, 7),
                new Vector3(0, 0, -1), //bottom wall
                new Vector3(1, 0, -1),
                new Vector3(2, 0, -1),
                new Vector3(3, 0, -1),
                new Vector3(4, 0, -1),
                new Vector3(5, 0, -1),
                new Vector3(6, 0, -1),
                new Vector3(7, 0, -1),
                new Vector3(8, 0, 0), //right wall
                new Vector3(8, 0, 1),
                new Vector3(8, 0, 2),
                new Vector3(8, 0, 3),
                new Vector3(8, 0, 4),
                new Vector3(8, 0, 5),
                new Vector3(8, 0, 6),
                new Vector3(8, 0, 7),
                new Vector3(0, 0, 8), //top wall
                new Vector3(1, 0, 8),
                new Vector3(2, 0, 8),
                new Vector3(3, 0, 8),
                new Vector3(4, 0, 8),
                new Vector3(5, 0, 8),
                new Vector3(6, 0, 8),
                new Vector3(7, 0, 8),
                new Vector3(0, 0, 3), //maze
                new Vector3(1, 0, 1),
                new Vector3(1, 0, 5),
                new Vector3(2, 0, 2),
                new Vector3(2, 0, 3),
                new Vector3(2, 0, 5),
                new Vector3(2, 0, 7),
                new Vector3(3, 0, 0),
                new Vector3(3, 0, 0),
                new Vector3(3, 0, 2),
                new Vector3(3, 0, 3),
                new Vector3(3, 0, 4),
                new Vector3(3, 0, 5),
                new Vector3(4, 0, 5),
                new Vector3(4, 0, 6),
                new Vector3(5, 0, 1),
                new Vector3(5, 0, 3),
                new Vector3(5, 0, 5),
                new Vector3(6, 0, 0),
                new Vector3(6, 0, 1),
                new Vector3(6, 0, 3),
                new Vector3(6, 0, 7),
                new Vector3(7, 0, 3),
                new Vector3(7, 0, 5),
            };
            WinPoint = new Vector3(7, 0, 7);
            break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Newpos = transform.position;
        if (!dead)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                Newpos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Newpos = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                Newpos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                Newpos = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
            }
            foreach (Vector3 point in DeathPoints)
            {
                if (Newpos == point)
                {
                    StartCoroutine(sceneMan(true));
                }
            }
            if (Newpos == WinPoint)
            {
                StartCoroutine(sceneMan(false));
            }
        }
        if(!dead)
        {
            transform.position = Newpos;
        }
    }
    IEnumerator sceneMan(bool shouldDie)
    {
        if (shouldDie)
        {
            dead = true;
            yield return new WaitForSeconds(1);
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
        else
        {
            yield return new WaitForSeconds(1);
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}