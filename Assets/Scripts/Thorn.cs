using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Thorn : MonoBehaviour {

    private Player playerScript;

    private Rigidbody2D thornRigidBody;
    public int minDrag;
    public int maxDrag;
    public float waitTime;
    private Vector3 startPosition;
    public GameObject thornPrefab;
    public GameObject explosionPrefab;
    public int points;

	// Use this for initialization
	void Start () {

        //Importando o script do Player
        //Fazendo os dois scripts conversarem
        playerScript = FindObjectOfType(typeof(Player)) as Player;

        startPosition = transform.position;
        
        //Inicializando o Rigibody
        thornRigidBody = GetComponent<Rigidbody2D>();
        
        //Não simular a física
        thornRigidBody.simulated = false;

        //Gerar um valor random de atrito
        int drag = Random.Range(minDrag, maxDrag);
        thornRigidBody.drag = drag;

        StartCoroutine("Drop");

	}
	
	IEnumerator Drop()
    {
        yield return new WaitForSeconds(Random.Range(1,waitTime));

        //Ativar a física
        thornRigidBody.simulated = true;
    }

    //colisão com qualquer coisa
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //1(objeto) 2(posição) 3(rotação)- mesma rotação desse objeto(this)
        GameObject tempThorn = Instantiate(thornPrefab, startPosition, transform.rotation) as GameObject;

        //Instanciada na posicao do espinho
        GameObject tempExplosion = Instantiate(explosionPrefab, transform.position, transform.rotation) as GameObject;
        //Destroy a explosao em 0.3 segundos
        Destroy(tempExplosion, 0.3f);

        //Para não deixar ele cair assim que for instanciado
        tempThorn.GetComponent<Rigidbody2D>().simulated = false;

        //Acessando o score do player e adicionando os pontos
        playerScript.score += points;

        //Destroi este o objeto que colidiu
        Destroy(this.gameObject);
    }
}
