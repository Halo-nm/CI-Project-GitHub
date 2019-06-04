using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternatingSpike : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] public bool Active;
    [SerializeField] int damageToDeal;
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
    /*private void OnCollisionEnter2D(Collision2D other)
    {
        other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToDeal);
    }*/
}
