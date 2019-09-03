dim aTest

aTest = qParams

 

dim forImpre

 

Dim args

Set args = WScript.Arguments




    Set SapGuiAuto = GetObject("SAPGUI")

    Set sapApplication = SapGuiAuto.GetScriptingEngine

    Set Connection = sapApplication.Children(0)

    Set session = Connection.Children(0)

      

   

 

session.findById("wnd[0]").resizeWorkingPane 256,37,false

session.findById("wnd[0]/tbar[0]/okcd").text = "MFP11"

session.findById("wnd[0]").sendVKey 0

 

session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/ctxtPLAPPLDATA-MATNR").text = args.Item(0)

session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/ctxtPLAPPLDATA-WERKS").text = args.Item(2) '"5210"

session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/txtPLAPPLDATA-MAXQUA").text = args.Item(1)

session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/ctxtPLAPPLDATA-LGORT").text = "0012"

session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/txtPLAPPLDATA-MAXQUA").setFocus

session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/txtPLAPPLDATA-MAXQUA").caretPosition = 1

session.findById("wnd[0]").sendVKey 0

session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0052/subAREA2:SAPLVHUDIAL2:0061/subPACKDIALOG:SAPLVHUSUBSC:0100/btnCREATE_HUS").press

 

session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA3:SAPLVHUDIAL2:0072/btnHUEDIT").press

session.findById("wnd[0]/usr/tabsTS_HU_VERP/tabpUE6POS/ssubTAB:SAPLV51G:6010/tblSAPLV51GTC_HU_001/ctxtV51VE-EXIDV[0,0]").setFocus

session.findById("wnd[0]/usr/tabsTS_HU_VERP/tabpUE6POS/ssubTAB:SAPLV51G:6010/tblSAPLV51GTC_HU_001/ctxtV51VE-EXIDV[0,0]").caretPosition = 0





idAl = "" + session.findById("wnd[0]/usr/tabsTS_HU_VERP/tabpUE6POS/ssubTAB:SAPLV51G:6010/tblSAPLV51GTC_HU_001/ctxtV51VE-EXIDV[0,0]").Text




session.findById("wnd[0]/tbar[0]/btn[12]").press

 

session.findById("wnd[0]").resizeWorkingPane 256,37,false

session.findById("wnd[0]/mbar/menu[0]/menu[10]").select

 

session.findById("wnd[0]/tbar[0]/btn[12]").press




session.findById("wnd[0]").resizeWorkingPane 256,37,false








' ------------------------ Impresion de etiqueta (Sin impresora, esto llena informacion en una tabla necesaria para TekGun) ------------------------------------

 

session.findById("wnd[0]/tbar[0]/okcd").text = "z_uc"

session.findById("wnd[0]").sendVKey 0

session.findById("wnd[0]/usr/ctxtV_DISPO").text = "001"

session.findById("wnd[0]/usr/ctxtB_DISPO").text = "999"

session.findById("wnd[0]/usr/ctxtB_DISPO").setFocus

session.findById("wnd[0]/usr/ctxtB_DISPO").caretPosition = 3

session.findById("wnd[0]/tbar[1]/btn[8]").press

session.findById("wnd[0]/tbar[0]/btn[15]").press

session.findById("wnd[0]/tbar[0]/btn[15]").press

 

WScript.Echo "-." + idAl + ".-"