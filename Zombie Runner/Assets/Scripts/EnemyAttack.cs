using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] PlayerHealth target;
    [SerializeField] int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AttackHitEvent()
    {
        if (target == null) { return; }
        target.LoseHealth(damage);
    }
}
