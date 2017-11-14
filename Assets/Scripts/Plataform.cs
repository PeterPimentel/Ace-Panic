using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour {

    public Transform plataform;
    public Transform positionA;
    public Transform positionB;
    private Vector3 destinyToward;
    public float speed;
    public float waitTime;
    private bool activate;

	// Use this for initialization
	void Start () {

        //A posição destino recebe a posição A (GameObject somente de referencia)
        destinyToward = positionA.position;
	}
	
	// Update is called once per frame
	void Update () {

        //objeto que vai mover = MoveTowards 1(posição de origem) 2(posição destino) 3(velocidade do movimento)
        plataform.position = Vector3.MoveTowards(plataform.position, destinyToward, speed*Time.deltaTime);

        /*
         * Se o activate for false e a plataforma estiver no destino A ou B
         * Chama a corrotine que será iniciada
         * Ativação é passada para true para ela não ser chamada denovo
         * e no final da execução ela é passada para false novamente
         * Execução final = waitForSeconds(20s) mais o tempo de descida
         * */
        if (plataform.position == destinyToward && !activate)
        {
            StartCoroutine("MovePlataform");
        }
	}

    //Função de corrotina serve para executar funções com tempo determinado
    IEnumerator MovePlataform()
    {
        activate = true;
        //Espera o tempo do waitForSeconds para executar o que vem embaixo
        yield return new WaitForSeconds(waitTime);

        //Esse trecho é executado depois do waitTime
        if(destinyToward == positionA.position)
        {
            destinyToward = positionB.position;
        }else if (destinyToward == positionB.position)
        {
            destinyToward = positionA.position;
        }
        activate = false;

    }
}
