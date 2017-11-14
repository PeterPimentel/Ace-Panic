using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Importar para usar os recursos do CANVAS
using UnityEngine.UI;

//Import para gerenciar SCENES
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    private Rigidbody2D playerRigidbody2D;
    public float speed;
    
    //Variavel de texto do Canvas
    public Text scoreText;

    public int score;


	// Use this for initialization
	void Start () {
        //Instanciando o componente Rigidbody2D
        playerRigidbody2D = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
        //Atualizando o score do CANVAS
        scoreText.text = score.ToString();
        
        //Quando apertar o botão esquerdo(0)
        if (Input.GetMouseButtonDown(0))
        {
            Flip();
        }

        //Fazer o personagem se mover
        playerRigidbody2D.velocity = new Vector2(speed, playerRigidbody2D.velocity.y);
	}

    //Inverter personagem
    void Flip()
    {
        //Criar um V3 e recebe o valor de escala do objeto
        Vector3 scale = transform.localScale;
        //Inverte somente o X dessa escala
        scale.x *= -1;
        //Passa o valor de volta para a escala local
        transform.localScale = scale;
        //Inverte a velocidade para o objeto ir no sentido contratio
        //Essa velocidade é utilizada no Rigidbody.velocity
        speed *= -1;
    }


    //Função de teste de colisão da Unity
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //collision é o objeto que colidiu com o que tem o script
        //Player - tem o script/ collision é o espinho
        //Pega o obeto apartir da tag
        if (collision.gameObject.tag == "espinho")
        {
            GameOver();
        }
    }

    //Trigger da Unity (o Boxcollider é marcado como trigger)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Pega o obeto apartir da tag
        if (collision.gameObject.tag == "espinho")
        {
            GameOver();
        }
    }

    void GameOver()
    {
        //Grava a pontuação para exibir na tela de GameOver
        PlayerPrefs.SetInt("score", score);

        //PlayerPrefs é como se fosse o banco de dados da Unity
        if (score > PlayerPrefs.GetInt("recorde"))
        {
            //Setando o valor na variavel record
            PlayerPrefs.SetInt("recorde", score);
        }
        SceneManager.LoadScene("gameover");
    }
}
