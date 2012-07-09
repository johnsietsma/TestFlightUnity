using System.Collections;
using TestFlightUnity;
using UnityEngine;

public class ExampleTestFlight : MonoBehaviour
{
    public string token;

    void Awake()
    {
        if( string.IsNullOrEmpty( token ) ) {
            Debug.LogError( "Please set your TestFlight SDK token in the editor." );
        }
        if( Debug.isDebugBuild ) {
            TestFlight.SetDeviceID();
        }
        TestFlight.AddCustomEnvironmentInformation( "Unity Version", Application.unityVersion );
        TestFlight.AddCustomEnvironmentInformation( "System Language", Application.systemLanguage.ToString() );
        TestFlight.TakeOff( token );
        TestFlight.Log( "Starting TestFlight example" );
        TestFlight.PassCheckpoint( "Started TestFlight example." );
        TestFlight.SendFeedback( "This example is awesome!" );
    }

    void OnGUI()
    {
        if( GUI.Button( new Rect( 20, 20, 200, 100 ), "Crash" ) ) {
            TestFlight.Log( "Crashing..." );
            TestFlight.PassCheckpoint( "About to crash" );
            TestFlight.Crash();
        }

        if( GUI.Button( new Rect( 20, 220, 200, 100 ), "Leave Feedback" ) ) {
            TestFlight.Log( "Leaving feedback" );
            TestFlight.OpenFeedbackView();
        }
    }
}
