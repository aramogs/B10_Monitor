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
       
   





'idAl = "" +  session.findById("wnd[0]/usr/tabsTS_HU_VERP/tabpUE6POS/ssubTAB:SAPLV51G:6010/tblSAPLV51GTC_HU_001/ctxtV51VE-EXIDV[0,0]").Text


idAl = args.Item(0)
noPlanta = args.Item(1)

session.findById("wnd[0]").resizeWorkingPane 256,37,false
session.findById("wnd[0]/tbar[0]/okcd").text = "mfhu"
session.findById("wnd[0]").sendVKey 0
session.findById("wnd[0]/usr/ctxtVHURMEAE-EXIDV_I").text = idAl
session.findById("wnd[0]/usr/ctxtVHURMEAE-WERKS").text = noPlanta '"5210"
session.findById("wnd[0]/usr/txtVHURMEAE-VERID").text = "1"
session.findById("wnd[0]/usr/txtVHURMEAE-VERID").setFocus
session.findById("wnd[0]/usr/txtVHURMEAE-VERID").caretPosition = 1
session.findById("wnd[0]").sendVKey 0
session.findById("wnd[0]/usr/subHULIST:SAPLVHURMSUB:1000/subHULIST_TC:SAPLVHURMSUB:1100/tblSAPLVHURMSUBTC_HULIST").getAbsoluteRow(0).selected = true
session.findById("wnd[0]/usr/subHULIST:SAPLVHURMSUB:1000/subHULIST_TC:SAPLVHURMSUB:1100/tblSAPLVHURMSUBTC_HULIST/lblVHURMHUD-HUSTATU[0,0]").setFocus
session.findById("wnd[0]/usr/subHULIST:SAPLVHURMSUB:1000/subHULIST_TC:SAPLVHURMSUB:1100/tblSAPLVHURMSUBTC_HULIST/lblVHURMHUD-HUSTATU[0,0]").caretPosition = 0
session.findById("wnd[0]/tbar[0]/btn[11]").press
session.findById("wnd[0]/tbar[0]/btn[12]").press
session.findById("wnd[0]/tbar[0]/btn[12]").press
