using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class troncsTranslation : MonoBehaviour
{
    public float vitesse;
    private float ylimit = 20.0f; 
    private float direction = 1.0f;
    private bool jeuEnCours;
    
    // Start is called before the first frame update
    void Start()
    {
        vitesse = Random.Range(30.0f, 40.0f);
        jeuEnCours=false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
        transform.position += new Vector3 (0,direction * vitesse * Time.deltaTime,0);
        if (transform.position.y >= ylimit || transform.position.y <= -ylimit)
        {
            direction *= -1;
        }
        if (transform.position.y <= -13)
        {
            vitesse = Random.Range(10.0f, 15.0f);
        }
        else if(transform.position.y > -13)
        {
            vitesse = Random.Range(30.0f, 40.0f);
        }
        
        

        
    }
}
