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
    private GameObject _staff;
    private GameObject _sphereStaff;
    Material _fireEffect;
    Material _frostEffect;

    public static int _playerLayer;
    public static bool hasKey = false;

    private int _life;
    private int _maxLife;
    private bool _isDead;

    enum Element { Fire, Frost };
    private Element _currentElement;

    private void Awake()
    {
        _life = 100;
        _maxLife = 100;
        _isDead = false;
        _playerLayer = gameObject.layer;
    }

    void Start()
    {
        _fireEffect = Resources.Load("Materials/FireEffect", typeof(Material)) as Material;
        _frostEffect = Resources.Load("Materials/Frost Effect/Frost", typeof(Material)) as Material;
        _currentElement = Element.Fire;
    }

    private void OnEnable()
    {
        Enemy.OnHit += LoseHealth;
        CollectibleItem.OnHeal += GainHealth;
    }

    private void OnDisable()
    {
        Enemy.OnHit -= LoseHealth;
        CollectibleItem.OnHeal += GainHealth;
    }

    void Update()
    {
        Shader.SetGlobalVector("_WorldSpacePlayerPos", transform.position);

        UpdateLife();

        if (!_isDead)
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
            if (Input.GetKeyDown(KeyCode.F))
                ChangeElement();
        }
        if (_isDead)
        {
            gameObject.GetComponent<PlayerInput>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectable"))
        {
            hasKey = true;
            other.gameObject.SetActive(false);
        }
    }

    public void UpdateLife()
    {
        if (_life < 0) { _life = 0; }
        if (_life > _maxLife) { _life = _maxLife; }

        if (_life == 0)
        {
            _isDead = true;
            Destroy(gameObject, 3);
            //play dissolve effect
        }

    }

    void GainHealth()
    {
        _life = 50;
    }

    private void LoseHealth()
    {
        _life -= 30;
    }

    public void ChangeElement()
    {
        _staff = GameObject.FindWithTag("Staff");
        _sphereStaff = GameObject.FindWithTag("SphereStaff");
        if (_currentElement == Element.Fire)
        {
            _sphereStaff.GetComponent<Renderer>().material = _frostEffect;
            _currentElement = Element.Frost;
        }
        else if (_currentElement == Element.Frost)
        {
            _sphereStaff.GetComponent<Renderer>().material = _fireEffect;
            _currentElement = Element.Fire;
        }
    }
}
