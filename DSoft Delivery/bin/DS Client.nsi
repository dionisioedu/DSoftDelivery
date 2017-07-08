; Script generated by the HM NIS Edit Script Wizard.

; HM NIS Edit Wizard helper defines
!define PRODUCT_NAME "DSoft Delivery"
!define PRODUCT_VERSION "1.4"
!define PRODUCT_PUBLISHER "DSoft Sistemas, Ltda."
!define PRODUCT_WEB_SITE "http://www.dsoftsistemas.com.br"
!define PRODUCT_DIR_REGKEY "Software\Microsoft\Windows\CurrentVersion\App Paths\unins000.exe"
!define PRODUCT_UNINST_KEY "Software\Microsoft\Windows\CurrentVersion\Uninstall\${PRODUCT_NAME}"
!define PRODUCT_UNINST_ROOT_KEY "HKLM"

; MUI 1.67 compatible ------
!include "MUI.nsh"

; MUI Settings
!define MUI_ABORTWARNING
!define MUI_ICON "${NSISDIR}\Contrib\Graphics\Icons\modern-install.ico"
!define MUI_UNICON "${NSISDIR}\Contrib\Graphics\Icons\modern-uninstall.ico"

; Welcome page
!insertmacro MUI_PAGE_WELCOME
; License page
!insertmacro MUI_PAGE_LICENSE "Licenca.txt"
; Instfiles page
!insertmacro MUI_PAGE_INSTFILES
; Finish page
!define MUI_FINISHPAGE_RUN "$INSTDIR\DSoft Delivery.exe"
!insertmacro MUI_PAGE_FINISH

; Uninstaller pages
!insertmacro MUI_UNPAGE_INSTFILES

; Language files
!insertmacro MUI_LANGUAGE "PortugueseBR"

; MUI end ------

Name "${PRODUCT_NAME} ${PRODUCT_VERSION}"
OutFile "DSoftDeliveryClient.exe"
InstallDir "C:\DSoft\DSoft Delivery"
InstallDirRegKey HKLM "${PRODUCT_DIR_REGKEY}" ""
ShowInstDetails show
ShowUnInstDetails show

Section "Se��oPrincipal" SEC01
  SetOutPath "$INSTDIR"
  SetOverwrite ifnewer
  CreateDirectory "C:\DSoft"
  CreateDirectory "C:\DSoft\Log"
  CreateDirectory "C:\DSoft\Key"
  CreateDirectory "C:\DSoft\Backup"
  
  CreateShortCut "$DESKTOP\DSoft Delivery.lnk" "$INSTDIR\DSoft Delivery.exe"
  
  File "Npgsql.dll"
  File "Mono.Security.dll"
  File "Confused\DSKey.pdb"
  File "Confused\dsoft_login14.png"
  File "Confused\dsoft_delivery14.png"
  File "Confused\DSoft Delivery.pdb"
  File "Confused\DSoft Delivery.exe"
  File "Confused\dsoft.ini"
  File "Confused\DSoftBD.pdb"
  File "Confused\DSoftCore.pdb"
  File "Confused\DSoftLogger.pdb"
  File "Confused\DSoftModels.pdb"
  File "Confused\DSoftParameters.pdb"
  File "Confused\DSoftConfig.pdb"
  File "Confused\DSoftForms.pdb"
  File "Confused\dsoft.backup"
  File "Confused\Functions.sql"
  File "C:\DSoft\Ferramentas\dotNetFx40_Full_setup.exe"
SectionEnd

!define NETVersion "4.0"
!define NETInstaller "C:\DSoft\Ferramentas\dotNetFx40_Full_setup.exe"
Section "MS .NET Framework v${NETVersion}" SecFramework
  IfFileExists "$WINDIR\Microsoft.NET\Framework\v${NETVersion}" NETFrameworkInstalled 0
  File /oname=$TEMP\${NETInstaller} ${NETInstaller}

  DetailPrint "Iniciando instala��o do Microsoft .NET Framework v${NETVersion}..."
  ExecWait "$TEMP\${NETInstaller}"
  Return

  NETFrameworkInstalled:
  DetailPrint "Microsoft .NET Framework j� instalado!"

SectionEnd

Section -AdditionalIcons
  CreateShortCut "$SMPROGRAMS\DSoft Delivery\Uninstall.lnk" "$INSTDIR\uninst.exe"
SectionEnd

Section -Post
  WriteUninstaller "$INSTDIR\uninst.exe"
  WriteRegStr HKLM "${PRODUCT_DIR_REGKEY}" "" "$INSTDIR\unins000.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayName" "$(^Name)"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "UninstallString" "$INSTDIR\uninst.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayIcon" "$INSTDIR\unins000.exe"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "DisplayVersion" "${PRODUCT_VERSION}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "URLInfoAbout" "${PRODUCT_WEB_SITE}"
  WriteRegStr ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}" "Publisher" "${PRODUCT_PUBLISHER}"
SectionEnd


Function un.onUninstSuccess
  HideWindow
  MessageBox MB_ICONINFORMATION|MB_OK "$(^Name) foi removido com sucesso do seu computador."
FunctionEnd

Function un.onInit
  MessageBox MB_ICONQUESTION|MB_YESNO|MB_DEFBUTTON2 "Tem certeza que quer remover completamente $(^Name) e todos os seus componentes?" IDYES +2
  Abort
FunctionEnd

Section Uninstall
  Delete "$INSTDIR\*"

  Delete "$DESKTOP\DSoft Delivery.lnk"
  Delete "$SMPROGRAMS\DSoft Delivery\DSoft Delivery.lnk"

  RMDir "$INSTDIR\DSoft Delivery"
  RMDir "$INSTDIR"

  DeleteRegKey ${PRODUCT_UNINST_ROOT_KEY} "${PRODUCT_UNINST_KEY}"
  DeleteRegKey HKLM "${PRODUCT_DIR_REGKEY}"
  SetAutoClose true
SectionEnd