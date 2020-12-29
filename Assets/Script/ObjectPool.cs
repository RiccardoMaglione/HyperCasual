using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    #region Variables
    public static ObjectPool SharedInstance;                            //Variabile statica per condividere l'istanza
    public List<GameObject> pooledObjects;                              //Lista di oggetti che saranno effettivamente presenti in scena dopo instanziati e sfruttabili
    [Header("Parameters of Object Pool")]
    public GameObject objectToPool;                                     //Oggetto da clonare per il pool
    public int amountToPool;                                            //Lunghezza massima della lista
    public bool IncreasePool;                                           //Variabile booleana per indicare che il pool non è fisso alla amountToPool ma può aumentare in caso di bisogno
    #endregion
    void Awake()
    {
        SharedInstance = this;                                          //Condivido l'istanza per usarla anche negli altri script
    }

    void Start()
    {
        pooledObjects = new List<GameObject>();                         //Inizializzo una nuova lista di GameObject chiamata pooledObjects
        GameObject tmp;                                                 //Definisco un oggetto temporaneo
        for (int i = 0; i < amountToPool; i++)                           //Ciclo: Per tutta la lunghezza della lista
        {
            tmp = Instantiate(objectToPool);                            //Instanzio l'oggetto prefab definito nella lista di pool nell'oggetto temporaneo
            tmp.SetActive(false);                                       //Disattivo l'oggetto appena instanziato
            pooledObjects.Add(tmp);                                     //Aggiungo l'oggetto temporaneo alla lista pooledObjects
        }
    }

    public GameObject GetPooledObject()                                 //Prende l'oggetto senza poszione e rotazione
    {
        for (int i = 0; i < amountToPool; i++)                           //Ciclo: Per tutta la lunghezza della lista
        {
            if (!pooledObjects[i].activeInHierarchy)                     //Se l'oggetto con indice i non è attivo
            {
                return pooledObjects[i];                                //Ritorno l'oggetto con quell'indice
            }
        }
        if (IncreasePool)                                               //Se IncreasePool è vero
        {
            GameObject increaseObj = Instantiate(objectToPool);         //Instanzio il nuovo oggetto
            pooledObjects.Add(increaseObj);                             //Aggiungo l'oggetto alla lista
            return increaseObj;                                         //Faccio ritornare l'oggetto che ho appena instanziato
        }

        return null;
    }
    public GameObject GetPooledObjectWithInfo(Vector3 PositionPooledObject, Quaternion RotationPooledObject)        //Prende l'oggetto con posizione e rotazione
    {
        for (int i = 0; i < amountToPool; i++)                                   //Ciclo: Per tutta la lunghezza della lista
        {
            if (!pooledObjects[i].activeInHierarchy)                             //Se l'oggetto con indice i non è attivo
            {
                pooledObjects[i].transform.position = PositionPooledObject;     //Setto la posizione direttamente nel pooler
                pooledObjects[i].transform.rotation = RotationPooledObject;     //Setto la rotazione direttamente nel pooler
                return pooledObjects[i];                                        //Ritorno l'oggetto con quell'indice
            }
        }
        if (IncreasePool)                                                       //Se IncreasePool è vero
        {
            GameObject increaseObj = Instantiate(objectToPool);                 //Instanzio il nuovo oggetto
            pooledObjects.Add(increaseObj);                                     //Aggiungo l'oggetto alla lista
            return increaseObj;                                                 //Faccio ritornare l'oggetto che ho appena instanziato
        }

        return null;
    }

    public void GeneralResetPooledObject(GameObject Go, Vector3 InitialPosition, Quaternion InitialRotation)
    {
        Go.SetActive(false);
        Go.transform.position = InitialPosition;
        Go.transform.rotation = InitialRotation;
    }

    public IEnumerator ResetPooledObjectWithTime(float WaitTime, GameObject Go, Vector3 InitialPosition, Quaternion InitialRotation)
    {
        yield return new WaitForSeconds(WaitTime);
        GeneralResetPooledObject(Go, InitialPosition, InitialRotation);
    }
}