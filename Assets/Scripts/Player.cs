using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _shield;
    [SerializeField] GameObject _projectileToSpawn;
    [SerializeField] Transform _projectileSpawnLocation;

    public static int _life;
    private int _maxLife;
    private bool _isDead;

    private void Awake()
    {
        _life = 100;
        _maxLife = 100;
        _isDead = false;
    }
    void Update()
    {
        Shader.SetGlobalVector("_WorldSpacePlayerPos", transform.position);
        
        UpdateLife();

        if(!_isDead)
        {
            // Projectile
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                GameObject clone = Instantiate(_projectileToSpawn, _projectileSpawnLocation.transform.position, Quaternion.identity);
                clone.transform.forward = transform.forward;
            }

            // Shield
            if (Input.GetKeyDown(KeyCode.E))
                _shield.SetActive(!_shield.activeSelf);
        }
        if (_isDead)
        {
            gameObject.GetComponent<PlayerInput>().enabled = false;
        }
        Debug.Log(_life);
    }

    public void UpdateLife()
    {
        if(_life < 0) { _life = 0; }
        if (_life > _maxLife) { _life = _maxLife; }

        CheckHeal();

        if (_life == 0) 
        {
            _isDead = true;
            Destroy(gameObject, 3);
            //play dissolve effect
        }
    }

    void CheckHeal()
    {
        // if (bool = true){
        //  _life += _healAmout;
        // }
    }
}
