using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetrimo : MonoBehaviour
{

    public float fallspeed = 10;
    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkUserInput();
    }


    Vector3 round(Vector3 input) {
        return new Vector3(Mathf.Round(input.x),Mathf.Round(input.y),Mathf.Round(input.z));

    }


    bool isValid(Transform tetrimo) {

        foreach(Transform minimo in tetrimo){

            Vector3 pos = round(minimo.position);

            if (!FindObjectOfType<Game>().isInGrid(pos)) {
                return false;
            }
            

        }

        return true;
    }

    void checkUserInput() {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position += Vector3.left;
            if (isValid(transform))
            {

            }
            else
            {
                transform.position += Vector3.right;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position += Vector3.right;
            if (isValid(transform))
            {

            }
            else
            {
                transform.position += Vector3.left;
            }
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Rotate(0, 0, 90);
            transform.position = round(transform.position);
            if (isValid(transform))
            {

            }
            else
            {
                transform.Rotate(0, 0, -90);
                transform.position = round(transform.position);
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Time.time - time >= fallspeed) {
            transform.position += Vector3.down;
            if (isValid(transform))
            {

            }
            else {
                transform.position += Vector3.up;
            }

            time = Time.time;
        }
    }

    
}
