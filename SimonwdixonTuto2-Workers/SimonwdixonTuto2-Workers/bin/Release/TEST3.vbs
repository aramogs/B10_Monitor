If Not IsObject(application) Then
   Set SapGuiAuto  = GetObject("SAPGUI")
   Set application = SapGuiAuto.GetScriptingEngine
End If
If Not IsObject(connection) Then
   Set connection = application.Children(0)
End If
If Not IsObject(session) Then
   Set session    = connection.Children(0)
End If
If IsObject(WScript) Then
   WScript.ConnectObject session,     "on"
   WScript.ConnectObject application, "on"
End If
session.findById("wnd[0]").resizeWorkingPane 256,37,false
session.findById("wnd[0]/tbar[0]/okcd").text = "ZZMFP11"
session.findById("wnd[0]").sendVKey 0
session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/txtPLAPPLDATA-MAXQUA").text = "45"
session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/txtPLAPPLDATA-MAXQUA").setFocus
session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/txtPLAPPLDATA-MAXQUA").caretPosition = 2
session.findById("wnd[0]").sendVKey 0
session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0052/subAREA2:SAPLVHUDIAL2:0061/subPACKDIALOG:SAPLVHUSUBSC:0100/btnCREATE_HUS").press
session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA3:SAPLVHUDIAL2:0072/cntlHUCONTAINER/shellcont/shell").selectItem "          3","3"
session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA3:SAPLVHUDIAL2:0072/cntlHUCONTAINER/shellcont/shell").ensureVisibleHorizontalItem "          3","3"
session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/txtPLAPPLDATA-MAXQUA").text = "45"
session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/txtPLAPPLDATA-MAXQUA").setFocus
session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/txtPLAPPLDATA-MAXQUA").caretPosition = 2
