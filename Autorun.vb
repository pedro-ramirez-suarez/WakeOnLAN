﻿'    WakeOnLAN - Wake On LAN
'    Copyright (C) 2004-2015 Aquila Technology, LLC. <webmaster@aquilatech.com>
'
'    This file is part of WakeOnLAN.
'
'    WakeOnLAN is free software: you can redistribute it and/or modify
'    it under the terms of the GNU General Public License as published by
'    the Free Software Foundation, either version 3 of the License, or
'    (at your option) any later version.
'
'    WakeOnLAN is distributed in the hope that it will be useful,
'    but WITHOUT ANY WARRANTY; without even the implied warranty of
'    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
'    GNU General Public License for more details.
'
'    You should have received a copy of the GNU General Public License
'    along with WakeOnLAN.  If not, see <http://www.gnu.org/licenses/>.

Imports Microsoft.Win32

Public Class Autorun
    ReadOnly _currentUser As Microsoft.Win32.RegistryKey = Registry.CurrentUser.CreateSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run")

    Property AutoRun As Boolean
        Get
            With _currentUser
                .OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", False)
                If (.GetValue(My.Application.Info.ProductName, "", RegistryValueOptions.None) = "") Then
                    Return False
                Else
                    Return True
                End If
            End With
        End Get

        Set(value As Boolean)
            With _currentUser
                .OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
                If (value) Then
                    .SetValue(My.Application.Info.ProductName, """" & Application.ExecutablePath & """" & " /min")
                Else
                    .DeleteValue(My.Application.Info.ProductName, False)
                End If
            End With

        End Set

    End Property

End Class
