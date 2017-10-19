using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementNarwhal : MonoBehaviour
{
    /// <summary>
    /// Made By Zach
    /// This will handle the Narwhal movement.
    /// Controls: Swim around by following the left thumbstick. Dash by hitting X (Temp)
    /// </summary>

    Vector2 m_Direction;
    float m_Speed;
    float m_SpeedIncrease = 0.5f;
    float m_MaxSpeed = 15.0f;
    float m_DashSpeedBoost;
    const float DASH_SPEED_BOOST = 10.0f;
    const float BASE_SPEED = 10.0f;
    float m_SpeedIncreaseCounter;
    const float SPEED_INCREASE_COUNTER = 0.5f;

    float m_DashSpeedDecrement = 0.75f;
    

    bool m_IsDashing = false;
	// Use this for initialization
	void Start ()
    {
        m_Speed = BASE_SPEED;
        m_SpeedIncreaseCounter = SPEED_INCREASE_COUNTER;
        m_DashSpeedBoost = DASH_SPEED_BOOST;

    }
	
	// Update is called once per frame
	void Update ()
    {
        m_Direction = InputManager.getMovement(InputManager.InputTypes.Gamepad1);
        
        if(m_Direction.x != 0 || m_Direction.y != 0)
        {
            if (m_SpeedIncreaseCounter >= 0)
            {
                m_SpeedIncreaseCounter -= Time.deltaTime;
            }

            if(m_SpeedIncreaseCounter <= 0 )
            { 
                if(m_Speed < m_MaxSpeed)
                {
                    m_Speed += m_SpeedIncrease;
                }
                m_SpeedIncreaseCounter = SPEED_INCREASE_COUNTER;
                Debug.Log(m_Speed);
            }
        }
        else
        {
            m_Speed = BASE_SPEED;
        }

        if(InputManager.getDash(InputManager.InputTypes.Gamepad1))
        {
            if(!m_IsDashing)
            {
                Dash();
            }
        }

        if (m_IsDashing)
        {
            
            if (m_Speed > m_MaxSpeed)
            {
                m_Speed -= m_DashSpeedDecrement;
            }

            else
            {
                m_IsDashing = false;
                m_DashSpeedBoost = DASH_SPEED_BOOST;
            }
        }

        transform.Translate(m_Direction * m_Speed * Time.deltaTime);
	}

    void Dash()
    {
        m_IsDashing = true;
        m_Speed += m_DashSpeedBoost;
        // m_Direction = m_Direction * m_DashSpeed * Time.deltaTime;
    }
}
