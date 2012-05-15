using System.Collections;
using TestFlightUnity;
using UnityEngine;

public class ExampleTestFlight : MonoBehaviour
{
    void Awake()
    {
        TestFlight.TakeOff( "253171cb1935bef24ac0d4fcb7928c65_NTk1MTIyMDEyLTA0LTIzIDAwOjU0OjExLjMzMjE4Mw" );
        TestFlight.Log( "Starting TestFlight exmaple" );
        TestFlight.AddCustomEnvironmentInformation( "Unity Version", Application.unityVersion );
        TestFlight.AddCustomEnvironmentInformation( "System Language", Application.systemLanguage.ToString() );
        TestFlight.PassCheckpoint( "Started TestFlight example." );
        TestFlight.SendFeedback( "This example is awesome!" );
        TestFlight.PassCheckpoint( "About to crash" );
    }

    void OnGUI()
    {
        if( GUI.Button( new Rect( 20, 20, 200, 100 ), "Crash" ) ) {
            TestFlight.Log( "Crashing..." );
            TestFlight.Crash();
        }

        if( GUI.Button( new Rect( 20, 220, 200, 100 ), "Leave Feedback" ) ) {
            TestFlight.Log( "Leaving feedback" );
            TestFlight.OpenFeedbackView();
        }
    }
}
