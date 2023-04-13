using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] GameObject _shield;
    [SerializeField] GameObject _projectileToSpawn;
    [SerializeField] Transform _projectileSpawnLocation;
    private GameObject _staff;
    private GameObject _sphereStaff;
    Material _fireEffect;
    Material _frostEffect;


    private int _life = 100;
    private int _maxLife = 100;

    enum Element { Fire, Frost };
    private Element _currentElement;

    void Start()
    {
        _fireEffect = Resources.Load("Materials/FireEffect", typeof(Material)) as Material;   
        _frostEffect = Resources.Load("Materials/Frost Effect/Frost", typeof(Material)) as Material;
        _currentElement = Element.Fire;
    }

    void Update()
    {
        Shader.SetGlobalVector("_WorldSpacePlayerPos", transform.position);

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

    public void UpdateLife(int valueToAdd)
    {
        // clamp the life between 0 and MaxLife;
        // if life == 0
        //    Visual effect + disable the movements of the player, etc etc...
    }
    public void ChangeElement()
    {
        _staff = GameObject.FindWithTag("Staff");
        _sphereStaff = GameObject.FindWithTag("SphereStaff");
        if(_currentElement == Element.Fire)
        {
            _sphereStaff.GetComponent<Renderer>().material = _frostEffect;
            _currentElement = Element.Frost;
        }
        else if(_currentElement == Element.Frost)
        {
            _sphereStaff.GetComponent<Renderer>().material = _fireEffect;
            _currentElement = Element.Fire;
        }
    }
}
