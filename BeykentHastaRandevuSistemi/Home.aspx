<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BeykentHastaRandevuSistemi.Home" %>

<%@ Register Src="~/UserControls/Doktor/DoktorRandevu.ascx" TagPrefix="uc1" TagName="DoktorRandevu" %>
<%@ Register Src="~/UserControls/Hasta/HastaRandevu.ascx" TagPrefix="uc1" TagName="HastaRandevu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="container-fluid" style="padding-left:100px !important;padding-right:100px !important">
                    <uc1:DoktorRandevu runat="server" id="DoktorRandevu"  />
                    <uc1:HastaRandevu runat="server" id="HastaRandevu" />
                   
                </div>
                <div class="clear-both"></div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
   




</asp:Content>
