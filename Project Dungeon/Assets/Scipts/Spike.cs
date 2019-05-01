using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public bool Active;
    [SerializeField] int Damage;
    [SerializeField] int spriteVersion = 0;
    //private SpriteRenderer spriteR;
    private BoxCollider2D boxCollider2D;
    public Animator animator;
    
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //var spikeSprite = Resources.Load<Sprite>("Dungeon_Tileset_214");
        //var noSpikeSprite = Resources.Load<Sprite>("Dungeon_Tileset_216");
        if (Active)
        {
            //spriteR.sprite = spikeSprite;
            animator.SetBool("spikeActive", true);
            boxCollider2D.enabled = true;
        }
        else
        {
            //spriteR.sprite = noSpikeSprite;
            animator.SetBool("spikeActive", false);
            boxCollider2D.enabled = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ((collision.gameObject.name == "Player" || collision.gameObject.name == "Player(Clone)")&& Active)
        {
            collision.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(Damage); ;
            
        }
    }
}
