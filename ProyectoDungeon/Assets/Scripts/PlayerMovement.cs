using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum PlayerState
{
    idle,
    walk,
    attack,
    interact,
    stagger,
    death,
    pause
}

public class PlayerMovement : MonoBehaviour
{
    //SObjects
    public SOPlayer soPlayer;
    public float playerSpeed;
    public float playerMaxHP;
    public int playerGold;
    //asd
    public float playerCurrentHP;
    public PlayerState playerCurrentState;
    private Rigidbody2D playerRB;
    private Vector3 playerPosition;
    private Vector3 playerMovement;
    private Animator playerAnimator;
    public SOLocation playerStartingPostition;
    //UI
    
    public Image healthBar;
    public Image healthBarContainer;
    public Text healthText;
    public Text goldText;
    public GameObject tomb;
    public AudioSource hitSound;

    private void Awake()
    {

        playerSpeed = soPlayer.playerSpeed;
        playerMaxHP = soPlayer.playerMaxHP;
        playerGold = soPlayer.playerGold;

        playerCurrentHP = playerMaxHP;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerCurrentState = PlayerState.idle;
        playerRB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
        playerAnimator.SetFloat("dirY", -1);
        healthText.text = playerCurrentHP + " / " + playerMaxHP;
        goldText.text = "Gold: " + playerGold;
        transform.position = playerStartingPostition.initialPosition;
    }

    // Update is called once per frame
    void Update()
    {
        playerPosition = transform.position;
        playerMovement = Vector3.zero;
        playerMovement.x = Input.GetAxisRaw("Horizontal");
        playerMovement.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Fire1") && playerCurrentState != PlayerState.attack && playerCurrentState != PlayerState.stagger)
        {
            StartCoroutine(AttackCo());
        }
        else if (playerCurrentState == PlayerState.walk || playerCurrentState == PlayerState.idle && playerCurrentState != PlayerState.stagger)
        {
            AnimationAndMovement();
        }
        //Update gold text
        goldText.text = "Gold: " + playerGold;
    }

    void AnimationAndMovement() {
        if (playerMovement != Vector3.zero)
        {
            Movement();
            playerAnimator.SetFloat("dirX", playerMovement.x);
            playerAnimator.SetFloat("dirY", playerMovement.y);
            playerAnimator.SetBool("isMoving", true);
        }
        else
        {
            playerAnimator.SetBool("isMoving", false);
        }
    }

    void Movement()
    {
        playerMovement.Normalize(); //Normalizo el vector para que no se sumen los valores y no vayas rapido en diagonal
        playerRB.MovePosition((playerPosition) + (playerSpeed * playerMovement * Time.deltaTime));
    }

    public void KnockBack(float _knockTime) {
        StartCoroutine(KnockbackCo(_knockTime));
    }

    public void TakeDamage(float _enemyDamage) {
        StartCoroutine(TakeDamageCo(_enemyDamage));
        
    }

    public void UpdateGold(int _gold) {
        StartCoroutine(UpdateGoldCo(_gold));
    }

    //Coruotines
    private IEnumerator AttackCo()
    {
        hitSound.Play();
        playerAnimator.SetBool("isAttacking", true);
        playerCurrentState = PlayerState.attack;
        yield return null;
        playerAnimator.SetBool("isAttacking", false);
        yield return new WaitForSeconds(0.3f);
        playerCurrentState = PlayerState.walk;
    }

    private IEnumerator KnockbackCo(float _knockTime)
    {
        if (playerRB != null)
        {
            yield return new WaitForSeconds(_knockTime);

            playerRB.velocity = Vector3.zero;

            playerCurrentState = PlayerState.idle;
            playerRB.velocity = Vector3.zero;
        }
    }
    private IEnumerator TakeDamageCo(float _enemyDamage)
    {
        playerCurrentHP -= _enemyDamage;
        if (playerCurrentHP >= 0) {
            healthBar.fillAmount = playerCurrentHP / playerMaxHP;
            healthText.text = playerCurrentHP + " / " + playerMaxHP;
        }
        if (playerCurrentHP <= 0)
        {
            healthText.text = "0" + " / " + playerMaxHP;
            playerCurrentState = PlayerState.death;
            playerAnimator.SetBool("isDead", true);
            Instantiate(tomb, transform.position, Quaternion.identity);
            GameObject.FindGameObjectWithTag("DeathPanel").GetComponent<DeathManager>().GetScore(playerGold);
            this.gameObject.SetActive(false);
        }
        yield return null;
        
    }
    private IEnumerator UpdateGoldCo(int _gold) {
        playerGold += _gold;
        yield return null;
    }
}
