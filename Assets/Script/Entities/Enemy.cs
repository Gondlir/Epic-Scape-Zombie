using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] private int maxLife;
    [SerializeField] private int damage;
    [SerializeField] private int gold = 5;
    [SerializeField] private float velocity;
    [SerializeField] private Transform target;
    
    private PhysicsController physicsController;
    public List<GameObject> enemysList = new List<GameObject>();
    public int CurrentLife { get; set; }
    private void Awake()
    {
        physicsController = GetComponent<PhysicsController>();
        enemysList.Add(this.gameObject);
    }
    private void Update()
    {
        FollowPlayer();
    }
    public void LoseLife(int damage)
    {
        CurrentLife = maxLife - damage;
        HUDManager.instance.enemyLife.text = CurrentLife.ToString();
        if(CurrentLife >= 20)
            HUDManager.instance.enemyImgLife.color = Color.green;
        if (CurrentLife <= 20)
            HUDManager.instance.enemyImgLife.color = Color.red;
        if (CurrentLife <= 0)
        {
            Destroy(this.gameObject);
            SpawnGold();        
        }
        else
            maxLife = CurrentLife;
    }   
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Enemy Collision");
        if (collision.gameObject.tag == "Player")
        {     
            Player player = collision.gameObject.GetComponent<Player>();
            player.LoseLife(damage);
        }
    }

    void FollowPlayer() 
    {
        float followPos = (target.position.x > this.transform.position.x) ? velocity : -velocity;
        physicsController.Move(followPos);
    }

    public void SpawnGold() 
    {
        Player.instance.GoldMount(gold);
    }
}
