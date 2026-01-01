using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeplacementCube : MonoBehaviour
{
    [SerializeField]
    private float vitesseDeplacement;
    public TMP_Text tempsGare;
    public TMP_Text tempsChantier;
    public TMP_Text tempsForet;
    public TMP_Text valeurTemps;
    public TMP_Text tempsGareFinal;
    public TMP_Text tempsChantierFinal;
    public TMP_Text tempsForetFinal;
    public TMP_Text tempsTotalFinal;
    public TMP_Text meilleursTempsGare;
    public TMP_Text meilleursTempsChantier;
    public TMP_Text meilleursTempsForet;
    public TMP_Text meilleursTempsTotal;
    public TMP_Text nom1;
    public TMP_Text nom2;
    public TMP_Text nom3;
    public TMP_Text nom4;
    public Button demarrer;
    public TMP_InputField nom;
    public GameObject panel;
    public GameObject ecran;
    private float _tempsJeu;
    private float tempsInitial;
    private float tempsInitial1;
    private float tempsFinal;
    private float tempsTotal;
    private int penaliteGare=0;
    private int penaliteChantier=0;
    private int penaliteForet=0;
    private bool aFranchitGare = false;
    private bool aFranchitChantier = false;
    private bool aFranchitForet= false;
    private bool jeuEnCours;
    private float[] temps = new float[4];
    private float[] meilleursTemps = new float[4];
    private float[] positionN = new float[3];






    // Start is called before the first frame update
    void Start()
    {
        ecran.gameObject.SetActive(false);
        jeuEnCours=false;
        transform.position = new Vector3(0,1.5f,-225);
        vitesseDeplacement = 40.0f;
        tempsInitial1 = Time.time;
        meilleursTemps[0]= 65.0f;
        meilleursTemps[1]= 98.0f;
        meilleursTemps[2]= 69.0f;
        meilleursTemps[3]= 220.0f;
        positionN[0]=50;
        positionN[1]=350;
        positionN[2]=650;
        
    }
    public void demarrerBtn()
    {
        if (nom.text=="")
            Debug.Log("Entrez votre nom.");
        ecran.gameObject.SetActive(true);
        panel.gameObject.SetActive(false);
        jeuEnCours = true;
        transform.position = new Vector3(0,1.5f,-225);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            if (aFranchitGare==false)
            {
                transform.position = new Vector3(0,1.5f,positionN[0]); 
            }
            else if (aFranchitChantier == false)
            {
                transform.position = new Vector3(0,1.5f,positionN[1]);
            }
            else if (aFranchitForet== false)
            {
                transform.position = new Vector3(0,1.5f,positionN[2]);
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ecran.gameObject.SetActive(false);
            panel.gameObject.SetActive(true);
        }


        if(jeuEnCours==true)
        {
            _tempsJeu+=Time.deltaTime;
            valeurTemps.text = FormatTemps(_tempsJeu);
            float horizontal = Input.GetAxis("Horizontal") * vitesseDeplacement * Time.deltaTime;
            float vertical = Input.GetAxis("Vertical") * vitesseDeplacement * Time.deltaTime;
            float positionX = transform.position.x + horizontal;
            float positionY = transform.position.y;
            float positionZ = transform.position.z + vertical;
            transform.position = new Vector3(positionX, positionY, positionZ);
            if (positionX < -125 || positionX > 125 || positionZ < -250)
                return; 

            if (positionZ > 50 && !aFranchitGare)
            {
                tempsFinal = Time.time - tempsInitial1;
                temps[0]= tempsFinal;
                tempsGare.text = FormatTemps(tempsFinal);
                aFranchitGare = true;
                _tempsJeu = 0f;
                tempsInitial = Time.time;
                
            }

            if (positionZ > 350 && !aFranchitChantier)
            {
                
                tempsFinal = Time.time - tempsInitial;
                temps[1]= tempsFinal;
                tempsChantier.text = FormatTemps(tempsFinal); 
                aFranchitChantier = true;
                _tempsJeu = 0f;
                tempsInitial = Time.time;
                
            }
            if (positionZ > 650 && !aFranchitForet)
            {
                
                tempsFinal = Time.time - tempsInitial;
                temps[2]= tempsFinal;
                tempsForet.text = FormatTemps(tempsFinal);
                aFranchitForet = true;
                _tempsJeu = 0f;
                tempsTotal = Time.time - tempsInitial1;
                temps[3]= tempsTotal;
                jeuEnCours = false;

                ecran.gameObject.SetActive(false);
                panel.gameObject.SetActive(true);
                
                tempsGareFinal.text = FormatTemps(temps[0]);
                tempsChantierFinal.text = FormatTemps(temps[1]);
                tempsForetFinal.text = FormatTemps(temps[2]);
                tempsTotalFinal.text = FormatTemps(temps[3]);

                if (temps[0] < meilleursTemps[0])
                {
                    
                    meilleursTempsGare.text = FormatTemps(temps[0]);
                    
                    nom1.text = nom.text;

                }

                if (temps[1] < meilleursTemps[1])
                {
                    meilleursTempsChantier.text = FormatTemps(temps[1]);
                    
                    nom2.text = nom.text;

                }

                if (temps[2] < meilleursTemps[2])
                {
                    meilleursTempsForet.text = FormatTemps(temps[2]);
                    
                    nom3.text = nom.text;
                }
                if (temps[3]< meilleursTemps[3])
                {
                    
                    meilleursTempsTotal.text = FormatTemps(temps[3]);
                    
                    nom4.text = nom.text;
                }
                
            }    
        }
    }
    private string FormatTemps(float t)
    {
        int totalSeconds = (int)t;
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        return minutes.ToString("00") + ":" + seconds.ToString("00");
    }

   
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "train")
        { 
            transform.position = new Vector3(0,1.5f,-225);
            penaliteGare++;
            _tempsJeu = penaliteGare;
        }
            
        if (other.gameObject.tag == "poutre")
        {   
            transform.position = new Vector3(0,1.5f,50);
            penaliteChantier++;
            _tempsJeu = penaliteChantier;
        }

        if (other.gameObject.tag == "tronc")
        {
            transform.position = new Vector3(0,1.5f,350);
            penaliteForet++;
            _tempsJeu = penaliteForet;
        }
    } 

}
