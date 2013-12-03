using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace TestFlightUnity
{
/// <summary>
/// The p/invoke wrapper around the C binding of the TestFlight SDK.
// <see href="https://testflightapp.com/sdk/doc/">
/// </summary>
public static class TestFlight
{
    [DllImport ( "__Internal" )]
    private static extern void TF_TakeOff( string token );

    [DllImport ( "__Internal" )]
    private static extern void TF_PassCheckpoint( string checkpoint );

    [DllImport ( "__Internal" )]
    private static extern void TF_AddCustomEnvironmentInformation( string info, string key );

    [DllImport ( "__Internal" )]
    private static extern void TF_OpenFeedbackView();

    [DllImport ( "__Internal" )]
    private static extern void TF_SendFeedback( string feedback );

    [DllImport ( "__Internal" )]
    private static extern void TF_SetDeviceID();

    [DllImport ( "__Internal" )]
    private static extern void TF_Log( string msg );

    [DllImport ( "__Internal" )]
    private static extern void TF_Crash();


    public static void TakeOff( string token )
    {
        if ( Application.platform == RuntimePlatform.IPhonePlayer ) {
            TF_TakeOff( token );
        }
        else if ( Application.platform == RuntimePlatform.Android ) {
#if UNITY_ANDROID
            using ( AndroidJavaClass jc = new AndroidJavaClass( "com.unity3d.player.UnityPlayer" ) )
            using ( AndroidJavaObject activity = jc.GetStatic<AndroidJavaObject>( "currentActivity" ) )
            using ( AndroidJavaObject app = activity.Call<AndroidJavaObject>( "getApplicationContext" ) ) {
                CallJavaTF( "takeOff", app, token );
            }
#endif
        }
    }


    public static void PassCheckpoint( string checkpoint )
    {
        if ( Application.platform == RuntimePlatform.IPhonePlayer ) {
            TF_PassCheckpoint( checkpoint );
        }
        else if ( Application.platform == RuntimePlatform.Android ) {
            CallJavaTF( "passCheckpoint", checkpoint );
        }
        else {
            Debug.LogWarning( "TestFlight: PassCheckpoint is not supported on your platform" );
        }
    }



    public static void AddCustomEnvironmentInformation( string info, string key )
    {
        if ( Application.platform == RuntimePlatform.IPhonePlayer ) {
            TF_AddCustomEnvironmentInformation( info, key );
        }
        else {
            Debug.LogWarning( "TestFlight: AddCustomEnvironmentInformation is not supported on your platform" );
        }

    }


    public static void OpenFeedbackView()
    {
        if ( Application.platform == RuntimePlatform.IPhonePlayer ) {
            TF_OpenFeedbackView();
        }
        else {
            Debug.LogWarning( "TestFlight: OpenFeedbackView is not supported on your platform" );
        }

    }


    public static void SendFeedback( string feedback )
    {
        if ( Application.platform == RuntimePlatform.IPhonePlayer ) {
            TF_SendFeedback( feedback );
        }
        else {
            Debug.LogWarning( "TestFlight: SendFeedback is not supported on your platform" );
        }
    }


    public static void SetDeviceID()
    {
        if ( Application.platform == RuntimePlatform.IPhonePlayer ) {
            TF_SetDeviceID();
        }
        else {
            Debug.LogWarning( "TestFlight: SetDeviceID is not supported on your platform" );
        }
    }


    public static void Log( string msg )
    {
        if ( Application.platform == RuntimePlatform.IPhonePlayer ) {
            TF_Log( msg );
        }
        else if ( Application.platform == RuntimePlatform.Android ) {
            CallJavaTF( "log", msg );
        }
        else {
            Debug.LogWarning( "TestFlight: Logging is not supported on your platform" );
        }

    }


    public static void Crash()
    {
        if ( Application.platform == RuntimePlatform.IPhonePlayer ) {
            TF_Crash();
        }
        else {
            Debug.LogWarning( "TestFlight: Crash is not supported on your platform" );
        }
    }

    private static void CallJavaTF( string method, params object[] args )
    {
#if UNITY_ANDROID
        if ( tf == null ) {
            tf = new AndroidJavaClass( "com.testflightapp.lib.TestFlight" );
        }
        tf.CallStatic( method, args );
#endif
    }
}
}

