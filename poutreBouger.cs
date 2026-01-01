using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using TMPro;
using UnityEngine;

public class poutreBouger : MonoBehaviour
{

    [SerializeField] private Vector3 axeRotation ;
    [SerializeField] private float vitesseRotation;

    
    // Start is called before the first frame update
    void Start()
    {
        axeRotation = new Vector3(0, 0, Random.Range(-1.0f, 1.0f)); 
        vitesseRotation = Random.Range(50.0f, 100.0f);
    }
    

    // Update is called once per frame
    void Update()
    {
        float angle = vitesseRotation * Time.deltaTime;
        transform.Rotate(axeRotation,angle);
    }

    
}
