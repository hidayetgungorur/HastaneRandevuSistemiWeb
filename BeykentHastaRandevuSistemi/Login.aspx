<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BeykentHastaRandevuSistemi.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8" />
        <title>Beykent HRS | Giriş</title>
        <meta content="width=device-width, initial-scale=1" name="viewport" />
        <meta content="Preview page of Metronic Admin Theme #3 for " name="description" />
        <meta content="" name="author" />
        <!-- BEGIN GLOBAL MANDATORY STYLES -->
        <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/simple-line-icons/simple-line-icons.min.css" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css" rel="stylesheet" type="text/css" />
        <!-- END GLOBAL MANDATORY STYLES -->
        <!-- BEGIN PAGE LEVEL PLUGINS -->
        <link href="../assets/global/plugins/select2/css/select2.min.css" rel="stylesheet" type="text/css" />
        <link href="../assets/global/plugins/select2/css/select2-bootstrap.min.css" rel="stylesheet" type="text/css" />
        <!-- END PAGE LEVEL PLUGINS -->
        <!-- BEGIN THEME GLOBAL STYLES -->
        <link href="../assets/global/css/components.min.css" rel="stylesheet" id="style_components" type="text/css" />
        <link href="../assets/global/css/plugins.min.css" rel="stylesheet" type="text/css" />
        <!-- END THEME GLOBAL STYLES -->
        <!-- BEGIN PAGE LEVEL STYLES -->
        <link href="../assets/pages/css/login-2.min.css" rel="stylesheet" type="text/css" />
        <!-- END PAGE LEVEL STYLES -->
        <!-- BEGIN THEME LAYOUT STYLES -->
        <!-- END THEME LAYOUT STYLES -->
        <link rel="shortcut icon" href="favicon.ico" />


     <!-- BEGIN CORE PLUGINS -->
        <script src="../assets/global/plugins/jquery.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/js.cookie.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js" type="text/javascript"></script>
        <!-- END CORE PLUGINS -->
        <!-- BEGIN PAGE LEVEL PLUGINS -->
        <script src="../assets/global/plugins/jquery-validation/js/jquery.validate.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/jquery-validation/js/additional-methods.min.js" type="text/javascript"></script>
        <script src="../assets/global/plugins/select2/js/select2.full.min.js" type="text/javascript"></script>
        <!-- END PAGE LEVEL PLUGINS -->
        <!-- BEGIN THEME GLOBAL SCRIPTS -->
        <script src="../assets/global/scripts/app.min.js" type="text/javascript"></script>
        <!-- END THEME GLOBAL SCRIPTS -->
        <!-- BEGIN PAGE LEVEL SCRIPTS -->
        <script src="../assets/pages/scripts/login.min.js" type="text/javascript"></script>
        <!-- END PAGE LEVEL SCRIPTS -->
        <!-- BEGIN THEME LAYOUT SCRIPTS -->
        <!-- END THEME LAYOUT SCRIPTS -->
