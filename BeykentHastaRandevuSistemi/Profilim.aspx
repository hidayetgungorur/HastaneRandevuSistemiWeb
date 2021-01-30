<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Profilim.aspx.cs" Inherits="BeykentHastaRandevuSistemi.Profilim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="container-fluid" style="padding-left: 100px !important; padding-right: 100px !important">
                    <div class="portlet box green">
                        <div class="portlet-title">
                            <div class="caption">
                                <i class="fa fa-user"></i>
                                <asp:Literal runat="server" Text="Bilgilerim" />
                            </div>
                            <div class="actions">
                            </div>
                        </div>
                        <div class="portlet-body form">
                            <div class="form-body kplus-fontsize-12">
                                <div class="kplus-box-100" runat="server" id="dvUnvan">
                                     <div class="col-md-2">
                                    </div>
                                     <div class="col-md-4">
                                        <asp:Label ID="Label7" runat="server" CssClass="bold bookinga-color-claretred" />
                                        <asp:TextBox ID="txtUnvan" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>

                                      <div class="col-md-2">
                                    </div>
                                    <div class="clear-both"></div>
                                </div>
                                <div class="kplus-box-100">
                                    <div class="col-md-2">
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="Label17" runat="server" Text="Adı" CssClass="bold bookinga-color-claretred" />
                                        <asp:TextBox ID="txtAdi" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="Label1" runat="server" Text="Soyadı" CssClass="bold bookinga-color-claretred" />
                                        <asp:TextBox ID="txtSoyadi" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                    </div>
                                    <div class="clear-both"></div>
                                </div>

                                <div class="kplus-box-100">
                                    <div class="col-md-2">
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="Label2" runat="server" Text="T.C Kimlik Numarası" CssClass="bold bookinga-color-claretred" />
                                        <asp:TextBox ID="txtKimlikNo" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>

                                    <div class="col-md-4">
                                        <asp:Label ID="Label3" runat="server" Text="Doğum Tarihi" CssClass="bold bookinga-color-claretred" />
                                        <asp:TextBox ID="txtDogumTarihi" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                    </div>
                                    <div class="clear-both"></div>
                                </div>
                                <div class="kplus-box-100">
                                    <div class="col-md-2">
                                    </div>

                                    <div class="col-md-4">
                                        <asp:Label ID="Label4" runat="server" Text="Email Adresi" CssClass="bold bookinga-color-claretred" />
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="Label5" runat="server" Text="Cinsiyet" CssClass="bold bookinga-color-claretred" />
                                        <asp:DropDownList ID="drpCinsiyet" Enabled="false" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="0" Text="Erkek"></asp:ListItem>
                                            <asp:ListItem Value="1" Text="Kadın"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>

                                    <div class="col-md-2">
                                    </div>
                                    <div class="clear-both"></div>
                                </div>
                                <div class="kplus-box-100">
                                    <div class="col-md-2">
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Label ID="Label6" runat="server" Text="Şifre" CssClass="bold bookinga-color-claretred" />
                                        <asp:TextBox ID="txtSifre" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>

                                     <div class="col-md-4">
                                        <asp:Label ID="Label8" runat="server" Text="Telefon" CssClass="bold bookinga-color-claretred" />
                                        <asp:TextBox ID="txtTelefon" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                  
                                    <div class="clear-both"></div>
                                </div>
                                 <div class="kplus-box-100">
                                    <div class="col-md-2">
                                    </div>
                                      <div class="col-md-8">
                                          <div class="alert alert-danger" runat="server" id="dvHata" visible="false">
                    <button class="close" data-close="alert"></button>
                    <span>Lütfen Bütün Alanları Eksiksiz Giriniz.</span>
                </div>

                                 <div class="alert alert-success" runat="server" id="dvBasarili" visible="false">
                    <button class="close" data-close="alert"></button>
                    <span>Bilgileriniz Güncellendi.</span>
                </div>
                                    </div>

                                      <div class="clear-both"></div>
                                </div>
                                 <div class="kplus-box-100" style="margin-bottom:100px;">
                                    <div class="col-md-2">
                                    </div>
                                       <div class="col-md-8">
                                        <br />
                                        <asp:LinkButton ID="btnSave" runat="server" CssClass="btn col-md-12  green-dark kplus-box-color mt-ladda-btn ladda-button" data-style="zoom-in" OnClick="btnSave_Click">
                                            <i class="fa fa-check"></i> 
                                            <span class="ladda-label"><asp:Literal runat="server" Text="Güncelle" /></span>
                                            <span class="ladda-spinner"></span>
                                        </asp:LinkButton>
                                    </div>
                                      <div class="clear-both"></div>
                                </div>

                                 


                            </div>
                        </div>
                    </div>


                </div>
                <div class="clear-both"></div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
