using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public CharacterDB characterDB;
    public SpriteRenderer artworkSprite;
    private int selectedOption = 0;
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    private float timeToFire;
    public Transform firingPoint1;
    public Transform firingPoint2;
    public Transform firingPoint3;
    // public GameObject bullet;

    public Memory memory;
    private Vector3 touchPosition = Vector3.zero;
    private float InstaKillTime;
    private float DoubleMoneyTime;
    public GameObject[] bulletColors;

    [SerializeField] private AudioSource bulletSound;
    [SerializeField] private AudioSource TempUpgradeSound;
    [SerializeField] private AudioSource PermaUpgradeSound;
    [SerializeField] private AudioSource DeathSound;
    [SerializeField] private AudioSource CoinPickup;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateCharacter(memory.skingChoice);
    }

    private void UpdateCharacter(int selectedOption){
        Character character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            touchPosition.z = 0f;
        }else{
        }

        Shoot();
        
        if (InstaKillTime <= memory.score)
        {
            memory.instaKill = 0;
        }
        if (DoubleMoneyTime <= memory.score)
        {
            memory.doubleMoney = 0;
        }

        if (memory.bulletSpeed <= 20)
        {
            memory.bulletSpeed += memory.score/1500000;
        }
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(touchPosition.x, transform.position.y, 0f);
        
        // Adjust the player's position gradually using Lerp
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.fixedDeltaTime * memory.playerSpeed);

    }

    private void Shoot() {

        if (timeToFire <= 0f) {
            timeToFire = memory.fireRate;
            if (memory.numBulletsSpawn == 1)
            {
                bulletSound.Play();
                Instantiate(bulletColors[memory.bulletColor], firingPoint1.transform.position, firingPoint1.transform.rotation);
            }
            else if (memory.numBulletsSpawn == 2)
            {
                bulletSound.Play();
                Instantiate(bulletColors[memory.bulletColor], firingPoint1.transform.position, firingPoint1.transform.rotation);
                Instantiate(bulletColors[memory.bulletColor], firingPoint2.transform.position, firingPoint2.transform.rotation);
            }
            else
            {
                bulletSound.Play();
                Instantiate(bulletColors[memory.bulletColor], firingPoint1.transform.position, firingPoint1.transform.rotation);
                Instantiate(bulletColors[memory.bulletColor], firingPoint2.transform.position, firingPoint2.transform.rotation);
                Instantiate(bulletColors[memory.bulletColor], firingPoint3.transform.position, firingPoint3.transform.rotation);
            }
        }
        else {

            timeToFire -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "MoreFireRate")
        {
            Destroy(other.gameObject);
            PermaUpgradeSound.Play();
            if (memory.fireRate >= 0.06)
            {
                memory.fireRate-=0.05f;
            }
        }
        else if (other.tag == "MoreBulletsSpawn")
        {
            Destroy(other.gameObject);
            if (memory.numBulletsSpawn<=3)
            {
                TempUpgradeSound.Play();
                memory.numBulletsSpawn+=1;
                memory.fireRate+=0.05f;
            }
        }
        else if (other.tag == "MoreDamage")
        {
            Destroy(other.gameObject);
            PermaUpgradeSound.Play();
            memory.damage += 1;
        }
        else if (other.tag == "DoubleMoney")
        {
            Destroy(other.gameObject);
            TempUpgradeSound.Play();
            memory.doubleMoney = 1;
            DoubleMoneyTime = memory.score + 15;
        }
        else if (other.tag == "InstaKill")
        {
            Destroy(other.gameObject);
            TempUpgradeSound.Play();
            memory.instaKill = 1;
            InstaKillTime = memory.score + 10;
        }
        else if (other.tag == "Money")
        {
            if (memory.doubleMoney == 1)
            {
                memory.money+=10;
            }
            else
            {
                memory.money+=5;
            }
            Destroy(other.gameObject);
            CoinPickup.Play();
        }
        else if (other.tag == "ColorChange")
        {
            int randomIndex = Random.Range(0, bulletColors.Length);
            memory.bulletColor = randomIndex;
            Destroy(other.gameObject);
            PermaUpgradeSound.Play();
        }
    }
}
