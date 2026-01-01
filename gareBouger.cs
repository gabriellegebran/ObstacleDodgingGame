using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class gareBouger : MonoBehaviour
{
    public float vitesse;
    private float xlimit = 125.0f; 
    private float direction = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        vitesse = Random.Range(50.0f, 100.0f);
        
    }

    // Update is called once per frame
    void Update() 
    {
        transform.position += new Vector3 (direction * vitesse * Time.deltaTime,0,0);
        if (transform.position.x >= xlimit || transform.position.x <= -xlimit)
        {
            direction *= -1;
        }
    }
}
