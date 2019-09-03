dim aTest
aTest = qParams

dim forImpre

Dim args
Set args = WScript.Arguments

'msgbox("Hello " & args.Item(0)) 

    Set SapGuiAuto = GetObject("SAPGUI")
    Set sapApplication = SapGuiAuto.GetScriptingEngine
    Set Connection = sapApplication.Children(0)
    Set session = Connection.Children(0)
       
   


''session.findById("wnd[0]").resizeWorkingPane 256,37,false
''session.findById("wnd[0]/tbar[0]/okcd").text = "ZZMFP11"
''session.findById("wnd[0]").sendVKey 0


''session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/ctxtPLAPPLDATA-MATNR").text = args.Item(0)
''session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/ctxtPLAPPLDATA-WERKS").text = args.Item(2) '"5210"
''session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/txtPLAPPLDATA-MAXQUA").text = args.Item(1)
''session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/txtPLAPPLDATA-MAXQUA").setFocus
''session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/txtPLAPPLDATA-MAXQUA").caretPosition = 1
''session.findById("wnd[0]").sendVKey 0
''session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0052/subAREA2:SAPLVHUDIAL2:0061/subPACKDIALOG:SAPLVHUSUBSC:0100/btnCREATE_HUS").press


''session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA3:SAPLVHUDIAL2:0072/btnHUEDIT").press
''session.findById("wnd[0]/usr/tabsTS_HU_VERP/tabpUE6POS/ssubTAB:SAPLV51G:6010/tblSAPLV51GTC_HU_001/ctxtV51VE-EXIDV[0,0]").setFocus
''session.findById("wnd[0]/usr/tabsTS_HU_VERP/tabpUE6POS/ssubTAB:SAPLV51G:6010/tblSAPLV51GTC_HU_001/ctxtV51VE-EXIDV[0,0]").caretPosition = 0




''idAl = "" + session.findById("wnd[0]/usr/tabsTS_HU_VERP/tabpUE6POS/ssubTAB:SAPLV51G:6010/tblSAPLV51GTC_HU_001/ctxtV51VE-EXIDV[0,0]").Text

'msgbox("id: " + session.findById("wnd[0]/usr/tabsTS_HU_VERP/tabpUE6POS/ssubTAB:SAPLV51G:6010/tblSAPLV51GTC_HU_001/ctxtV51VE-EXIDV[0,0]").Text) 


'msgbox("var: " + idAl)


''session.findById("wnd[0]/tbar[0]/btn[12]").press


''session.findById("wnd[0]").resizeWorkingPane 256,37,false
''session.findById("wnd[0]/mbar/menu[0]/menu[10]").select


''session.findById("wnd[0]/tbar[0]/btn[12]").press

'forImpre = session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA3:SAPLVHUDIAL2:0072/cntlHUCONTAINER/shellcont/shell").selectItem "1","3".Text


''session.findById("wnd[0]").resizeWorkingPane 256,37,false
'session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA3:SAPLVHUDIAL2:0072/cntlHUCONTAINER/shellcont/shell").selectItem "          1","3"
'session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA3:SAPLVHUDIAL2:0072/cntlHUCONTAINER/shellcont/shell").ensureVisibleHorizontalItem "          1","3"















' ------------------------ imprecion etiqueta ------------------------------------





session.findById("wnd[0]").resizeWorkingPane 256,37,false
session.findById("wnd[0]/tbar[0]/okcd").text = "z_uc_del"
session.findById("wnd[0]").sendVKey 0


session.findById("wnd[0]").resizeWorkingPane 256,37,false
session.findById("wnd[0]/usr/chkCOPY").selected = true
session.findById("wnd[0]/usr/ctxtV_DISPO").text = "001"
session.findById("wnd[0]/usr/ctxtB_DISPO").text = "999"
session.findById("wnd[0]/usr/ctxtP_LDEST").text = args.Item(2) 'antes 2'
'"S522"
session.findById("wnd[0]/usr/chkCOPY").setFocus


session.findById("wnd[0]/tbar[1]/btn[8]").press


session.findById("wnd[0]/mbar/menu[0]/menu[2]").select
session.findById("wnd[0]/mbar/menu[0]/menu[4]").select



session.findById("wnd[0]").resizeWorkingPane 256,37,false
'alma = 
'session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA3:SAPLVHUDIAL2:0072/cntlHUCONTAINER/shellcont/shell").selectItem "          3","3"
'session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA3:SAPLVHUDIAL2:0072/cntlHUCONTAINER/shellcont/shell").selectItem"          1","3"
'session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA3:SAPLVHUDIAL2:0072/cntlHUCONTAINER/shellcont/shell").selectItem("          1","3").value

'alma2 = session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA3:SAPLVHUDIAL2:0072/cntlHUCONTAINER/shellcont/shell").ensureVisibleHorizontalItem("          1","3").Text



'session.findById("wnd[0]").resizeWorkingPane 256,37,false
'session.findById("wnd[0]/mbar/menu[0]/menu[10]").select

'session.findById("wnd[0]").resizeWorkingPane 256,37,false
'session.findById("wnd[0]/mbar/menu[0]/menu[10]").select

'msgbox("Hello " + session.findById("wnd[1]/usr/lbl%_AUTOTEXT003").Text + " ... " + session.findById("wnd[1]/usr/lbl%_AUTOTEXT013").Text) 





WScript.Echo "-." + idAl + ".-"


'session.findById("wnd[0]").resizeWorkingPane 256,37,false
'session.findById("wnd[0]/tbar[0]/okcd").text = "mfhu"
'session.findById("wnd[0]").sendVKey 0
'session.findById("wnd[0]/usr/ctxtVHURMEAE-EXIDV_I").text = idAl
'session.findById("wnd[0]/usr/ctxtVHURMEAE-WERKS").text = "5210"
'session.findById("wnd[0]/usr/txtVHURMEAE-VERID").text = "1"
'session.findById("wnd[0]/usr/txtVHURMEAE-VERID").setFocus
'session.findById("wnd[0]/usr/txtVHURMEAE-VERID").caretPosition = 1
'session.findById("wnd[0]").sendVKey 0
'session.findById("wnd[0]/usr/subHULIST:SAPLVHURMSUB:1000/subHULIST_TC:SAPLVHURMSUB:1100/tblSAPLVHURMSUBTC_HULIST").getAbsoluteRow(0).selected = true
'session.findById("wnd[0]/usr/subHULIST:SAPLVHURMSUB:1000/subHULIST_TC:SAPLVHURMSUB:1100/tblSAPLVHURMSUBTC_HULIST/lblVHURMHUD-HUSTATU[0,0]").setFocus
'session.findById("wnd[0]/usr/subHULIST:SAPLVHURMSUB:1000/subHULIST_TC:SAPLVHURMSUB:1100/tblSAPLVHURMSUBTC_HULIST/lblVHURMHUD-HUSTATU[0,0]").caretPosition = 0
'session.findById("wnd[0]/tbar[0]/btn[11]").press
'session.findById("wnd[0]/tbar[0]/btn[12]").press
'session.findById("wnd[0]/tbar[0]/btn[12]").press
