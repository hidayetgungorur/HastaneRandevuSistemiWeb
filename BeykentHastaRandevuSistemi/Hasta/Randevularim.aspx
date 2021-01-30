<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Randevularim.aspx.cs" Inherits="BeykentHastaRandevuSistemi.Hasta.Randevularim" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <div class="page-content">
                <div class="container-fluid" style="padding-left:100px !important;padding-right:100px !important">
            <div class="portlet box green">
                <div class="portlet-title">
                    <div class="caption">
                        <asp:Literal runat="server" Text="Randevularım" />
                    </div>
                    <div class="actions">
                    </div>
                </div>
                <div class="portlet-body form">
                    <div class="form-body kplus-fontsize-12">
                        <div class="kplus-box-100">
                            <div class="table-responsive">
                                <table class="table table-striped table-bordered table-advance table-hover">
                                    <thead>
                                        <tr>
                                            <th class="kplus-color-claretred" style="text-align: center;">Randevu Tarihi
                                            </th>
                                            <th class="kplus-color-claretred" style="text-align: center;">Doktor</th>
                                            <th class="kplus-color-claretred" style="text-align: center;">Poliklinik
                                            </th>
                                            <th class="kplus-color-claretred" style="text-align: center;">Durum</th>
                                        </tr>
                                        <tbody>
                                            <asp:Repeater ID="rptRandevularim" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class="text-center">
                                                            <asp:HiddenField ID="hdnRecId" runat="server" Value='<%#Eval("RecId")%>' />
                                                            <%# Eval("Tarih","{0:dd.MM.yyyy HH:mm}") %>
                                                        </td>
                                                        <td class="text-center">
                                                            <%#Eval("DoktorAdi")%> 
                                                        </td>
                                                        <td class="text-center">
                                                            <%#Eval("PoliklinikAdi")%> 
                                                        </td>
                                                        <td class="text-center">

                                                          <asp:Label runat="server" Text='<%#Eval("Durum")%>' Visible=' <%#Eval("Durum").ToString() =="Aktif" ? false:true %>'></asp:Label> 

                                                            <asp:LinkButton ID="lbDeleteRandevu" Visible=' <%#Eval("Durum").ToString() =="Aktif" ? true:false %> ' ClientIDMode="AutoID" data-toggle="confirmation" data-original-title="Randevunuzu İtal Etmek İstediğinizden Emin misiniz ?" OnClick="lbDeleteRandevu_Click" CssClass="btn default btn-xs red btn-circle" runat="server">
                                                                            <i class="fa fa-trash" ></i> İptal
                                                            </asp:LinkButton>
                                                        </td>
                                                    </tr>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </tbody>
                                    </thead>
                                </table>
                            </div>


                            <div class="clear-both"></div>
                        </div>
                    </div>
                </div>
            </div>
                    </div>
                 </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
