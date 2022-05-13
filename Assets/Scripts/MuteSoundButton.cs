using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteSoundButton : MonoBehaviour
{
    private bool muted = true;
    
    public Sprite notMutedPic;
    public Sprite mutedPic;
    private Image muteImage;

    private void Start()
    {
        muteImage = GetComponent<Image>();
        muteImage.sprite = notMutedPic;
    }

    public void MuteButton()
    {
        if (muted == true)
        {
            AudioListener.volume = 0;
            muteImage.sprite = mutedPic;
            muted = false;
        }
        else
        {
            AudioListener.volume = 1;
            muteImage.sprite = notMutedPic;
            muted = true;
        }
    }
}
