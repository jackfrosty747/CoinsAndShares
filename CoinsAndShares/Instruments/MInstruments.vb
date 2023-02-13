﻿Imports System.ComponentModel

Namespace Instruments
    Module MInstuments
        Friend Enum EInstrumentType
            <Description("C")> Crypto
            <Description("S")> Share
        End Enum
        Friend Function GetInstrumentTypeFromCode(sCode As String, fSilent As Boolean) As EInstrumentType
            For Each i As EInstrumentType In [Enum].GetValues(GetType(EInstrumentType))
                If i.Code.Equals(sCode, StringComparison.CurrentCultureIgnoreCase) Then
                    Return i
                End If
            Next
            If fSilent Then
                Return EInstrumentType.Crypto
            End If
            Throw New WarningException(My.Resources.Error_ItemNotFound)
        End Function
        Friend Function GetInstrumentTypeFromName(sName As String, fSilent As Boolean) As EInstrumentType
            For Each i As EInstrumentType In [Enum].GetValues(GetType(EInstrumentType))
                If i.ToString.Replace("_", " ").Equals(sName.Replace("_", " "), StringComparison.CurrentCultureIgnoreCase) Then
                    Return i
                End If
            Next
            If fSilent Then
                Return EInstrumentType.Crypto
            End If
            Throw New WarningException(My.Resources.Error_InstrumentTypeNotValid)
        End Function
    End Module
End Namespace
