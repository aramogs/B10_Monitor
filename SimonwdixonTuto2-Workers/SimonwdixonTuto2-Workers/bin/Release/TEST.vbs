dim aTest
aTest = qParams

Dim args
Set args = WScript.Arguments

msgbox("Hello " + args.Item(0)) 

    Set SapGuiAuto = GetObject("SAPGUI")
    Set sapApplication = SapGuiAuto.GetScriptingEngine
    Set Connection = sapApplication.Children(0)
    Set session = Connection.Children(0)
       
    session.findById("wnd[0]").resizeWorkingPane 256, 37, False
    session.findById("wnd[0]/tbar[0]/okcd").Text = "se38"
    session.findById("wnd[0]").sendVKey 0
    session.findById("wnd[0]/usr/ctxtRS38M-PROGRAMM").Text = "zo_test1"
    session.findById("wnd[0]/usr/ctxtRS38M-PROGRAMM").caretPosition = 8
    session.findById("wnd[0]/usr/btnNEW").press

	session.findById("wnd[1]/usr/lbl%_AUTOTEXT003").setFocus

	msgbox("Hello " + session.findById("wnd[1]/usr/lbl%_AUTOTEXT003").Text + " ... " + session.findById("wnd[1]/usr/lbl%_AUTOTEXT013").Text) 