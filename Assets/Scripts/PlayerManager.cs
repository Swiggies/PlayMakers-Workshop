using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : IGameService
{
    // Variables here are stored and persistant through scenes
    
    // While these variables are not - they are set in here so they can be be retrieved from any controller without any expensive lookups
    public GameObject Player;
    public GameObject CameraTarget;
}
