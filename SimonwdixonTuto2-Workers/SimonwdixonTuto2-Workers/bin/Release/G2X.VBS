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
       
   


session.findById("wnd[0]").resizeWorkingPane 256,37,false
session.findById("wnd[0]/tbar[0]/okcd").text = "ZZMFP11"
session.findById("wnd[0]").sendVKey 0


session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/ctxtPLAPPLDATA-MATNR").text = args.Item(0)
session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/ctxtPLAPPLDATA-WERKS").text = args.Item(2) '"5210"
session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/txtPLAPPLDATA-MAXQUA").text = args.Item(1)
session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/txtPLAPPLDATA-MAXQUA").setFocus
session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA1:SAPLVHUDIAL2:0110/tabsTABSTRIP1/tabpTAB1/ssubSUB1:SAPLVHUDIAL2:0200/txtPLAPPLDATA-MAXQUA").caretPosition = 1
session.findById("wnd[0]").sendVKey 0
session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0052/subAREA2:SAPLVHUDIAL2:0061/subPACKDIALOG:SAPLVHUSUBSC:0100/btnCREATE_HUS").press


session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA3:SAPLVHUDIAL2:0072/btnHUEDIT").press
session.findById("wnd[0]/usr/tabsTS_HU_VERP/tabpUE6POS/ssubTAB:SAPLV51G:6010/tblSAPLV51GTC_HU_001/ctxtV51VE-EXIDV[0,0]").setFocus
session.findById("wnd[0]/usr/tabsTS_HU_VERP/tabpUE6POS/ssubTAB:SAPLV51G:6010/tblSAPLV51GTC_HU_001/ctxtV51VE-EXIDV[0,0]").caretPosition = 0




idAl = "" + session.findById("wnd[0]/usr/tabsTS_HU_VERP/tabpUE6POS/ssubTAB:SAPLV51G:6010/tblSAPLV51GTC_HU_001/ctxtV51VE-EXIDV[0,0]").Text

'msgbox("id: " + session.findById("wnd[0]/usr/tabsTS_HU_VERP/tabpUE6POS/ssubTAB:SAPLV51G:6010/tblSAPLV51GTC_HU_001/ctxtV51VE-EXIDV[0,0]").Text) 


'msgbox("var: " + idAl)


session.findById("wnd[0]/tbar[0]/btn[12]").press


session.findById("wnd[0]").resizeWorkingPane 256,37,false
session.findById("wnd[0]/mbar/menu[0]/menu[10]").select


session.findById("wnd[0]/tbar[0]/btn[12]").press

'forImpre = session.findById("wnd[0]/usr/subSPLITTED_SCREEN:SAPLVHUDIAL2:0053/subAREA3:SAPLVHUDIAL2:0072/cntlHUCONTAINER/shellcont/shell").selectItem "1","3".Text


session.findById("wnd[0]").resizeWorkingPane 256,37,false



session.findById("wnd[0]/tbar[0]/okcd").text = "Z_UC_WM" 'NOMBRE DE LA NUEVA TRANSACCION
session.findById("wnd[0]").sendVKey 0
session.findById("wnd[0]/usr/ctxtP_VSTEL").text = args.Item(3)  ' PRIMER PASO COLOCAR NUMERO DE PLANTA
session.findById("wnd[0]/usr/ctxtP_EXIDV").text = args.Item(0) 'SEGUNDO PASO COLOCAR NUMERO DE SERIE DE ETIQUETA CREADA EN TRANSACCION ZZMFP11
session.findById("wnd[0]/usr/ctxtP_DDEST").text = args.Item(2) ' TERCER PASO COLOCAR NOMBRE DE LA IMPRESORA REQUERIDA, LA CUAL SE ADQUIERE DE LA ESTACION     
session.findById("wnd[0]/usr/ctxtP_DDEST").setFocus      
session.findById("wnd[0]/usr/ctxtP_DDEST").caretPosition = 4 
session.findById("wnd[0]/tbar[1]/btn[8]").press             ' CUARTO PASO, PRESIONAR EL BOTON DE EJECUTAR
session.findById("wnd[0]/tbar[0]/btn[15]").press			' QUINTO PASO, SALIR DE LA TRANSACCION, SE REQUIERE PRESIONAR 2 VECES EL BOTON DE SALIDA	
session.findById("wnd[0]/tbar[0]/btn[15]").press			' QUINTO PASO, SALIR DE LA TRANSACCION, SE REQUIERE PRESIONAR 2 VECES EL BOTON DE SALIDA




WScript.Echo "-." + idAl + ".-"

WScript.Echo "planta-." + args.Item(3) + ".-"
WScript.Echo "numero de SERIE-." + args.Item(0) + ".-"
WScript.Echo "impresora-." + args.Item(2) + ".-"