</head>
<body class=" login" >
    <form  id="form1" runat="server" autocomplete="off">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
          <!-- BEGIN LOGO -->
        <div class="logo">
            <a href="#">
                <img src="https://www.beykent.edu.tr/elements/images/beykent-universitesi-logo.svg" style="height: 100px;" alt="" /> 
                <p style="font-size:20px">Beykent Hasta Randevu Sistemi</p>
            </a>
        </div>
        <!-- END LOGO -->
        <!-- BEGIN LOGIN -->
        <div class="content">
            <!-- BEGIN LOGIN FORM -->
            <div runat="server" id="dvGirişBilgileriForm"  >
                <div class="form-title">
                    <span class="form-title">Giriş Bilgileriniz</span>
                </div>
                <div class="alert alert-danger" runat="server" id="dvGirisBilgisiHatalı" visible="false">
                    <button class="close" data-close="alert"></button>
                    <span>Lütfen Kullanıcı Bilgileriniz Tekrar Giriniz.</span>
                </div>
                <div class="form-group">
                    <!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
                    <label class="control-label visible-ie8 visible-ie9">Username</label>
                    <asp:TextBox runat="server" ID="txtGirisKimlikNo" CssClass="form-control form-control-solid placeholder-no-fix" placeholder="T.C Kimlik Numaranız"></asp:TextBox> </div>
                
               
                <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">Password</label>
                     <asp:TextBox runat="server" ID="txtGirisSifre" CssClass="form-control form-control-solid placeholder-no-fix" placeholder="Şifreniz"></asp:TextBox> </div>
               
                   <div class="form-actions">
                    <div class="pull-left">
                        <label class="rememberme mt-checkbox mt-checkbox-outline">
                            <asp:CheckBox runat="server" ID="chbDoktor" /> Doktor
                            <span></span>
                        </label>
                    </div>
                </div>
                <div class="form-actions">
                    <%--<button type="submit" class="btn red btn-block uppercase">GIRIS</button>--%>
                    <asp:LinkButton runat="server" ID="btnLogin" CssClass="btn red btn-block uppercase" OnClick="btnLogin_Click">Giriş</asp:LinkButton>
                </div>
                <div class="form-actions">
                    <div class="pull-left">
                         <asp:LinkButton runat="server" ID="btnHesapOlustur" CssClass="btn-primary btn" OnClick="btnHesapOlustur_Click">Hesap Oluştur</asp:LinkButton>
                    </div>
                    <div class="pull-right forget-password-block">
                         <asp:LinkButton runat="server" ID="btnSifremiUnuttum" CssClass="forget-password" OnClick="btnSifremiUnuttum_Click">Şifremi unuttum ?</asp:LinkButton>

                    </div>
                </div>
                <div style="border-top: 1px solid #69a0c4;margin-top: 20px;">
                </div>
            </div>
            <!-- END LOGIN FORM -->
            <!-- BEGIN FORGOT PASSWORD FORM -->
            <div runat="server" id="dvSifremiUnuttumForm" visible="false" >
                <div class="form-title">
                    <span class="form-title">Şifremi Unuttum ?</span>
                </div>
                <div class="form-group">
                    <input class="form-control placeholder-no-fix" type="text" autocomplete="off" placeholder="T.C Kimlik Numaranız" name="email" />
                    
                </div>
                 <div class="form-group">
                     <input class="form-control placeholder-no-fix" type="text" autocomplete="off" placeholder="E-mail Adresiniz" name="email" />
                     </div>
                <div class="form-actions">
                     <asp:LinkButton runat="server" ID="btnSifremiUnuttumGeri" CssClass="btn btn-default" OnClick="btnSifremiUnuttumGeri_Click">Geri</asp:LinkButton>
                     <asp:LinkButton runat="server" ID="btnSendPassword" CssClass="btn btn-primary uppercase pull-right" OnClick="btnSendPassword_Click">Gönder</asp:LinkButton>

                </div>
            </div>
            <!-- END FORGOT PASSWORD FORM -->
            <!-- BEGIN REGISTRATION FORM -->
            <div runat="server"  id="dvHesapBilgileriForm" visible="false">
                <div class="form-title">
                    <span class="form-title">Hesap Bilgileri</span>
                </div>
                 <div class="alert alert-danger" runat="server" id="dvHesapBilgileriHata" visible="false">
                    <button class="close" data-close="alert"></button>
                    <span>Lütfen Bütün Alanları Eksiksiz Giriniz.</span>
                </div>

                <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">Adı</label>
                    <asp:TextBox runat="server" ID="txtAdi" CssClass="form-control placeholder-no-fix" placeholder="Adınız"></asp:TextBox>
                     </div>
                  <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">Soyadı</label>
                       <asp:TextBox runat="server" ID="txtSoyadi" CssClass="form-control placeholder-no-fix" placeholder="Soyadınız"></asp:TextBox>
                     </div>
                 <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">T.C Kimlik Numaranız</label>
                     <asp:TextBox runat="server" ID="txtKimlikNo" CssClass="form-control placeholder-no-fix" placeholder="T.C Kimlik Numaranız"></asp:TextBox>
                    </div>
                 <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">T.C Kimlik Numaranız</label>
                     <asp:TextBox runat="server" ID="txtDogumTarihi" CssClass="form-control placeholder-no-fix" placeholder="Doğum Tarihiniz ( 01.01.1990 )"></asp:TextBox>
                    </div>
                <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">Telefon Numaranız</label>
                    <asp:TextBox runat="server" ID="txtTelefonNo" CssClass="form-control placeholder-no-fix" placeholder="Telefon Numaranız"></asp:TextBox>
                     </div>
                 <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">Email Adresiniz</label>
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control placeholder-no-fix" placeholder="Email Adresiniz"></asp:TextBox>
                     </div>

                <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">Cinsiyetiniz</label>
                    <asp:DropDownList ID="drpCinsiyet" runat="server" CssClass="form-control">
                        <asp:ListItem Value="" Text="Cinsiyetiniz"></asp:ListItem>
                         <asp:ListItem Value="0" Text="Erkek"></asp:ListItem>
                         <asp:ListItem Value="1" Text="Kadın"></asp:ListItem>
                    </asp:DropDownList>
                </div>
               
                <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">Password</label>
                    <asp:TextBox runat="server" ID="txtSifre" CssClass="form-control placeholder-no-fix" placeholder="Şifreniz"></asp:TextBox>
                     </div>
                <div class="form-actions">
                    <asp:LinkButton runat="server" ID="btnSaveBack" CssClass="btn btn-default" OnClick="btnSaveBack_Click">Geri</asp:LinkButton>
                    <asp:LinkButton runat="server" ID="btnSave" CssClass="btn red uppercase pull-right" OnClick="btnSave_Click">Kaydet</asp:LinkButton>
                </div>
            </div>
            <!-- END REGISTRATION FORM -->
        </div>
        <!-- END LOGIN -->
    </form>
</body>
</html>
