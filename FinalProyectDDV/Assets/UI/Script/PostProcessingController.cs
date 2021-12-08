using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class PostProcessingController : MonoBehaviour
{
    [SerializeField]private PostProcessProfile _postProcessProfile;
    private Bloom _bloom;
    // Start is called before the first frame update
    void Start()
    {
        _postProcessProfile.TryGetSettings(out _bloom);


    }

    public void _bloomOnOff(bool value)
    {
        _bloom.active = value;
    }

}
