using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField]
    GameObject Candy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject newCandy = Instantiate(Candy);
            newCandy.transform.position = transform.position;
        }
        
    }
}
