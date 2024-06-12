using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float velocidade = 5;
    [SerializeField] private float alturaDoPulo = 10;
    public LayerMask groundLayer;
    public LayerMask wallLayer;

    private Rigidbody2D playerRb;
    private Animator anim;
    [SerializeField]
    private Transform castPoint;
    [SerializeField]
    private LayerMask layerPotion;

    private int lives = 1;
    private bool hasShield = false;
    private float shieldEndTime;

    public bool isDead;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<Animator>();
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Verifica se o jogador está colidindo com a camada do chão
        if (((1 << collision.gameObject.layer) & groundLayer) != 0 && transform.position.y > collision.transform.position.y)
        {
            Pular();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica se colidiu com uma parede
        if (((1 << collision.gameObject.layer) & wallLayer) != 0)
        {
            // Obtém o ponto médio da colisão para calcular a direção oposta
            Vector2 collisionPoint = collision.contacts[0].point;
            Vector2 playerPosition = transform.position;
            Vector2 oppositeDirection = (playerPosition - collisionPoint).normalized;

            // Aplica uma força contrária ao jogador
            playerRb.AddForce(oppositeDirection * velocidade, ForceMode2D.Impulse);
        }
    }


    private void Pular()
    {
        playerRb.velocity = Vector2.up * alturaDoPulo;
    }

    public void Die()
    {
        if (hasShield)
        {
            Debug.Log("Usou a Pot");
            hasShield = false; // Remove o escudo
        }
        else
        {
            Destroy(gameObject);
            isDead = true;
            SceneManager.LoadScene("GameOverScene");
        }
    }

    public void ActivateShield()
    {
        hasShield = true;
        shieldEndTime = 20f;
    }

    void Update()
    {
        //Escudo
        shieldEndTime -= Time.deltaTime;
        if (hasShield && shieldEndTime <= 0)
        {
            Debug.Log("Acabou a Pot");
            hasShield = false;
        }

        //Movimento
        float movimentoHorizontal = Input.GetAxis("Horizontal");
        playerRb.velocity = new Vector2(movimentoHorizontal * velocidade, playerRb.velocity.y);

        if (playerRb.velocity.y > alturaDoPulo)
        {
            playerRb.velocity = new Vector2(playerRb.velocity.x, alturaDoPulo);
        }
        Vector2 direction = new(castPoint.position.x, -450);
        RaycastHit2D hit = Physics2D.Raycast(castPoint.position, -Vector3.up, 20, layerPotion);
        Debug.DrawRay(castPoint.position, -Vector3.up, Color.red, 10);

        if (hit.collider != null)
        {
            Debug.Log("hit");
            hit.collider.gameObject.GetComponent<GarrafaPoderosa>().CrackB();
        }
    }
}