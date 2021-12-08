using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class EffectController : MonoBehaviour
{   
    [SerializeField] private PostProcessVolume ppVolumeC1;
    [SerializeField] private PostProcessVolume ppVolumeC2;
    private Bloom _bloom;
    private Grain _grain;

    // Start is called before the first frame update
    void Start()
    {
        ppVolumeC1.profile.TryGetSettings(out _bloom);
	    ppVolumeC2.profile.TryGetSettings(out _grain);
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyDown("."))
	    {
		    BloomOnOff();
	    }
	
        if (Input.GetKeyDown("o"))
	    {
		    GrainOnOff();
	    }
        
    }

    private void BloomOnOff()
    {
        if (_bloom.active == true)
        {
            _bloom.active = false;
        }
        else if (_bloom.active == false)
        {
            _bloom.active = true;
        }
    }
    private void GrainOnOff()
    {
        if (_grain.active == true)
        {
            _grain.active = false;
        }
        else if (_grain.active == false)
        {
            _grain.active = true;
        }
    }
}
