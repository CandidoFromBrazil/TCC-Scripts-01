using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class Player : MonoBehaviour
{
    public float hp = 100;
    public float moveSpeed;   //Atributo que vai guardar a velocidade de movimento
    public Rigidbody2D rig2D; //Atributo que iremos guardar o RigdBody do Player
    public int enemiesDefeat = 0;

    public float moveX;  //Atributo referente a movimentação para direita e esquerda
    public float moveY;  //Atributo referente a movimenta��o para cima e baixo

    bool isMoving; //Atributo que vai ser true quando o player se move e false se estiver parado

    public Animator  anim;

    public Image heart; //Atributo que controla o preenchimento de Heart!
    public float maxHp = 100;

    // Start is called before the first frame update
    void Start() //M�todo executado apenas quando o jogo � iniciado
    {
        hp = maxHp;
        anim = GetComponent<Animator>(); //Atribuiu ao amim o nosso Animator 
    }

    // Update is called once per frame
    void Update() //M�todo executado a todo o momento
    {
        Movement(); //A cada Atualiza��o � chamado o M�todo Movement
        Animation(); //A cada Atualiza��o � chamado o M�todo Animation
        Attack(); // A cada Atualização é chamado o Método Ataque
        UpdateUI(); // A cada atualização é chamado o método UpdateUI

        if (hp <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        if (enemiesDefeat >= 1)
        {
            SceneManager.LoadScene("GameWin");
        }

    }
    
    void Movement() //M�todo respons�vel pela a��o de movimentar do Player
    {
        moveX = Input.GetAxisRaw("Horizontal"); //Verifica se a tecla est� sendo precionada e guarda no atributo MoveX
        moveY = Input.GetAxisRaw("Vertical");   //Verifica se a tecla est� sendo precionada e guarda no atributo MoveY

        rig2D.MovePosition(transform.position + new Vector3(moveX, moveY, 0) * moveSpeed * Time.deltaTime);
        //^^ Comando respons�vel por atualizar a posi��o do Player
    }

    void Animation() //M�todo respons�vel pela anima��o do Player
    {
        if(moveX == 0 && moveY == 0) //Se moveX e moveY forem igual a 0 � executado o bloco de dentro
        {
            isMoving = false;
        }
        else                        //Se n�o, � executado este bloco
        {
            isMoving = true;
        }

        anim.SetBool("isMoving", isMoving); 
        anim.SetFloat("Horizontal", moveX);
        anim.SetFloat("Vertical", moveY);
    }

    void Attack() //Metodo responsável pela animação de ataque do Player
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("isAttack");

        }       
    }

    void UpdateUI()
    {
        heart.fillAmount = hp / maxHp;
    }
}
