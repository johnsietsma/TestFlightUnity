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
        if( GUI.Button( new Rect( 20, 20, 200, 80 ), "Crash" ) ) {
            TestFlight.Log( "Crashing..." );
            TestFlight.PassCheckpoint( "About to crash" );
            TestFlight.Crash();
        }

        if( GUI.Button( new Rect( 20, 120, 200, 80 ), "Leave Feedback" ) ) {
            TestFlight.Log( "Leaving feedback" );
            TestFlight.OpenFeedbackView();
        }

        // Setup questions on the TestFlight websiight to match these checkpoints.
        if( GUI.Button( new Rect( 20, 220, 200, 80 ), "Q1" ) ) {
            TestFlight.Log( "Checkpoint Q1" );
            TestFlight.PassCheckpoint( "Q1" );
        }

        if( GUI.Button( new Rect( 20, 320, 200, 80 ), "Q2" ) ) {
            TestFlight.Log( "Checkpoint Q2" );
            TestFlight.PassCheckpoint( "Q2" );
        }

        if( GUI.Button( new Rect( 20, 420, 200, 80 ), "Q3" ) ) {
            TestFlight.Log( "Checkpoint Q3" );
            TestFlight.PassCheckpoint( "Q3" );
        }
    }
}
