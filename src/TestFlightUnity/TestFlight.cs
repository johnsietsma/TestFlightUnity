using System;
using System.Runtime.InteropServices;
using UnityEngine;

namespace TestFlightUnity
{
public static class TestFlight
{
    [DllImport ("__Internal")]
    private static extern void TF_TakeOff( string token );

    public static void TakeOff( string token )
    {
        if( Application.platform != RuntimePlatform.IPhonePlayer )
            return;

        TF_TakeOff( token );
    }

    [DllImport ("__Internal")]
    private static extern void TF_PassCheckpoint( string checkpoint );

    public static void PassCheckpoint( string checkpoint )
    {
        if( Application.platform != RuntimePlatform.IPhonePlayer )
            return;

        TF_PassCheckpoint( checkpoint );
    }

    [DllImport ("__Internal")]
    private static extern void TF_AddCustomEnvironmentInformation( string info, string key );

    public static void AddCustomEnvironmentInformation( string info, string key )
    {
        if( Application.platform != RuntimePlatform.IPhonePlayer )
            return;

        TF_AddCustomEnvironmentInformation( info, key );
    }

    [DllImport ("__Internal")]
    private static extern void TF_OpenFeedbackView();

    public static void OpenFeedbackView()
    {
        if( Application.platform != RuntimePlatform.IPhonePlayer )
            return;

        TF_OpenFeedbackView();
    }

    [DllImport ("__Internal")]
    private static extern void TF_SendFeedback( string feedback );

    public static void SendFeedback( string feedback )
    {
        if( Application.platform != RuntimePlatform.IPhonePlayer )
            return;

        TF_SendFeedback( feedback );
    }

    [DllImport ("__Internal")]
    private static extern void TF_SetDeviceID();

    public static void SetDeviceID()
    {
        if( Application.platform != RuntimePlatform.IPhonePlayer )
            return;

        TF_SetDeviceID();
    }

    [DllImport ("__Internal")]
    private static extern void TF_Log( string msg );

    public static void Log( string msg )
    {
        if( Application.platform != RuntimePlatform.IPhonePlayer )
            return;

        TF_Log( msg );
    }

    [DllImport ("__Internal")]
    private static extern void TF_Crash();

    public static void Crash()
    {
        if( Application.platform != RuntimePlatform.IPhonePlayer )
            return;

        TF_Crash();
    }
}
}

