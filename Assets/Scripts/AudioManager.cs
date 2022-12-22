using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public enum AudioType { Lobby, GameScene, Jump, Run, CountDown, NewScore, HighScore1, HighScore2, Graphic }

    public AudioSource lobbySound = null;     
    public AudioSource GameSceneSound = null;
    public AudioSource JumpSound = null;
    public AudioSource RunSound = null;
    public AudioSource CountDownSound = null;
    public AudioSource NewScoreSound = null;
    public AudioSource HighScoreSound1 = null;
    public AudioSource HighScoreSound2 = null;
    public AudioSource GraphicSound = null;

    public void PlaySound(AudioType type, bool isLoop)
    {
        AudioSource playSound = null;
        switch (type)
        {
            case AudioType.Lobby:
                playSound = lobbySound;
                break;

            case AudioType.GameScene:
                playSound = GameSceneSound;
                break;

            case AudioType.Jump:
                playSound = JumpSound;
                break;

            case AudioType.Run:
                playSound = RunSound;
                break;

            case AudioType.CountDown:
                playSound = CountDownSound;
                break;

            case AudioType.NewScore:
                playSound = NewScoreSound;
                break;

            case AudioType.HighScore1:
                playSound = HighScoreSound1;
                break;

            case AudioType.HighScore2:
                playSound = HighScoreSound2;
                break;

            case AudioType.Graphic:
                playSound = GraphicSound;
                break;
        }

        if (isLoop == true)
        {
            playSound.loop = true;
        }
        else
        {
            playSound.loop = false;
        }

        if(playSound.isPlaying == false)
            playSound.Play();
    }
}
