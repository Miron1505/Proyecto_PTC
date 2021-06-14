using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private Transform theTransform = null;
    public bool shouldBeDestroyedOnDeath = true;
    public bool shouldShowFinal = false;

    public float healthPoints 
    {
        get {
            return _healthPoints;
        }
        
        set {

            _healthPoints = value;

            if (_healthPoints <= 0)
            {
                SendMessage("Die", SendMessageOptions.DontRequireReceiver);

                if(true)
                {
                    if(shouldBeDestroyedOnDeath)
                    {
                        Destroy(gameObject);
                    }

                    if (shouldShowFinal)
                    {
                        //GameController.FinalState();
                    }
                }

            }

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        // Cuando inicie obtenemos la posicion
        theTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //100% de la vida, solo puede ser tocada por Set y get del metodo healthPoints
    [SerializeField]
    private float _healthPoints = 100.0f;

}
