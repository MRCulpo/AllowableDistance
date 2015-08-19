using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void eventAllowableDistance(GameObject gameObject);
public class AllowableDistanceManager 
{
    private static AllowableDistanceManager allowableDistanceManager;

    private List<GameObject> allowableDistanceObjects;

    public eventAllowableDistance addAllowable;
    public eventAllowableDistance removeAllowable;

    public static AllowableDistanceManager instance
    {
        get 
        {
            if(allowableDistanceManager == null)
            {
                allowableDistanceManager = new AllowableDistanceManager();
            }
            return allowableDistanceManager;
        }
    }

    public List<GameObject> AllowableDistanceObjects
    {
        get 
        {
            return this.allowableDistanceObjects;
        }
        set 
        {
            this.allowableDistanceObjects = value;
        }
    }

    public void addAllowableDistanceObjects(GameObject _obj)
    {
        if (this.allowableDistanceObjects == null)
            this.allowableDistanceObjects = new List<GameObject>();
        this.allowableDistanceObjects.Add(_obj);
        if (this.addAllowable != null) this.addAllowable(_obj);
    }

    public void removeAllowableDistanceObjects(GameObject _obj)
    {
        if(this.allowableDistanceObjects != null)
        {
            this.allowableDistanceObjects.Remove(_obj);
            if (this.removeAllowable != null) this.removeAllowable(_obj);
        }
    }
}
